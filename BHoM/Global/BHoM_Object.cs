using System;
using System.Collections.Generic;
using System.Xml;
using System.Linq;

namespace BHoM.Global
{
    /// <summary>
    /// BHoM object abstract class, all methods and attributes applicable to all structural objects with
    /// BHoM implemented
    /// </summary>
    public abstract class BHoMObject
    {
        /// <summary>BHoM unique ID</summary>
        public System.Guid BHoM_Guid { get; internal set; }

        /// <summary>Name</summary>
        public string Name { get; internal set; }

        /// <summary>Object parameters</summary>
        public ObjectParameters UserData { get; set; }

        internal BHoMObject()
        {
            UserData = new ObjectParameters();
            this.BHoM_Guid = System.Guid.NewGuid();
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
            aResult += string.Format("\"{0}\": {1},", "Primitive", "{\""+GetType().AssemblyQualifiedName+"\"}");

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

            //aResult += ",\"UserData\": {";
            //foreach (Parameter param in UserData)
            //{
            //    var value = param.Value;
            //    if (value == null) continue;

            //    if (value is BHoMObject)
            //        aResult += string.Format("\"{0}\": \"{1}\",", param.Name, (value as BHoMObject).BHoM_Guid);
            //    else if (value.GetType().GetMethod("ToJSON") != null)
            //        aResult += string.Format("\"{0}\": {1},", param.Name, value.GetType().GetMethod("ToJSON").Invoke(value, null));
            //    else
            //        aResult += string.Format("\"{0}\": \"{1}\",", param.Name, value.ToString());
            //}           

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
            var typeString = definition["Primitive"].Replace("\"", "").Replace("{", "").Replace("}", "");
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

                //System.Reflection.PropertyInfo pInfo = newObject.GetType().GetProperty(prop);
                //if (pInfo == null) continue;

                //Type pType = pInfo.PropertyType;
                //string valueString = kvp.Value.Trim().Replace("\"", "");
                //if (pType == typeof(System.String))
                //    pInfo.SetValue(newObject, valueString);
                //else if (pType.BaseType == typeof(BHoMObject))
                //{
                //    BHoMObject b = Project.ActiveProject.GetObject(new Guid(valueString));
                //    if (b != null)
                //    {
                //        pInfo.SetValue(newObject, b);
                //    }
                //    else
                //    {
                //        Project.ActiveProject.AddTask(new Task());
                //    }
                //}
                //else
                //{
                //    System.Reflection.MethodInfo jsonMethod = pType.GetMethod("FromJSON");
                //    if (jsonMethod != null)
                //        pInfo.SetValue(newObject, jsonMethod.Invoke(newObject, new object[] { valueString }));
                //    else
                //    {
                //        System.Reflection.MethodInfo parseMethod = pType.GetMethod("Parse", new Type[] { typeof(string) });
                //        if (parseMethod != null)
                //            pInfo.SetValue(newObject, parseMethod.Invoke(newObject, new object[] { valueString }));
                //    }
                //}
            }

            return newObject;
        }      
        /// <summary>
        /// BHoM Object will return its name as default 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.GetType().Name + ": " + Name;
        }
    }
}