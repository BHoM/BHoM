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
    [Description("Structural timber material of type Glued Laminated Timber to be used on structural elements and properties, or as a fragment of the physical material.")]
    public class Glulam : BHoMObject, ITimber
    {
        /***************************************************/
        /**** Properties - General and analysis         ****/
        /***************************************************/

        [Description("Name. A unique name is required for some structural packages to create and identify the object.")]
        public override string Name { get; set; }

        [Density]
        [Description("Mean Density. Used to calculate mass. Called ρg,mean in Eurocode.")]
        public virtual double Density { get; set; }

        [Density]
        [Description("Characteristic Density. Used to calculate other mechanical properties (not mass). Called ρg,k in Eurocode.")]
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

        [YoungsModulus]
        [Description("Mean modulus of elasticity parallel bending, E0,g,mean in Eurocode.")]
        public virtual double YoungsModulusParallelMean { get; set; }

        [YoungsModulus]
        [Description("5 percentile modulus of elasticity parallel bending, E0,g,05 in Eurocode.")]
        public virtual double YoungsModulusParallelCharacteristic { get; set; }

        [YoungsModulus]
        [Description("Mean modulus of elasticity perpendicular, E90,g,mean in Eurocode.")]
        public virtual double YoungsModulusPerpendicularMean { get; set; }

        [YoungsModulus]
        [Description("Mean modulus of elasticity perpendicular, E90,g,05 in Eurocode.")]
        public virtual double YoungsModulusPerpendicularCharacteristic { get; set; }

        [ShearModulus]
        [Description("Mean shear modulus parallel to the grain, Gg,mean in Eurocode.")]
        public virtual double ShearModulusMean { get; set; }

        [ShearModulus]
        [Description("Characteristic shear modulus parallel to the grain, Gg,05 in Eurocode.")]
        public virtual double ShearModulusCharacteristic { get; set; }

        [ShearModulus]
        [Description("Mean shear modulus parallel to the grain, Gr,g,mean in Eurocode.")]
        public virtual double RollingShearModulusMean { get; set; }

        [ShearModulus]
        [Description("Characteristic shear modulus parallel to the grain, Gr,g,05 in Eurocode.")]
        public virtual double RollingShearModulusCharacteristic { get; set; }

        /***************************************************/
        /**** Properties - Strength                     ****/
        /***************************************************/

        [Stress]
        [Description("Bending Strength. Tension stress parallel to the grain at failure in bending as calculated from beam equations. Called fm,g,k in Eurocode.")]
        public virtual double BendingStrength { get; set; }

        [Stress]
        [Description("Tension Parallel Strength. Tension stress parallel to the grain at failure in net tension. Called ft,0,g,k in Eurocode.")]
        public virtual double TensionParallelStrength { get; set; }

        [Stress]
        [Description("Tension Perpendicular Strength. Tension stress perpendicular to the grain at failure in net tension. Called ft,90,g,k in Eurocode.")]
        public virtual double TensionPerpendicularStrength { get; set; }

        [Stress]
        [Description("Compression Parallel Strength. Compression stress parallel to the grain at failure in net compression. Called fc,0,g,k in Eurocode.")]
        public virtual double CompressionParallelStrength { get; set; }

        [Stress]
        [Description("Compression Perpendicular Strength. Compression stress perpendicular to the grain at failure in net compression. Called fc,90,g,k in Eurocode.")]
        public virtual double CompressionPerpendicularStrength { get; set; }

        [Stress]
        [Description("Shear Strength. Shear stress parallel to the grain at failure in net shear, i.e. shear relevant to beam bending. Called fv,g,k in Eurocode.")]
        public virtual double ShearStrength { get; set; }

        [Stress]
        [Description("Rolling Shear Strength. Shear stress perpendicular to the grain at failure in net shear. Called fr,g,k in Eurocode.")]
        public virtual double RollingShearStrength { get; set; }

        /***************************************************/

    }
}


