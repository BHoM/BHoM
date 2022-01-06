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
using BH.oM.Spatial.ShapeProfiles;
using BH.oM.Quantities.Attributes;
using System.ComponentModel;

namespace BH.oM.Structure.SectionProperties
{
    [Description("Timber section to be used on Bars. Defined by a section profile.")]
    public class TimberSection : BHoMObject, IGeometricalSection, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("A unique Name is required for some structural packages to create and identify the object.")]
        public override string Name { get; set; }

        [Description("Homogeneous material used throughout the full section.")]
        public virtual IMaterialFragment Material { get; set; } = null;

        /***************************************************/
        /**** Properties - Section profile              ****/
        /***************************************************/

        [Description("Profile of the section, containing dimensions and section geometry.")]
        public virtual IProfile SectionProfile { get; }

        /***************************************************/
        /**** Properties - Section constants            ****/
        /***************************************************/

        [Area]
        [Description("Gross Area of the cross section.")]
        public virtual double Area { get; }

        [Length]
        [Description("Radius of Gyration about the local Y-Axis.")]
        public virtual double Rgy { get; }

        [Length]
        [Description("Radius of Gyration about the local Z-Axis.")]
        public virtual double Rgz { get; }

        [TorsionConstant]
        [Description("Torsion Constant.")]
        public virtual double J { get; }

        [SecondMomentOfArea]
        [Description("Moment of Inertia about the local Y-Axis.")]
        public virtual double Iy { get; }

        [SecondMomentOfArea]
        [Description("Moment of Inertia about the local Z-Axis.")]
        public virtual double Iz { get; }

        [WarpingConstant]
        [Description("Warping Constant.")]
        public virtual double Iw { get; }

        [SectionModulus]
        [Description("Elastic Modulus of the section about the local Y-Axis.")]
        public virtual double Wely { get; }

        [SectionModulus]
        [Description("Elastic Modulus of the section about the local Z-Axis.")]
        public virtual double Welz { get; }

        [SectionModulus]
        [Description("Plastic Modulus of the section about the local Y-Axis.")]
        public virtual double Wply { get; }

        [SectionModulus]
        [Description("Plastic Modulus of the section about the local Z-Axis.")]
        public virtual double Wplz { get; }

        [Length]
        [Description("Geometric centre of the section in the local Z direction.")]
        public virtual double CentreZ { get; }

        [Length]
        [Description("Geometric centre of the section in the local Y direction.")]
        public virtual double CentreY { get; }

        [Length]
        [Description("Z distance from the centroid of the section to top edge of the section.")]
        public virtual double Vz { get; }

        [Length]
        [Description("Z distance from the centroid of the section to bottom edge of the section.")]
        public virtual double Vpz { get; }

        [Length]
        [Description("Y distance from the centroid of the section to right edge of the section.")]
        public virtual double Vy { get; }

        [Length]
        [Description("Y distance from the centroid of the section to Left edge of the section.")]
        public virtual double Vpy { get; }

        [Area]
        [Description("Shear Area in the local Y direction.")]
        public virtual double Asy { get; }

        [Area]
        [Description("Shear Area in the local Z direction.")]
        public virtual double Asz { get; }


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        //Main constructor setting all of the properties of the object
        public TimberSection(
            IProfile sectionProfile,

            double area,
            double rgy,
            double rgz,
            double j,
            double iy,
            double iz,
            double iw,
            double wely,
            double welz,
            double wply,
            double wplz,
            double centreZ,
            double centreY,
            double vz,
            double vpz,
            double vy,
            double vpy,
            double asy,
            double asz)

        {

            SectionProfile = sectionProfile;

            Area = area;
            Rgy = rgy;
            Rgz = rgz;
            J = j;
            Iy = iy;
            Iz = iz;
            Iw = iw;
            Wely = wely;
            Welz = welz;
            Wply = wply;
            Wplz = wplz;
            CentreZ = centreZ;
            CentreY = centreY;
            Vz = vz;
            Vpz = vpz;
            Vy = vy;
            Vpy = vpy;
            Asy = asy;
            Asz = asz;

        }

        /***************************************************/
    }
}




