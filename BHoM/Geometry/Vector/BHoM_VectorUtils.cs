using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Geometry
{
    public static class VectorUtils
    {
        internal const double ALLOWANCE = 0.00001;
        internal const int X = 0;
        internal const int Y = 1;
        internal const int Z = 2;
        internal const int W = 3;

        internal static bool Equal(double[] v1, double[] v2)
        {
            if (v1.Length != v2.Length) return false;

            for (int i = 0; i < v1.Length; i++)
            {
                if (v1[i] != v2[i]) return false;
            }
            return true;
        }

        internal static bool Equal(double[] v1, double[] v2, double epsilon)
        {
            if (v1.Length != v2.Length) return false;

            for (int i = 0; i < v1.Length; i++)
            {
                if (v1[i] > v2[i] + epsilon || v1[i] < v2[i] - epsilon) return false;
            }
            return true;
        }

        internal static double[] Max(double[] v1, double[] v2)
        {
            if (v1.Length != v2.Length) return null;

            double[] result = new double[v1.Length];

            for (int i = 0; i < v1.Length; i++)
            {
                result[i] = Math.Max(v1[i], v2[i]);
            }
            return result;
        }

        internal static double[] Min(double[] v1, double[] v2)
        {
            if (v1.Length != v2.Length) return null;

            double[] result = new double[v1.Length];

            for (int i = 0; i < v1.Length; i++)
            {
                result[i] = Math.Min(v1[i], v2[i]);
            }
            return result;
        }

        internal static double MinValue(double[] v)
        {
            double min = double.MaxValue;
            for (int i = 0; i < v.Length; i++)
            {
                min = Math.Min(v[i], min);
            }
            return min;
        }


        internal static double MaxValue(double[] v)
        {
            double max = double.MinValue;
            for (int i = 0; i < v.Length; i++)
            {
                max = Math.Max(v[i], max);
            }
            return max;
        }

        internal static int[] MaxMin(double[] v, int length)
        {
            int[] result = new int[(length * 2)];
            for (int i = 0; i < length * 2; i++) result[i] = i % length;

            for (int i = length; i < v.Length; i += length)
            {
                for (int j = 0; j < length; j++)
                {
                    if (v[i + j] > v[result[j]]) result[j] = i + j;
                    if (v[i + j] < v[result[j + length]]) result[j + length] = i + j;
                }
            }

            return result;
        }

        //internal static double[] AddMany(double[] v1, double[] v2)

        internal static double[] Splat(double value, int length)
        {
            double[] result = new double[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = value;
            }
            return result;
        }

        internal static void Add(double[] v1, double[] v2, double[] vOut)
        {
            for (int i = 0; i < v1.Length; i++)
            {
                vOut[i] = v1[i] + v2[i % v2.Length];
            }
        }

        internal static double[] Add(double[] v1, double[] v2)
        {
            if (v1.Length == v2.Length)
            {
                double[] result = new double[v1.Length];

                for (int i = 0; i < v1.Length; i++)
                {
                    result[i] = v1[i] + v2[i];
                }
                return result;
            }
            else
            {
                double[] vLong = v1.Length > v2.Length ? v1 : v2;
                double[] vShort = v1.Length > v2.Length ? v2 : v1;

                double[] result = new double[vLong.Length];
                for (int i = 0; i < vLong.Length; i++)
                {
                    result[i] = vLong[i] + vShort[i % vShort.Length];
                }
                return result;
            }
        }

        internal static double[] Add(double[] l, int i1, int i2, int dimension)
        {
            double[] result = new double[dimension];

            for (int i = 0; i < dimension; i++)
            {
                result[i] = l[i1 + i] + l[i2 + i];
            }
            return result;
        }

        internal static double[] Sub(double[] v1, double[] v2)
        {
            if (v1.Length == v2.Length)
            {
                double[] result = new double[v1.Length];

                for (int i = 0; i < v1.Length; i++)
                {
                    result[i] = v1[i] - v2[i];
                }
                return result;
            }
            else
            {
                int l1 = v1.Length;
                int l2 = v2.Length;

                double[] result = new double[Math.Max(l1, l2)];
                for (int i = 0; i < Math.Max(l1, l2); i++)
                {
                    result[i] = v1[i % l1] - v2[i % l2];
                }
                return result;
            }
        }

        internal static double[] Sub(double[] l, int i1, int i2, int dimension)
        {
            double[] result = new double[dimension];

            for (int i = 0; i < dimension; i++)
            {
                result[i] = l[i1 + i] - l[i2 + i];
            }
            return result;
        }

        internal static double[] Average(double[] v1, double[] v2)
        {
            if (v1.Length != v2.Length) return null;

            double[] result = new double[v1.Length];

            for (int i = 0; i < v1.Length; i++)
            {
                result[i] = (v1[i] + v2[i]) / 2;
            }
            return result;
        }

        internal static double[] Average(double[] l, int i1, int i2, int dimension)
        {
            double[] result = new double[dimension];

            for (int i = 0; i < dimension; i++)
            {
                result[i] = (l[i1 + i] + l[i2 + i]) / 2;
            }
            return result;
        }

        internal static double[] Multiply(double[] v1, double s)
        {
            double[] result = new double[v1.Length];

            for (int i = 0; i < v1.Length; i++)
            {
                result[i] = v1[i] * s;
            }
            return result;
        }

        internal static double[] Multiply(double[] v1, double s, int index, int length)
        {
            double[] result = new double[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = v1[i + index] * s;
            }
            return result;
        }

        internal static double[] Multiply(double[] v1, double[] v2)
        {
            double[] vLong = v1.Length > v2.Length ? v1 : v2;
            double[] vShort = v1.Length > v2.Length ? v2 : v1;

            double[] result = new double[vLong.Length];
            for (int i = 0; i < vLong.Length; i++)
            {
                result[i] = vLong[i] * vShort[i % vShort.Length];
            }
            return result;
        }


        internal static double[] Multiply(double[] v1, int segment1, double[] v2, int segment2)
        {
            int size = Math.Min(v1.Length * segment1, v2.Length * segment2);
            double[] result = new double[size];

            for (int i = 0; i < size; i++)
            {
                result[i] = v1[i / segment1] * v2[i / segment2];
            }
            return result;
        }

        internal static double[] Multiply(double[][] m, double[] v)
        {
            double[] result = new double[v.Length];
            for (int i = 0; i < m.Length; i++)
            {
                result[i] = DotProduct(m[i], v);
            }
            return result;
        }



        internal static double[] MultiplyMany(double[][] m, double[] v)
        {
            double[] result = new double[v.Length];
            int mLength = m.Length;
            for (int i = 0; i < v.Length; i++)
            {
                result[i] = DotProduct(m[i % mLength], v, (i / mLength) * mLength, mLength);
            }
            return result;
        }

        internal static double[][] Transpose(double[][] m)
        {
            double[][] transpose = new double[m.Length][];

            for (int i = 0; i < m.Length; i++)
            {
                transpose[i] = new double[m.Length];
                for (int j = 0; j < m.Length; j++)
                {
                    transpose[i][j] = m[j][i];
                }
            }
            return transpose;
        }

        internal static double[][] Multiply(double[][] m1, double[][] m2)
        {
            if (m1[0].Length != m2.Length) return null;

            double[][] result = new double[m1.Length][];
            double[][] mTranspose = Transpose(m2);

            for (int i = 0; i < result.Length; i++)
            {
                double[] row = new double[mTranspose.Length];
                for (int j = 0; j < row.Length; j++)
                {
                    row[j] = DotProduct(m1[i], mTranspose[j]);
                }
                result[i] = row;
            }
            return result;
        }

        internal static double Sum(double[] v1)
        {
            double result = 0;

            for (int i = 0; i < v1.Length; i++)
            {
                result += v1[i];
            }
            return result;
        }

        internal static double[] Sum(double[] v1, int segments)
        {
            double[] result = new double[v1.Length / segments];

            for (int i = 0; i < v1.Length; i++)
            {
                result[i / segments] += v1[i];
            }
            return result;
        }

        internal static double[] Divide(double[] v1, double s)
        {
            double[] result = new double[v1.Length];

            for (int i = 0; i < v1.Length; i++)
            {
                result[i] = v1[i] / s;
            }
            return result;
        }

        public static double[] CrossProduct(double[] v1, double[] v2)
        {
            return new double[] {
                v1[1] * v2[2] - v1[2] * v2[1],
                v1[2] * v2[0] - v1[0] * v2[2],
                v1[0] * v2[1] - v1[1] * v2[0],
                0
            };
        }

        internal static double LengthSq(double[] v)
        {
            double result = 0;

            for (int i = 0; i < v.Length; i++)
            {
                result += v[i] * v[i];
            }
            return result;
        }

        internal static double Length(double[] v)
        {
            return Math.Sqrt(LengthSq(v));
        }

        internal static double[] DotProduct(double[] v1, double[] v2, int length)
        {
            double[] vLong = v1.Length > v2.Length ? v1 : v2;
            double[] vShort = v1.Length > v2.Length ? v2 : v1;

            int resultLength = vLong.Length / length;

            double[] result = new double[resultLength];
            for (int i = 0; i < resultLength; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    result[i] += vLong[i * length + j] * vShort[j];
                }
            }
            return result;
        }

        internal static double DotProduct(double[] v1, double[] v2)
        {
            if (v1.Length != v2.Length) return 0;

            double result = 0;

            for (int i = 0; i < v1.Length; i++)
            {
                result += v1[i] * v2[i];
            }
            return result;
        }

        internal static double[] Intersect(double[] s1, double[] v1, double[] s2, double[] v2, bool bound)
        {
            int a1 = 0;
            int a2 = 1;

            if (v1[a1] == 0 && v2[a1] == 0) a1++;
            if (v1[a2] == 0 && v2[a2] == 0) a2++;

            double[] rhs = VectorUtils.Sub(s2, s1);
            int tries = 0;
            while (tries++ < 2)
            {
                double multiplier = v1[a1] / v1[a2];

                if (!double.IsInfinity(multiplier))
                {
                    double t = (rhs[a2] * multiplier - rhs[a1]) / (v2[a1] - v2[a2] * multiplier);
                    return double.IsNaN(t) || bound && (t > 1 || t < 0) ? null : VectorUtils.Add(s2, VectorUtils.Multiply(v2, t));
                }
                else
                {
                    int temp = a2;
                    a2 = a1;
                    a1 = temp;
                }
            }
            return null;
        }

        internal static double[] Intersect(double[] s1, double[] v1, double[] s2, double[] v2)
        {
            int a1 = 0;
            int a2 = 1;

            if (v1[a1] == 0 && v2[a1] == 0) a1++;
            if (v1[a2] == 0 && v2[a2] == 0) a2++;

            double[] rhs = VectorUtils.Sub(s2, s1);
            int tries = 0;
            while (tries++ < 2)
            {
                double multiplier = v1[a1] / v1[a2];

                if (!double.IsInfinity(multiplier))
                {
                    double t = (rhs[a2] * multiplier - rhs[a1]) / (v2[a1] - v2[a2] * multiplier);
                    return VectorUtils.Add(s2, VectorUtils.Multiply(v2, t));
                }
                else
                {
                    int temp = a2;
                    a2 = a1;
                    a1 = temp;
                }
            }
            return null;
        }

        internal static double DotProduct(double[] row, double[] vector, int index, int length)
        {
            double result = 0;

            for (int i = 0; i < length; i++)
            {
                result += row[i] * vector[i + index];
            }
            return result;
        }

        internal static double Angle(double[] v1, double[] v2)
        {
            double dotProduct = DotProduct(v1, v2);
            double length = Length(v1) * Length(v2);

            return dotProduct< length ? Math.Acos(dotProduct / length) : 0;
        }

        internal static double[] Normalise(double[] m_Coordinates)
        {
            double length = VectorUtils.Length(m_Coordinates);
            if (length == 1) return m_Coordinates;

            double[] result = new double[m_Coordinates.Length];

            for (int i = 0; i < m_Coordinates.Length; i++)
            {
                result[i] = m_Coordinates[i] / length;
            }
            return result;
        }

        internal static int Parallel(double[] v1, double[] v2, double epsilion)
        {
            double angle = VectorUtils.Angle(v1, v2);

            return angle > Math.PI / 2 ? Math.PI - angle <= epsilion ? -1 : 0 : angle <= epsilion ? 1 : 0;
        }

    }
}
