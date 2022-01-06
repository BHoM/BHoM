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

        [Description("A unique Name is required for some structural packages to create and identify the object.")]
        public override string Name { get; set; }

        [Description("Material of the section.")]
        public virtual IMaterialFragment Material { get; set; } = null;

        [Area]
        [Description("Gross Area of the cross section.")]
        public virtual double Area { get; set; } = 0;

        [Length]
        [Description("Radius of Gyration about the local Y-Axis.")]
        public virtual double Rgy { get; set; } = 0;

        [Length]
        [Description("Radius of Gyration about the local Z-Axis.")]
        public virtual double Rgz { get; set; } = 0;

        [TorsionConstant]
        [Description("Torsion Constant.")]
        public virtual double J { get; set; } = 0;

        [SecondMomentOfArea]
        [Description("Moment of Inertia about the local Y-Axis.")]
        public virtual double Iy { get; set; } = 0;

        [SecondMomentOfArea]
        [Description("Moment of Inertia about the local Z-Axis.")]
        public virtual double Iz { get; set; } = 0;

        [WarpingConstant]
        [Description("Warping Constant.")]
        public virtual double Iw { get; set; } = 0;

        [SectionModulus]
        [Description("Elastic Modulus of the section about the local Y-Axis.")]
        public virtual double Wely { get; set; } = 0;

        [SectionModulus]
        [Description("Elastic Modulus of the section about the local Z-Axis.")]
        public virtual double Welz { get; set; } = 0;

        [SectionModulus]
        [Description("Plastic Modulus of the section about the local Y-Axis.")]
        public virtual double Wply { get; set; } = 0;

        [SectionModulus]
        [Description("Plastic Modulus of the section about the local Z-Axis.")]
        public virtual double Wplz { get; set; } = 0;

        [Length]
        [Description("Geometric centre of the section in the local Z direction.")]
        public virtual double CentreZ { get; set; } = 0;

        [Length]
        [Description("Geometric centre of the section in the local Y direction.")]
        public virtual double CentreY { get; set; } = 0;

        [Length]
        [Description("Z distance from the centroid of the section to top edge of the section.")]
        public virtual double Vz { get; set; } = 0;

        [Length]
        [Description("Z distance from the centroid of the section to bottom edge of the section.")]
        public virtual double Vpz { get; set; } = 0;

        [Length]
        [Description("Y distance from the centroid of the section to right edge of the section.")]
        public virtual double Vy { get; set; } = 0;

        [Length]
        [Description("Y distance from the centroid of the section to Left edge of the section.")]
        public virtual double Vpy { get; set; } = 0;

        [Area]
        [Description("Shear Area in the local Y direction.")]
        public virtual double Asy { get; set; } = 0;

        [Area]
        [Description("Shear Area in the local Z direction.")]
        public virtual double Asz { get; set; } = 0;

        /***************************************************/
    }
}



