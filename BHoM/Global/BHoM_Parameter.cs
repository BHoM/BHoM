using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Global
{
    public enum StorageType
    {
        Integer,
        Double,
        String,
        Id
    }

    public class Parameter
    {
        public string Name { get; private set; }
        public object Data { get; private set; }
        public StorageType DataType { get; private set; }

        public Parameter(string name, object value)
        {
            Name = name;
            Data = value;
            string type = value.GetType().ToString();
            switch (type)
            {
                case "System.Integer":
                    DataType = StorageType.Integer;
                    break;
                case "System.Double":
                    DataType = StorageType.Double;
                    break;
                case "System.String":
                    DataType = StorageType.String;
                    break;
                default:
                    DataType = StorageType.Id;
                    break;
            }
        }
        public Parameter(string name, double value)
        {
            Name = name;
            Data = value;
            DataType = StorageType.Double;
        }
        public Parameter(string name, int value)
        {
            Name = name;
            Data = value;
            DataType = StorageType.Integer;
        }
        public Parameter(string name, string value)
        {
            Name = name;
            Data = value;
            DataType = StorageType.String;
        }
        public Parameter(string name, Guid value)
        {
            Name = name;
            Data = value;
            DataType = StorageType.Id;
        }

        internal Parameter(string name, string value, string storage)
        {   
            Name = name;
            DataType = (StorageType)Enum.Parse(typeof(StorageType),  storage);
            SetValue(value);        
        }


        internal void SetValue(string value)
        {
            switch (DataType)
            {
                case StorageType.Double:
                    Data = double.Parse(value);
                    break;
                case StorageType.Integer:
                    Data = int.Parse(value);
                    break;
                case StorageType.String:
                    Data = value;
                    break;
                default:
                    Data = new Guid(value);
                    break;
            }
        }

        public T GetValue<T>()
        {
            return (T)Data;
        }

        public void SetValue(object value)
        {
            Data = value;
        }

        public override string ToString()
        {
            return "Name=\"" + Name + " Storage=\"" + Enum.GetName(typeof(StorageType), DataType) + "\" Value=\"" + Data.ToString();
        }
    }
}
