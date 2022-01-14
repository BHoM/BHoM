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
using BH.oM.Base;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Base.Attributes;

namespace BH.oM.Environment.Climate
{
    public class WeatherFile : BHoMObject
    {
        public virtual string CityName { get; set; } = null;
        public virtual string StateName { get; set; } = null;
        public virtual string Country { get; set; } = null;
        public virtual string WeatherSource { get; set; } = null;
        public virtual string WMOID { get; set; } = null;
        public virtual SpaceTime SpaceTime { get; set; } = new SpaceTime();
        public virtual List<int> Year { get; set; } = null;
        public virtual List<int> Month { get; set; } = null;
        public virtual List<int> Day { get; set; } = null;
        public virtual List<int> Hour { get; set; } = null;
        public virtual List<int> Minute { get; set; } = null;
        public virtual List<string> UncertaintyFlag { get; set; } = null;
        public virtual List<double> DryBulbTemperature { get; set; } = null;
        public virtual List<double> DewPointTemperature { get; set; } = null;
        public virtual List<double> RelativeHumidity { get; set; } = null;
        public virtual List<double> AtmosphericStationPressure { get; set; } = null;
        public virtual List<double> ExtraterrestrialHorizontalRadiation { get; set; } = null;
        public virtual List<double> ExtraterrestrialDirectNormalRadiation { get; set; } = null;
        public virtual List<double> HorizontalInfraredRadiationIntensity { get; set; } = null;
        public virtual List<double> GlobalHorizontalRadiation { get; set; } = null;
        public virtual List<double> DirectNormalRadiation { get; set; } = null;
        public virtual List<double> DiffuseHorizontalRadiation { get; set; } = null;
        public virtual List<double> GlobalHorizontalIlluminance { get; set; } = null;
        public virtual List<double> DirectNormalIlluminance { get; set; } = null;
        public virtual List<double> DiffuseHorizontalIlluminance { get; set; } = null;
        public virtual List<double> ZenithLuminance { get; set; } = null;
        public virtual List<double> WindDirection { get; set; } = null;
        public virtual List<double> WindSpeed { get; set; } = null;
        public virtual List<double> TotalSkyCover { get; set; } = null;
        public virtual List<double> OpaqueSkyCover { get; set; } = null;
        public virtual List<double> Visibility { get; set; } = null;
        public virtual List<double> CeilingHeight { get; set; } = null;
        public virtual List<double> PresentWeatherObservation { get; set; } = null;
        public virtual List<double> PresentWeatherCodes { get; set; } = null;
        public virtual List<double> PrecipitableWater { get; set; } = null;
        public virtual List<double> AerosolOpticalDepth { get; set; } = null;
        public virtual List<double> SnowDepth { get; set; } = null;
        public virtual List<double> DaysSinceLastSnowfall { get; set; } = null;
        public virtual List<double> Albedo { get; set; } = null;
        public virtual List<double> LiquidPrecipitationDepth { get; set; } = null;
        public virtual List<double> LiquidPrecipitationQuantity { get; set; } = null;
    }
}


