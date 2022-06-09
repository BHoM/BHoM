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

using BH.oM.Base;
using System.ComponentModel;

namespace BH.oM.Environment.Fragments
{
    [Description("Fragment containing geometric and thermal properties of a panel")]
    public class PanelAnalyticalFragment : IFragment
    {
        public virtual double Altitude { get; set; } = 0.0;

        public virtual double AltitudeRange { get; set; } = 0.0;

        public virtual double Inclination { get; set; } = 0.0;

        public virtual double InclinationRange { get; set; } = 0.0;

        public virtual double Orientation { get; set; } = 0.0;

        public virtual double GValue { get; set; } = 0.0;

        public virtual double LTValue { get; set; } = 0.0;

        public virtual double UValue { get; set; } = 0.0;

        public virtual double ApertureFlowIn { get; set; } = 0.0;

        public virtual double ApertureFlowOut { get; set; } = 0.0;

        public virtual double ApertureOpening { get; set; } = 0.0;

        public virtual double ExternalCondensation { get; set; } = 0.0;

        public virtual double ExternalConduction { get; set; } = 0.0;

        public virtual double ExternalConvection { get; set; } = 0.0;

        public virtual double ExternalLongWave { get; set; } = 0.0;

        public virtual double ExternalSolar { get; set; } = 0.0;

        public virtual double ExternalTemperature { get; set; } = 0.0;

        public virtual double InternalCondensation { get; set; } = 0.0;

        public virtual double InternalConduction { get; set; } = 0.0;

        public virtual double InternalConvection { get; set; } = 0.0;

        public virtual double InternalLongWave { get; set; } = 0.0;

        public virtual double InternalSolar { get; set; } = 0.0;

        public virtual double InternalTemperature { get; set; } = 0.0;

        public virtual double InterstitialCondensation { get; set; } = 0.0;
    }
}



