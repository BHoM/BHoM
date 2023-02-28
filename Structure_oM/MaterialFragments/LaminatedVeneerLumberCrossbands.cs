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

    [Description("Structural timber material of type Laminated Veneer Lumber without crossband veneers. To be used on structural elements and properties, or as a fragment of the physical material.")]
    public class LaminatedVeneerLumberCrossbands : BHoMObject, ITimber
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
        [Description("Modulus Of Elasticity of the material to be used for Analysis. Ratio between stress and strain in all directions.\n" +
                     "Values can be automatically populated based on material parameters by calling the SetAnalysisParameters method.\n" +
                     "Vector defines stiffnesses as follows:\n" +
                     "X - Stiffness along the local x-axis of the element. For most cases this will be the Parallel stiffness.\n" +
                     "Y - Stiffness along the local y-axis of the element. For most cases this will be the perpendicular stiffness - flat or edgewise depending material usage and orientation.\n" +
                     "Z - Stiffness along the local z-axis of the element. For most cases this will be the perpendicular stiffness - flat or edgewise depending material usage and orientation.")]
        public virtual Vector YoungsModulus { get; set; }

        [ShearModulus]
        [Description("Shear Modulus or Modulus of Rigidity of the material to be used for Analysis. Ratio between shear stress and shear strain.\n" +
                             "Values can be automatically populated based on material parameters by calling the SetAnalysisParameters method.\n" +
                             "Vector components defined as:\n" +
                             "X - Shear Modulus in the local xy-plane (Gxy). For most cases this will Parallel shear modulus (G_0) - flat or edgewise depending material usage and orientation.\n" +
                             "Y - Shear Modulus in the local yz-plane (Gyz). For most cases this will be the Rolling Shear modulus (Gr_k or Gr_Mean)\n" +
                             "Z - Shear Modulus in the local zx-plane (Gyz). For most cases this will be the Shear modulus (G_k or G_Mean)")]
        public virtual Vector ShearModulus { get; set; }

        [Ratio]
        [Description("Poisson's Ratio. Ratio between axial and transverse strain. Typically taken as 0.4 for X and Y component (νxy and νyz) and as 0.4*E_90/E_0 for the Z component, though value varies depending on timber species.\n" +
                     "Vector components made up of:\n" +
                     "X - Poisson's ratio for strain in the local y direction generated by unit strain in x direction (νxy). Generally strain in perpendicular direction caused by strain in longitudinal direction.\n" +
                     "Y - Poisson's ratio for strain in the local z direction generated by unit strain in y direction (νyz). Generally strain in perpendicular direction caused by strain in other perpendicular direction.\n" +
                     "Z - Poisson's ratio for strain in the local x direction generated by unit strain in z direction (νzx). Generally strain in longitudinal direction caused by strain in perpendicular direction. Note that this value generally is significantly lower than values for the other two components.")]
        public virtual Vector PoissonsRatio { get; set; }

        [ThermalExpansionCoefficient]
        [Description("Thermal Expansion Coefficeint. Strain induced in the material per unit change of temperature. Typically take as 5x10^-6 in all directions, though value varies depending on timber species.\n" +
                     "Vector defines stiffnesses as follows:\n" +
                     "X - Thermal expansion along the local x-axis of the element (αx).\n" +
                     "Y - Thermal expansion along the local y-axis of the element (αy).\n" +
                     "Z - Thermal expansion along the local z-axis of the element (αz).")]
        public virtual Vector ThermalExpansionCoeff { get; set; }


        /***************************************************/
        /**** Properties - Stiffness                    ****/
        /***************************************************/

        [YoungsModulus]
        [Description("Characteristic modulus of elasticity parallel to grain, E0,k in Eurocode. Value same for Em,0,edge,k, Em,0,flat,k, Et,0,k, and Ec,0,k.")]
        public virtual double E_0_k { get; set; }

        [YoungsModulus]
        [Description("Characteristic modulus of elasticity for flatwise compression and tension perpendicular to the grain, Ec,90,flat,k and Et,90,flat,k in Eurocode.")]
        public virtual double E_90_Flat_k { get; set; }

        [YoungsModulus]
        [Description("Characteristic modulus of elasticity for flatwise bending perpendicular to the grain, Em,90,flat,k in Eurocode.\n" +
                     "Stiffness direction same as E_90_Edge_k. Load condidion should define which of the two to be used in analysis.")]
        public virtual double E_90_m_k { get; set; }

        [YoungsModulus]
        [Description("Characteristic modulus of elasticity for edgewise axialforce perpendicular to the grain, Ec,90,edge,k and Et,90,edge,k in Eurocode.\n" +
                     "Stiffness direction same as E_90_m_k. Load condidion should define which of the two to be used in analysis.")]
        public virtual double E_90_Edge_k { get; set; }

        [YoungsModulus]
        [Description("Mean modulus of elasticity parallel to grain, E0,mean in Eurocode. Value same for Em,0,edge,mean, Em,0,flat,mean, Et,0,mean, and Ec,0,mean.")]
        public virtual double E_0_Mean { get; set; }

        [YoungsModulus]
        [Description("Mean modulus of elasticity for flatwise compression and tension perpendicular to the grain, Ec,90,flat,mean and Et,90,flat,mean in Eurocode.")]
        public virtual double E_90_Flat_Mean { get; set; }

        [YoungsModulus]
        [Description("Mean modulus of elasticity for flatwise bending perpendicular to the grain, Em,90,flat,mean in Eurocode.\n" +
                     "Stiffness direction same as E_90_Edge_Mean. Load condidion should define which of the two to be used in analysis.")]
        public virtual double E_90_m_Mean { get; set; }

        [YoungsModulus]
        [Description("Mean modulus of elasticity for edgewise axialforce perpendicular to the grain, Ec,90,edge,mean and Et,90,edge,mean in Eurocode.\n" +
                     "Stiffness direction same as E_90_m_Mean. Load condidion should define which of the two to be used in analysis.")]
        public virtual double E_90_Edge_Mean { get; set; }

        [ShearModulus]
        [Description("Characteristic shear modulus for edgewise shear parallel to the grain, G0,edge,k in Eurocode.")]
        public virtual double G_0_Edge_k { get; set; }

        [ShearModulus]
        [Description("Characteristic shear modulus for flatwise shear parallel to the grain, G0,flat,k in Eurocode.")]
        public virtual double G_0_Flat_k { get; set; }

        [ShearModulus]
        [Description("Characteristic shear modulus for flatwise shear perpendicular to the grain, G90,flat,k in Eurocode.")]
        public virtual double G_90_Flat_k { get; set; }

        [ShearModulus]
        [Description("Mean shear modulus for edgewise shear parallel to the grain, G0,edge,mean in Eurocode.")]
        public virtual double G_0_Edge_Mean { get; set; }

        [ShearModulus]
        [Description("Mean shear modulus for flatwise shear parallel to the grain, G0,flat,mean in Eurocode.")]
        public virtual double G_0_Flat_Mean { get; set; }

        [ShearModulus]
        [Description("Mean shear modulus for flatwise shear perpendicular to the grain, G90,flat,mean in Eurocode.")]
        public virtual double G_90_Flat_Mean { get; set; }


        /***************************************************/
        /**** Properties - Strength                     ****/
        /***************************************************/

        [Stress]
        [Description("Edgewise bending Strength, parallel to the grain. Called fm,0,edge,k in Eurocode.")]
        public virtual double BendingStrengthEdgeParallel { get; set; }

        [Stress]
        [Description("Flatwise, bending Strength, parallel to the grain. Called fm,0,flat,k in Eurocode.")]
        public virtual double BendingStrengthFlatParallel { get; set; }

        [Stress]
        [Description("Flatwise, bending Strength, perpendicular to the grain. Called fm,90,flat,k in Eurocode.")]
        public virtual double BendingStrengthFlatPerpendicular { get; set; }

        [Description("Size effect parameter for strength.")]
        public virtual double SizeEffectParameter { get; set; }

        [Stress]
        [Description("Tensile Parallel Strength. Tension stress parallel to the grain at failure in net tension. Called ft,0,k in Eurocode.")]
        public virtual double TensileStrengthParallel { get; set; }

        [Stress]
        [Description("Edgewise tensile Perpendicular Strength. Tension stress perpendicular to the grain at failure in net tension. Called ft,90,edge,k in Eurocode.")]
        public virtual double TensileStrengthEdgePerpendicular { get; set; }

        [Stress]
        [Description("Flatwise tensile Perpendicular Strength. Tension stress perpendicular to the grain at failure in net tension. Called ft,90,flat,k in Eurocode.")]
        public virtual double TensileStrengthFlatPerpendicular { get; set; }

        [Stress]
        [Description("Compressive Parallel Strength. Compression stress parallel to the grain at failure in net compression. Called fc,0,k in Eurocode.")]
        public virtual double CompressiveStrengthParallel { get; set; }

        [Stress]
        [Description("Edgewise compressive Perpendicular Strength. Compression stress perpendicular to the grain at failure in net compression. Called fc,90,edge,k in Eurocode.")]
        public virtual double CompressiveStrengthEdgePerpendicular { get; set; }

        [Stress]
        [Description("Flatwise compressive Perpendicular Strength. Compression stress perpendicular to the grain at failure in net compression. Called fc,90,flat,k in Eurocode.")]
        public virtual double CompressiveStrengthFlatPerpendicular { get; set; }

        [Stress]
        [Description("Edgewise Shear Strength parallel. Shear stress parallel to the grain at failure in net shear for edgewise shearing. Called fv,0,edge,k in Eurocode.")]
        public virtual double ShearStrengthEdge { get; set; }

        [Stress]
        [Description("Flatwise Shear Strength parallel. Shear stress parallel to the grain at failure in net shear for flatwise shearing. Called fv,0,flat,k in Eurocode.")]
        public virtual double ShearStrengthFlatParallel { get; set; }

        [Stress]
        [Description("Flatwise Shear Strength parallel. Shear stress parallel to the grain at failure in net shear for flatwise shearing. Called fv,0,flat,k in Eurocode.")]
        public virtual double ShearStrengthFlatPerpendicular { get; set; }

        /***************************************************/
    }
}
