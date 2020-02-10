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

using BH.oM.Geometry;
using BH.oM.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BH.oM.Structure.MaterialFragments;
using BH.oM.Geometry.ShapeProfiles;
using System.ComponentModel;
using BH.oM.Quantities.Attributes;

namespace BH.oM.Structure.SectionProperties
{
    [Description("Concrete section to be used on Bars. Defined by a section profile. Note that all section constants are assuming an uncracked section and are disregarding reinforcement.")]
    public class ConcreteSection : BHoMObject, IGeometricalSection, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("List of Reinforcement of the concrete section.")]
        public List<Reinforcement.Reinforcement> Reinforcement { get; set; }

        [Length]
        [Description("Minimum reinforcement cover of the section.")]
        public double MinimumCover { get; }  //TODO: Do we need this property or should it be a BHoM_Engine query?

        [Description("Concrete material used throughout the full section.")]
        public IMaterialFragment Material { get; set; }

        /***************************************************/
        /**** Properties - Section dimensions           ****/
        /***************************************************/

        [Description("Profile of the section, containing dimensions and section geometry.")]
        public IProfile SectionProfile { get; }


        /***************************************************/
        /**** Properties - Section constants            ****/
        /***************************************************/

        [Area]
        [Description("Gross Area of the cross section"
            + "\n Uncracked section disregarding the reinforcement.")]
        public double Area { get; }

        [Length]
        [Description("Radius of Gyration about the local Y-Axis"
            + "\n Uncracked section disregarding the reinforcement.")]
        public double Rgy { get; }

        [Length]
        [Description("Radius of Gyration about the local Z-Axis"
            + "\n Uncracked section disregarding the reinforcement.")]
        public double Rgz { get; }

        [TorsionConstant]
        [Description("Torsion Constant"
            + "\n Uncracked section disregarding the reinforcement.")]
        public double J { get; }

        [SecondMomentOfArea]
        [Description("Moment of Inertia about the local Y-Axis"
            + "\n Uncracked section disregarding the reinforcement.")]
        public double Iy { get; }

        [SecondMomentOfArea]
        [Description("Moment of Inertia about the local Z-Axis"
            + "\n Uncracked section disregarding the reinforcement.")]
        public double Iz { get; }

        [WarpingConstant]
        [Description("Warping Constant"
            + "\n Uncracked section disregarding the reinforcement.")]
        public double Iw { get; }

        [SectionModulus]
        [Description("Elastic Modulus of the section about the local Y-Axis"
            + "\n Uncracked section disregarding the reinforcement.")]
        public double Wely { get; }

        [SectionModulus]
        [Description("Elastic Modulus of the section about the local Z-Axis"
            + "\n Uncracked section disregarding the reinforcement.")]
        public double Welz { get; }

        [SectionModulus]
        [Description("Plastic Modulus of the section about the local Y-Axis"
            + "\n Uncracked section disregarding the reinforcement.")]
        public double Wply { get; }

        [SectionModulus]
        [Description("Plastic Modulus of the section about the local Z-Axis"
            + "\n Uncracked section disregarding the reinforcement.")]
        public double Wplz { get; }

        [Length]
        [Description("Geometric centre of the section in the local Z direction" 
            + "\n Uncracked section disregarding the reinforcement.")]
        public double CentreZ { get; }

        [Length]
        [Description("Geometric centre of the section in the local Y direction" 
            + "\n Uncracked section disregarding the reinforcement.")]
        public double CentreY { get; }

        [Length]
        [Description("Z distance from the centroid of the section to top edge of the section"
            + "\n Uncracked section disregarding the reinforcement.")]
        public double Vz { get; }

        [Length]
        [Description("Z distance from the centroid of the section to bottom edge of the section"
            + "\n Uncracked section disregarding the reinforcement.")]
        public double Vpz { get; }

        [Length]
        [Description("Y distance from the centroid of the section to right edge of the section"
            + "\n Uncracked section disregarding the reinforcement.")]
        public double Vy { get; }

        [Length]
        [Description("Y distance from the centroid of the section to Left edge of the section"
            + "\n Uncracked section disregarding the reinforcement.")]
        public double Vpy { get; }

        [Length]
        [Description("Shear Area in the local Y direction"
            + "\n Uncracked section disregarding the reinforcement.")]
        public double Asy { get; }

        [Length]
        [Description("Shear Area in the local Z direction" 
            + "\n Uncracked section disregarding the reinforcement.")]
        public double Asz { get; }


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public ConcreteSection(             //Main constructor setting all of the properties of the object

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



