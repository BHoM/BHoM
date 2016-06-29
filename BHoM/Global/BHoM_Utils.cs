using BHoM.Structural.Loads;
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
            int index = 0;
            Dictionary<string, string> definition = new Dictionary<string, string>();
            for (int i = 0; i < inside.Length; i++)
            {
                if (inside[i] == '{' || inside[i] == '[')
                    level++;
                else if (inside[i] == '}' || inside[i] == ']')
                    level--;
                else if (level == 0 && inside[i] == ':')
                {
                    key = inside.Substring(i0, i - i0).Trim().Replace("\"", "");
                    i0 = i + 1;
                }
                else if (level == 0 && inside[i] == ',')
                {
                    value = inside.Substring(i0, i - i0).Trim();
                    definition.Add(key == "" ? index++.ToString() : key, value);
                    i0 = i + 1;
                }
                if (i == inside.Length - 1)
                {
                    value = inside.Substring(i0, i + 1 - i0).Trim();
                    definition.Add(key == "" ? index++.ToString() : key, value);
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
            object result = ReadValue(pType, value, obj);
            if (result == null && obj is BHoMObject)
            {
                Project.ActiveProject.AddTask(new Task(obj as BHoMObject, propertyName, value));
            }
            else
            {
                pInfo.SetValue(obj, result);
            }
        }

        internal static object ReadValue(Type type, string value, object obj = null)
        {
            System.Reflection.MethodInfo jsonMethod = null;
            if (type == typeof(System.String) || type == typeof(System.Object))
                return value;
            else if (type.BaseType == typeof(BHoMObject))
            {
                BHoMObject b = Project.ActiveProject.GetObject(new Guid(value));             
                return b;
            }
            else if ((jsonMethod = type.GetMethod("FromJSON")) != null)
            {
                return jsonMethod.Invoke(null, new object[] { value });
            }
            else if (IsEnumerableType(type))
            {
                return ReadCollection(type, value);
            }            
            else 
            {
                if (type.BaseType != null && (jsonMethod = type.BaseType.GetMethod("FromJSON")) != null)
                    return jsonMethod.Invoke(null, new object[] { value });
                else
                {
                    System.Reflection.MethodInfo parseMethod = type.GetMethod("Parse", new Type[] { typeof(string) });
                    if (parseMethod != null)
                        return parseMethod.Invoke(null, new object[] { value });
                    parseMethod = type.BaseType.GetMethod("Parse", new Type[] { typeof(Type), typeof(string) });
                    if (parseMethod != null)
                        return parseMethod.Invoke(null, new object[] { type, value });
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
                Dictionary<string, string> values = GetDefinitionFromJSON(data);

                foreach (var item in values.Values)
                {
                    list.Add(ReadValue(listType, item));
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
                    array.SetValue(ReadValue(array.GetValue(0).GetType(), item), index++);
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
                    list.Add(ReadValue(keyType, item.Key), ReadValue(valueType, item.Value));
                }
                return list;
            }
            else
            {

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
                aResult = aResult.Trim(',');
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
            else if (value is Boolean)
                aResult += ((bool)value ? "true" : "false");
            else if (value is Guid)
                aResult += "\"" + value + "\"";
            else
                aResult += value.ToString();
            return aResult;
        }


        internal static IEnumerable<T> GetObjectsFromGuid<T>(Project p, List<Guid> ids) where T : class 
        {
            List<T> objects = new List<T>();
            for (int i = 0; i < ids.Count; i++)
            {
                T obj = p.GetObject(ids[i]) as T;
                if (obj != null) objects.Add(obj);
                else ids.RemoveAt(i--);
            }
            return objects;
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
