using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BHoM.Base;
using BHoM.Global;
using System.Reflection;

namespace BHoM.Base
{
    public static class BHoMJSON
    {

        /**************************************/
        /****  Self Contained Collection   ****/
        /**************************************/

        public static string WritePackage(List<BHoMObject> objects, string password = "")
        {
            // Write Collection type
            Type type = typeof(List<BHoMObject>);
            string aResult = "{";
            aResult += string.Format("\"{0}\": {1}", "Type", "\"" + type + "\"");
            aResult += string.Format(",\"{0}\": {1}", "Primitive", "\"" + type.AssemblyQualifiedName.Replace(",", ";") + "\"");

            // Write all the dependencies
            Dictionary<Guid, BHoMObject> dependencies = new Dictionary<Guid, BHoMObject>();
            foreach (BHoMObject bhomObject in objects)
            {
                foreach (KeyValuePair<Guid, BHoMObject> kvp in bhomObject.GetDeepDependencies())
                {
                    if (!dependencies.ContainsKey(kvp.Key))
                        dependencies[kvp.Key] = kvp.Value;
                }
            }
            aResult += ",\"Dependencies\": [";
            foreach (BHoMObject obj in dependencies.Values)
                aResult += obj.ToJSON() + ",";
            aResult = aResult.Trim(',');
            aResult += "]";

            // Write all the contained objects
            aResult += ",\"Objects\": [";
            foreach (var value in objects)
            {
                aResult += value.ToJSON() + ",";
            }
            aResult = aResult.Trim(',');
            aResult += "]}";

            if (password.Length > 0)
                return Cipher.Encrypt(Compress.Zip(aResult), password);
            else
                return aResult;
        }

        /**************************************/

        public static List<BHoMObject> ReadPackage(string package, string password = "")
        {
            string json = package;
            if (password.Length > 0)
                json = Compress.Unzip(Cipher.Decrypt(package, password));

            Project project = new Project();
            Dictionary<string, string> definition = BHoMJSON.GetDefinitionFromJSON(json);

            // Try to create an object that correponds the object type stored in "Primitive"
            var typeString = definition["Type"].Replace("\"", "").Replace("{", "").Replace("}", "");
            if (typeString != typeof(List<BHoMObject>).ToString() && typeString != typeof(Project).ToString()) return null;

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

            return objects;
        }


        /**************************************/
        /****  Various Collections         ****/
        /**************************************/

        public static object WriteCollection(IEnumerable collection)
        {
            string aResult = "";
            if (typeof(IDictionary).IsAssignableFrom(collection.GetType()))
            {
                aResult += "{";
                foreach (DictionaryEntry obj in collection as IDictionary)
                {
                    aResult += WriteProperty(WriteValue(obj.Key).Trim('"'), obj.Value) + ',';
                }
                aResult = aResult.Trim(',');
                aResult += "}";
            }
            else
            {
                aResult += "[";
                foreach (object obj in collection)
                {
                    aResult += WriteValue(obj) + ",";
                }
                aResult = aResult.Trim(',');
                aResult += "]";
            }

            return aResult;
        }

        /**************************************/

        public static IEnumerable ReadCollection(Type t, string data, Project project)
        {
            if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(List<>))
            {
                Type listType = t.GetGenericArguments()[0];
                var newList = typeof(List<>);
                var listOfType = newList.MakeGenericType(listType);
                IList list = Activator.CreateInstance(listOfType) as IList;
                // Dictionary<string, string> values = GetDefinitionFromJSON(data);
                List<string> items = GetArrayFromJSON(data);

                foreach (var item in items)
                {
                    try
                    {
                        list.Add(ReadValue(listType, item, project));
                    }
                    catch (Exception ex)
                    {

                    }
                }
                return list;
            }
            else if (t.BaseType == typeof(System.Array))
            {
                //string[] items = data.Trim(' ', '[', ']').Split(',');
                int i0 = data.IndexOf('[') + 1;
                string[] items = data.Substring(i0, data.LastIndexOf(']') - i0).Split(',');
                Array array = Activator.CreateInstance(t, items.Length) as Array;
                int index = 0;
                foreach (var item in items)
                {
                    array.SetValue(ReadValue(array.GetValue(0).GetType(), item, project), index++);
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
                    list.Add(ReadValue(keyType, item.Key, project), ReadValue(valueType, item.Value, project));
                }
                return list;
            }
            else
            {

            }
            return null;
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


        /**************************************/
        /****  Properties and Values       ****/
        /**************************************/

        public static string WriteProperty(string name, object value)
        {
            return string.Format("\"{0}\": {1}", name, WriteValue(value));
        }

        /**************************************/

        public static string WriteValue(object value)
        {
            string aResult = "";

            if (value is BHoMObject)
                aResult += "\"" + (value as BHoMObject).BHoM_Guid + "\"";
            else if (value.GetType().GetMethod("ToJSON") != null)
                aResult += value.GetType().GetMethod("ToJSON").Invoke(value, null);
            else if (value is System.Collections.IEnumerable && !(value is string))
                aResult += WriteCollection(value as System.Collections.IEnumerable);
            else if (value is Boolean)
                aResult += ((bool)value ? "true" : "false");
            else if (value is Guid)
                aResult += "\"" + value + "\"";
            else if (value is string)
                aResult += "\"" + value + "\"";
            else if (value is Enum)
                aResult += (int)value;
            else
                aResult += value.ToString();
            return aResult;
        }

        /**************************************/

        public static void ReadProperty(object obj, string propertyName, string value, Project project)
        {
            System.Reflection.PropertyInfo pInfo = obj.GetType().GetProperty(propertyName);
            if (pInfo == null) return;

            Type pType = pInfo.PropertyType;
            object result = ReadValue(pType, value, project);
            if (result == null && obj is BHoMObject)
            {
                project.AddTask(new Task(obj as BHoMObject, propertyName, value));
            }
            else
            {
                pInfo.SetValue(obj, result);
            }
        }

        /**************************************/

        public static object ReadValue(Type type, string value, Project project = null)
        {
            if (project == null)
                project = Project.ActiveProject;

            System.Reflection.MethodInfo jsonMethod = null;
            if (type == typeof(System.String) || type == typeof(System.Object))
                return value;
            else if (type.BaseType == typeof(BHoMObject))
            {
                BHoMObject b = project.GetObject(new Guid(value));
                return b;
            }
            else if ((jsonMethod = type.GetMethod("FromJSON")) != null)
            {
                return jsonMethod.Invoke(null, new object[] { value, project });
            }
            else if (IsEnumerableType(type))
            {
                return ReadCollection(type, value, project);
            }
            else
            {
                if (type.BaseType != null && (jsonMethod = type.BaseType.GetMethod("FromJSON")) != null)
                    return jsonMethod.Invoke(null, new object[] { value, project });
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
        /****  Utility Stuff               ****/
        /**************************************/


        private static bool IsEnumerableType(Type type)
        {
            return (type.GetInterface("IEnumerable") != null);
        }

        /**************************************/

        public static IEnumerable<T> GetObjectsFromGuid<T>(Project p, List<Guid> ids) where T : class
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
}
