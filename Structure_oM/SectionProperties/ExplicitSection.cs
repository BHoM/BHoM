/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2020, the respective contributors. All rights reserved.
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
using BH.oM.Structure.MaterialFragments;
using System.ComponentModel;
using BH.oM.Quantities.Attributes;

namespace BH.oM.Structure.SectionProperties
{
    [Description("Material agnostic section. Does not own any geometry. Allows explicit setting of all section constants.")]
    public class ExplicitSection : BHoMObject, ISectionProperty
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Material of the section.")]
        public IMaterialFragment Material { get; set; } = null;

        [Area]
        [Description("Gross Area of the cross section.")]
        public double Area { get; set; } = 0;

        [Length]
        [Description("Radius of Gyration about the local Y-Axis.")]
        public double Rgy { get; set; } = 0;

        [Length]
        [Description("Radius of Gyration about the local Z-Axis.")]
        public double Rgz { get; set; } = 0;

        [TorsionConstant]
        [Description("Torsion Constant.")]
        public double J { get; set; } = 0;

        [SecondMomentOfArea]
        [Description("Moment of Inertia about the local Y-Axis.")]
        public double Iy { get; set; } = 0;

        [SecondMomentOfArea]
        [Description("Moment of Inertia about the local Z-Axis.")]
        public double Iz { get; set; } = 0;

        [WarpingConstant]
        [Description("Warping Constant.")]
        public double Iw { get; set; } = 0;

        [SectionModulus]
        [Description("Elastic Modulus of the section about the local Y-Axis.")]
        public double Wely { get; set; } = 0;

        [SectionModulus]
        [Description("Elastic Modulus of the section about the local Z-Axis.")]
        public double Welz { get; set; } = 0;

        [SectionModulus]
        [Description("Plastic Modulus of the section about the local Y-Axis.")]
        public double Wply { get; set; } = 0;

        [SectionModulus]
        [Description("Plastic Modulus of the section about the local Z-Axis.")]
        public double Wplz { get; set; } = 0;

        [Length]
        [Description("Geometric centre of the section in the local Z direction.")]
        public double CentreZ { get; set; } = 0;

        [Length]
        [Description("Geometric centre of the section in the local Y direction.")]
        public double CentreY { get; set; } = 0;

        [Length]
        [Description("Z distance from the centroid of the section to top edge of the section.")]
        public double Vz { get; set; } = 0;

        [Length]
        [Description("Z distance from the centroid of the section to bottom edge of the section.")]
        public double Vpz { get; set; } = 0;

        [Length]
        [Description("Y distance from the centroid of the section to right edge of the section.")]
        public double Vy { get; set; } = 0;

        [Length]
        [Description("Y distance from the centroid of the section to Left edge of the section.")]
        public double Vpy { get; set; } = 0;

        [Area]
        [Description("Shear Area in the local Y direction.")]
        public double Asy { get; set; } = 0;

        [Area]
        [Description("Shear Area in the local Z direction.")]
        public double Asz { get; set; } = 0;

        /***************************************************/
    }
}

