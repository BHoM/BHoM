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

using System.Collections.Generic;
using System.ComponentModel;
using BH.oM.Geometry;
using BH.oM.Base;

namespace BH.oM.Acoustic
{
    [Description("An acoustics room is defined by the criteria related to the sound within the space, as well as its geometry")]
    public class Room : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        
        public virtual PolySurface Boundaries { get; set; } = new PolySurface();
        
        public virtual double Area { get; set; } = 0;

        public virtual double Volume { get; set; } = 0;

        public virtual List<Receiver> Samples { get; set; } = new List<Receiver>();

        [Description("Average Indoor Ambient Noise Level is the total continuous noise level of a time-varying noise within a space; it is usually composed of noise from many sources, near and far. It is measured in A-weighted decibels (dBA).")]
        public virtual int AverageInternalAmbientNoiseLevelRequirement { get; set; } = 0;

        [Description("")]
        public virtual int MaximumInternalAmbientNoiseLevelRequirement { get; set; } = 0;

        [Description("")]
        public virtual double ReverberationTime { get; set; } = 0.0;

        [Description("")]
        public virtual int NoiseRating { get; set; } = 0;

        [Description("")]
        public virtual int ImpactSoundInsulation { get; set; } = 0;

        [Description("")]
        public virtual double SpeechIntelligibilityIndex { get; set; } = 0.0;

        [Description("")]
        public virtual string PrivacyRequirement { get; set; } = "";

        [Description("")]
        public virtual int MinimumSoundPressureLevel { get; set; } = 0;

        [Description("")]
        public virtual double SoundPressureLevelCoverage { get; set; } = 0.0;


        /***************************************************/
    }
}
