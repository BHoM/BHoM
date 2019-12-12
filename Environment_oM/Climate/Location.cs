﻿/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2019, the respective contributors. All rights reserved.
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
using System.ComponentModel;

namespace BH.oM.Environment.Climate
{
    [Description("An environment location object defining locations in space for climate analys")]
    public class Location : BHoMObject, IClimateObject
    {
        [Description("The latitude for the location")]
        public double Latitude { get; set; } = 0;

        [Description("The longitude for the location")]
        public double Longitude { get; set; } = 0;

        [Description("The elevation for the location")]
        public double Elevation { get; set; } = 0;

        [Description("The offset from UTC for the location (positive or negative)")]
        public double UtcOffset { get; set; } = 0;
    }
}
