/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2023, the respective contributors. All rights reserved.
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
using BH.oM.Quantities.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using BH.oM.Dimensional;

namespace BH.oM.Geometry
{
    [Description("Closed, planar, non-self intersecting curve built up of multiple curve segments.")]
    public class BoundaryCurve : ICurve, IPolyCurve, IBoundary, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("A collection of curves, of any or mixed type, which together define a closed, planar, non-self intersection boundary loop.")]
        public virtual IReadOnlyList<ICurve> Curves { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public BoundaryCurve(IEnumerable<ICurve> curves)
        {
            Curves = new ReadOnlyCollection<ICurve>(curves == null ? new List<ICurve>() : curves.ToList());
        }

        /***************************************************/
        /**** Implicit Casting                          ****/
        /***************************************************/

        [Description("Enables implicit casting of a BoundaryCurve to a PolyCurve. This ensures that a BoundaryCurve can be passed freely to a method expecting a PolyCurve.")]
        public static implicit operator PolyCurve(BoundaryCurve boundary)
        {
            return new PolyCurve { Curves = boundary.Curves.ToList() };
        }

        /***************************************************/
    }
}



