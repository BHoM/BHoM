/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2020, the respective contributors. All rights reserved.
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
    [Description("A plane curve. A standard ellipse defining a curve of constant combined distance around two foci." +
                 "\nThe larger of the two radii defines the major axis of the Ellipse, and the line along which the two foci lie.")]
    public class Ellipse : ICurve
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Origin point defining location of the Ellipse in three-dimensional space.")]
        public Point Centre { get; set; } = new Point();

        [Description("Together with Axis2 also defines orientation in three-dimensional space. Direction only, and not magnitude, matters.")]
        public Vector Axis1 { get; set; } = new Vector { X = 1.0, Y = 0.0, Z = 0.0 };

        [Description("Together with Axis1 also defines orientation in three-dimensional space. Direction only, and not magnitude, matters.")]
        public Vector Axis2 { get; set; } = new Vector { X = 0.0, Y = 1.0, Z = 0.0 };

        [Length]
        [Description("Distance from the Centre to a point on the Ellipse along Axis1.")]
        public double Radius1 { get; set; } = 0;

        [Length]
        [Description("Distance from the Centre to a point on the Ellipse along Axis2.")]
        public double Radius2 { get; set; } = 0;
        
        /***************************************************/
    }
}

