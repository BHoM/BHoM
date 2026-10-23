/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2026, the respective contributors. All rights reserved.
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using BH.oM.Base;
using BH.oM.Base.Attributes;

namespace BH.oM.LifeCycleAssessment
{
    [Description("Attribute applied to a Module to define that it is a part of a combination module, where the value of the combination module is the sum of the values of its parts.\nOnly the combination module that the module is directly a part of is to be specified. Combination modules can in turn be parts of other combination modules, which makes the combinations recursive, e.g. B1 is part of B1toB3, which in turn is part of B1toB5.")]
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class PartOfAttribute : Attribute
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("The combination module that the module is directly a part of. The value of this combination module is the sum of the values of all its parts.")]
        public virtual Module PartOf { get; set; }

        [Description("Defines whether the module is required to have a value for the combination module to be computed.\nIf true, the combination module can only be computed if this module has a value.\nIf false, this module is included in the combination module if it has a value, but the combination module can be computed without it. A combination module made up of only non-required parts can only be computed if at least one of its parts has a value.")]
        public virtual bool IsRequired { get; set; } = true;

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        [Description("Creates an attribute defining the combination module that the annotated module is a part of.")]
        public PartOfAttribute(Module partOf, bool isRequired = true)
        {
            PartOf = partOf;
            IsRequired = isRequired;
        }
    }
}





