using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Global
{
    //public enum StorageType
    //{
    //    Integer,
    //    Double,
    //    String,
    //    Id,
    //    Generic
    //}

    public enum AccessType
    {
       Item,
       List
    }

    public interface IParam
    {

    }

    public abstract class Parameter
    {
        public string Name { get; protected set; }
        public object Value { get; protected set; }
        public AccessType Access { get; protected set; }

        internal Parameter() { }

        internal Parameter(string name, AccessType access)
        {
            Name = name;
            Access = access;
        }

        public T GetData<T>()
        {
            return (T)Value;
        }

        public List<T> GetDataList<T>()
        {
            return (List<T>)Value;
        }

        public void SetValue(object value)
        {
            Value = value;
        }
        
        public abstract string DataString();
      
        public static Parameter CreateData(string name, object data)
        {
            string type = data.GetType().ToString();
            switch (type)
            {
                case "System.String":
                    return new BH_String(name, data.ToString(), AccessType.Item);
                case "System.Integer":
                    return new BH_Interger(name, (int)data);
                case "System.Double":
                    return new BH_Double(name, (double)data);
                case "System.Guid":
                    return new BH_Guid(name, (Guid)data);
                default:
                    return null;
            }
        }


        internal static Parameter CreateDataList<T>(string name, List<T> data)
        {
            string type = typeof(T).ToString();
            switch (type)
            {
                case "System.String":
                    return new BH_String(name, data.Cast<string>().ToList());
                case "System.Integer":
                case "System.Int32":
                case "System.Int16":
                case "System.Byte":
                    return new BH_Interger(name, data.Cast<int>().ToList());
                case "System.Double":
                case "System.Float":
                    return new BH_Double(name, data.Cast<double>().ToList());
                case "System.Guid":
                    return new BH_Guid(name, data.Cast<Guid>().ToList());
                default:
                    return null;
            }
        }

        public abstract void SetData(string name, string value, AccessType access);
    }

    public class BH_Interger : Parameter
    {
        internal BH_Interger() { }

        internal BH_Interger(string name, int value) : base(name, AccessType.Item)
        {
            Value = value;
        }

        internal BH_Interger(string name, List<int> value)
            : base(name, AccessType.List)
        {
            Value = value;
        }

        internal BH_Interger(string name, string value, AccessType type) : base(name, type)
        {
            SetData(name, value, type);
        }

        public override string DataString()
        {
            switch (Access)
            {
                case AccessType.Item:
                    return Value.ToString();
                case AccessType.List:
                    string result = "{";
                    List<int> values = GetDataList<int>();
                    for (int i = 0; i < values.Count; i++)
                    {
                        result += values[i].ToString() + ",";
                    }
                    result = result.Trim(',');
                    return result + "}";
            }
            return "";
        }
    
        public override void SetData(string name, string value, AccessType access)
        {
            Name = name;
 	        if (access == AccessType.Item)
            {
                Value = int.Parse(value);
            }
            else
            {
                string[] values = value.Trim('{', '}').Split(',');
                List<int> data = new List<int>();
                for (int i = 0; i < values.Length; i++)
                {
                    data.Add(int.Parse(values[i]));
                }
                Value = data;
            }
        }
}

    public class BH_Double : Parameter
    {
        
        internal BH_Double() { }

        internal BH_Double(string name, double value) : base(name, AccessType.Item)
        {
            Value = value;
        }

        internal BH_Double(string name, List<double> value)
            : base(name, AccessType.List)
        {
            Value = value;
        }

        internal BH_Double(string name, string value, AccessType type)
        {
            Name = name;
            if (type == AccessType.Item)
            {
                Value = double.Parse(value);
            }
            else
            {
                string[] values = value.Trim('{', '}').Split(',');
                List<double> data = new List<double>();
                for (int i = 0; i < values.Length; i++)
                {
                    data.Add(double.Parse(values[i]));
                }
                Value = data;
            }
            Access = type;
        }

        public override string DataString()
        {
            switch (Access)
            {
                case AccessType.Item:
                    return Value.ToString();
                case AccessType.List:
                    string result = "{";
                    List<double> values = GetDataList<double>();
                    for (int i = 0; i < values.Count; i++)
                    {
                        result += values[i].ToString() + ",";
                    }
                    return result.Trim(',') + "}";
            }
            return "";
        }

        public override void SetData(string name, string value, AccessType access)
        {
            Name = name;
 	        
            if (access == AccessType.Item)
            {
                Value = double.Parse(value);
            }
            else
            {
                string[] values = value.Trim('{', '}').Split(',');
                List<double> data = new List<double>();
                for (int i = 0; i < values.Length; i++)
                {
                    data.Add(double.Parse(values[i]));
                }
                Value = data;
            }
        }
    }

    public class BH_String : Parameter
    {
        internal BH_String() { }

        internal BH_String(string name, List<string> value)
            : base(name, AccessType.List)
        {
            Value = value;
        }

        internal BH_String(string name, string value, AccessType type)
        {
            Name = name;
            if (type == AccessType.Item)
            {
                Value = value;
            }
            else
            {
                string[] values = value.Trim('{', '}').Split(',');
                Value = values.ToList();
            }
            Access = type;
        }

        public override string DataString()
        {
            switch (Access)
            {
                case AccessType.Item:
                    return Value.ToString();
                case AccessType.List:
                    string result = "{";
                    List<string> values = GetDataList<string>();
                    for (int i = 0; i < values.Count; i++)
                    {
                        result += values[i].ToString() + ",";
                    }
                    return result.Trim(',') + "}";
            }
            return "";
        }

        public override void SetData(string name, string value, AccessType access)
        {
            Name = name;
 	        
            if (access == AccessType.Item)
            {
                Value = value;
            }
            else
            {
                Value = value.Trim('{', '}').Split(',').ToList();               
            }
        }
    }

    public class BH_Guid : Parameter
    {
        internal BH_Guid() { } 

         internal BH_Guid(string name, List<Guid> value)
            : base(name, AccessType.List)
        {
            Value = value;
        }

        internal BH_Guid(string name, Guid id) : base(name, AccessType.Item)
        {
            Value = id;
        }

        internal BH_Guid(string name, string value, AccessType type)
            : base(name, type)
        {
            if (type == AccessType.Item)
            {
                Value = new Guid(value);
            }
            else
            {
                string[] values = value.Trim('{', '}').Split(',');
                List<Guid> data = new List<Guid>();
                for (int i = 0; i < values.Length; i++)
                {
                    data.Add(new Guid(values[i]));
                }
                Value = data;
            }
        }

        public override string DataString()
        {
            switch (Access)
            {
                case AccessType.Item:
                    return Value.ToString();
                case AccessType.List:
                    string result = "{";
                    List<Guid> values = GetDataList<Guid>();
                    for (int i = 0; i < values.Count; i++)
                    {
                        result += values[i].ToString() + ",";
                    }
                    return result.Trim(',') + "}";
            }
            return "";
        }

        public override void SetData(string name, string value, AccessType access)
        {
            Name = name;
 	        
            if (access == AccessType.Item)
            {
                Value = new Guid(value);
            }
            else
            {
                string[] values = value.Trim('{', '}').Split(',');
                List<Guid> data = new List<Guid>();
                for (int i = 0; i < values.Length; i++)
                {
                    data.Add(new Guid(values[i]));
                }
                Value = data;
            }
        }
    }
}
