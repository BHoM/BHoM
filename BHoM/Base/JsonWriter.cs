using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Base
{
    public static class JSONWriter
    {
        public static string Write(object value, IList<string> tags = null)
        {
            if (value == null)
                return "null";
            else if (value is Boolean)
                return Write((bool)value);
            else if (value is Char)
                return Write((char)value);
            else if (value is int || value is Enum)
                return Write((int)value);
            else if (value is double)
                return Write((double)value);
            else if (value is Guid)
                return Write((Guid)value);
            else if (value is string)
                return Write((string)value);
            else if (value is IDictionary)
                return Write((IDictionary)value);
            else if (value is IList)
                return Write((IList)value);
            else
                return WriteObject(value, tags);
        }

        /**************************************/

        public static string Write(bool value)
        {
            return (value ? "true" : "false");
        }

        /**************************************/

        public static string Write(char value)
        {
            return "\"" + value + "\""; 
        }

        /**************************************/

        public static string Write(int value)
        {
            return value.ToString();
        }

        /**************************************/

        public static string Write(double value)
        {
            return value.ToString();
        }

        /**************************************/

        public static string Write(Guid value)
        {
            return "\"" + value + "\"";
        }

        /**************************************/

        public static string Write(string value)
        {
            return "\"" + value + "\"";
        }

        /**************************************/

        public static string Write(IDictionary collection)
        {
            string result = "{\"__Type__\":\"" + collection.GetType() + "\"";
            foreach (DictionaryEntry obj in collection as IDictionary)
            {
                result += "," + string.Format("\"{0}\": {1}", Write(obj.Key).Trim('"'), Write(obj.Value));
            }
            return result + "}";
        }

        /**************************************/

        public static string Write(IList collection)
        {
            string result = "[";
            foreach (object obj in collection)
            {
                result += Write(obj) + ",";
            }
            result = result.Trim(',');

            return result + "]";
        }

        /**************************************/
        /****  Private Methods             ****/
        /**************************************/

        private static string WriteObject(object obj, IList<string> tags = null)
        {
            // Handle null objects
            if (obj == null)
                return "null";

            // Write the type & tags
            string result = "{\"__Type__\":\"" + obj.GetType() + "\"";
            if (tags != null) result += "," + WriteTags(tags);

            // Write all the properties
            foreach (var prop in obj.GetType().GetProperties())
            {
                if (!prop.CanRead || !prop.CanWrite || prop.GetMethod.GetParameters().Count() > 0) continue;  //TODO: Need to sort out when property is of Type Item[]
                var value = prop.GetValue(obj, null);
                if (value != null)
                    result += "," + string.Format("\"{0}\": {1}", Write(prop.Name).Trim('"'), Write(value)); 
            }

            return result + "}";
        }


        /**************************************/

        private static string WriteTags(IList<string> tags)
        {
            string result = "\"__Tags__\":[";
            if (tags != null)
            {
                foreach (string tag in tags)
                    result += tag + ",";
            }
                
            return result.Trim(',') + "]";
        }
    }
}
