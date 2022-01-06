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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using BH.oM.Base;
using BH.oM.Environment.Fragments;
using BH.oM.Quantities.Attributes;

namespace BH.oM.Environment.Climate
{
    [Description("Defines a uniquely identifiable point on the Earth in standard global Latitude, Longitude and Elevation, coordinate system. Particularly useful for specifying local climate conditions for environmental analysis.")]
    public class Location : BHoMObject, IClimateObject
    {
        [Description("Defines North-South position on the Earth. Between -90 to +90 degrees.")]
        public virtual double Latitude { get; set; } = 0;

        [Description("Defines the East-West position on the Earth. Between -180 to +180 degrees.")]
        public virtual double Longitude { get; set; } = 0;

        [Length]
        [Description("The elevation for the location, measured relative to sea level.")]
        public virtual double Elevation { get; set; } = 0;

        [Description("The Coordinated Universal Time (UTC) for the location (in -12 to +14 hours)")]
        public virtual double UtcOffset { get; set; } = 0;
    }
}



