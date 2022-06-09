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
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using BH.oM.Quantities.Attributes;

namespace BH.oM.Geometry
{
    [Description("Solid representation defined by a collection of connected surfaces forming a closed volume")]
    public class BoundaryRepresentation : ISolid, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("List of ISurfaces must form a closed volume - checks and guarantees to be performed at conversion")]
        public virtual ReadOnlyCollection<ISurface> Surfaces { get; }

        [Volume]
        [Description("The enclosed volume created by the boundary surfaces. Property is set where available at conversion. If unavailable, or invalidated, will read NaN (not a number)")]
        public virtual double Volume { get; } = double.NaN;

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public BoundaryRepresentation(IEnumerable<ISurface> surfaces, double volume)
        {
            Surfaces = new ReadOnlyCollection<ISurface>(surfaces.ToList());
            Volume = volume;
        }


        /***************************************************/
    }
}



