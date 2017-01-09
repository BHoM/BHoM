using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHoM.Global;
using System.Reflection;

namespace BHoM.Base
{
    public static class JsonReader
    {
        public static bool ReadBool(string json)
        {
            return Boolean.Parse(json);
        }

        /**************************************/

        public static char ReadChar(string json)
        {
            return Char.Parse(json);
        }

        /**************************************/

        public static int ReadInt(string json)
        {
            return Int32.Parse(json);
        }

        /**************************************/

        public static double ReadDouble(string json)
        {
            return Double.Parse(json);
        }

        /**************************************/

        public static Guid ReadGuid(string json)
        {
            return Guid.Parse(json);
        }

        /**************************************/

        public static object ReadObject(string json)
        {
            char[] toTrim = { ' ', '\"' };

            if (!json.StartsWith("{"))
                return json;

            // Get definition and type name
            Dictionary<string, string> def = GetDefinitionFromJSON(json);
            string typeName = "";
            if (!def.TryGetValue("__Type__", out typeName)) return null;
            typeName = typeName.Trim(toTrim);

            // Process separately if this is a dictionary
            if (typeName.StartsWith("System.Collections.Generic.Dictionary"))
                return ReadDictionary(def);

            // Create the object
            Type type = TypeDictionary.GetType(typeName);
            if (type == null) return null;
            object newObject = Activator.CreateInstance(type, true);

            // Set the properties
            foreach (KeyValuePair<string, string> kvp in def)
            {
                string propString = kvp.Key.Trim(toTrim);
                string valueString = kvp.Value.Trim(toTrim);
                if (propString.StartsWith("__")) continue;

                PropertyInfo pInfo = newObject.GetType().GetProperty(propString);
                if (pInfo != null)
                {
                    var val = ReadValue(pInfo.PropertyType, valueString);
                    if (val != null)
                        pInfo.SetValue(newObject, val);
                } 
            }

            return newObject;
        }

        /**************************************/
        /****  Private Methods             ****/
        /**************************************/

        private static object ReadValue(Type type, string json)
        {
            MethodInfo parseMethod = type.GetMethod("Parse", new Type[] { typeof(string) });

            if (type == typeof(string))
                return json;
            else if (type.IsValueType && parseMethod != null)
                return parseMethod.Invoke(null, new object[] { json });
            else if (type.IsEnum)
                return Enum.Parse(type, json);
            else if (type.GetInterface("IList") != null)
                return ReadCollection(type, json);
            else
                return ReadObject(json);
        }

        /**************************************/

        private static IList ReadCollection(Type type, string json)
        {
            List<String> jsonList = GetArrayFromJSON(json);

            Type itemType = type.GetElementType();
            IList collection = Activator.CreateInstance(type, jsonList.Count) as IList;

            for (int i = 0; i < jsonList.Count; i++)
                collection[i] = (ReadValue(itemType, jsonList[i]));

            return collection;
        }

        /**************************************/

        private static IDictionary ReadDictionary(Dictionary<string, string> def)
        {
            char[] toTrim = { ' ', '\"' };

            Type dicType = System.Type.GetType(def["__Type__"].Trim(toTrim));
            Type keyType = dicType.GetGenericArguments()[0];
            Type valueType = dicType.GetGenericArguments()[1];
            IDictionary collection = Activator.CreateInstance(dicType) as IDictionary;

            foreach (KeyValuePair<string, string> kvp in def)
            {
                string keyString = kvp.Key.Trim(toTrim);
                string valueString = kvp.Value.Trim(toTrim);
                if (keyString.StartsWith("_")) continue;

                collection.Add(ReadValue(keyType, keyString), ReadValue(valueType, valueString));
            }
            return collection;
        }


        /**************************************/
        /****  Utility Stuff               ****/
        /**************************************/

        public static Dictionary<string, string> GetDefinitionFromJSON(string json)
        {
            int level = 0;
            string key = "";
            string value = "";
            int i0 = json.IndexOf('{') + 1;
            string inside = json.Substring(i0, json.LastIndexOf('}') - i0);
            i0 = 0;
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

        /**************************************/

        public static List<String> GetArrayFromJSON(string json)
        {
            int level = 0;
            int i0 = json.IndexOf('[') + 1;
            string inside = json.Substring(i0, json.LastIndexOf(']') - i0);
            i0 = 0;
            int index = 0;
            List<string> array = new List<string>();
            for (int i = 0; i < inside.Length; i++)
            {
                if (inside[i] == '{' || inside[i] == '[')
                    level++;
                else if (inside[i] == '}' || inside[i] == ']')
                    level--;
                else if (level == 0 && inside[i] == ',')
                {
                    array.Add(inside.Substring(i0, i - i0).Trim());
                    i0 = i + 1;
                }
                if (i == inside.Length - 1)
                {
                    array.Add(inside.Substring(i0, i + 1 - i0).Trim());
                    i0 = i + 1;
                }
            }

            return array;
        }

    }
}
