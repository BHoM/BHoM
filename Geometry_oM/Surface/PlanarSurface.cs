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
using BH.oM.Base.Attributes;
using System.Collections.Generic;
using System.ComponentModel;

namespace BH.oM.Geometry
{
    [Description("A surface defined by boundary edge curves lying in a common plane. Planarity toleraces default to the BH.oM.Geometry.Tolerace.Distance.")]
    public class PlanarSurface : ISurface , IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Closed planar curve defining the outer boundary of the surface.")]   
        public virtual ICurve ExternalBoundary { get; }

        [Description("List of closed (co)planar curves defining any internal openings in the surface.")]
        public virtual List<ICurve> InternalBoundaries { get; }

        /***************************************************/

        public PlanarSurface(ICurve externalBoundary, List<ICurve> internalBoundaries)
        {
            ExternalBoundary = externalBoundary;
            InternalBoundaries = internalBoundaries;
        }
    }
}



