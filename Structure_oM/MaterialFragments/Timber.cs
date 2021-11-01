/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2021, the respective contributors. All rights reserved.
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

        [Description("A unique Name is required for some structural packages to create and identify the object.")]
        public override string Name { get; set; }

        [Density]
        public virtual double Density { get; set; }

        [Ratio]
        [Description("Dynamic damping ratio, expressed as a ratio between actual damping and critical damping. For structures, typically taken as 0.02 (i.e. 2%).")]
        public virtual double DampingRatio { get; set; }

        [YoungsModulus]
        [Description("Modulus of elasticity of the material. Ratio between axial stress and axial strain.")]
        public virtual Vector YoungsModulus { get; set; }

        [Ratio]
        [Description("Ratio between axial and transverse strain.")]
        public virtual Vector PoissonsRatio { get; set; }

        [ThermalExpansionCoefficient]
        [Description("The strain induced in the material per unit change of temperature.")]
        public virtual Vector ThermalExpansionCoeff { get; set; }

        [ShearModulus]
        [Description("The shear modulus or modulus of rigidity. Defined as the ratio between shear stress and shear strain.")]
        public virtual Vector ShearModulus { get; set; }

        [Description("Bending Strength or F_b. Defined as the tension stress parallel to the grain at failure resulting from bending stresses")]
        public virtual double BendingStrength { get; set; }

        [Description("Tension Parallel Strength or F_t. Defined as the tension stress parallel to the grain at failure")]
        public virtual double ParallelTensionStrength { get; set; }

        [Description("Compression Parallel Strength or F_cll. Defined as the compression stress parallel to the grain at failure")]
        public virtual double PerpendicularCompressionStrength { get; set; }

        [Description("Compression Perpendicular Strength or F_cperp. Defined as the compression stress perpendicular to the grain at failure")]
        public virtual double ParallelCompressionStrength { get; set; }

        [Description("Shear Strength or F_v. Defined as the shear stress in the 1-3 or 1-2 plane, relevant to beam bending.")]
        public virtual double ShearStrength { get; set; }

        /***************************************************/

    }
}

