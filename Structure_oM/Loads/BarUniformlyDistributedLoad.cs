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

using BH.oM.Geometry;
using BH.oM.Structure.Elements;
using System.ComponentModel;
using BH.oM.Quantities.Attributes;
using BH.oM.Base;

namespace BH.oM.Structure.Loads
{
    [Description("Uniformly distributed load applied to Bars. Can be used to apply force and/or moments.")]
    public class BarUniformlyDistributedLoad : BHoMObject, IElementLoad<Bar>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [ForcePerUnitLength]
        [Description("Force per length unit to be applied to the full length of the Bar. The load requires the Force and/or the Moment Vector to be non-zero to have any effect.")]
        public virtual Vector Force { get; set; } = new Vector();

        [MomentPerUnitLength]
        [Description("Moment per length unit to be applied to the full length of the Bar. The load requires the Force and/or the Moment Vector to be non-zero to have any effect.")]
        public virtual Vector Moment { get; set; } = new Vector();

        [Description("The Loadcase in which the load is applied.")]
        public virtual Loadcase Loadcase { get; set; }

        [Description("The group of Bars that the load should be applied to. For most analysis packages the objects added here need to be pulled from the analysis package before being assigned to the load.")]
        public virtual BHoMGroup<Bar> Objects { get; set; } = new BHoMGroup<Bar>();

        [Description("Defines whether the load is applied in local or global coordinates.")]
        public virtual LoadAxis Axis { get; set; } = LoadAxis.Global;

        [Description("If true the load is projected to the element. This means that the load will be reduced when its direction is at an angle to the element.")]
        public virtual bool Projected { get; set; } = false;

        /***************************************************/
    }
}



