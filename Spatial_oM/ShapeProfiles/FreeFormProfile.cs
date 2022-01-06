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
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace BH.oM.Spatial.ShapeProfiles
{
    [Description("Freeform profile only defined by its geometry without any dimensional data. To be used as a fallback for profiles not yet explicitly defined.")]
    public class FreeFormProfile : BHoMObject, IProfile, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        public virtual ShapeType Shape { get; } = ShapeType.FreeForm;

        [Description("Edge curves defining the section. Should be curves defined in the global XY-plane.\n" +
                     "This assumes that the outermost curve(s) are solid. Curves inside a solid region are assumed to be openings, and curves within openings are assumed to be solid, etc.")]
        public virtual ReadOnlyCollection<ICurve> Edges { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public FreeFormProfile(IEnumerable<ICurve> edges)
        {
            Edges = new ReadOnlyCollection<ICurve>(edges.ToList());
        }


        /***************************************************/
    }
}



