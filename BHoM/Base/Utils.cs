using BHoM.Structural.Loads;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BHoM.Base;

namespace BHoM.Base
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

        public static T[] SubArray<T>(this T[] data, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }

        public static T[] Reverse<T>(this T[] data, int groupSize)
        {
            T[] result = new T[data.Length];
            int offset = result.Length;

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = data[offset - (i / groupSize) * groupSize - (groupSize - (i % groupSize))];
            }


            return result;
        }

        public static T[] Copy<T>(this T[] data)
        {
            if (data != null)
            {
                T[] result = new T[data.Length];
                Array.Copy(data, result, data.Length);
                return result;
            }
            return null;
        }

        public static T[] Merge<T>(T[] data1, T[] data2)
        {
            T[] result = new T[data1.Length + data2.Length];
            Array.Copy(data1, result, data1.Length);
            Array.Copy(data2, 0, result, data1.Length, data2.Length);
            return result;
        }

        public static T[] Merge<T>(params T[][] data)
        {
            int totalLength = 0;
            int accumLength = 0;
            for (int i = 0; i < data.Length; i++)
            {
                totalLength += data[i].Length;
            }
            T[] result = new T[totalLength];
            for (int i = 0; i < data.Length; i++)
            {
                Array.Copy(data[i], 0, result, accumLength, data[i].Length);
                accumLength += data[i].Length;
            }
            return result;
        }

        public static string CollectionToString(IEnumerable data)
        {
            string result = "[";
            foreach (object value in data)
            {
                result += value + ",";
            }
            return result.Trim(',') + "]";
        }

        public static bool InRange(double value, double upper, double lower, double tolerance)
        {
            return value < upper + tolerance && value > lower - tolerance;
        }

        public static bool InBetween(double value, double b1, double b2, double tolerance)
        {
            if (b1 > b2)
            {
                return InRange(value, b1, b2, tolerance);
            }
            else
            {
                return InRange(value, b2, b1, tolerance);
            }
        }

        public static bool NearEqual(double value1, double value2, double eps)
        {
            return value1 < value2 + eps && value1 > value2 - eps;
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

            public enum LoadUnit
            {
                kN_per_m2,
                kN,
                Pascals
            }
        }
    }
}

