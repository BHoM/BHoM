using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Geometry
{
    [Serializable]
    public class TransformMatrix
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double[,] Matrix { get; set; } = new double[4, 4];


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public TransformMatrix() { }

        /***************************************************/

        public TransformMatrix(double[,] matrix)
        {
            Matrix = matrix;
        }


        /***************************************************/
        /**** Static special cases                      ****/
        /***************************************************/

        public static readonly TransformMatrix Zero = new TransformMatrix(new double[4, 4]);

        /***************************************************/

        public static readonly TransformMatrix Identify = new TransformMatrix(new double[4, 4]
        {
            { 1, 0, 0, 0 },
            { 0, 1, 0, 0 },
            { 0, 0, 1, 0 },
            { 0, 0, 0, 1 }
        });


        /***************************************************/
        /**** Static Operators Override                 ****/
        /***************************************************/

        public static TransformMatrix operator +(TransformMatrix t1, TransformMatrix t2)
        {
            double[,] m1 = t1.Matrix;
            double[,] m2 = t2.Matrix;
            const int s = 4;

            double[,] result = new double[s, s];

            for (int i = 0; i < s; i++)
            {
                for (int j = 0; j < s; j++)
                {
                    result[i, j] += m1[i, j] + m2[i, j];
                }
            }

            return new TransformMatrix(result);
        }


        /***************************************************/

        public static TransformMatrix operator +(TransformMatrix t1, double d)
        {
            double[,] m1 = t1.Matrix;
            const int s = 4;

            double[,] result = new double[s, s];

            for (int i = 0; i < s; i++)
            {
                for (int j = 0; j < s; j++)
                {
                    result[i, j] += m1[i, j] + d;
                }
            }

            return new TransformMatrix(result);
        }

        /***************************************************/

        public static TransformMatrix operator *(TransformMatrix t1, TransformMatrix t2)
        {
            double[,] m1 = t1.Matrix;
            double[,] m2 = t2.Matrix;
            const int s = 4;

            double[,] result = new double[s, s];

            for (int i = 0; i < s; i++)
            {
                for (int j = 0; j < s; j++)
                {
                    for (int k = 0; k < s; k++)
                        result[i, j] += m1[i, k] * m2[k, j];
                }
            }

            return new TransformMatrix(result);
        }

        /***************************************************/

        public static TransformMatrix operator *(TransformMatrix t1, double d)
        {
            double[,] m1 = t1.Matrix;
            const int s = 4;

            double[,] result = new double[s, s];

            for (int i = 0; i < s; i++)
            {
                for (int j = 0; j < s; j++)
                {
                    result[i, j] += m1[i, j] * d;
                }
            }

            return new TransformMatrix(result);
        }

        /***************************************************/

        public static TransformMatrix operator /(TransformMatrix t1, double d)
        {
            double[,] m1 = t1.Matrix;
            const int s = 4;

            double[,] result = new double[s, s];

            for (int i = 0; i < s; i++)
            {
                for (int j = 0; j < s; j++)
                {
                    result[i, j] += m1[i, j] / d;
                }
            }

            return new TransformMatrix(result);
        }


        /***************************************************/


    }
}
