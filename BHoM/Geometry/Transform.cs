using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Geometry
{
    public class Transform
    {
        private double[][] m_Matrix;

        private Transform(double[][] m)
        {
            m_Matrix = m;
        }

        internal Transform(Quarternion q)
        {
            m_Matrix = new double[][]
            {
                new double[] {  1 - 2*Math.Pow(q.Y,2) - 2*Math.Pow(q.Z, 2), 2 * q.X*q.Y - 2 * q.W*q.Z, 2 * q.X*q.Z + 2 * q.Y*q.W,   0   },
                new double[] {  2 * q.X*q.Y + 2 * q.W*q.Z,  1 - 2*Math.Pow(q.X,2) - 2*Math.Pow(q.Z, 2), 2 * q.Y*q.Z - 2 * q.W*q.X,  0   },
                new double[] {  2 * q.X*q.Z - 2 * q.W*q.Y,  2 * q.Y*q.Z + 2 * q.W*q.X,  1 - 2*Math.Pow(q.X,2) - 2*Math.Pow(q.Y, 2), 0   },
                new double[] {  0,                          0,                          0,                                          1   }
            };
        }
        /// <summary>
        /// Creates a new Rotational Transformation
        /// </summary>
        /// <param name="centre">Centre of rotation</param>
        /// <param name="axis">Axis of rotation</param>
        /// <param name="angle">Rotation angle</param>
        /// <returns>A new instance of a rotation matrix</returns>
        public static Transform Rotation(Point centre, Vector axis, double angle)
        {
            Transform rotation = new Transform(Quarternion.QuaternionRotationNormal(axis, angle));
            Transform t1 = Translation(centre - Point.Origin);
            Transform t2 = Translation(Point.Origin - centre);

            return t1 * rotation * t2;
        }
        /// <summary>
        /// Creates a new Translation Transformation
        /// </summary>
        /// <param name="vector"></param>
        /// <returns>A new instance of a Translation matrix</returns>
        public static Transform Translation(Vector vector)
        {
            return new Transform(new double[][]
            {
                new double[] {  1,  0,  0,  vector.X   },
                new double[] {  0,  1,  0,  vector.Y   },
                new double[] {  0,  0,  1,  vector.Z   },
                new double[] {  0,  0,  0,  1   }
            });
        }
        /// <summary>
        /// Create a new Indentity transformation
        /// </summary>
        /// <returns>An identity matrix</returns>
        public static Transform Identity()
        {
            return new Transform(new double[][]
             {
                new double[] {  1,  0,  0,  0   },
                new double[] {  0,  1,  0,  0   },
                new double[] {  0,  0,  1,  0   },
                new double[] {  0,  0,  0,  1   }
             });
        }

        public static Transform Scale(Point about, Vector scale)
        {
            return null;
        }


        public Transform Scale(double value)
        {
            for (int i = 0; i < m_Matrix.Length;i++)
            {
                m_Matrix[i] = VectorUtils.Multiply(m_Matrix[i], value);
            }
            return this;
        }

        public static implicit operator double[][] (Transform t)
        {
            return t.m_Matrix;
        }

        public Vector Multiply(Vector v)
        {
            return this * v;
        }
        /// <summary>
        /// Inverse
        /// </summary>
        /// <returns>Transform Inserves</returns>
        public Transform Inverse()
        {
            double[][] m = m_Matrix;
            double[][] mNew = new double[4][];

            mNew[0] = new double[]
            {
                m[1][2] * m[2][3] * m[3][1] - m[1][3] * m[2][2] * m[3][1] + m[1][3] * m[2][1] * m[3][2] - m[1][1] * m[2][3] * m[3][2] - m[1][2] * m[2][1] * m[3][3] + m[1][1] * m[2][2] * m[3][3],
                m[0][3] * m[2][2] * m[3][1] - m[0][2] * m[2][3] * m[3][1] - m[0][3] * m[2][1] * m[3][2] + m[0][1] * m[2][3] * m[3][2] + m[0][2] * m[2][1] * m[3][3] - m[0][1] * m[2][2] * m[3][3],
                m[0][2] * m[1][3] * m[3][1] - m[0][3] * m[1][2] * m[3][1] + m[0][3] * m[1][1] * m[3][2] - m[0][1] * m[1][3] * m[3][2] - m[0][2] * m[1][1] * m[3][3] + m[0][1] * m[1][2] * m[3][3],
                m[0][3] * m[1][2] * m[2][1] - m[0][2] * m[1][3] * m[2][1] - m[0][3] * m[1][1] * m[2][2] + m[0][1] * m[1][3] * m[2][2] + m[0][2] * m[1][1] * m[2][3] - m[0][1] * m[1][2] * m[2][3]
            };
            mNew[1] = new double[]
            {
                m[1][3] * m[2][2] * m[3][0] - m[1][2] * m[2][3] * m[3][0] - m[1][3] * m[2][0] * m[3][2] + m[1][0] * m[2][3] * m[3][2] + m[1][2] * m[2][0] * m[3][3] - m[1][0] * m[2][2] * m[3][3],
                m[0][2] * m[2][3] * m[3][0] - m[0][3] * m[2][2] * m[3][0] + m[0][3] * m[2][0] * m[3][2] - m[0][0] * m[2][3] * m[3][2] - m[0][2] * m[2][0] * m[3][3] + m[0][0] * m[2][2] * m[3][3],
                m[0][3] * m[1][2] * m[3][0] - m[0][2] * m[1][3] * m[3][0] - m[0][3] * m[1][0] * m[3][2] + m[0][0] * m[1][3] * m[3][2] + m[0][2] * m[1][0] * m[3][3] - m[0][0] * m[1][2] * m[3][3],
                m[0][2] * m[1][3] * m[2][0] - m[0][3] * m[1][2] * m[2][0] + m[0][3] * m[1][0] * m[2][2] - m[0][0] * m[1][3] * m[2][2] - m[0][2] * m[1][0] * m[2][3] + m[0][0] * m[1][2] * m[2][3]
            };
            mNew[2] = new double[]
            {
                m[1][1] * m[2][3] * m[3][0] - m[1][3] * m[2][1] * m[3][0] + m[1][3] * m[2][0] * m[3][1] - m[1][0] * m[2][3] * m[3][1] - m[1][1] * m[2][0] * m[3][3] + m[1][0] * m[2][1] * m[3][3],
                m[0][3] * m[2][1] * m[3][0] - m[0][1] * m[2][3] * m[3][0] - m[0][3] * m[2][0] * m[3][1] + m[0][0] * m[2][3] * m[3][1] + m[0][1] * m[2][0] * m[3][3] - m[0][0] * m[2][1] * m[3][3],
                m[0][1] * m[1][3] * m[3][0] - m[0][3] * m[1][1] * m[3][0] + m[0][3] * m[1][0] * m[3][1] - m[0][0] * m[1][3] * m[3][1] - m[0][1] * m[1][0] * m[3][3] + m[0][0] * m[1][1] * m[3][3],
                m[0][3] * m[1][1] * m[2][0] - m[0][1] * m[1][3] * m[2][0] - m[0][3] * m[1][0] * m[2][1] + m[0][0] * m[1][3] * m[2][1] + m[0][1] * m[1][0] * m[2][3] - m[0][0] * m[1][1] * m[2][3]
            };
            mNew[3] = new double[]
            {
                m[1][2] * m[2][1] * m[3][0] - m[1][1] * m[2][2] * m[3][0] - m[1][2] * m[2][0] * m[3][1] + m[1][0] * m[2][2] * m[3][1] + m[1][1] * m[2][0] * m[3][2] - m[1][0] * m[2][1] * m[3][2],
                m[0][1] * m[2][2] * m[3][0] - m[0][2] * m[2][1] * m[3][0] + m[0][2] * m[2][0] * m[3][1] - m[0][0] * m[2][2] * m[3][1] - m[0][1] * m[2][0] * m[3][2] + m[0][0] * m[2][1] * m[3][2],
                m[0][2] * m[1][1] * m[3][0] - m[0][1] * m[1][2] * m[3][0] - m[0][2] * m[1][0] * m[3][1] + m[0][0] * m[1][2] * m[3][1] + m[0][1] * m[1][0] * m[3][2] - m[0][0] * m[1][1] * m[3][2],
                m[0][1] * m[1][2] * m[2][0] - m[0][2] * m[1][1] * m[2][0] + m[0][2] * m[1][0] * m[2][1] - m[0][0] * m[1][2] * m[2][1] - m[0][1] * m[1][0] * m[2][2] + m[0][0] * m[1][1] * m[2][2]
            };
            return new Transform(mNew).Scale(1 / Determinant());
        }
        /// <summary>
        /// Determinant
        /// </summary>
        /// <returns>The Determinant of the Transform<returns>
        public double Determinant()
        {
            double[][] m = m_Matrix;
            double value;
            value =
            m[0][3] * m[1][2] * m[2][1] * m[3][0] - m[0][2] * m[1][3] * m[2][1] * m[3][0] - m[0][3] * m[1][1] * m[2][2] * m[3][0] + m[0][1] * m[1][3] * m[2][2] * m[3][0] +
            m[0][2] * m[1][1] * m[2][3] * m[3][0] - m[0][1] * m[1][2] * m[2][3] * m[3][0] - m[0][3] * m[1][2] * m[2][0] * m[3][1] + m[0][2] * m[1][3] * m[2][0] * m[3][1] +
            m[0][3] * m[1][0] * m[2][2] * m[3][1] - m[0][0] * m[1][3] * m[2][2] * m[3][1] - m[0][2] * m[1][0] * m[2][3] * m[3][1] + m[0][0] * m[1][2] * m[2][3] * m[3][1] +
            m[0][3] * m[1][1] * m[2][0] * m[3][2] - m[0][1] * m[1][3] * m[2][0] * m[3][2] - m[0][3] * m[1][0] * m[2][1] * m[3][2] + m[0][0] * m[1][3] * m[2][1] * m[3][2] +
            m[0][1] * m[1][0] * m[2][3] * m[3][2] - m[0][0] * m[1][1] * m[2][3] * m[3][2] - m[0][2] * m[1][1] * m[2][0] * m[3][3] + m[0][1] * m[1][2] * m[2][0] * m[3][3] +
            m[0][2] * m[1][0] * m[2][1] * m[3][3] - m[0][0] * m[1][2] * m[2][1] * m[3][3] - m[0][1] * m[1][0] * m[2][2] * m[3][3] + m[0][0] * m[1][1] * m[2][2] * m[3][3];
            return value;
        }
        /// <summary>
        /// Matrix Transpose
        /// </summary>
        /// <returns>The transpose matrix of the current Transfrom</returns>
        public Transform Transpose()
        {
            double[][] transpose = new double[m_Matrix[0].Length][];

            for (int i = 0; i < m_Matrix[0].Length; i++)
            {
                transpose[i] = new double[m_Matrix.Length];
                for (int j = 0; j < m_Matrix.Length; j++)
                {
                    transpose[i][j] = m_Matrix[j][i];
                }
            }
            return new Transform(transpose);
        }

        /// <summary>
        /// Transform operations
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Transform operator *(Transform a, Transform b)
        {
            return new Transform(VectorUtils.Multiply(a, b));
        }

        /// <summary>
        /// Transform operations
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector operator *(Transform a, Vector b)
        {
            return new Vector(VectorUtils.Multiply(a, b));
        }

        /// <summary>
        /// Transform operations
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Point operator *(Transform a, Point b)
        {
            return new Point(VectorUtils.Multiply(a, b));
        }
    }
}
