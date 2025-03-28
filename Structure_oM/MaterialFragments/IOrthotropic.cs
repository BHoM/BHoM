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
using BH.oM.Quantities.Attributes;
using System.ComponentModel;
using BH.oM.Geometry;

namespace BH.oM.Structure.MaterialFragments
{
    [Description("Base interface for orthotropic structural materials.")]
    public interface IOrthotropic : IMaterialFragment
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [YoungsModulus]
        [Description("Modulus of elasticity of the material. Ratio between axial stress and axial strain.")]
        Vector YoungsModulus { get; set; }

        [Ratio]
        [Description("Ratio between axial and transverse strain.")]
        Vector PoissonsRatio { get; set; }

        [ThermalExpansionCoefficient]
        [Description("The strain induced in the material per unit change of temperature.")]
        Vector ThermalExpansionCoeff { get; set; }

        [ShearModulus]
        [Description("The shear modulus or modulus of rigidity. Defined as the ratio between shear stress and shear strain.")]
        Vector ShearModulus { get; set; }

        /***************************************************/
    }
}





