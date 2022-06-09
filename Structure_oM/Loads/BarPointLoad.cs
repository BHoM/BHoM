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

using BH.oM.Structure.Elements;
using System.ComponentModel;
using BH.oM.Quantities.Attributes;
using BH.oM.Geometry;
using BH.oM.Base;

namespace BH.oM.Structure.Loads
{
    [Description("Point load to be applied for Bars, positioned a set distance from the StartNode.")]
    public class BarPointLoad : BHoMObject, IElementLoad<Bar>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Length]
        [Description("Distance along the Bar between the StartNode and the load position.")]
        public virtual double DistanceFromA { get; set; } = 0;

        [Force]
        [Description("Magnitude and direction of the Force. The load requires the Force and/or the Moment Vector to be non-zero to have any effect.")]
        public virtual Vector Force { get; set; } = new Vector();

        [Force]
        [Description("Magnitude and direction of the Moment. The load requires the Force and/or the Moment Vector to be non-zero to have any effect.")]
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



