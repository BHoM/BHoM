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
    [Description("Structural timber material of type Laminated Veneer Lumber with crossband veneers. To be used on structural elements and properties, or as a fragment of the physical material.")]
    public class LVLC : BHoMObject, ITimber
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

        [YoungsModulus]
        [Description("Mean modulus of elasticity parallel to grain, E0,mean in Eurocode. Value same for Em,0,edge,mean, Et,0,mean, Em,0,flat,mean, and Ec,0,mean.")]
        public virtual double YoungsModulusParallelMean { get; set; }

        [YoungsModulus]
        [Description("Characteristic modulus of elasticity parallel to grain, E0,k in Eurocode. Value same for Em,0,edge,k, Et,0,k, Em,0,flat,k, and Ec,0,k.")]
        public virtual double YoungsModulusParallelCharacteristic { get; set; }

        [YoungsModulus]
        [Description("Edgewise mean modulus of elasticity perpendicular to grain, Ec,90,edge,mean in Eurocode. Value same for Et,90,edge,mean.")]
        public virtual double YoungsModulusPerpendicularEdgeMean { get; set; }

        [YoungsModulus]
        [Description("Edgewise characteristic modulus of elasticity perpendicular to grain, Ec,90,edge,k in Eurocode. Value same for Et,90,edge,k.")]
        public virtual double YoungsModulusPerpendicularEdgeCharacteristic { get; set; }

        [YoungsModulus]
        [Description("Flatwise mean modulus of elasticity perpendicular to grain, Em,90,flat,mean in Eurocode.")]
        public virtual double YoungsModulusPerpendicularFlatMean { get; set; }

        [YoungsModulus]
        [Description("Flatwise characteristic modulus of elasticity perpendicular to grain, Em,90,flat,k in Eurocode.")]
        public virtual double YoungsModulusPerpendicularFlatCharacteristic { get; set; }

        [ShearModulus]
        [Description("Edgewise mean shear modulus parallel to the grain, G0,edge,mean in Eurocode.")]
        public virtual double ShearModulusEdgeMean { get; set; }

        [ShearModulus]
        [Description("Edgewise characteristic shear modulus parallel to the grain, G0,edge,k in Eurocode.")]
        public virtual double ShearModulusEdgeCharacteristic { get; set; }

        [ShearModulus]
        [Description("Flatwise mean shear modulus parallel to the grain, G0,flat,mean in Eurocode.")]
        public virtual double ShearModulusParallelFlatMean { get; set; }

        [ShearModulus]
        [Description("Flatwise characteristic shear modulus parallel to the grain, G0,flat,k in Eurocode.")]
        public virtual double ShearModulusParallelFlatCharacteristic { get; set; }

        [ShearModulus]
        [Description("Flatwise mean shear modulus perpendicular to the grain, G90,flat,mean in Eurocode.")]
        public virtual double ShearModulusPerpendicularFlatMean { get; set; }

        [ShearModulus]
        [Description("Flatwise characteristic shear modulus perpendicular to the grain, G90,flat,k in Eurocode.")]
        public virtual double ShearModulusPerpendicularFlatCharacteristic { get; set; }


        /***************************************************/
        /**** Properties - Strength                     ****/
        /***************************************************/

        [Stress]
        [Description("Edgewise bending Strength, parallel to the grain. Called fm,0,edge,k in Eurocode.")]
        public virtual double BendingStrengthParallelEdge { get; set; }

        [Stress]
        [Description("Flatwise, bending Strength, parallel to the grain. Called fm,0,flat,k in Eurocode.")]
        public virtual double BendingStrengthParallelFlat { get; set; }

        [Stress]
        [Description("Flatwise, bending Strength, perpendicular to the grain. Called fm,90,flat,k in Eurocode.")]
        public virtual double BendingStrengthPerpendicularFlat { get; set; }

        [Stress]
        [Description("Tension Parallel Strength. Tension stress parallel to the grain at failure in net tension. Called ft,0,k in Eurocode.")]
        public virtual double TensionParallelStrength { get; set; }

        [Stress]
        [Description("Edgewise tension Perpendicular Strength. Tension stress perpendicular to the grain at failure in net tension. Called ft,90,edge,k in Eurocode.")]
        public virtual double TensionPerpendicularStrengthEdge { get; set; }

        [Stress]
        [Description("Compression Parallel Strength for service class 1. Compression stress parallel to the grain at failure in net compression. Called fc,0,k in Eurocode.")]
        public virtual double CompressionParallelStrengthSC1 { get; set; }

        [Stress]
        [Description("Compression Parallel Strength for service class 2. Value may also be applied in Service Class 1 as a conservative value. Compression stress parallel to the grain at failure in net compression. Called fc,0,k in Eurocode.")]
        public virtual double CompressionParallelStrengthSC2 { get; set; }

        [Stress]
        [Description("Edgewise compression Perpendicular Strength. Compression stress perpendicular to the grain at failure in net compression. Called fc,90,edge,k in Eurocode.")]
        public virtual double CompressionPerpendicularStrengthEdge { get; set; }

        [Stress]
        [Description("Flatwise compression Perpendicular Strength. Compression stress perpendicular to the grain at failure in net compression. Called ƒc,90,flat,k in Eurocode.")]
        public virtual double CompressionPerpendicularStrengthFlat { get; set; }

        [Stress]
        [Description("Edgewise Shear Strength parallel. Shear stress parallel to the grain at failure in net shear for edgewise shearing. Called fv,0,edge,k in Eurocode.")]
        public virtual double ShearStrengthParallelEdge { get; set; }

        [Stress]
        [Description("Flatwise Shear Strength parallel. Shear stress parallel to the grain at failure in net shear for flatwise shearing. Called fv,0,flat,k in Eurocode.")]
        public virtual double ShearStrengthParallelFlat { get; set; }

        [Stress]
        [Description("Flatwise Shear Strength perpendicular. Shear stress perpendicular to the grain at failure in net shear for flatwise shearing. Called fv,90,flat,k in Eurocode.")]
        public virtual double ShearStrengthPerpendicularFlat { get; set; }

        /***************************************************/

    }
}


