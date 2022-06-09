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
    [Description("Constraint objects with three translational degrees of freedom, used for support of 2D analytical objects.")]
    public class Constraint3DOF : BHoMObject, IProperty
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("A unique Name is required for some structural packages to create and identify the object.")]
        public override string Name { get; set; }

        [Description("Defines the translational fixity in the X-direction.")]
        public virtual DOFType UX { get; set; }

        [Description("Defines the translational fixity in the Y-direction.")]
        public virtual DOFType UY { get; set; }

        [Description("Defines the translational fixity in the Z- or Normal-direction.")]
        public virtual DOFType Normal { get; set; }

        [ForcePerUnitLength]
        [Description("Defines the stiffness in X-direction. This will only be active when corresponding degree of freedom has a DOFType with a stiffness dependency, such as Spring.")]
        public virtual double KX { get; set; } = 0;

        [ForcePerUnitLength]
        [Description("Defines the stiffness in Y-direction. This will only be active when corresponding degree of freedom has a DOFType with a stiffness dependency, such as Spring.")]
        public virtual double KY { get; set; } = 0;

        [ForcePerUnitLength]
        [Description("Defines the stiffness in Z- or Normal-direction. This will only be active when corresponding degree of freedom has a DOFType with a stiffness dependency, such as Spring.")]
        public virtual double KNorm { get; set; } = 0;


        /***************************************************/
    }
}



