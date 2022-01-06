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
    [Description("Standard sphere defining the closed bounding surface of constant distance from a point, its Centre")]
    public class Sphere : ISolid
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Origin point defining location of the Sphere in three-dimensional space")]
        public virtual Point Centre { get; set; } = new Point();

        [Length]
        [Description("Distance from the Centre to the Sphere boundary surface")]
        public virtual double Radius { get; set; } = 0.0;

        /***************************************************/
    }
}



