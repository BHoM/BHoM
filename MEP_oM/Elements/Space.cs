/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2026, the respective contributors. All rights reserved.
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
using BH.oM.Base;
using BH.oM.Geometry;
using BH.oM.MEP.Criteria;
using BH.oM.Quantities.Attributes;

namespace BH.oM.MEP.Elements
{
    [Description("Approved calculation space. Identity and the measures a calculation is allowed to use. Source identity for Revit, IFC, IES or Excel is carried as a fragment.")]
    public class Space : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Space number used on drawings and schedules.")]
        public virtual string Number { get; set; } = "";

        [Description("Assigned reusable space-use template. Null means no space type has been assigned.")]
        public virtual SpaceType SpaceType { get; set; } = null;

        [Length]
        [Description("Approved floor-to-ceiling height (m). NaN means the height has not been approved.")]
        public virtual double Height { get; set; } = double.NaN;

        [Description("Plan outline and position of the space. The elevation is the Z of ExternalBoundary. Area and volume are queried from this surface and the height.")]
        public virtual PlanarSurface Surface { get; set; } = null;

        /***************************************************/
    }
}
