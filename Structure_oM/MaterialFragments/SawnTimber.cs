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
using BH.oM.Geometry;
using BH.oM.Quantities.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BH.oM.Structure.MaterialFragments
{
    [Description("Structural material of standard construction Timber to be used on structural elements and properties, or as a fragment of the physical material.")]
    public class SawnTimber : BHoMObject, ITimber<YoungsModulusSawnTimber, ShearModulusSawnTimber, StrengthSawnTimber>
    {
        /***************************************************/
        /**** Properties - General and analysis         ****/
        /***************************************************/

        [Description("Name. A unique name is required for some structural packages to create and identify the object.")]
        public override string Name { get; set; }

        [Density]
        [Description("Mean Density. Used to calculate mass. Called ρmean in Eurocode.")]
        public virtual double Density { get; set; }

        [Density]
        [Description("Characteristic Density. Used to calculate other mechanical properties (not mass). Called ρk in Eurocode.")]
        public virtual double DensityCharacteristic { get; set; }

        [Ratio]
        [Description("Dynamic Damping Ratio. Ratio between actual damping and critical damping.")]
        public virtual double DampingRatio { get; set; }

        [YoungsModulus]
        [Description("Modulus Of Elasticity of the material to be used for Analysis. Ratio between stress and strain in all directions. Vector components should generally be made up of: X - Parallel; Y - Perpendicular; Z - Perpendicular.")]
        public virtual Vector YoungsModulus { get; set; }

        [Ratio]
        [Description("Poisson's Ratio. Ratio between axial and transverse strain. Typically take as 0.4 in all directions, though value varies depending on timber species. Vector components made up of: X - Parallel; Y - Perpendicular; Z - Perpendicular.")]
        public virtual Vector PoissonsRatio { get; set; }

        [ThermalExpansionCoefficient]
        [Description("Thermal Expansion Coefficeint. Strain induced in the material per unit change of temperature. Typically take as 5x10^-6 in all directions, though value varies depending on timber species. Vector components made up of: X - Parallel; Y - Perpendicular; Z - Perpendicular.")]
        public virtual Vector ThermalExpansionCoeff { get; set; }

        [ShearModulus]
        [Description("Shear Modulus or Modulus of Rigidity of the material to be used for Analysis. Ratio between shear stress and shear strain. Vector components should generally be made up of: X - Parallel; Y - Parallel; Z - Perpendicular.")]
        public virtual Vector ShearModulus { get; set; }

        /***************************************************/
        /**** Properties - Stiffness                    ****/
        /***************************************************/

        [Description("Storage for YoungsModulus proeprties in various directions.")]
        public virtual YoungsModulusSawnTimber YoungsModulusProperties { get; set; }

        [Description("Storage for Shear Modulus proeprties in various directions.")]
        public virtual ShearModulusSawnTimber ShearModulusProperties { get; set; }

        [Description("Storage for Strength proeprties.")]
        public virtual StrengthSawnTimber Strength { get; set; }

        /***************************************************/

    }

    //[Description("Structural material of standard construction Timber to be used on structural elements and properties, or as a fragment of the physical material.")]
    //public class SawnTimber : BHoMObject, ITimber
    //{
    //    /***************************************************/
    //    /**** Properties - General and analysis         ****/
    //    /***************************************************/

    //    [Description("Name. A unique name is required for some structural packages to create and identify the object.")]
    //    public override string Name { get; set; }

    //    [Density]
    //    [Description("Mean Density. Used to calculate mass. Called ρmean in Eurocode.")]
    //    public virtual double Density { get; set; }

    //    [Density]
    //    [Description("Characteristic Density. Used to calculate other mechanical properties (not mass). Called ρk in Eurocode.")]
    //    public virtual double DensityCharacteristic { get; set; }

    //    [Ratio]
    //    [Description("Dynamic Damping Ratio. Ratio between actual damping and critical damping.")]
    //    public virtual double DampingRatio { get; set; }

    //    [YoungsModulus]
    //    [Description("Modulus Of Elasticity of the material to be used for Analysis. Ratio between stress and strain in all directions. Vector components should generally be made up of: X - Parallel; Y - Perpendicular; Z - Perpendicular.")]
    //    public virtual Vector YoungsModulus { get; set; }

    //    [Ratio]
    //    [Description("Poisson's Ratio. Ratio between axial and transverse strain. Typically take as 0.4 in all directions, though value varies depending on timber species. Vector components made up of: X - Parallel; Y - Perpendicular; Z - Perpendicular.")]
    //    public virtual Vector PoissonsRatio { get; set; }

    //    [ThermalExpansionCoefficient]
    //    [Description("Thermal Expansion Coefficeint. Strain induced in the material per unit change of temperature. Typically take as 5x10^-6 in all directions, though value varies depending on timber species. Vector components made up of: X - Parallel; Y - Perpendicular; Z - Perpendicular.")]
    //    public virtual Vector ThermalExpansionCoeff { get; set; }

    //    [ShearModulus]
    //    [Description("Shear Modulus or Modulus of Rigidity of the material to be used for Analysis. Ratio between shear stress and shear strain. Vector components should generally be made up of: X - Parallel; Y - Parallel; Z - Perpendicular.")]
    //    public virtual Vector ShearModulus { get; set; }

    //    /***************************************************/
    //    /**** Properties - Stiffness                    ****/
    //    /***************************************************/

    //    [YoungsModulus]
    //    [Description("Mean modulus of elasticity parallel bending, Em,0,mean in Eurocode.")]
    //    public virtual double YoungsModulusParallelMean { get; set; }

    //    [YoungsModulus]
    //    [Description("5 percentile modulus of elasticity parallel bending, Em,0,k in Eurocode.")]
    //    public virtual double YoungsModulusParallelCharacteristic { get; set; }

    //    [YoungsModulus]
    //    [Description("Mean modulus of elasticity perpendicular, Em,90,mean in Eurocode.")]
    //    public virtual double YoungsModulusPerpendicularMean { get; set; }

    //    [ShearModulus]
    //    [Description("Mean shear modulus, G,mean in Eurocode.")]
    //    public virtual double ShearModulusMean { get; set; }

    //    /***************************************************/
    //    /**** Properties - Strength                     ****/
    //    /***************************************************/

    //    [Stress]
    //    [Description("Bending Strength. Tension stress parallel to the grain at failure in bending as calculated from beam equations. Called f_mk in Eurocode.")]
    //    public virtual double BendingStrength { get; set; }

    //    [Stress]
    //    [Description("Tension Parallel Strength. Tension stress parallel to the grain at failure in net tension. Called  f_t0k in Eurocode.")]
    //    public virtual double TensionParallelStrength { get; set; }

    //    [Stress]
    //    [Description("Tension Perpendicular Strength. Tension stress perpendicular to the grain at failure in net tension. Called f_t90k in Eurocode.")]
    //    public virtual double TensionPerpendicularStrength { get; set; }

    //    [Stress]
    //    [Description("Compression Parallel Strength. Compression stress parallel to the grain at failure in net compression. Called f_c0k in Eurocode.")]
    //    public virtual double CompressionParallelStrength { get; set; }

    //    [Stress]
    //    [Description("Compression Perpendicular Strength. Compression stress perpendicular to the grain at failure in net compression. Called f_c90k in Eurocode.")]
    //    public virtual double CompressionPerpendicularStrength { get; set; }

    //    [Stress]
    //    [Description("Shear Strength. Shear stress parallel to the grain at failure in net shear, i.e. shear relevant to beam bending. Called f_vk in Eurocode.")]
    //    public virtual double ShearStrength { get; set; }

    //    /***************************************************/

    //}
}


