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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BH.oM.Base.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor)]
    [Description("Attribute providing information about an output parameter of a method." +
                 "\nTo be applied to all methods that do not return void nor BH.oM.Base.Output types.")]
    public class OutputAttribute : Attribute, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Name of the correspondent output parameter (to be used in the UI).")]
        public virtual string Name { get; } = "";

        [Description("Description of the correspondent output parameter.")]
        public virtual string Description { get; } = "";

        [Description("Classification of the correspondent output parameter, e.g. folder path, quantity etc.")]
        public virtual ClassificationAttribute Classification { get; } = null;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public OutputAttribute(string description)
        {
            Description = description;
        }

        /***************************************************/

        public OutputAttribute(string name, string description)
        {
            Name = name;
            Description = description;
        }

        /***************************************************/

        public OutputAttribute(string name, string description, Type classification) : this(name, description)
        {
            if (classification != null && typeof(ClassificationAttribute).IsAssignableFrom(classification) && !classification.IsAbstract)
            {
                Classification = (ClassificationAttribute)Activator.CreateInstance(classification);
            }
        }

        /***************************************************/

        public OutputAttribute(string name, string description, ClassificationAttribute classification) : this(name, description)
        {
            Classification = classification;
        }

        /***************************************************/
    }
}






