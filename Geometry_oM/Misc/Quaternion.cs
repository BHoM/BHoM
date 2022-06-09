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
    [Description("A four-dimensional vector, useful in calculation of affine transformations in three-dimensional space. See also BH.oM.Geometry.TransformMatrix.")]
    public class Quaternion : IGeometry
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public virtual double X { get; set; } = 0;

        public virtual double Y { get; set; } = 0;

        public virtual double Z { get; set; } = 0;

        public virtual double W { get; set; } = 0;


        /***************************************************/
        /**** Static Operators Override                 ****/
        /***************************************************/

        public static Quaternion operator *(Quaternion q1, Quaternion q2)
        {
            return new Quaternion {
                X = q1.W * q2.X + q1.X * q2.W + q1.Y * q2.Z - q1.Z * q2.Y,
                Y = q1.W * q2.Y - q1.X * q2.Z + q1.Y * q2.W + q1.Z * q2.X,
                Z = q1.W * q2.Z + q1.X * q2.Y - q1.Y * q2.X + q1.Z * q2.W,
                W = q1.W * q2.W - q1.X * q2.X - q1.Y * q2.Y - q1.Z * q2.Z
            };
        }

        /***************************************************/

        public static Quaternion operator -(Quaternion q)
        {
            return new Quaternion { X = -q.X, Y = -q.Y, Z = -q.Z, W = q.W };
        }

        /***************************************************/
    }
}



