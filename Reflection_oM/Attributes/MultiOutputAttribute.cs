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

using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Quantities.Attributes;

namespace BH.oM.Reflection.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class MultiOutputAttribute : Attribute, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public virtual int Index { get; private set; } = 0;

        public virtual string Name { get; private set; } = "";

        public virtual string Description { get; private set; } = "";

        public virtual QuantityAttribute Quantity { get; set; } = null;

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public MultiOutputAttribute(int index, string name, string description, Type quantity = null)
        {
            Index = index;
            Name = name;
            Description = description;
            if (quantity != null && typeof(QuantityAttribute).IsAssignableFrom(quantity) && quantity != typeof(QuantityAttribute))
            {
                Quantity = (QuantityAttribute)Activator.CreateInstance(quantity);
            }
        }

        /***************************************************/
    }
}

