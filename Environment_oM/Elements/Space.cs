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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;

using BH.oM.Environment.Fragments;
using BH.oM.Environment.Gains;

using BH.oM.Geometry;
using System.ComponentModel;

namespace BH.oM.Environment.Elements
{
    [Description("An analytical Space object.")]
    public class Space : BHoMObject, IEnvironmentObject
    {
        [Description("A collection of zone names the Space is to be included in.")]
        public List<string> Zones { get; set; } = new List<string>();

        [Description("A collection of internal gains to be applied to the Space.")]
        public List<IGain> Gains { get; set; } = new List<IGain>();

        [Description("The primary use type of the Space (e.g. Office, Bedroom, WC etc.).")]
        public SpaceType Type { get; set; } = SpaceType.Undefined;

        [Description("A point in 3D space providing a basic location point of the Space.")]
        public Point Location { get; set; } = new Point();
    }
}

