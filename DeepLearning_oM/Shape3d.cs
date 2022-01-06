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

using BH.oM.Base;
using System.Text.RegularExpressions;

namespace BH.oM.DeepLearning
{
    public class Shape3d : BHoMObject, IShape
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public virtual int Dim1 { get; set; } = -1;

        public virtual int Dim2 { get; set; } = -1;

        public virtual int Dim3 { get; set; } = -1;


        /***************************************************/
        /**** Casting Operators                         ****/
        /***************************************************/

        public static explicit operator Shape3d(string shape)
        {
            Regex regex = new Regex(".*([0-9]),.*([0-9]),.*([0-9]).*");
            Match match = regex.Match(shape);

            if (match.Groups.Count < 3)
                return null;

            return new Shape3d()
            {
                Dim1 = int.Parse(match.Groups[1].Value),
                Dim2 = int.Parse(match.Groups[2].Value),
                Dim3 = int.Parse(match.Groups[3].Value)
            };
        }

        /***************************************************/
    }
}



