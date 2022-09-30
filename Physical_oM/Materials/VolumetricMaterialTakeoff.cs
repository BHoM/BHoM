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
using BH.oM.Quantities.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BH.oM.Physical.Materials
{
    [Description("Defines the make up of an object through a list of Materials and their corresponding volumes.\n" +
                 "There must be the same number of items in both lists, assigning a single Volume for each Material.")]
    public class VolumetricMaterialTakeoff : BHoMObject, IPhysical, IImmutable, IFragment
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("The Materials that form an object's make up, the order of which corresponds to the order of the Volumes.")]
        public virtual IReadOnlyList<Material> Materials { get; } = new List<Material>();

        [Volume]
        [Description("The list of Material Volumes order corresponding to the Materials list, i.e. the amount of each material.")]
        public virtual IReadOnlyList<double> Volumes { get; } = new List<double>();


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        [Description("The base constructor for MaterialComposition, assigns the properties to the read-only lists.")]
        public VolumetricMaterialTakeoff(IEnumerable<Material> materials, IEnumerable<double> volumes)
        {
            Materials = materials?.ToList();
            Volumes = volumes?.ToList();
        }
        /***************************************************/

    }
}


