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
    [Description("Base interface for all bar section properties. Contains the material and all section constants.")]
    public interface ISectionProperty : IBHoMObject, IProperty
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Material of the section.")]
        IMaterialFragment Material { get; set; }

        [Area]
        [Description("Gross Area of the cross section.")]
        double Area { get; }

        [Length]
        [Description("Radius of Gyration about the local Y-Axis.")]
        double Rgy { get; }

        [Length]
        [Description("Radius of Gyration about the local Z-Axis.")]
        double Rgz { get; }

        [TorsionConstant]
        [Description("Torsion Constant.")]
        double J { get; }

        [SecondMomentOfArea]
        [Description("Moment of Inertia about the local Y-Axis.")]
        double Iy { get; }

        [SecondMomentOfArea]
        [Description("Moment of Inertia about the local Z-Axis.")]
        double Iz { get; }

        [WarpingConstant]
        [Description("Warping Constant.")]
        double Iw { get; }

        [SectionModulus]
        [Description("Elastic Modulus of the section about the local Y-Axis.")]
        double Wely { get; }

        [SectionModulus]
        [Description("Elastic Modulus of the section about the local Z-Axis.")]
        double Welz { get; }

        [SectionModulus]
        [Description("Plastic Modulus of the section about the local Y-Axis.")]
        double Wply { get; }

        [SectionModulus]
        [Description("Plastic Modulus of the section about the local Z-Axis.")]
        double Wplz { get; }

        [Length]
        [Description("Geometric centre of the section in the local Z direction.")]
        double CentreZ { get; }

        [Length]
        [Description("Geometric centre of the section in the local Y direction.")]
        double CentreY { get; }

        [Length]
        [Description("Z distance from the centroid of the section to top edge of the section.")]
        double Vz { get; }

        [Length]
        [Description("Z distance from the centroid of the section to bottom edge of the section.")]
        double Vpz { get; }

        [Length]
        [Description("Y distance from the centroid of the section to right edge of the section.")]
        double Vy { get; }

        [Length]
        [Description("Y distance from the centroid of the section to Left edge of the section.")]
        double Vpy { get; }

        [Area]
        [Description("Shear Area in the local Y direction.")]
        double Asy { get; }

        [Area]
        [Description("Shear Area in the local Z direction.")]
        double Asz { get; }

        /***************************************************/
    }
}



