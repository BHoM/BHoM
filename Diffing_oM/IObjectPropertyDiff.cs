/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2021, the respective contributors. All rights reserved.
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
using BH.oM.Reflection.Attributes;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Diffing
{
    [Description("Represents the differences between two sets of objects.")]
    public interface IObjectPropertyDiff<O, D> : IObject
    {
        O Object1 { get; set; }
        O Object2 { get; set; }
        List<D> DifferentProperties { get; set; }
    }

    public interface IPropertyDiff<O> : IObject
    {
        string Name { get; set; }
        O OldValue { get; set; }
        O NewValue { get; set; }
    }

    public class ObjectPropertyDiff : IObjectPropertyDiff<object, PropertyDifference>
    {
        public object Object1 { get; set; }
        public object Object2 { get; set; }
        public List<PropertyDifference> DifferentProperties { get; set; }
    }

    public class PropertyDifference : IPropertyDiff<object>
    {
        public string Name { get; set; }
        public object OldValue { get; set; }
        public object NewValue { get; set; }
    }

    public class RevitParameterDifference
    {

    }

}


