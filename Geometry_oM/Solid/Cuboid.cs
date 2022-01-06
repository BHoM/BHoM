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
    [Description("A polyhedron. Standard cuboid consisting of six right-angled quadrilateral faces.")]
    public class Cuboid : ISolid
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Defines both the Cuboid centre as the CoordinateSystem Origin, as well as the orientation in three-dimensional space.")]
        public virtual CoordinateSystem.Cartesian CoordinateSystem { get; set; } = new CoordinateSystem.Cartesian();

        [Length]
        [Description("Dimension in the local x-axis. The Cuboid will have one face at a distance of Length/2 from the centre along the positive local x-axis and, one face at a distance of Length/2 from the centre along the negative local x-axis.")]
        public virtual double Length { get; set; } = 0.0;

        [Length]
        [Description("Dimension in the local y-axis. The Cuboid will have one face at a distance of Depth/2 from the centre along the positive local y-axis and, one face at a distance of Depth/2 from the centre along the negative local y-axis.")]
        public virtual double Depth { get; set; } = 0.0;

        [Length]
        [Description("Dimension in the local z-axis. The Cuboid will have one face at a distance of Height/2 from the centre along the positive local z-axis and, one face at a distance of Height/2 from the centre along the negative local z-axis.")]
        public virtual double Height { get; set; } = 0.0;


        /***************************************************/
    }
}


