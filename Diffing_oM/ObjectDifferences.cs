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
using System.ComponentModel;
using System.Linq;
using BH.oM.Base.Attributes;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Diffing
{
    [Description("Represents all the differences found between a Previous and Following version of an object.")]
    public class ObjectDifferences : IObject
    {
        [Description("Older version of the object (created or modified before `FollowingObject`).")]
        public virtual object PastObject { get; set; }

        [Description("Newer version of the object (created or modified after `PastObject`).")]
        public virtual object FollowingObject { get; set; }

        [Description("Represents all of the property differences found between the `past` and `following` versions of the object (under a given ComparisonConfig).")]
        public virtual List<PropertyDifference> Differences { get; set; } = new List<PropertyDifference>();
    }
}



