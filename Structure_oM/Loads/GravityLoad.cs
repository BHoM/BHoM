/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2025, the respective contributors. All rights reserved.
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
    [Description("Gravity load to be applied to elements such as Bars, Panels and FEMeshes.")]
    public class GravityLoad : BHoMObject, IElementLoad<BHoMObject>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        
        [Description("The magnitude and direction of gravity. This will be scaled by the gravity constant g in the analysis, which means a load representing gravity should be a Vector with -1 as its Z-component.")]
        public virtual Vector GravityDirection { get; set; } = new Vector { X = 0, Y = 0, Z = -1 };

        [Description("The Loadcase in which the load is applied.")]
        public virtual Loadcase Loadcase { get; set; }

        [Description("The group of structural elements, Bars and IAreaElements, that the load should be applied to. For most analysis packages the objects added here need to be pulled from the analysis package before being assigned to the load.")]
        public virtual BHoMGroup<BHoMObject> Objects { get; set; } = new BHoMGroup<BHoMObject>();

        [Description("Defines whether the load is applied in local or global coordinates.")]
        public virtual LoadAxis Axis { get; set; } = LoadAxis.Global;

        [Description("If true the load is projected to the element. This means that the load will be reduced when its direction is at an angle to the element.")]
        public virtual bool Projected { get; set; } = false;

        /***************************************************/
    }
}






