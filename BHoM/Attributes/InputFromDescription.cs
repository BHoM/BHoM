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
using System.ComponentModel;
using System.Reflection;

namespace BH.oM.Base.Attributes
{
    [Description("Attribute to define an input parameter for a method or constructor, using the description of a member (Type, MemberInfo, ParameterInfo or Enum).")]
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor, AllowMultiple = true)]
    public class InputFromDescription : Attribute, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Name of the method parameter this attribute corresponds to.")]
        public virtual string InputName { get; private set; } = "";

        [Description("Member to grab the description from. Should be a Type, MemberInfo, ParameterInfo or Enum.")]
        public virtual object Member { get; private set; } = null;

        [Description("Classification of the correspondent input parameter, e.g. folder path, quantity etc.")]
        public virtual ClassificationAttribute Classification { get; } = null;

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        [Description("Method for Serialisation")]
        public InputFromDescription(string inputName, object member, ClassificationAttribute classification = null)
        {
            InputName = inputName;
            Member = member;
            Classification = classification;
        }

        /***************************************************/

        public InputFromDescription(string inputName, object member, Type classification = null)
        {
            InputName = inputName;
            Member = member;

            if (classification != null && typeof(ClassificationAttribute).IsAssignableFrom(classification) && !classification.IsAbstract)
            {
                Classification = (ClassificationAttribute)Activator.CreateInstance(classification);
            }
        }

        /***************************************************/

    }
}






