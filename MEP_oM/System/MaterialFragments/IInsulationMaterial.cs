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

using System.ComponentModel;
using BH.oM.Base;
using BH.oM.Physical.Materials;

namespace BH.oM.MEP.System.MaterialFragments
{
    [Description("Insulation is the material surrounding a duct, pipe or wire which mitigates the loss of the internal conditions of the fluid within the object.")]
    public interface IInsulationMaterial : IFragment, IMaterialProperties
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        [Description("RValue is the measure of the resistance of conductive heat loss by the insulation material.")]
        double RValue { get; set; }

        [Description("KValue is the measure of the insulation material's ability to conduct heat (W/m*K), the lower the KValue the better the ability to conduct heat.")]
        double KValue { get; set; }

        /***************************************************/
    }
}


