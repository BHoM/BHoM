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

using System.ComponentModel;
using BH.oM.Base;
using BH.oM.Quantities.Attributes;

namespace BH.oM.Structure.Constraints
{

    [Description("Constraint objects with six degrees of freedom, three translational and three rotational, used for supports and bar end releases.")]
    public class Constraint6DOF : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [ForcePerUnitLength]
        [Description("Defines the stiffness in X-direction. This will only be active when corresponding degree of freedom has a DOFType with a stiffness dependency, such as Spring.")]
        public double TranslationalStiffnessX { get; set; } = 0;

        [ForcePerUnitLength]
        [Description("Defines the stiffness in Y-direction. This will only be active when corresponding degree of freedom has a DOFType with a stiffness dependency, such as Spring.")]
        public double TranslationalStiffnessY { get; set; } = 0;

        [ForcePerUnitLength]
        [Description("Defines the stiffness in Z-direction. This will only be active when corresponding degree of freedom has a DOFType with a stiffness dependency, such as Spring.")]
        public double TranslationalStiffnessZ { get; set; } = 0;

        [MomentPerUnitAngle]
        [Description("Defines the stiffness for rotation about the X-axis. This will only be active when corresponding degree of freedom has a DOFType with a stiffness dependency, such as Spring.")]
        public double RotationalStiffnessX { get; set; } = 0;

        [MomentPerUnitAngle]
        [Description("Defines the stiffness for rotation about the Y-axis. This will only be active when corresponding degree of freedom has a DOFType with a stiffness dependency, such as Spring.")]
        public double RotationalStiffnessY { get; set; } = 0;

        [MomentPerUnitAngle]
        [Description("Defines the stiffness for rotation about the Z-axis. This will only be active when corresponding degree of freedom has a DOFType with a stiffness dependency, such as Spring.")]
        public double RotationalStiffnessZ { get; set; } = 0;

        [Description("Defines the translational fixity in the X-direction.")]
        public DOFType TranslationX { get; set; } = DOFType.Free;

        [Description("Defines the translational fixity in the Y-direction.")]
        public DOFType TranslationY { get; set; } = DOFType.Free;

        [Description("Defines the translational fixity in the Z-direction.")]
        public DOFType TranslationZ { get; set; } = DOFType.Free;

        [Description("Defines the rotational fixity about the X-axis.")]
        public DOFType RotationX { get; set; } = DOFType.Free;

        [Description("Defines the rotational fixity about the Y-axis.")]
        public DOFType RotationY { get; set; } = DOFType.Free;

        [Description("Defines the rotational fixity about the Z-axis.")]
        public DOFType RotationZ { get; set; } = DOFType.Free;


        /***************************************************/
    }
}


