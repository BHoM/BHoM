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
    [Description("A constant circular cross section surface, following a defined curve path.")]
    public class Pipe : ISurface
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Defines the central axis perpendicular to the circular cross sections, and thus the path along which the tubular surface follows.")]
        public virtual ICurve Centreline { get; set; } = new Line();

        [Length]
        [Description("The distance from the Curve Centreline to a point on the Pipe surface.")]
        public virtual double Radius { get; set; } = 0;

        [Description("Defines the Pipe as closed and therfore a solid volume.")]
        public virtual bool Capped { get; set; } = true;
        
        /***************************************************/
    }
}



