using System;
using System.Collections.Generic;
using System.Linq;
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
            }

            return definition;
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
