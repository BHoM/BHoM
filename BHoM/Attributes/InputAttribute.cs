/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2025, the respective contributors. All rights reserved.
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
using BH.oM.Base.Attributes.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BH.oM.Base.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor, AllowMultiple = true)]
    [Description("Attribute providing information about an input parameter of a method.")]
    public class InputAttribute : Attribute, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Name of the method parameter this attribute corresponds to.")]
        public virtual string Name { get; } = "";

        [Description("Description of the correspondent input parameter.")]
        public virtual string Description { get; } = "";

        [Description("Classification of the correspondent input parameter, e.g. folder path, quantity etc.")]
        public virtual ClassificationAttribute Classification { get; } = null;

        [Description("Information whether the correspondent input parameter is meant to be shown in the UI or not.")]
        public virtual UIExposure Exposure { get; } = UIExposure.Display; //Default to allow all input attributes to be exposed by default

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public InputAttribute(string name, string description)
        {
            Name = name;
            Description = description;
        }

        /***************************************************/

        public InputAttribute(string name, string description, UIExposure exposure) : this(name, description)
        {
            Exposure = exposure;
        }

        /***************************************************/

        public InputAttribute(string name, string description, Type classification) : this(name, description)
        {
            if (classification != null && typeof(ClassificationAttribute).IsAssignableFrom(classification) && !classification.IsAbstract)
            {
                Classification = (ClassificationAttribute)Activator.CreateInstance(classification);
            }
        }

        /***************************************************/

        public InputAttribute(string name, string description, Type classification, UIExposure exposure) : this(name, description, classification)
        {
            Exposure = exposure;
        }

        /***************************************************/

        public InputAttribute(string name, string description, ClassificationAttribute classification, UIExposure exposure)
        {
            Name = name;
            Description = description;
            Classification = classification;
            Exposure = exposure;
        }

        /***************************************************/
    }
}






