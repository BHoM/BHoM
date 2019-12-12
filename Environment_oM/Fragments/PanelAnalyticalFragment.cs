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
using System.ComponentModel;

namespace BH.oM.Environment.Fragments
{
    [Description("Fragment containing the panel analytical property related to buildings")]
    public class PanelAnalyticalFragment : IBHoMFragment
    {
        [Description("The altitude of the panel")]
        public double Altitude { get; set; } = 0.0;

        [Description("The altitude range of the panel")]
        public double AltitudeRange { get; set; } = 0.0;

        [Description("The inclination of the panel")]
        public double Inclination { get; set; } = 0.0;

        [Description("The inclination range of the panel")]
        public double InclinationRange { get; set; } = 0.0;

        [Description("The orientation of the panel")]
        public double Orientation { get; set; } = 0.0;

        [Description("The gValue of the panel")]
        public double GValue { get; set; } = 0.0;

        [Description("The ltValue of the panel")]
        public double LTValue { get; set; } = 0.0;

        [Description("The uValue of the panel")]
        public double UValue { get; set; } = 0.0;

        [Description("The aperture flow in towards the panel")]
        public double ApertureFlowIn { get; set; } = 0.0;

        [Description("The aperture flow out from the panel")]
        public double ApertureFlowOut { get; set; } = 0.0;

        [Description("The aperture for the opening of the panel")]
        public double ApertureOpening { get; set; } = 0.0;

        [Description("The external condensation for the panel")]
        public double ExternalCondensation { get; set; } = 0.0;

        [Description("The external conduction for the panel")]
        public double ExternalConduction { get; set; } = 0.0;

        [Description("The external convection for the panel")]
        public double ExternalConvection { get; set; } = 0.0;

        [Description("The external long wave for the panel")]
        public double ExternalLongWave { get; set; } = 0.0;

        [Description("The external solar result of the panel")]
        public double ExternalSolar { get; set; } = 0.0;

        [Description("The external temperature of the panel")]
        public double ExternalTemperature { get; set; } = 0.0;

        [Description("The internal condensation for the panel")]
        public double InternalCondensation { get; set; } = 0.0;

        [Description("The internal conduction for the panel")]
        public double InternalConduction { get; set; } = 0.0;

        [Description("The internal convection for the panel")]
        public double InternalConvection { get; set; } = 0.0;

        [Description("The internal long wave for the panel")]
        public double InternalLongWave { get; set; } = 0.0;

        [Description("The internal solar result of the panel")]
        public double InternalSolar { get; set; } = 0.0;

        [Description("The internal temperature of the panel")]
        public double InternalTemperature { get; set; } = 0.0;

        [Description("A Panel Analytical Fragment object - this can be added to an Environment Panel")]
        public double InterstitialCondensation { get; set; } = 0.0;
    }
}
