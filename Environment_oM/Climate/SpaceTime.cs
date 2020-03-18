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
using System.ComponentModel;

namespace BH.oM.Environment.Climate
{
    [Description("An environment object used to describe time for climate analysis")]
    public class SpaceTime : BHoMObject, IClimateObject
    {
        [Description("The location for the climate analysis")]
        public Location Location { get; set; } = new Location();

        [Description("A number that represents the year for the space time object (e.g. 1970)")]
        public int Year { get; set; } = 1900;

        [Description("A number that represents the month of the year for the space time object (between 1 to 12, where 1 is January)")]
        public int Month { get; set; } = 1;

        [Description("A number that represents the day of the month for the space time object (between 1 to 31)")]
        public int Day { get; set; } = 1;

        [Description("A number that represents the hour of the day for the spacetime object (between 0 to 23)")]
        public int Hour { get; set; } = 0;

        [Description("A number that represents the minute for the space time object (between 0 to 59)")]
        public int Minute { get; set; } = 0;

        [Description("A number that represents the second for the space time object (between 0 to 59)")]
        public int Second { get; set; } = 0;

        [Description("A number that represents the millisecond for the space time object (between 0 to 999)")]
        public int Millisecond { get; set; } = 0;
    }
}

