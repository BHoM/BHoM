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
using BH.oM.Structure.MaterialFragments;

namespace BH.oM.Structure.SectionProperties
{
    public interface ISectionProperty : IBHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        IMaterialFragment Material { get; set; }

        /// <summary>
        /// Gross Area of the cross section
        /// </summary>
        double Area { get; }

        /// <summary>
        /// Radius of Gyration about the Y-Axis
        /// </summary>
        double Rgy { get; }

        /// <summary>
        /// Radius of Gyration about the Z-Axis
        /// </summary>
        double Rgz { get; }

        /// <summary>
        /// Torsion Constant
        /// </summary>
        double J { get; }

        /// <summary>
        /// Moment of Inertia about the Y-Axis
        /// </summary>
        double Iy { get; }

        /// <summary>
        /// Moment of Inertia about the Z-Axis
        /// </summary>
        double Iz { get; }

        /// <summary>
        /// Warping Constant
        /// </summary>
        double Iw { get; }

        /// <summary>
        /// Elastic Modulus of the section about the Y-Axis
        /// </summary>
        double Wely { get; }

        /// <summary>
        /// Elastic Modulus of the section about the Z-Axis
        /// </summary>
        double Welz { get; }
        /// <summary>
        /// Plastic Modulus of the section about the Y-Axis
        /// </summary>
        double Wply { get; }

        /// <summary>
        /// Plastic Modulus of the section about the Z-Axis
        /// </summary>
        double Wplz { get; }
        /// <summary>
        /// Geometric centre of the section in the Z direction
        /// </summary>
        double CentreZ { get; }
        /// <summary>
        /// Geometric centre of the section in the Y direction
        /// </summary>
        double CentreY { get; }

        /// <summary>
        /// Z Distance from the centroid of the section to top edge of the section
        /// </summary>
        double Vz { get; }

        /// <summary>
        /// Z Distance from the centroid of the section to bottom edge of the section
        /// </summary>
        double Vpz { get; }
        /// <summary>
        /// Y Distance from the centroid of the section to right edge of the section
        /// </summary>
        double Vy { get; }
        /// <summary>
        /// Y Distance from the centroid of the section to Left edge of the section
        /// </summary>
        double Vpy { get; }

        /// <summary>
        /// Shear Area in the Y direction
        /// </summary>
        double Asy { get; }

        /// <summary>
        /// Shear Area in the Z direction
        /// </summary>
        double Asz { get; }

        /***************************************************/
    }
}
