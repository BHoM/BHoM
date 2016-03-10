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
        public int Number { get; internal set; }

        /// <summary>Project</summary>
        public Project Project { get; set; }
               
        /// <summary>User text input. Can be used to store user information in an object
        /// such as a user ID or a project specific parameter</summary>
        public BHoM.Collections.Dictionary<string, object> UserData { get; set; }

        /// <summary>Object parameters</summary>
        public ObjectParameters Parameters { get; set; }

        internal BHoMObject()
        {
            Parameters = new ObjectParameters();
            Number = -1;
            this.BHoM_Guid = System.Guid.NewGuid();
        }

        /// <summary>
        /// Set the BHoM_Guid
        /// </summary>
        internal void SetBHoMGuid()
        {
            BHoM_Guid = Guid.NewGuid();
        }

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

        protected virtual string JSON(string NestedJSON)
        {
            string aResult = "{";
            aResult += string.Format("\"{0}\": \"{1}\",", "primitive", GetType().Name);
            aResult += string.Format("\"{0}\": \"{1}\",", "Id", BHoM_Guid.ToString());
            aResult += string.Format("\"{0}\": \"{1}\",", "Name", Name);
<<<<<<< HEAD
            aResult += string.Format("\"{0}\": \"{1}\",", "Type", GetType().Name);
=======
            aResult += string.Format("\"{0}\": \"{1}\",", "Number", Number);
            aResult += string.Format("\"{0}\": \"{1}\",", "Type", GetType().ToString());
>>>>>>> origin/develop

            if (Parameters.Count > 0)
            {
                aResult += string.Format("\"{0}\": {1}", "Parameters", "{");
                foreach (Parameter aParameter in Parameters)
                    if (aParameter != null)
                        if (aParameter is BH_Double)
                            aResult += string.Format("\"{0}\": {1},", aParameter.Name, aParameter.Value as double?);
                        else if (aParameter is BH_Interger)
                            aResult += string.Format("\"{0}\": {1},", aParameter.Name, aParameter.Value as int?);
                        else if (aParameter is BH_String)
                            aResult += string.Format("\"{0}\": \"{1}\",", aParameter.Name, aParameter.Value as string);
                        else if (aParameter is BH_Guid)
                            aResult += string.Format("\"{0}\": \"{1}\",", aParameter.Name, (aParameter.Value as Guid?).ToString());

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