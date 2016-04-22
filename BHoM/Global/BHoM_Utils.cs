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
