using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using BHoM.Base;
using BHoM.Structural;
using BHoM.Structural.Elements;
using BHoM.Base.Data;

namespace BHoM.Global
{
    public struct Task
    {
        public Task(BHoMObject bhomObject, string property, string value)
        {
            BhomObject = bhomObject;
            Property = property;
            Value = value;
        }

        public BHoMObject BhomObject;
        public string Property;
        public string Value;
    }

    /// <summary>
    /// A global project class that encapsulates all objects (all disciplines) of a BHoM project
    /// </summary>
    
    public class Project
    {
        private Dictionary<Guid, BHoM.Base.BHoMObject> m_Objects;
        private Queue<Task> m_TaskQueue;
        private Dictionary<Database, IDataAdapter> m_Databases;

        private static readonly Lazy<Project> m_Instance = new Lazy<Project>(() => new Project());
        
        /// <summary>
        /// All object currently in the model
        /// </summary>
        public IEnumerable<BHoMObject> Objects
        {
            get
            {
                return m_Objects.Values;
            }
        }

        /// <summary>Structure name</summary>
        public string Name { get; set; }

        /// <summary>Tolerance of structure for node merge etc</summary>
        public double Tolerance { get; private set; }

        /// <summary>
        /// Project Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Active project
        /// </summary>
        public static Project ActiveProject
        {
            get
            {
                return m_Instance.Value;
            }
        }

        public Config Config { get; set; }

        /// <summary>
        /// Writes the entire project to JSON Format
        /// </summary>
        /// <param name="extra"></param>
        /// <returns>JSON formatted text</returns>
        public string ToJSON(string extra = "")
        {
            string aResult = "{";
            aResult += string.Format("\"{0}\": {1},", "Type", "\"" + GetType() + "\"");
            aResult += string.Format("\"{0}\": {1},", "Primitive", "\"" + GetType().AssemblyQualifiedName.Replace(",", ";") + "\"");

            // Write all the properties
            aResult += "\"Properties\": {";
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
                aResult = aResult.Trim(',');
            aResult += "}";

            // Write all the dependencies
            Dictionary<Guid, BHoMObject> dependencies = new Dictionary<Guid, BHoMObject>();
            foreach (BHoMObject bhomObject in Objects)
            {
                foreach (KeyValuePair<Guid, BHoMObject> kvp in bhomObject.GetDeepDependencies())
                {
                    BHoMObject value = null;
                    if (!dependencies.TryGetValue(kvp.Key, out value) && this.GetObject(kvp.Key) == null)
                        dependencies.Add(kvp.Key, kvp.Value);
                }
            }
            aResult += ",\"Dependencies\": [";
            foreach (BHoMObject obj in dependencies.Values)
                aResult += obj.ToJSON() + ",";
            aResult = aResult.Trim(',');
            aResult += "]";

            // Write all the contained objects
            aResult += ",\"Objects\": [";
            foreach (var value in Objects)
            {
                aResult += value.ToJSON() + ",";
            }
            aResult = aResult.Trim(',');
            aResult += "]";
            // Write the extra information
            if (extra.Length > 0)
                aResult += "," + extra;

            aResult += "}";

            return aResult;
        }

        /// <summary>
        /// Loads an entire Project from JSON Format
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static Project FromJSON(string json)
        {
            Project project = new Project();

            Dictionary<string, string> definition = BHoMJSON.GetDefinitionFromJSON(json);
            if (!definition.ContainsKey("Primitive") || !definition.ContainsKey("Properties")) return null;

            // Try to create an object that correponds the object type stored in "Primitive"
            var typeString = definition["Type"].Replace("\"", "").Replace("{", "").Replace("}", "");
            if (typeString != "BHoM.Global.Project") return null;

            // Get the definition of the properties
            Dictionary<string, string> properties = BHoMJSON.GetDefinitionFromJSON(definition["Properties"]);
            foreach (KeyValuePair<string, string> kvp in properties)
            {
                string prop = kvp.Key.Trim().Replace("\"", "");
                string valueString = kvp.Value.Trim().Replace("\"", "");
                BHoMJSON.ReadProperty(project, prop, valueString, project);                
            }

            // Get all the dependencies
            List<BHoMObject> depDefs = BHoMJSON.ReadCollection(typeof(List<BHoMObject>), definition["Dependencies"], project) as List<BHoMObject>;
            foreach (BHoMObject o in depDefs)
            {
                project.AddObject(o);
            }

            // Get all the contained objects
            List<BHoMObject> objects = BHoMJSON.ReadCollection(typeof(List<BHoMObject>), definition["Objects"], project) as List<BHoMObject>;
            foreach (BHoMObject o in objects)
            {
                project.AddObject(o);
            }

            project.RunTasks();

            return project;
        }

