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


       /// <summary>Structure number</summary>
        public int Number { get; private set; }

        /// <summary>Structure name</summary>
        public string Name { get; private set; }

        /// <summary>List of nodes</summary>
        public List<Node> Nodes
        {
            get
            {
                return m_Objects.Values.Where(obj => obj.GetType() == typeof(Node)).Cast<Node>().ToList();
            }
        }

        /// <summary>List of bars</summary>
        public List<Bar> Bars
        {
            get
            {
                return m_Objects.Values.Where(obj => obj.GetType() == typeof(Bar)).Cast<Bar>().ToList();
            }
        }

        /// <summary>List of faces</summary>
        public Dictionary<int,Face> Faces { get; private set; }

        /// <summary>Dictionary of constraints</summary>
        public Dictionary<string, BHoM.Structural.Constraint> Constraints {get; private set;}

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
                obj.BHoM_Guid = new Guid(node.Attributes.GetNamedItem("Id").Value);
                foreach (XmlNode parameter in node.ChildNodes)
                {
                    string name = parameter.Attributes.GetNamedItem("Name").Value;
                    string enumType = parameter.Attributes.GetNamedItem("DataType").Value;                 
                    string value = parameter.Attributes.GetNamedItem("Value").Value;
                    obj.SetParameter(name, value, enumType);
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
            Faces = new Dictionary<int,Face>();
            Constraints = new Dictionary<string, BHoM.Structural.Constraint>();
        }
 
        public BHoM.Global.BHoMObject GetObject(Guid id)
        {
            BHoM.Global.BHoMObject result = null;
            m_Objects.TryGetValue(id, out result);
            return result;
        }

        public void AddObject(BHoM.Global.BHoMObject value)
        {
            value.Project = this;
            m_Objects.Add(value.BHoM_Guid, value);
        }

    }
}
