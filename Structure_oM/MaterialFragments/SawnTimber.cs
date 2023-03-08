﻿/*
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
    public class SawnTimber : BHoMObject, ITimber
    {
        /***************************************************/
        /**** Properties - General and analysis         ****/
        /***************************************************/

        [Description("A unique name is required for some structural packages to create and identify the object.")]
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
        [Description("Modulus Of Elasticity of the material to be used for Analysis. Ratio between stress and strain in all directions.\n" +
                     "Values can be automatically populated based on material parameters by calling the SetAnalysisParameters method.\n" +
                     "Vector defines stiffnesses as follows:\n" +
                     "X - Stiffness along the local x-axis of the element (Ex). For most cases this will be the parallel stiffness.\n" +
                     "Y - Stiffness along the local y-axis of the element (Ey). For most cases this will be the perpendicular stiffness.\n" +
                     "Z - Stiffness along the local z-axis of the element (Ez). For most cases this will be the perpendicular stiffness.")]
        public virtual Vector YoungsModulus { get; set; }

        [ShearModulus]
        [Description("Shear Modulus or Modulus of Rigidity of the material to be used for Analysis. Ratio between shear stress and shear strain.\n" +
                     "Values can be automatically populated based on material parameters by calling the SetAnalysisParameters method.\n" +
                     "Vector components defined as:\n" +
                     "X - Shear Modulus in the local xy-plane (Gxy).\n" +
                     "Y - Shear Modulus in the local yz-plane (Gyz), generally referred to as rolling shear.\n" +
                     "Z - Shear Modulus in the local zx-plane (Gzx).")]
        public virtual Vector ShearModulus { get; set; }

        [Ratio]
        [Description("Poisson's Ratio. Ratio between axial and transverse strain. Typically taken as 0.4 for X and Y component (νxy and νyz) and as 0.4*E_90/E_0 for the Z component, though value varies depending on timber species.\n" +
                     "Vector components made up of:\n" +
                     "X - Poisson's ratio for strain in the local y direction generated by unit strain in x direction (νxy). Generally strain in perpendicular direction caused by strain in longitudinal direction.\n" +
                     "Y - Poisson's ratio for strain in the local z direction generated by unit strain in y direction (νyz). Generally strain in perpendicular direction caused by strain in other perpendicular direction.\n" +
                     "Z - Poisson's ratio for strain in the local x direction generated by unit strain in z direction (νzx). Generally strain in longitudinal direction caused by strain in perpendicular direction. Note that this value generally is significantly lower than values for the other two components.")]
        public virtual Vector PoissonsRatio { get; set; }

        [ThermalExpansionCoefficient]
        [Description("Thermal Expansion Coefficeint. Strain induced in the material per unit change of temperature. Typically taken as 5x10^-6 in all directions, though value varies depending on timber species and grain orientation.\n" +
                     "Vector defines stiffnesses as follows:\n" +
                     "X - Thermal expansion along the local x-axis of the element (αx).\n" +
                     "Y - Thermal expansion along the local y-axis of the element (αy).\n" +
                     "Z - Thermal expansion along the local z-axis of the element (αz).")]
        public virtual Vector ThermalExpansionCoeff { get; set; }

        /***************************************************/
        /**** Properties - Stiffness                    ****/
        /***************************************************/

        [YoungsModulus]
        [Description("Mean modulus of elasticity parallel bending, Em,0,mean in Eurocode.")]
        public virtual double E_0_Mean { get; set; }

        [YoungsModulus]
        [Description("5 percentile modulus of elasticity parallel bending, Em,0,k in Eurocode.")]
        public virtual double E_0_k { get; set; }

        [YoungsModulus]
        [Description("Mean modulus of elasticity perpendicular, Em,90,mean in Eurocode.")]
        public virtual double E_90_Mean { get; set; }

        [ShearModulus]
        [Description("Mean shear modulus, G,mean in Eurocode.")]
        public virtual double G_Mean { get; set; }

        /***************************************************/
        /**** Properties - Strength                     ****/
        /***************************************************/

        [Stress]
        [Description("Characteristic Bending Strength. Normal stress parallel to the grain at failure in bending as calculated from beam equations. Called f_mk in Eurocode.")]
        public virtual double BendingStrength { get; set; }

        [Stress]
        [Description("Characteristic Tensile parallel Strength. Tensile stress parallel to the grain at failure in net tension. Called  f_t0k in Eurocode.")]
        public virtual double TensileStrengthParallel { get; set; }

        [Stress]
        [Description("Characteristic Tensile perpendicular Strength. Tensile stress perpendicular to the grain at failure in net tension. Called f_t90k in Eurocode.")]
        public virtual double TensileStrengthPerpendicular { get; set; }

        [Stress]
        [Description("Characteristic Compressive parallel Strength. Compressive stress parallel to the grain at failure in net compression. Called f_c0k in Eurocode.")]
        public virtual double CompressiveStrengthParallel { get; set; }

        [Stress]
        [Description("Characteristic Compressive perpendicular Strength. Compressive stress perpendicular to the grain at failure in net compression. Called f_c90k in Eurocode.")]
        public virtual double CompressiveStrengthPerpendicular { get; set; }

        [Stress]
        [Description("Characteristic Shear Strength. Shear stress parallel to the grain at failure in net shear, i.e. shear relevant to beam bending. Called f_vk in Eurocode.")]
        public virtual double ShearStrength { get; set; }

        /***************************************************/

    }
}


