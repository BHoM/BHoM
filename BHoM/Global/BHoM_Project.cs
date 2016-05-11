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
    public struct Task
    {
        public Guid BHoMGuid;
        public string Property;
        public string Value;
    }


    /// <summary>
    /// A global project class that encapsulates all objects (all disciplines) of a BHoM project
    /// </summary>
    public class Project
    {
        private Dictionary<Guid, BHoM.Global.BHoMObject> m_Objects;
        private Queue<Task> m_TaskQueue;

        private static readonly Lazy<Project> m_Instance = new Lazy<Project>(() => new Project());

        public IEnumerable<BHoMObject> Objects
        {
            get
            {
                return m_Objects.Values;
            }
        }

        /// <summary>Structure property - gets or sets the structure of the object as a BHoM.Structural.Structure</summary>
        public Structure Structure { get; private set; }

        /// <summary>Structure name</summary>
        public string Name { get; private set; }

        /// <summary>Tolerance of structure for node merge etc</summary>
        public double Tolerance { get; private set; }

        public Guid Id { get; set; }

        public static Project ActiveProject
        {
            get
            {
                return m_Instance.Value;
            }
        }

        public string ToJSON(string extra = "")
        {
            string aResult = "{";
            aResult += string.Format("\"{0}\": {1}", "Primitive", "{\"Project\"}");

            // Write all the properties
            aResult += ",\"Properties\": {";
            foreach (var prop in this.GetType().GetProperties())
            {
                if (!prop.CanRead || !prop.CanWrite) continue;

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
            aResult += ",\"Objects\": {";
            int objIndex = 0;
            foreach (var value in Objects)
            {
                aResult += string.Format("\"{0}\": {1},", objIndex++, value.ToJSON());
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

        public static Project FromJSON(string json)
        {
            Dictionary<string, string> definition = Utils.GetDefinitionFromJSON(json);
            if (!definition.ContainsKey("Primitive") || !definition.ContainsKey("Properties")) return null;

            // Try to create an object that correponds the object type stored in "Primitive"
            var typeString = definition["Primitive"].Replace("\"", "").Replace("{", "").Replace("}", "");
            if (typeString != "Project") return null;

            // Get the definition of the properties
            Dictionary<string, string> properties = Utils.GetDefinitionFromJSON(definition["Properties"]);
            foreach (KeyValuePair<string, string> kvp in properties)
            {
                string prop = kvp.Key.Trim().Replace("\"", "");
                string valueString = kvp.Value.Trim().Replace("\"", "");
                Utils.ReadProperty(ActiveProject, prop, valueString);                
            }

            Dictionary<string, string> objects = Utils.GetDefinitionFromJSON(definition["Objects"]);
            foreach (KeyValuePair<string, string> kvp in objects)
            {
                ActiveProject.AddObject(BHoMObject.FromJSON(kvp.Value));
            }

            ActiveProject.RunTasks();

            return ActiveProject;
        }

        /// <summary>
        /// Constructs an empty project
        /// </summary>
        private Project()
        {
            m_Objects = new Dictionary<Guid, Global.BHoMObject>();
            m_TaskQueue = new Queue<Task>();
            Structure = new Structure(this, m_Objects);
        }

        /// <summary>Returns a BHoM by unique identifier</summary>
        public BHoM.Global.BHoMObject GetObject(Guid id)
        {
            BHoM.Global.BHoMObject result = null;
            m_Objects.TryGetValue(id, out result);
            return result;
        }

        public void AddObject(BHoM.Global.BHoMObject value)
        {
            m_Objects.Add(value.BHoM_Guid, value);
        }

        public void RemoveObject(Guid guid)
        {
            m_Objects.Remove(guid);
        }

        internal void AddTask(Task task)
        {
            m_TaskQueue.Enqueue(task);
        }

        internal void RunTasks()
        {
            while(m_TaskQueue.Count > 0)
            {
                Task t = m_TaskQueue.Dequeue();
                BHoMObject obj = null;
                if (m_Objects.TryGetValue(t.BHoMGuid, out obj))
                {
                    Utils.ReadProperty(obj, t.Property, t.Value);
                }
            }
        }
    }
}
