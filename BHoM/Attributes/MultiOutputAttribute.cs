/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2023, the respective contributors. All rights reserved.
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
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    [Description("Attribute providing information about an output parameter of a multi-output method." +
                 "\nTo be applied to all methods that return BH.oM.Base.Output types.")]
    public class MultiOutputAttribute : Attribute, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Index of the output parameter this attribute corresponds to.")]
        public virtual int Index { get; private set; } = 0;

        [Description("Name of the correspondent output parameter (to be used in the UI).")]
        public virtual string Name { get; private set; } = "";

        [Description("Description of the correspondent output parameter.")]
        public virtual string Description { get; private set; } = "";

        [Description("Classification of the correspondent output parameter, e.g. folder path, quantity etc.")]
        public virtual ClassificationAttribute Classification { get; } = null;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public MultiOutputAttribute(int index, string name, string description)
        {
            Index = index;
            Name = name;
            Description = description;
        }

        /***************************************************/

        public MultiOutputAttribute(int index, string name, string description, Type classification) : this (index, name, description)
        {
            if (classification != null && typeof(ClassificationAttribute).IsAssignableFrom(classification) && !classification.IsAbstract)
            {
                Classification = (ClassificationAttribute)Activator.CreateInstance(classification);
            }
        }

        /***************************************************/

        public MultiOutputAttribute(int index, string name, string description, ClassificationAttribute classification, Type typeId)
        {
            Index = index;
            Name = name;
            Description = description;
            Classification = classification;
        }

        /***************************************************/
    }
}




