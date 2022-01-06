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
    [Description("A constant cross section surface, defined by a single profile curve and a linear axis.")]
    public class Extrusion : ISurface
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("The Extrusion profile curve defining the constant cross sectional shape. Idential curves can be recreated at any point along the Extrusion axis through intersection with the Surface.")]
        public virtual ICurve Curve { get; set; } = new Line();

        [Length]
        [Description("The axis along which to translate the profile curve. The Vector magnitude determining the Extrusion length.")]
        public virtual Vector Direction { get; set; } = new Vector { X = 0, Y = 0, Z = 1 };

        [Description("Defines the Extrusion as closed and therfore a solid volume.")]
        public virtual bool Capped { get; set; } = true;
        
        /***************************************************/
    }
}



