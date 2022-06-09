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
using BH.oM.Geometry;
using System.ComponentModel;
using BH.oM.Quantities.Attributes;

namespace BH.oM.Structure.Loads
{
    [Description("Distributed load to be applied over a line.")]
    public class GeometricalLineLoad : BHoMObject, ILoad
    {
        /***************************************************/
        /****            Public Properties              ****/
        /***************************************************/

        [Description("The Loadcase in which the load is applied.")]
        public virtual Loadcase Loadcase { get; set; }

        [Description("Defines whether the load is applied in local or global coordinates.")]
        public virtual LoadAxis Axis { get; set; }

        [Description("If true the load is projected to the region.")]
        public virtual bool Projected { get; set; }

        [ForcePerUnitLength]
        [Description("Force per unit length at the start of the line.")]
        public virtual Vector ForceA { get; set; } = new Vector();

        [ForcePerUnitLength]
        [Description("Force per unit length at the end of the line.")]
        public virtual Vector ForceB { get; set; } = new Vector();

        [MomentPerUnitLength]
        [Description("Moment per unit length at the start of the line.")]
        public virtual Vector MomentA { get; set; } = new Vector();

        [MomentPerUnitLength]
        [Description("Moment per unit length at the end of the line.")]
        public virtual Vector MomentB { get; set; } = new Vector();

        [Description("Line defining the location of the load.")]
        public virtual Line Location { get; set; } = null;

        /***************************************************/
    }

}


