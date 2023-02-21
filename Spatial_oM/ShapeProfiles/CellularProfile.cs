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
using BH.oM.Geometry;
using BH.oM.Quantities.Attributes;
using BH.oM.Spatial.ShapeProfiles.CellularOpenings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace BH.oM.Spatial.ShapeProfiles
{
    [Description("Shape profile for cellular/castellated members.")]
    public class CellularProfile : BHoMObject, IProfile, IImmutable
    {

        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        public virtual ShapeType Shape { get; } = ShapeType.ISection;

        [Description("The IShape from which the cellular beam was cut.")]
        public virtual ISectionProfile BaseProfile { get; }

        [Description("Top half of the profile at a cut through the maximum opening.")]
        public virtual TSectionProfile OpeningProfile { get; }

        [Description("The profile at a cut through the solid section.")]
        public virtual ISectionProfile SolidProfile { get; }

        [Description("Dimensions of the opening.")]
        public virtual ICellularOpening Opening { get; }

        [Description("Edge curves thought an opening that matches the dimensions in the global XY-plane.")]
        public virtual ReadOnlyCollection<ICurve> Edges { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public CellularProfile(ISectionProfile baseProfile, TSectionProfile openingProfile, ISectionProfile solidProfile, ICellularOpening opening, IEnumerable<ICurve> edges)
        {
            BaseProfile = baseProfile;
            OpeningProfile = openingProfile;
            SolidProfile = solidProfile;
            Opening = opening;
            Edges = new ReadOnlyCollection<ICurve>(edges.ToList());
        }

        /***************************************************/
    }
}


