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
        public string Name { get; internal set; }
        public int Number { get; internal set; }
        public Project Project { get; set; }

        /// <summary>User text input. Can be used to store user information in an object
        /// such as a user ID or a project specific parameter</summary>
        /// 
        public ObjectParameters Parameters { get; set; }
        public BHoM.Collections.Dictionary<string, object> UserData { get; set; }

        internal BHoMObject()
        {
            Parameters = new ObjectParameters();
            Number = -1;
            this.BHoM_Guid = System.Guid.NewGuid();
        }

        ///// <summary>
        ///// Set the BHoM_Guid
        ///// </summary>
        //public void SetBHoMGuid()
        //{
        //    this.BHoM_Guid = System.Guid.NewGuid();
        //}

        //public void SetParameter(string name, object data)
        //{
        //    Parameter p = null;
        //    if (Parameters.TryGetValue(name, out p))
        //    {
        //        p.SetValue(data);
        //    }
        //    else
        //    {
        //        Parameters.Add(name,new Parameter(name, data));
        //    }
        //}

        //internal void SetParameter(string name, string data, string storage)
        //{
        //    Parameter p = null;
        //    if (Parameters.TryGetValue(name, out p))
        //    {
        //        p.SetValue(data);
        //    }
        //    else
        //    {
        //        Parameters.Add(name, new Parameter(name, data, storage));
        //    }
        //}

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