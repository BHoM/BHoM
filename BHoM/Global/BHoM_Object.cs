﻿using System.Collections.Generic;
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
        public string Name { get; internal set; }
        public Project Project { get; set; }

        /// <summary>User text input. Can be used to store user information in an object
        /// such as a user ID or a project specific parameter</summary>
        /// 
        public Dictionary<string, Parameter> Parameters { get; set; }
        public BHoM.Collections.Dictionary<string, object> UserData { get; set; }

        internal BHoMObject()
        {
            Parameters = new Dictionary<string, Parameter>();
        }

        /// <summary>
        /// Set the BHoM_Guid
        /// </summary>
        public void SetBHoMGuid()
        {
            this.BHoM_Guid = System.Guid.NewGuid();
        }

        public void SetParameter(string name, object data)
        {
            Parameter p = null;
            if (Parameters.TryGetValue(name, out p))
            {
                p.SetValue(data);
            }
            else
            {
                Parameters.Add(name, new Parameter(name, data));
            }
        }

        internal void SetParameter(string name, string data, string storage)
        {
            Parameter p = null;
            if (Parameters.TryGetValue(name, out p))
            {
                p.SetValue(data);
            }
            else
            {
                Parameters.Add(name, new Parameter(name, data, storage));
            }
        }

        //////////////
        ////Methods///
        //////////////

        /// <summary>Method which gets a properties dictionary for simple downstream deconstruct</summary>
        public BHoM.Collections.Dictionary<string, object> GetProperties()
        {
            BHoM.Collections.Dictionary<string, object> PropertiesDictionary = new BHoM.Collections.Dictionary<string, object>();
            foreach (var prop in this.GetType().GetProperties())
            {
                PropertiesDictionary.Add(prop.Name, prop.GetValue(this));
            }
            return PropertiesDictionary;
        }

        public virtual XmlNode Xml()
        {
            XmlDocument doc = Project.m_Xml;

            XmlNode objectNode = doc.CreateElement("BHoM_Object");
            objectNode.Attributes.Append(doc.CreateAttribute("Id")).Value = BHoM_Guid.ToString();
            objectNode.Attributes.Append(doc.CreateAttribute("Name")).Value = Name;
            objectNode.Attributes.Append(doc.CreateAttribute("Type")).Value = this.GetType().ToString();

            XmlNode parameter;
            foreach (string key in Parameters.Keys)
            {
                parameter = objectNode.AppendChild(doc.CreateElement("Parameter"));
                parameter.Attributes.Append(doc.CreateAttribute("Name")).Value = Parameters[key].Name;
                parameter.Attributes.Append(doc.CreateAttribute("DataType")).Value = Parameters[key].DataType.ToString();
                parameter.Attributes.Append(doc.CreateAttribute("Value")).Value = Parameters[key].Data.ToString();

            }
            return objectNode;
        }

        protected virtual string JSON(string NestedJSON)
        {
            string aResult = "{";
            aResult += string.Format("\"{0}\": \"{1}\",", "primitive", "BHoM_Object");
            aResult += string.Format("\"{0}\": \"{1}\",", "Id", BHoM_Guid.ToString());
            aResult += string.Format("\"{0}\": \"{1}\",", "Name", Name);
            aResult += string.Format("\"{0}\": \"{1}\",", "Type", GetType().ToString());

            if (Parameters.Count > 0)
            {
                aResult += string.Format("\"{0}\": {1}", "Parameters", "{");
                foreach (string key in Parameters.Keys)
                {
                    switch(Parameters[key].DataType)
                    {
                        case StorageType.Double:
                            aResult += string.Format("\"{0}\": {1},", Parameters[key].Name, Parameters[key].Data);
                            break;
                        case StorageType.String:
                            aResult += string.Format("\"{0}\": \"{1}\",", Parameters[key].Name, Parameters[key].Data);
                            break;
                        case StorageType.Id:
                            aResult += string.Format("\"{0}\": \"{1}\",", Parameters[key].Name, Parameters[key].Data);
                            break;
                        case StorageType.Integer:
                            aResult += string.Format("\"{0}\": {1},", Parameters[key].Name, Parameters[key].Data);
                            break;
                    }
                    
                }
                if (aResult.Last() == ',')
                    aResult = aResult.Substring(0, aResult.Length - 1);
                aResult += "}";
            }
            if (aResult.Last() == ',')
                aResult = aResult.Substring(0, aResult.Length - 1);


            aResult += NestedJSON;
            aResult += "}";
            return aResult;
        }

        public virtual string JSON()
        {
            return JSON(string.Empty);
        }  

    }
}