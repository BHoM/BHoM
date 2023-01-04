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
using System.ComponentModel;
using BH.oM.Geometry;

namespace BH.oM.Structure.MaterialFragments
{
    [Description("Structural timber material to be used on structural elements and properties or as a fragment of the physical material.")]
    public class Timber : BHoMObject, IOrthotropic
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Name. A unique name is required for some structural packages to create and identify the object.")]
        public override string Name { get; set; }

        [Density]
        [Description("Characteristic Density. Used to calculate other mechanical properties (not mass). Called G (specific gravity) in American codes, p_k in Eurocode.")]
        public virtual double DensityCharacteristic { get; set; }

        [Density]
        [Description("Mean Density. Used to calculate mass. Called p_mean in Eurocode.")]
        public virtual double Density { get; set; }

        [Ratio]
        [Description("Dynamic Damping Ratio. Ratio between actual damping and critical damping.")]
        public virtual double DampingRatio { get; set; }
        
        [YoungsModulus]
        [Description("Characteristic Modulus Of Elasticity of the material. Ratio between stress and strain in all directions. Vector components made up of: X - Parallel, E_0,k in Eurocode; Y - Perpendicular, E_90,k in Eurocode; Z - Perpendicular, E_90,k in Eurocode.")]
        public virtual Vector YoungsModulus { get; set; }

        [YoungsModulus]
        [Description("Mean Modulus Of Elasticity of the material. Ratio between stress and strain in all directions. Vector components made up of: X - Parallel, E_0,mean in Eurocode; Y - Perpendicular, E_90,mean in Eurocode; Z - Perpendicular, E_90,mean in Eurocode.")]
        public virtual Vector YoungsModulusMean { get; set; }

        [Ratio]
        [Description("Poisson's Ratio. Ratio between axial and transverse strain. Typically take as 0.4 in all directions, though value varies depending on timber species. Vector components made up of: X - Parallel; Y - Perpendicular; Z - Perpendicular.")]
        public virtual Vector PoissonsRatio { get; set; }

        [ThermalExpansionCoefficient]
        [Description("Thermal Expansion Coefficeint. Strain induced in the material per unit change of temperature. Typically take as 5x10^-6 in all directions, though value varies depending on timber species. Vector components made up of: X - Parallel; Y - Perpendicular; Z - Perpendicular.")]
        public virtual Vector ThermalExpansionCoeff { get; set; }

        [ShearModulus]
        [Description("Characterstic Shear Modulus or Modulus of Rigidity. Ratio between shear stress and shear strain. Vector components made up of: X - Parallel, G_k in Eurocode; Y - Parallel, G_k in Eurocode; Z - Perpendicular, G_r,05 in Eurocode.")]
        public virtual Vector ShearModulus { get; set; }

        [ShearModulus]
        [Description("Mean Shear Modulus or Modulus of Rigidity. Ratio between shear stress and shear strain. Vector components made up of: X - Parallel, G_mean in Eurocode; Y - Parallel, G_mean in Eurocode; Z - Perpendicular, G_r,mean in Eurocode.")]
        public virtual Vector ShearModulusMean { get; set; }

        [Stress]
        [Description("Bending Strength. Tension stress parallel to the grain at failure in bending as calculated from beam equations. Called F_b in American codes, f_mk in Eurocode.")]
        public virtual double BendingStrength { get; set; }

        [Stress]
        [Description("Tension Parallel Strength. Tension stress parallel to the grain at failure in net tension. Called F_t\u2225 in American codes, f_t0k in Eurocode.")]
        public virtual double TensionParallelStrength { get; set; }

        [Stress]
        [Description("Tension Perpendicular Strength. Tension stress perpendicular to the grain at failure in net tension. Called F_t\u27c2 in American codes, f_t90k in Eurocode.")]
        public virtual double TensionPerpendicularStrength { get; set; }

        [Stress]
        [Description("Compression Parallel Strength. Compression stress parallel to the grain at failure in net compression. Called F_c\u2225 in American codes, f_c0k in Eurocode.")]
        public virtual double CompressionParallelStrength { get; set; }

        [Stress]
        [Description("Compression Perpendicular Strength. Compression stress perpendicular to the grain at failure in net compression. Called F_c\u27c2 in American codes, f_c90k in Eurocode.")]
        public virtual double CompressionPerpendicularStrength { get; set; }

        [Stress]
        [Description("Shear Strength. Shear stress parallel to the grain at failure in net shear, i.e. shear relevant to beam bending. Called F_v in American codes, f_vk in Eurocode.")]
        public virtual double ShearStrength { get; set; }
        
        [Stress]
        [Description("Rolling Shear Strength. Shear stress perpendicular to the grain at failure in net shear. Called F_s in American codes, F_rk in Eurocode.")]
        public virtual double RollingShearStrength { get; set; }

        /***************************************************/

    }
}



