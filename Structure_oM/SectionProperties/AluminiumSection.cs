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
using BH.oM.Geometry.ShapeProfiles;
using System.ComponentModel;

namespace BH.oM.Structure.SectionProperties
{
    [Description("Aluminium section to be used on Bars. Defined by a section profile")]
    public class AluminiumSection : BHoMObject, IGeometricalSection, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Material of the section")]
        public IMaterialFragment Material { get; set; } = null;

        /***************************************************/
        /**** Properties - Section profile              ****/
        /***************************************************/

        [Description("Profile of the section, containing dimensions and section geometry")]
        public IProfile SectionProfile { get; }

        /***************************************************/
        /**** Properties - Section constants            ****/
        /***************************************************/

        [Description("Gross Area of the cross section")]
        public double Area { get; }

        [Description("Radius of Gyration about the local Y-Axis")]
        public double Rgy { get; }

        [Description("Radius of Gyration about the local Z-Axis")]
        public double Rgz { get; }

        [Description("Torsion Constant")]
        public double J { get; }

        [Description("Moment of Inertia about the local Y-Axis")]
        public double Iy { get; }

        [Description("Moment of Inertia about the local Z-Axis")]
        public double Iz { get; }

        [Description("Warping Constant")]
        public double Iw { get; }

        [Description("Elastic Modulus of the section about the local Y-Axis")]
        public double Wely { get; }

        [Description("Elastic Modulus of the section about the local Z-Axis")]
        public double Welz { get; }

        [Description("Plastic Modulus of the section about the local Y-Axis")]
        public double Wply { get; }

        [Description("Plastic Modulus of the section about the local Z-Axis")]
        public double Wplz { get; }

        [Description("Geometric centre of the section in the local Z direction")]
        public double CentreZ { get; }

        [Description("Geometric centre of the section in the local Y direction")]
        public double CentreY { get; }

        [Description("Z Distance from the centroid of the section to top edge of the section")]
        public double Vz { get; }

        [Description("Z Distance from the centroid of the section to bottom edge of the section")]
        public double Vpz { get; }

        [Description("Y Distance from the centroid of the section to right edge of the section")]
        public double Vy { get; }

        [Description("Y Distance from the centroid of the section to Left edge of the section")]
        public double Vpy { get; }

        [Description("Shear Area in the local Y direction")]
        public double Asy { get; }

        [Description("Shear Area in the local Z direction")]
        public double Asz { get; }


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        //Main constructor setting all of the properties of the object
        public AluminiumSection(
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


