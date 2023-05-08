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
using System.ComponentModel;

namespace BH.oM.Physical.Materials
{
    [Description("Class storing takeoff values of relevant quantities corresponding to a particular material.")]
    public class TakeoffItem : IObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Material to which the takeoff values correspond.")]
        public virtual Material Material { get; set; }

        [Volume]
        [Description("Total volume of the material. Applicable for most takeoffs.")]
        public virtual double Volume { get; set; } = double.NaN;

        [Mass]
        [Description("Total mass of the material. Applicable for materials with a set density.")]
        public virtual double Mass { get; set; } = double.NaN;

        [Area]
        [Description("Total area of the material. Applicable for takeoffs of 2-dimensional elements or 2-dimensional parts.")]
        public virtual double Area { get; set; } = double.NaN;

        [Length]
        [Description("Total length of the material. Applicable for takeoffs of 1-dimensional elements or elements with 1-dimensional parts.")]
        public virtual double Length { get; set; } = double.NaN;

        [Description("Total number of items containing the material in the takeoff. Applicable for most takeoffs.")]
        public virtual int NumberItem { get; set; } = 0;

        [ElectricCurrent]
        [Description("Total Electric current associated with the material. Applicable for takeoffs of some electrical equipment elements.")]
        public virtual double ElectricCurrent { get; set; } = double.NaN;

        [Energy]
        [Description("Total Electric current associated with the material. Applicable for takeoffs of some electrical equipment elements.")]
        public virtual double Energy { get; set; } = double.NaN;

        [EnergyPerUnitTime]
        [Description("Total Power or apparent power associated with the material. Applicable for takeoffs of some electrical equipment elements.")]
        public virtual double Power { get; set; } = double.NaN;

        [VolumetricFlowRate]
        [Description("Total VolumetricFlowRate associated with the material. Applicable for takeoffs of elements relating to flow of substance through the element.")]
        public virtual double VolumetricFlowRate { get; set; } = double.NaN;


        /***************************************************/

    }
}


