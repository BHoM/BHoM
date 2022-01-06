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
using BH.oM.Quantities.Attributes;

namespace BH.oM.Geometry
{
    [Description("A standard solid circular ring torus, formed as a surface of revolution of a circle about an axis.")]
    public class Torus : ISolid
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Origin point defining location of the Torus in three-dimensional space.")]
        public virtual Point Centre { get; set; } = new Point();

        [Description("Vector defining the axis of revolution and the orientation of the Torus in three-dimensional space.")]
        public virtual Vector Axis { get; set; } = new Vector { X = 0, Y = 0, Z = 1 };

        [Length]
        [Description("Distance from the Torus Centre (and the axis of revolution) to the centre of the circular cross section.")]
        public virtual double RadiusMajor { get; set; } = 0.0;

        [Length]
        [Description("The radius defining the size of the circular cross section.")]
        public virtual double RadiusMinor { get; set; } = 0.0;

        /***************************************************/
    }
}


