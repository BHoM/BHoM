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

using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Physical.Materials
{
    [Description("Represents a generic material by its category, type, grade, and constituent. This classification can be used to identify and group materials for various purposes, such as material selection, specification, and analysis.\n" +
                 "The classification can be put on a phsyical Material as a IMaterialProeprties or on a MaterialFragment as a IFragment.")]
    public class MaterialClassification : BHoMObject, IMaterialProperties, IFragment
    {
        [Description("The category of the material, e.g., 'Concrete', 'Steel', 'Wood', etc.")]
        public virtual string Category { get; set; } = "";

        [Description("The type of the material, e.g., 'Reinforced', 'Prestressed', etc.")]
        public virtual string Type { get; set; } = "";

        [Description("The grade of the material, e.g., 'C30/37', 'S420', 'F175', etc.")]
        public virtual string Grade { get; set; } = "";

        [Description("The constituent of the material, e.g., Fly Ash, GGBS, etc.")]
        public virtual string Constituent { get; set; } = "";
    }

}
