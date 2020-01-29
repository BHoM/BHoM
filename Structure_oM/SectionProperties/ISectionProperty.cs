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

namespace BH.oM.Structure.SectionProperties
{
    [Description("Base interface for all bar section properties. Contains the material and all section constants")]
    public interface ISectionProperty : IBHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Material of the section")]
        IMaterialFragment Material { get; set; }

        [Description("Gross Area of the cross section")]
        double Area { get; }

        [Description("Radius of Gyration about the local Y-Axis")]
        double Rgy { get; }

        [Description("Radius of Gyration about the local Z-Axis")]
        double Rgz { get; }

        [Description("Torsion Constant")]
        double J { get; }

        [Description("Moment of Inertia about the local Y-Axis")]
        double Iy { get; }

        [Description("Moment of Inertia about the local Z-Axis")]
        double Iz { get; }

        [Description("Warping Constant")]
        double Iw { get; }

        [Description("Elastic Modulus of the section about the local Y-Axis")]
        double Wely { get; }

        [Description("Elastic Modulus of the section about the local Z-Axis")]
        double Welz { get; }

        [Description("Plastic Modulus of the section about the local Y-Axis")]
        double Wply { get; }

        [Description("Plastic Modulus of the section about the local Z-Axis")]
        double Wplz { get; }

        [Description("Geometric centre of the section in the local Z direction")]
        double CentreZ { get; }

        [Description("Geometric centre of the section in the local Y direction")]
        double CentreY { get; }

        [Description("Z Distance from the centroid of the section to top edge of the section")]
        double Vz { get; }

        [Description("Z Distance from the centroid of the section to bottom edge of the section")]
        double Vpz { get; }

        [Description("Y Distance from the centroid of the section to right edge of the section")]
        double Vy { get; }

        [Description("Y Distance from the centroid of the section to Left edge of the section")]
        double Vpy { get; }

        [Description("Shear Area in the local Y direction")]
        double Asy { get; }

        [Description("Shear Area in the local Z direction")]
        double Asz { get; }

        /***************************************************/
    }
}