        /// <summary>
        /// Constructs an empty project
        /// </summary>
        public Project()
        {
            m_Objects = new Dictionary<Guid, BHoMObject>();
            m_TaskQueue = new Queue<Task>();
            m_Databases = new Dictionary<Database, IDataAdapter>();
            Config = new Config();
        }

        /// <summary>Returns a BHoM by unique identifier</summary>
        public BHoM.Base.BHoMObject GetObject(Guid id)
        {
            BHoM.Base.BHoMObject result = null;
            m_Objects.TryGetValue(id, out result);
            return result;
        }

        /// <summary>Returns a BHoM by unique identifier</summary>
        public BHoM.Base.BHoMObject GetObject(string id)
        {
            BHoM.Base.BHoMObject result = null;
            Guid guid = new Guid();
            if (Guid.TryParse(id, out guid))
                m_Objects.TryGetValue(guid, out result);
            return result;
        }
         
        /// <summary>
        /// Adds a BHoM Object to the project
        /// </summary>
        /// <param name="value"></param>
        public void AddObject(BHoM.Base.BHoMObject value)
        {
            if (m_Objects.ContainsKey(value.BHoM_Guid))
                return;

            m_Objects.Add(value.BHoM_Guid, value);

            Dictionary<Guid, BHoMObject> dependencies = value.GetShallowDependencies();

            foreach (KeyValuePair<Guid, BHoMObject> obj in dependencies)
            {
                AddObject(obj.Value);
            }
        }

        /// <summary>
        /// Adds a BHoM Object to the project
        /// </summary>
        /// <param name="values"></param>
        public void AddObjects(IEnumerable<BHoM.Base.BHoMObject> values)
        {
           foreach (BHoMObject b in values)
            {
                AddObject(b);
            }
        }

        /// <summary>
        /// Removes an object from the project
        /// </summary>
        /// <param name="guid"></param>
        public void RemoveObject(Guid guid)
        {
            m_Objects.Remove(guid);
        }

        /// <summary>
        /// Removes all objects from the project
        /// </summary>
        public void Clear()
        {
            m_Objects.Clear();
        }

        internal void AddTask(Task task)
        {
            m_TaskQueue.Enqueue(task);
        }

        public void RunTasks()
        {
            while(m_TaskQueue.Count > 0)
            {
                Task t = m_TaskQueue.Dequeue();
                BHoMJSON.ReadProperty(t.BhomObject, t.Property, t.Value, this);               
            }
        }

        public IEnumerable<string> GetTaskValues()
        {
            return m_TaskQueue.Select(x => x.Value);
        }

        public void MergeWithin(double tolerance)
        {
            List<Node> nodes = new BHoM.Base.ObjectFilter<Node>(new Project()).ToList();

            nodes.Sort(delegate (Node n1, Node n2)
            {
                return n1.Point.DistanceTo(BHoM.Geometry.Point.Origin).CompareTo(n2.Point.DistanceTo(BHoM.Geometry.Point.Origin));
            });

            for (int i = 0; i < nodes.Count; i++)
            {
                double distance = nodes[i].Point.DistanceTo(BHoM.Geometry.Point.Origin);
                int j = i + 1;
                while (j < nodes.Count && Math.Abs(nodes[j].Point.DistanceTo(BHoM.Geometry.Point.Origin) - distance) < tolerance)
                {
                    if (nodes[i].Point.DistanceTo(nodes[j].Point) < tolerance)
                    {
                        nodes[j] = nodes[j].Merge(nodes[i]);
                        Project.ActiveProject.RemoveObject(nodes[i].BHoM_Guid);
                        break;
                    }
                    j++;
                }
            }
        }

        public IDataAdapter GetDatabase<T>(Database dbType) where T : IDataRow
        {
            IDataAdapter result = null;
            if (!m_Databases.TryGetValue(dbType, out result))
            {
                result = new JsonFileDB<T>(dbType);
                m_Databases.Add(dbType, result);
            }
            return result;
        }
    }
}
