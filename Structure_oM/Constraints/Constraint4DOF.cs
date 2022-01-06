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

using System.ComponentModel;
using BH.oM.Base;
using BH.oM.Quantities.Attributes;

namespace BH.oM.Structure.Constraints
{
    [Description("Constraint objects with four degrees of freedom, three translational and one rotational. Used for support or release of 1D analytical elements of 2D analytical objects. The Rotational DOF will correspond to rotation about the axis of the object.")]
    public class Constraint4DOF : BHoMObject, IProperty
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("A unique Name is required for some structural packages to create and identify the object.")]
        public override string Name { get; set; }

        [Description("Defines the translational fixity in the X-direction.")]
        public virtual DOFType TranslationX { get; set; } = DOFType.Free;

        [Description("Defines the translational fixity in the Y-direction.")]
        public virtual DOFType TranslationY { get; set; } = DOFType.Free;

        [Description("Defines the translational fixity in the Z-direction.")]
        public virtual DOFType TranslationZ { get; set; } = DOFType.Free;

        [Description("Defines the rotational fixity about the axis of the element.")]
        public virtual DOFType RotationX { get; set; } = DOFType.Free;

        [ForcePerUnitLength]
        [Description("Defines the stiffness in X-direction. This will only be active when corresponding degree of freedom has a DOFType with a stiffness dependency, such as Spring.")]
        public virtual double TranslationalStiffnessX { get; set; } = 0;

        [ForcePerUnitLength]
        [Description("Defines the stiffness in Y-direction. This will only be active when corresponding degree of freedom has a DOFType with a stiffness dependency, such as Spring.")]
        public virtual double TranslationalStiffnessY { get; set; } = 0;

        [ForcePerUnitLength]
        [Description("Defines the stiffness in Z-direction. This will only be active when corresponding degree of freedom has a DOFType with a stiffness dependency, such as Spring.")]
        public virtual double TranslationalStiffnessZ { get; set; } = 0;

        [MomentPerUnitAngle]
        [Description("Defines the stiffness for rotation about the axis of the element. This will only be active when corresponding degree of freedom has a DOFType with a stiffness dependency, such as Spring.")]
        public virtual double RotationalStiffnessX { get; set; } = 0;


        /***************************************************/
    }

}



