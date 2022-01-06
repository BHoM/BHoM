/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2022, the respective contributors. All rights reserved.
 *
 * Each contributor holds copyright over their respective contributions.
 * The project versioning (Git) records all such contribution source information.
 *                                           
 *                                                                              
 * The BHoM is free software: you can redistribute it and/or modify         
 * it under the terms of the GNU Lesser General Public License as published by  
 * the Free Software Foundation, either version 3.0 of the License, or          
 * (at your option) any later version.                                          
 *                                                                              
 * The BHoM is distributed in the hope that it will be useful,              
 * but WITHOUT ANY WARRANTY; without even the implied warranty of               
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the                 
 * GNU Lesser General Public License for more details.                          
 *                                                                            
 * You should have received a copy of the GNU Lesser General Public License     
 * along with this code. If not, see <https://www.gnu.org/licenses/lgpl-3.0.html>.      
 */

using System.ComponentModel;

namespace BH.oM.Geometry
{
    [Description("A 4x4 matrix describing linear tranformations in three-dimensional space, such as translations, rotations, reflections, scaling and shearing.")]
    public class TransformMatrix : IGeometry
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public virtual double[,] Matrix { get; set; } = new double[4, 4];


        /***************************************************/
        /**** Static Special Cases                      ****/
        /***************************************************/

        public static readonly TransformMatrix Zero = new TransformMatrix { Matrix = new double[4, 4] };

        /***************************************************/

        public static readonly TransformMatrix Identity = new TransformMatrix
        {
            Matrix = new double[4, 4]
            {
                { 1, 0, 0, 0 },
                { 0, 1, 0, 0 },
                { 0, 0, 1, 0 },
                { 0, 0, 0, 1 }
            }
        };


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

            return new TransformMatrix { Matrix = result };
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

            return new TransformMatrix { Matrix = result };
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

            return new TransformMatrix { Matrix = result };
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

            return new TransformMatrix { Matrix = result };
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

            return new TransformMatrix { Matrix = result };
        }

        /***************************************************/
    }
}



