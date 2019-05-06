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

using BH.oM.Base;
using BH.oM.Physical.Materials;

namespace BH.oM.Structure.Properties.Section
{
    public class ExplicitSection : BHoMObject, ISectionProperty
    {

        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Material Material { get; set; } = null;

        /// <summary>
        /// Gross Area of the cross section
        /// </summary>
        public double Area { get; set; } = 0;

        /// <summary>
        /// Radius of Gyration about the Y-Axis
        /// </summary>
        public double Rgy { get; set; } = 0;

        /// <summary>
        /// Radius of Gyration about the Z-Axis
        /// </summary>
        public double Rgz { get; set; } = 0;

        /// <summary>
        /// Torsion Constant
        /// </summary>
        public double J { get; set; } = 0;

        /// <summary>
        /// Moment of Inertia about the Y-Axis
        /// </summary>
        public double Iy { get; set; } = 0;

        /// <summary>
        /// Moment of Inertia about the Z-Axis
        /// </summary>
        public double Iz { get; set; } = 0;

        /// <summary>
        /// Warping Constant
        /// </summary>
        public double Iw { get; set; } = 0;

        /// <summary>
        /// Elastic Modulus of the section about the Y-Axis
        /// </summary>
        public double Wely { get; set; } = 0;

        /// <summary>
        /// Elastic Modulus of the section about the Z-Axis
        /// </summary>
        public double Welz { get; set; } = 0;
        /// <summary>
        /// Plastic Modulus of the section about the Y-Axis
        /// </summary>
        public double Wply { get; set; } = 0;

        /// <summary>
        /// Plastic Modulus of the section about the Z-Axis
        /// </summary>
        public double Wplz { get; set; } = 0;
        /// <summary>
        /// Geometric centre of the section in the Z direction
        /// </summary>
        public double CentreZ { get; set; } = 0;
        /// <summary>
        /// Geometric centre of the section in the Y direction
        /// </summary>
        public double CentreY { get; set; } = 0;

        /// <summary>
        /// Z Distance from the centroid of the section to top edge of the section
        /// </summary>
        public double Vz { get; set; } = 0;

        /// <summary>
        /// Z Distance from the centroid of the section to bottom edge of the section
        /// </summary>
        public double Vpz { get; set; } = 0;
        /// <summary>
        /// Y Distance from the centroid of the section to right edge of the section
        /// </summary>
        public double Vy { get; set; } = 0;
        /// <summary>
        /// Y Distance from the centroid of the section to Left edge of the section
        /// </summary>
        public double Vpy { get; set; } = 0;

        /// <summary>
        /// Shear Area in the Y direction
        /// </summary>
        public double Asy { get; set; } = 0;

        /// <summary>
        /// Shear Area in the Z direction
        /// </summary>
        public double Asz { get; set; } = 0;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public ExplicitSection()
        {

        }
    }
}
