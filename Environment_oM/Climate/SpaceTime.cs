/*
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
    [Description("An Environment SpaceTime object used for defining locations in space and time for climate analys")]
    public class SpaceTime : BHoMObject, IClimateObject
    {
        [Description("An Environment Location object specifying the latitude, longitude and other location specifics of the SpaceTime object")]
        public Location Location { get; set; } = new Location();

        [Description("The year of the time for the space time object")]
        public int Year { get; set; } = 1900;

        [Description("The month of the time for the space time object")]
        public int Month { get; set; } = 1;

        [Description("The day of the time for the space time object")]
        public int Day { get; set; } = 1;

        [Description("The hour of the time for the space time object")]
        public int Hour { get; set; } = 0;

        [Description("The minute of the time for the space time object")]
        public int Minute { get; set; } = 0;

        [Description("The second of the time for the space time object")]
        public int Second { get; set; } = 0;

        [Description("The millisecond of the time for the space time object")]
        public int Millisecond { get; set; } = 0;
    }
}
