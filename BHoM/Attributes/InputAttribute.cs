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
using BH.oM.Base.Attributes.Enums;
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

        public virtual string Name { get; } = "";

        public virtual string Description { get; } = "";

        public virtual QuantityAttribute Quantity { get; } = null;

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

        public InputAttribute(string name, string description, Type quantity) : this(name, description)
        {
            if (quantity != null && typeof(QuantityAttribute).IsAssignableFrom(quantity) && !quantity.IsAbstract)
            {
                Quantity = (QuantityAttribute)Activator.CreateInstance(quantity);
            }
        }

        /***************************************************/

        public InputAttribute(string name, string description, Type quantity, UIExposure exposure) : this(name, description, quantity)
        {
            Exposure = exposure;
        }

        /***************************************************/

        public InputAttribute(string name, string description, QuantityAttribute quantity, UIExposure exposure)
        {
            Name = name;
            Description = description;
            Quantity = quantity;
            Exposure = exposure;
        }

        /***************************************************/
    }
}




