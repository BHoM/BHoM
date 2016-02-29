using BHoM.Structural;
using BHoM.Structural.SectionProperties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BHoM.Global
{
    public class Project
    {
        private Dictionary<Guid, BHoM.Global.BHoMObject> m_Objects;
        internal XmlDocument m_Xml;


        public Structure Structure { get; private set; }
       /// <summary>Structure number</summary>
        public int Number { get; private set; }

        /// <summary>Structure name</summary>
        public string Name { get; private set; }

        /// <summary>Dictionary of storeys</summary>
        public Dictionary<int, Storey> Storeys { get; private set; }
        
        /// <summary>List of section properties</summary>
        public List<SectionProperty> SectionProperties { get;  private set; }

        /// <summary>Tolerance of structure for node merge etc</summary>
        public double Tolerance { get; private set; }

        public static Project LoadXml(string fileName)
        {
            Project structure = new Project();
            structure.m_Xml = new XmlDocument();
            structure.m_Xml.Load(fileName);

            XmlNode objects = structure.m_Xml.FirstChild;
            foreach (XmlNode node in objects.ChildNodes)
            {
                Type type = Type.GetType(node.Attributes.GetNamedItem("Type").Value);
                BHoM.Global.BHoMObject obj = (BHoM.Global.BHoMObject)Activator.CreateInstance(type, true);
                obj.Name = node.Attributes.GetNamedItem("Name").Value;
                obj.Number = int.Parse(node.Attributes.GetNamedItem("Number").Value);
                obj.BHoM_Guid = new Guid(node.Attributes.GetNamedItem("Id").Value);
                foreach (XmlNode parameter in node.ChildNodes)
                {
                    string name = parameter.Attributes.GetNamedItem("Name").Value;
                    Type paramType = Type.GetType(parameter.Attributes.GetNamedItem("Type").Value);
                    string value = parameter.Attributes.GetNamedItem("Value").Value;
                    string access = parameter.Attributes.GetNamedItem("Access").Value;                

                    BHoM.Global.Parameter param = (BHoM.Global.Parameter)Activator.CreateInstance(paramType, true);
                    param.SetData(name, value, (AccessType)Enum.Parse(typeof(AccessType), access));
                    obj.Parameters.AddParameter(param);
                }
                structure.AddObject(obj);
            }
            return structure;
        }

        public void WriteXml(string filePath)
        {
            m_Xml = new XmlDocument();
            XmlNode objects = m_Xml.AppendChild(m_Xml.CreateElement("Objects"));
            foreach (Global.BHoMObject obj in m_Objects.Values)
            {
                objects.AppendChild(obj.Xml());
            }
            m_Xml.Save(filePath);
        }

        /// <summary>
        /// Constructs an empty structure
        /// </summary>
        public Project()
        {
            m_Objects = new Dictionary<Guid, Global.BHoMObject>();
            Structure = new Structure(this, m_Objects);
        }
 
        public BHoM.Global.BHoMObject GetObject(Guid id)
        {
            BHoM.Global.BHoMObject result = null;
            m_Objects.TryGetValue(id, out result);
            return result;
        }

        internal void AddObject(BHoM.Global.BHoMObject value)
        {
            value.Project = this;
            m_Objects.Add(value.BHoM_Guid, value);
        }


        internal void RemoveObject(Guid guid)
        {
            m_Objects.Remove(guid);
        }
    }
}
