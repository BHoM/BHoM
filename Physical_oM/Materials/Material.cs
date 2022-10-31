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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using BH.oM.Quantities.Attributes;

using BH.oM.Base;


namespace BH.oM.Physical.Materials
{
    [Description("Physical material to be used for Takeoffs and asigned to Physical elements. Material is capable of storing discipline specific data in Properties.")]
    public class Material : BHoMObject, IPhysical
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Density]
        [Description("Density to be used for takeoffs and methods relying on takeoff information. Can differ from densities assigned on discipline specific IMaterialProeprties.")]
        public virtual double Density { get; set; }

        [Description("Discipline data related to the material.")]
        public virtual List<IMaterialProperties> Properties { get; set; } = new List<IMaterialProperties>();

        /***************************************************/
    }
}



