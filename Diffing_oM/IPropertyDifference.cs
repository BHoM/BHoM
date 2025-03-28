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
using BH.oM.Base.Attributes;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Diffing
{
    [Description("Represents a difference found between a Previous and Following version of an object.")]
    public interface IPropertyDifference : IObject
    {
        [Description("The human-friendly name associated with this property difference. This may differ from the actual property name: see `FullName`.")]
        string Name { get; set; }

        [Description("A human-friendly description associated with this property difference.")]
        string Description { get; set; }

        [Description("The older value of this property (associated with the past version of the object).")]
        object PastValue { get; set; }

        [Description("The newer value of this property (associated with the following version of the object).")]
        object FollowingValue { get; set; }

        [Description("Actual Full Name of the object's property whose value is different.")]
        string FullName { get; set; }
    }
}






