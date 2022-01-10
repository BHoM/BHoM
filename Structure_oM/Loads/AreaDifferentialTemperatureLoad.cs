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
using BH.oM.Base;
using BH.oM.Geometry;
using System.Collections.Generic;
using BH.oM.Base.Attributes;

namespace BH.oM.Structure.Loads
{
    [Description("Vertical differential temperature load for area elements such as Panels and FEMeshes.")]
    [NoAutoConstructor()]
    public class AreaDifferentialTemperatureLoad : BHoMObject, IElementLoad<IAreaElement>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Temperature]
        [Description("Vertical differential temperature profile of the area element expressed as a Dictionary of the normalised position from the bottom face of the surface property and the temperature at each increment.")]
        public virtual Dictionary<double,double> TemperatureProfile { get; set; }

        [Description("The Loadcase in which the load is applied.")]
        public virtual Loadcase Loadcase { get; set; }

        [Description("The group of IAreaElements that the load should be applied to. For most analysis packages the objects added here need to be pulled from the analysis package before being assigned to the load.")]
        public virtual BHoMGroup<IAreaElement> Objects { get; set; } = new BHoMGroup<IAreaElement>();

        [Description("Defines whether the load is applied in local or global coordinates.")]
        public virtual LoadAxis Axis { get; set; } = LoadAxis.Global;

        [Description("If true the load is projected to the element. This means that the load will be reduced when its direction is at an angle to the element.")]
        public virtual bool Projected { get; set; } = false;

        /***************************************************/
    }
}



