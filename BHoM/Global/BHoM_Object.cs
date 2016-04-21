using System;
using System.Collections.Generic;
using System.Xml;

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
        public int Number { get; internal set; }

        /// <summary>Project</summary>
        public Project Project { get; set; }

        /// <summary>Object parameters</summary>
        public ObjectParameters Parameters { get; set; }

        internal BHoMObject()
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