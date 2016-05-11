using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Global
{
    public static class Utils
    {
        public static List<T> IntToEnumList<T>(List<int> values)
        {
            List<T> result = new List<T>();
            for (int i = 0; i < values.Count; i++)
            {
                result.Add((T)Enum.ToObject(typeof(T), values[i]));
            }
            return result;
        }


        public static List<int> EnumToIntList<T>(List<T> values)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < values.Count; i++)
            {
                result.Add(Convert.ToInt32(values[i]));
            }
            return result;
        }

        internal static Dictionary<string, string> GetDefinitionFromJSON(string json)
        {
            int i0 = 0;
            int level = 0;
            string key = "";
            string value = "";
            string inside = json.Substring(json.IndexOf('{') + 1, json.LastIndexOf('}') - 1);

            Dictionary<string, string> definition = new Dictionary<string, string>();
            for (int i = 0; i < inside.Length; i++)
            {
                if (inside[i] == '{')
                    level++;
                else if (inside[i] == '}')
                    level--;
                else if (level == 0 && inside[i] == ':')
                {
                    key = inside.Substring(i0, i - i0).Trim().Replace("\"", "");
                    i0 = i + 1;
                }
                else if (level == 0 && inside[i] == ',')
                {
                    value = inside.Substring(i0, i - i0).Trim();
                    definition.Add(key, value);
                    i0 = i + 1;
                }
                if (i == inside.Length - 1)
                {
                    value = inside.Substring(i0, i + 1 - i0).Trim();
                    definition.Add(key, value);
                    i0 = i + 1;
                }
            }

            return definition;
        }

        internal static void ReadProperty(object obj, string propertyName, string value)
        {
            System.Reflection.PropertyInfo pInfo = obj.GetType().GetProperty(propertyName);
            if (pInfo == null) return;

            Type pType = pInfo.PropertyType;
            pInfo.SetValue(obj, ReadValue(pType, obj, value));        
        }

        internal static object ReadValue(Type type, object obj, string value)
        {
            if (type == typeof(System.String))
                return value;
            else if (type.BaseType == typeof(BHoMObject))
            {
                BHoMObject b = Project.ActiveProject.GetObject(new Guid(value));
                if (b == null)
                { 
                    Project.ActiveProject.AddTask(new Task());               
                }
                return b;
            }
            else if (IsEnumerableType(type))
            {
                return ReadCollection(type, value);
            }
            else
            {
                System.Reflection.MethodInfo jsonMethod = type.GetMethod("FromJSON");
                if (jsonMethod != null)
                    return jsonMethod.Invoke(obj, new object[] { value });
                else
                {
                    System.Reflection.MethodInfo parseMethod = type.GetMethod("Parse", new Type[] { typeof(string) });
                    if (parseMethod != null)
                        return parseMethod.Invoke(obj, new object[] { value });
                }
            }
            return null;
        }


        internal static IEnumerable ReadCollection(Type t, string data)
        {
            if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(List<>))
            {
                Type listType = t.GetGenericArguments()[0];
                var newList = typeof(List<>);
                var listOfType = newList.MakeGenericType(listType);
                IList list = Activator.CreateInstance(listOfType) as IList;
                foreach (var item in data.Trim(' ','[',']','{','}').Split(','))
                {
                    list.Add(ReadValue(listType, null, item));
                }
                return list;
            }
            else if (t.BaseType == typeof(System.Array))
            {
                string[] items = data.Trim(' ', '[', ']', '{', '}').Split(',');
                Array array = Activator.CreateInstance(t, items.Length) as Array;
                int index = 0;
                foreach (var item in items)
                {
                    array.SetValue(ReadValue(array.GetValue(0).GetType(), null, item), index++);
                }
                return array;
            }
            else if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Dictionary<,>))
            {
                Dictionary<string, string> items = GetDefinitionFromJSON(data);
                Type keyType = t.GetGenericArguments()[0];
                Type valueType = t.GetGenericArguments()[1];
                var newList = typeof(Dictionary<,>);
                var listOfType = newList.MakeGenericType(keyType, valueType);
                IDictionary list = Activator.CreateInstance(listOfType) as IDictionary;
                foreach (var item in items)
                {
                    list.Add(ReadValue(keyType, null, item.Key), ReadValue(valueType, null, item.Value));
                }
                return list;
            }
            return null;
        }

       internal static bool IsEnumerableType(Type type)
        {
            return (type.GetInterface("IEnumerable") != null);
        }

        internal static object WriteCollection(IEnumerable collection)
        {
            string aResult = "";
            if (typeof(IDictionary).IsAssignableFrom(collection.GetType()))
            {
                foreach (DictionaryEntry obj in collection as IDictionary)
                {
                    aResult += WriteProperty(WriteValue(obj.Key), obj.Value);
                }
            }
            else
            {
                foreach (object obj in collection)
                {
                    aResult += WriteValue(obj) +",";
                }
            }
            if (aResult.Length > 0 && aResult.Last() == ',')
                aResult = aResult.Substring(0, aResult.Length - 1);
            return aResult;
        }

        internal static string WriteProperty(string name, object value)
        {
            return string.Format("\"{0}\": {1},", name, WriteValue(value));        
        }

        internal static string WriteValue(object value)
        {
            string aResult = "";

            if (value is BHoMObject)
                aResult += "\"" + (value as BHoMObject).BHoM_Guid + "\"";
            else if (value.GetType().GetMethod("ToJSON") != null)
                aResult += value.GetType().GetMethod("ToJSON").Invoke(value, null);
            else if (value is System.Collections.IEnumerable && !(value is string))
                aResult += "{" + Utils.WriteCollection(value as System.Collections.IEnumerable) + "}";
            else
                aResult += value.ToString();
            return aResult;
        }
    }

    public static class Units
    {
        public enum LengthUnit
        {
            Millimetre,
            Centimetre,
            Metre,
            Kilometre,
            Inch,
            Foot,
            Yard
        }

        public enum TimeUnit
        {
            Millisecond,
            Second,
            Minute,
            Hour
        }

        public enum TemperatureUnit
        {
            Celsius,
            Kelvin,
            Fahrenheit
        }
    }
}
