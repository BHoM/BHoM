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

using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BH.oM.Base.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor, AllowMultiple = true)]
    public class InputAttribute : Attribute, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public virtual string Name { get; private set; } = "";

        public virtual string Description { get; private set; } = "";

        public virtual InputClassificationAttribute Classification { get; } = null;

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public InputAttribute(string name, string description, Type classification = null)
        {
            Name = name;
            Description = description;
            if (classification != null && typeof(InputClassificationAttribute).IsAssignableFrom(classification) && classification != typeof(InputClassificationAttribute))
            {
                Classification = (InputClassificationAttribute)Activator.CreateInstance(classification);
            }
        }

        /***************************************************/

        public InputAttribute(string name, string description, InputClassificationAttribute classification, Type typeId)
        {
            Name = name;
            Description = description;
            Classification = classification;
        }

        /***************************************************/

        public InputAttribute(string name, string description)
        {
            Name = name;
            Description = description;
        }

        /***************************************************/
    }
}



