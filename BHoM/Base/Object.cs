using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System.ComponentModel;
using BHoM.Base;
using BHoM.Global;
using System.Reflection;

namespace BHoM.Base
{
    public interface IBase
    {
        System.Guid BHoM_Guid { get; }
        string Name { get; set; }
        Dictionary<string, object> CustomData { get; set; }
        BHoMObject ShallowClone(bool newGuid = false);
    }

    /// <summary>
    /// BHoM object abstract class, all methods and attributes applicable to all structural objects with
    /// BHoM implemented
    /// </summary>
    public abstract class BHoMObject : IBase
    {
        /// <summary>BHoM unique ID</summary>
        public System.Guid BHoM_Guid { get; protected set; }

        /// <summary>Name</summary>
        [DefaultValue("")]
        public string Name { get; set; }

        /// <summary>Object parameters</summary>
        [DisplayName("CustomData")]
        [Description("Additonal object information")]
        [DefaultValue(null)]
        public Dictionary<string, object> CustomData { get; set; }

        public BHoMObject()
        {
            CustomData = new Dictionary<string, object>();
            this.BHoM_Guid = System.Guid.NewGuid();
            Name = "";
        }

        /// <summary>
        /// Creates a BHoM Object of the specified type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static BHoMObject CreateInstance(Type type)
        {
            return Activator.CreateInstance(type, true) as BHoMObject;
        }
        /// <summary>
        /// Looks for the key in the custom data dictionary
        /// </summary>
        /// <param name="key">Data key</param>
        /// <returns>The corresponding object if the key exists, null otherwise</returns>
        public object this[string key]
        {
            get
            {
                object value = null;
                CustomData.TryGetValue(key, out value);
                return value;
            }
        }

        //////////////
        ////Methods///
        //////////////

        /// <summary>Create a shallow copy of the object</summary>
        public BHoMObject ShallowClone(bool newGuid = false)
        {
            BHoMObject obj = (BHoMObject)this.MemberwiseClone();
            if(newGuid)
                obj.BHoM_Guid = Guid.NewGuid();
            return obj;
        }



        /// <summary>Gets the geometry of the object (whatever that might be)</summary>
        public virtual BHoM.Geometry.GeometryBase GetGeometry()
        {
            return null;
        }

        /// <summary>Sets the geometry of the object (whatever that might be)</summary>
        public virtual void SetGeometry(BHoM.Geometry.GeometryBase geometry)
        {
        }


        /// <summary>Method which gets a properties dictionary for simple downstream deconstruct</summary>
        public List<string> GetPropertyNames()
        {
            List<string> propertyNames = new List<string>();
            foreach (var prop in this.GetType().GetProperties())
            {
                propertyNames.Add(prop.Name);
            }
            propertyNames.Sort();
            return propertyNames;
        }

        /// <summary>
        /// Method which convert the object as a Json string
        /// </summary>
        public virtual string ToJSON(string extra = "")
        {
            string aResult = "{";
            aResult += string.Format("\"{0}\": {1},", "Type", "\"" + GetType() + "\"");
            aResult += string.Format("\"{0}\": {1},", "Primitive", "\""+GetType().AssemblyQualifiedName.Replace(",", ";") + "\"");

            // Write all the properties
            aResult += "\"Properties\": {";
            foreach (var prop in this.GetType().GetProperties())
            {
                if (!prop.CanRead || !prop.CanWrite) continue;
                var value = prop.GetValue(this, null);
                if (value == null) continue;

                aResult += BHoMJSON.WriteProperty(prop.Name, value) + ',';
            }
            if (aResult.Last() == ',')
                aResult = aResult.Trim(',');
            aResult += "}";

            // Write the extra information
            if (extra.Length > 0)
                aResult += "," + extra;
   
            aResult += "}";
            return aResult;
        }

