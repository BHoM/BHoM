using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Common
{
    public static class Utils
    {
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

            for (int i = 0; i < result.Length;i++)
            {
                result[i] = data[offset - (i/groupSize) * groupSize - (groupSize - (i % groupSize))];
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


    }
}
