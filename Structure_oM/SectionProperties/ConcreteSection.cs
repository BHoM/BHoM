/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2018, the respective contributors. All rights reserved.
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

namespace BH.oM.Structure.SectionProperties
{

    public class ConcreteSection : BHoMObject, IGeometricalSection, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<Reinforcement.Reinforcement> Reinforcement { get; set; }

        public double MinimumCover { get; }  //TODO: Do we need this property or should it be a BHoM_Engine query?

        public IMaterialFragment Material { get; set; }


        /***************************************************/
        /**** Properties - Section dimensions           ****/
        /***************************************************/

        public IProfile SectionProfile { get; }


        /***************************************************/
        /**** Properties - Section constants            ****/
        /***************************************************/

        /// <summary>
        /// Gross Area of the cross section
        /// Uncracked section disregarding the reinforcement.
        /// </summary>
        public double Area { get; } = 0;

        /// <summary>
        /// Radius of Gyration about the Y-Axis
        /// Uncracked section disregarding the reinforcement.
        /// </summary>
        public double Rgy { get; } = 0;

        /// <summary>
        /// Radius of Gyration about the Z-Axis
        /// Uncracked section disregarding the reinforcement.
        /// </summary>
        public double Rgz { get; } = 0;

        /// <summary>
        /// Torsion Constant
        /// Uncracked section disregarding the reinforcement.
        /// </summary>
        public double J { get; } = 0;

        /// <summary>
        /// Moment of Inertia about the Y-Axis
        /// Uncracked section disregarding the reinforcement.
        /// </summary>
        public double Iy { get; } = 0;

        /// <summary>
        /// Moment of Inertia about the Z-Axis
        /// Uncracked section disregarding the reinforcement.
        /// </summary>
        public double Iz { get; } = 0;

        /// <summary>
        /// Warping Constant
        /// Uncracked section disregarding the reinforcement.
        /// </summary>
        public double Iw { get; } = 0;

        /// <summary>
        /// Elastic Modulus of the section about the Y-Axis
        /// Uncracked section disregarding the reinforcement.
        /// </summary>
        public double Wely { get; } = 0;

        /// <summary>
        /// Elastic Modulus of the section about the Z-Axis
        /// Uncracked section disregarding the reinforcement.
        /// </summary>
        public double Welz { get; } = 0;
        /// <summary>
        /// Plastic Modulus of the section about the Y-Axis
        /// Uncracked section disregarding the reinforcement.
        /// </summary>
        public double Wply { get; } = 0;

        /// <summary>
        /// Plastic Modulus of the section about the Z-Axis
        /// Uncracked section disregarding the reinforcement.
        /// </summary>
        public double Wplz { get; } = 0;
        /// <summary>
        /// Geometric centre of the section in the Z direction
        /// Uncracked section disregarding the reinforcement.
        /// </summary>
        public double CentreZ { get; } = 0;
        /// <summary>
        /// Geometric centre of the section in the Y direction
        /// Uncracked section disregarding the reinforcement.
        /// </summary>
        public double CentreY { get; } = 0;

        /// <summary>
        /// Z Distance from the centroid of the section to top edge of the section
        /// Uncracked section disregarding the reinforcement.
        /// </summary>
        public double Vz { get; } = 0;

        /// <summary>
        /// Z Distance from the centroid of the section to bottom edge of the section
        /// Uncracked section disregarding the reinforcement.
        /// </summary>
        public double Vpz { get; } = 0;
        /// <summary>
        /// Y Distance from the centroid of the section to right edge of the section
        /// Uncracked section disregarding the reinforcement.
        /// </summary>
        public double Vy { get; } = 0;
        /// <summary>
        /// Y Distance from the centroid of the section to Left edge of the section
        /// Uncracked section disregarding the reinforcement.
        /// </summary>
        public double Vpy { get; } = 0;

        /// <summary>
        /// Shear Area in the Y direction
        /// Uncracked section disregarding the reinforcement.
        /// </summary>
        public double Asy { get; } = 0;

        /// <summary>
        /// Shear Area in the Z direction
        /// Uncracked section disregarding the reinforcement.
        /// </summary>
        public double Asz { get; } = 0;


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