        /// <summary>
        /// Method which convert the object as a Json string
        /// </summary>
        public static BHoMObject FromJSON(string json, Project project = null)
        {
            if (project == null)
                project = Project.ActiveProject;

            // Get the top level definition of the json content
            Dictionary<string, string> definition = BHoMJSON.GetDefinitionFromJSON(json);
            if (!definition.ContainsKey("Primitive") || !definition.ContainsKey("Properties")) return null;

            // Try to create an object that correponds the object type stored in "Primitive"
            var typeString = definition["Primitive"].Replace("\"", "").Replace(";", ",");
            Type type = Type.GetType(typeString);
            if (type == null)
                type = TypeDictionary[typeString];
            BHoMObject newObject = Activator.CreateInstance(type, true) as BHoMObject;

            // Get the definition of the properties
            Dictionary<string, string> properties = BHoMJSON.GetDefinitionFromJSON(definition["Properties"]);
            foreach (KeyValuePair<string, string> kvp in properties)
            {
                string prop = kvp.Key.Trim().Replace("\"", "");
                string valueString = kvp.Value.Trim().Replace("\"", "");
                BHoMJSON.ReadProperty(newObject, prop, valueString, project);
            }

            return newObject;
        }


        /// <summary>
        /// Create an object based on its type name
        /// </summary>
        /// <returns></returns>
        public static BHoMObject FromTypeName(string typeString)
        {
            Type type = Type.GetType(typeString);
            if (type == null)
                type = TypeDictionary[typeString];
            return Activator.CreateInstance(type, true) as BHoMObject;
        }



        /// <summary>
        /// BHoM Object will return its name as default 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.GetType().Name + (!string.IsNullOrEmpty(Name) ? ": " + Name : "");
        }

        /// <summary>
        /// Get all dependencies related to that object
        /// </summary>
        public void GetDeepDependencies(ref Dictionary<Guid, BHoMObject> dependencies)
        {
            foreach (var prop in this.GetType().GetProperties())
            {
                if (!prop.CanRead || !prop.CanWrite) continue;
                var value = prop.GetValue(this, null);
                if (value == null) continue;

                if (value is BHoMObject)
                    CheckAndAddDependency(ref dependencies, value as BHoMObject);
                else if (value is IEnumerable)
                {
                    foreach (object val in value as IEnumerable)
                    {
                        if (val is BHoMObject)
                            CheckAndAddDependency(ref dependencies, val as BHoMObject);
                        else
                            break;
                    }
                }
                
            }
        }

        private void CheckAndAddDependency(ref Dictionary<Guid, BHoMObject> dependencies, BHoMObject obj)
        {
            Guid id = obj.BHoM_Guid;
            if (!dependencies.ContainsKey(id))
            {
                obj.GetDeepDependencies(ref dependencies);
                dependencies[id] = obj;
            }
        }

        public Dictionary<Guid, BHoMObject> GetDeepDependencies()
        {
            Dictionary<Guid, BHoMObject> dependencies = new Dictionary<Guid, BHoMObject>();
            GetDeepDependencies(ref dependencies);
            return dependencies;
        }

        /*****************************************************/

        /// <summary>
        /// Get all dependencies related to that object
        /// </summary>
        public void GetShallowDependencies(ref Dictionary<Guid, BHoMObject> dependencies)
        {
            foreach (var prop in this.GetType().GetProperties())
            {
                if (!prop.CanRead || !prop.CanWrite) continue;
                var value = prop.GetValue(this, null);
                if (value == null || !(value is BHoMObject)) continue;

                BHoMObject obj = value as BHoMObject;
                Guid id = obj.BHoM_Guid;
                if (!dependencies.ContainsKey(id))
                {
                    dependencies[id] = obj;
                }
            }
        }

        public Dictionary<Guid, BHoMObject> GetShallowDependencies()
        {
            Dictionary<Guid, BHoMObject> dependencies = new Dictionary<Guid, BHoMObject>();
            GetShallowDependencies(ref dependencies);
            return dependencies;
        }
        /**************************************/
        /****  Type dictionary             ****/
        /**************************************/

        public static Dictionary<string, Type> TypeDictionary
        {
            get
            {
                if (m_TypeDictionary == null)
                {
                    m_TypeDictionary = new Dictionary<string, Type>();

                    foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
                    {
                        string name = asm.GetName().Name;
                        if (name == "BHoM" || name.EndsWith("_oM"))
                        {
                            foreach (Type type in asm.GetTypes())
                            {
                                m_TypeDictionary[type.Name] = type;
                                m_TypeDictionary[type.FullName] = type;
                            }
                        }
                    }
                }
                return m_TypeDictionary;
            }
        }

        /**************************************/

        private static Dictionary<string, Type> m_TypeDictionary;
    }
}