using BHoM.Structural;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Global
{
    public abstract class ObjectFactory //: IList<T>
    {
        private Project m_Project;
        private Dictionary<string, BHoMObject> m_Data;
        private int m_FreeNumber;

        public ObjectFactory(Project project, List<BHoMObject> items)
        {
            m_Project = project;
            m_Data = new Dictionary<string, BHoMObject>();
            for (int i = 0; i < items.Count; i++)
            {
                m_Data.Add(items[i].Number.ToString(), items[i]);
            }
        }

        public ObjectFactory ForceUniqueByNumber()
        {
            Dictionary<string, BHoMObject> newDictionary = new Dictionary<string,BHoMObject>();
            foreach (BHoMObject value in m_Data.Values)
            {
                newDictionary.Add(value.Number.ToString(), value);
            }

            m_Data = newDictionary;
            return this;
        }

        public ObjectFactory ForceUniqueByName()
        {
            Dictionary<string, BHoMObject> newDictionary = new Dictionary<string, BHoMObject>();
            foreach (BHoMObject value in m_Data.Values)
            {
                newDictionary.Add(value.Name, value);
            }

            m_Data = newDictionary;
            return this;
        }
        //public void Clear()
        //{
        //    foreach (int i = 0; i < m_Data.Count; i++)
        //    {               
        //        m_Project.RemoveObject(m_Data[i].BHoM_Guid);              
        //    }
        //    m_Data.Clear();
        //}

        //public BHoMObject Get(int number)
        //{
        //    return m_Data.First(o => o.Number == number);
        //}

        public BHoMObject this[int key]
        {
            get
            {
                BHoMObject result = null;
                m_Data.TryGetValue(key.ToString(), out result);
                return result;
            }
            set
            {
                BHoMObject result = null;
                m_Data.TryGetValue(key.ToString(), out result);
                result = value;
            }
        }

        public BHoMObject this[string key]
        {
            get
            {
                BHoMObject result = null;
                m_Data.TryGetValue(key.ToString(), out result);
                return result;
            }
            set
            {
                BHoMObject result = null;
                m_Data.TryGetValue(key.ToString(), out result);
                result = value;
            }
        }

        public bool ContainsName(string name)
        {
            BHoMObject obj = null;
            return m_Data.Count == 0 ? false : m_Data.TryGetValue(name.ToString(), out obj);
        }

        public bool ContainsNumber(int number)
        {
            BHoMObject obj = null;
            return m_Data.Count == 0 ? false : m_Data.TryGetValue(number.ToString(), out obj);
        }

        protected void Add(BHoMObject obj)
        {
            m_Data.Add(obj.Number.ToString(), obj);
            m_Project.AddObject(obj);
            m_FreeNumber = Math.Max(obj.Number, m_FreeNumber) + 1;
        }

        public int FreeNumber()
        {
            if (m_FreeNumber == 0)
            {
                m_FreeNumber = m_Data.Count == 0 ? 1 : m_Data.Values.Max(o=>o.Number) + 1;
            }
            return m_FreeNumber;
        }

        //public T AddUnique(T item, bool checkNumber)
        //{
        //    BHoMObject obj = item as BHoMObject;
        //    if (obj != null)
        //    {
        //        int counter = 0;
        //        foreach (T element in m_Data)
        //        {
        //            BHoMObject currentObj = element as BHoMObject;
        //            if (currentObj.Name == obj.Name)
        //            {
        //                break;
        //            }
        //            counter++;
        //        }
        //        if (counter == 0)
        //        {
        //            m_Data.Add(item);
        //            m_Project.AddObject(obj);
        //        }
        //        else
        //        {
        //            return m_Data[counter];
        //        }
        //    }
        //    return default(T);
        //}

        public int Count
        {
            get 
            { 
                return m_Data.Count; 
            }
        }
    }

    public class NodeFactory : ObjectFactory
    {
        public NodeFactory(Project p, List<BHoM.Global.BHoMObject> nodes) : base(p, nodes) { }

        public Node Create(int number, double x, double y, double z)
        {
            if (this.ContainsNumber(number))
            {
                return this[number] as Node;
            }
            else
            {
                Node node = new Node(x, y, z, number);
                this.Add(node);
                return node;
            }
        }

        public Node Create(double x, double y, double z)
        {
            Node node = new Node(x, y, z, FreeNumber());
            this.Add(node);
            return node;
        }
    }

    public class BarFactory : ObjectFactory
    {
        public BarFactory(Project p, List<BHoM.Global.BHoMObject> bars) : base(p, bars) { }

        public Bar Create(int number, Node n1, Node n2)
        {
            if (this.ContainsNumber(number))
            {
                return this[number] as Bar;
            }
            else
            {
                Bar bar = new Bar(n1, n2, number);
                this.Add(bar);
                return bar;
            }
        }

        public Bar Create(Node n1, Node n2)
        {          
            Bar bar = new Bar(n1, n2, FreeNumber());
            this.Add(bar);
            return bar;          
        }
    }

    public class ConstraintFactory : ObjectFactory
    {
        public ConstraintFactory(Project p, List<BHoM.Global.BHoMObject> constraint) : base(p, constraint) { }

        public Constraint Create(string name, double x, double y, double z, double xx, double yy, double zz)
        {
            if (this.ContainsName(name))
            {
                return this[name] as Constraint;
            }
            else
            {
                return new Constraint(name, new double[] { 0, 0, 0, 0, 0, 0 });
            }
        }

        public Constraint Create(string name, bool x, bool y, bool z, bool xx, bool yy, bool zz)
        {
            if (this.ContainsName(name))
            {
                return this[name] as Constraint;
            }
            else
            {
                Constraint c = new Constraint(name, new bool[] { x, y, z, xx, yy, zz}, new double[6]);
                this.Add(c);
                return c;
            }
        }

        public Constraint Create(string name, bool[] fixity, double[] values)
        {
            if (this.ContainsName(name))
            {
                return this[name] as Constraint;
            }
            else
            {
                Constraint c = new Constraint(name, fixity, values);
                this.Add(c);
                return c;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="fixity">Constraint string x indicates fixity and f indices freedom must be 6 characters long or nothing will be returned</param>
        /// <returns></returns>
        public Constraint Create(string name, string fixity)
        {
            if (this.ContainsName(name))
            {
                return this[name] as Constraint;
            }
            else
            {
                if (fixity.Length == 6)
                {
                    bool[] f = new bool[6];
                    for (int i = 0; i < 6;i++)
                    {
                        f[i]= fixity[i] == 'x';
                    }
                    return new Constraint(name, f, new double[6]);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
