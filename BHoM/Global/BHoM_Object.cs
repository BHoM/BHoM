using System;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System.ComponentModel;

namespace BHoM.Global
{
    /// <summary>
    /// BHoM object abstract class, all methods and attributes applicable to all structural objects with
    /// BHoM implemented
    /// </summary>
    public abstract class BHoMObject
    {
        /// <summary>BHoM unique ID</summary>
        public System.Guid BHoM_Guid { get; protected set; }

        /// <summary>Name</summary>
        [DefaultValue("")]
        public string Name { get; set; }

        /// <summary>Object parameters</summary>
        [DisplayName("User Data")]
        [Description("Additonal object information")]
        [DefaultValue(null)]
        public Dictionary<string, object> CustomData { get; set; }

        public BHoMObject()
        {
            CustomData = new Dictionary<string, object>();
            this.BHoM_Guid = System.Guid.NewGuid();
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

                aResult += Utils.WriteProperty(prop.Name, value);
            }
            if (aResult.Last() == ',')
                aResult = aResult.Substring(0, aResult.Length - 1);
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
        public static BHoMObject FromJSON(string json)
        {
            // Get the top level definition of the json content
            Dictionary<string, string> definition = Utils.GetDefinitionFromJSON(json);
            if (!definition.ContainsKey("Primitive") || !definition.ContainsKey("Properties")) return null;

            // Try to create an object that correponds the object type stored in "Primitive"
            var typeString = definition["Primitive"].Replace("\"", "").Replace(";", ",");
            Type type = Type.GetType(typeString);
            if (type == null) return null;
            BHoMObject newObject = Activator.CreateInstance(type, true) as BHoMObject;

            // Get the definition of the properties
            Dictionary<string, string> properties = Utils.GetDefinitionFromJSON(definition["Properties"]);
            foreach (KeyValuePair<string, string> kvp in properties)
            {
                string prop = kvp.Key.Trim().Replace("\"", "");
                string valueString = kvp.Value.Trim().Replace("\"", "");
                Utils.ReadProperty(newObject, prop, valueString);
            }

            return newObject;
        }      
        /// <summary>
        /// BHoM Object will return its name as default 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.GetType().Name + (!string.IsNullOrEmpty(Name) ? ": " + Name : "");
        }
    }
}