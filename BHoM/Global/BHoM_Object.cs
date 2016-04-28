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

        /// <summary>Number</summary>
        public int Number { get; internal set; }        // #AD - This should be moved to parameters and Guid should be used instead

        /// <summary>Project</summary>
        public Project Project { get; set; }            // #AD - I don't think this should be there at all

        /// <summary>Object parameters</summary>
        public ObjectParameters Parameters { get; set; }

        public BHoMObject()
        {
            Parameters = new ObjectParameters();
            Number = -1;
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
            aResult += string.Format("\"{0}\": \"{1}\",", "Primitive", "{"+GetType().AssemblyQualifiedName+"}");

            // Write all the properties
            aResult += "\"Properties\": {";
            foreach (var prop in this.GetType().GetProperties())
            {
                var value = prop.GetValue(this, null);
                if (value == null) continue;

                if (value is BHoMObject)
                    aResult += string.Format("\"{0}\": \"{1}\",", prop.Name, (value as BHoMObject).BHoM_Guid);
                else if (value.GetType().GetMethod("ToJSON") != null)
                    aResult += string.Format("\"{0}\": {1},", prop.Name, value.GetType().GetMethod("ToJSON").Invoke(value, null));
                else
                    aResult += string.Format("\"{0}\": \"{1}\",", prop.Name, value.ToString());
            }
            if (aResult.Last() == ',')
                aResult = aResult.Substring(0, aResult.Length - 1);
            aResult += "}";

            // Write all the parameters
            aResult += ",\"Parameters\": {";
            foreach (Parameter param in Parameters)
            {
                var value = param.Value;
                if (value == null) continue;

                if (value is BHoMObject)
                    aResult += string.Format("\"{0}\": \"{1}\",", param.Name, (value as BHoMObject).BHoM_Guid);
                else if (value.GetType().GetMethod("ToJSON") != null)
                    aResult += string.Format("\"{0}\": {1},", param.Name, value.GetType().GetMethod("ToJSON").Invoke(value, null));
                else
                    aResult += string.Format("\"{0}\": \"{1}\",", param.Name, value.ToString());
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
            Dictionary<string, string> definition = GetDefinitionFromJSON(json);
            if (!definition.ContainsKey("Primitive") || !definition.ContainsKey("Properties")) return null;

            // Try to create an object that correponds the object type stored in "Primitive"
            var typeString = definition["Primitive"].Replace("\"", "").Replace("{", "").Replace("}", "");
            Type type = Type.GetType(typeString);
            if (type == null) return null;
            BHoMObject newObject = Activator.CreateInstance(type) as BHoMObject;

            // Get the definition of the properties
            Dictionary<string, string> properties = GetDefinitionFromJSON(definition["Properties"]);
            foreach (KeyValuePair<string, string> kvp in properties)
            {
                string prop = kvp.Key.Trim().Replace("\"", "");
                System.Reflection.PropertyInfo pInfo = newObject.GetType().GetProperty(prop);
                if (pInfo == null) continue;

                Type pType = pInfo.PropertyType;
                string valueString = kvp.Value.Trim().Replace("\"", "");
                if (pType == typeof(System.String))
                    pInfo.SetValue(newObject, valueString);
                else
                {
                    System.Reflection.MethodInfo jsonMethod = pType.GetMethod("FromJSON");
                    if (jsonMethod != null)
                        pInfo.SetValue(newObject, jsonMethod.Invoke(newObject, new object[] { valueString }));
                    else
                    {
                        System.Reflection.MethodInfo parseMethod = pType.GetMethod("Parse", new Type[] { typeof(string) });
                        if (parseMethod != null)
                            pInfo.SetValue(newObject, parseMethod.Invoke(newObject, new object[] { valueString }));
                    }
                }

            }

            return newObject;
        }

        private static Dictionary<string, string> GetDefinitionFromJSON(string json)
        {
            int i0 = 0;
            int level = 0;
            string key = "";
            string value = "";
            string inside = json.Substring(json.IndexOf('{') + 1, json.LastIndexOf('}') - 1);

            Dictionary<string, string> definition = new Dictionary<string, string>();
            for (int i = 0; i < inside.Length; i++)
            {
                if (inside[i] == '{')
                    level++;
                else if (inside[i] == '}')
                    level--;
                else if (level == 0 && inside[i] == ':')
                {
                    key = inside.Substring(i0, i - i0).Trim().Replace("\"", "");
                    i0 = i + 1;
                }
                else if (level == 0 && inside[i] == ',')
                {
                    value = inside.Substring(i0, i - i0).Trim();
                    definition.Add(key, value);
                    i0 = i + 1;
                }
            }

            return definition;
        }

        /// <summary>
        /// Convert object paramters to XML
        /// </summary>
        /// <returns></returns>
        public virtual XmlNode Xml()
        {
            XmlDocument doc = Project.m_Xml;

            XmlNode objectNode = doc.CreateElement("BHoM_Object");
            objectNode.Attributes.Append(doc.CreateAttribute("Id")).Value = BHoM_Guid.ToString();
            objectNode.Attributes.Append(doc.CreateAttribute("Name")).Value = Name;
            objectNode.Attributes.Append(doc.CreateAttribute("Number")).Value = Number.ToString();
            objectNode.Attributes.Append(doc.CreateAttribute("Type")).Value = this.GetType().ToString();
           
            XmlNode parameter;
            foreach (Parameter p in Parameters)
            {
                parameter = objectNode.AppendChild(doc.CreateElement("Parameter"));
                parameter.Attributes.Append(doc.CreateAttribute("Name")).Value = p.Name;
                parameter.Attributes.Append(doc.CreateAttribute("Type")).Value = p.GetType().ToString();
                parameter.Attributes.Append(doc.CreateAttribute("Value")).Value = p.DataString();
                parameter.Attributes.Append(doc.CreateAttribute("Access")).Value = p.Access.ToString();

            }
            return objectNode;
        }       

    }
}