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

        [Description("This specifies the list of spaces associated with a particular occupant activity's acoustic criteria.")]
        public virtual string AcousticZone { get; set; } = "";

        [Description("This specifies the list of spaces associated with similar Public Address and Voice Alarm devices")]
        public virtual string PublicAddressVoiceAlarmZone { get; set; } = "";

        [Description("This acoustic requirement specificies the maximum equivalent continuous noise level of a time-varying noise (LAeq,T) within a space. This metric is usually composed of noise from many sources, near and far and is measured in A-weighted decibels (dBA).")]
        public virtual int AverageInternalAmbientNoiseLevelRequirement { get; set; } = 0;

        [Description("This acoustic requirement specifies the maximum sound pressure level within a space (LAF,max). It is typically measured using the fast time constant in A-weighted decibels (dBA).")]
        public virtual int MaximumInternalAmbientNoiseLevelRequirement { get; set; } = 0;

        [Description("This acoustic requirement specifies the maximum time for a steady sound pressure level in an enclosed space to decay by 60 dB. This parameter is measured in second from the moment the sound source is switched off. ")]
        public virtual double ReverberationTime { get; set; } = 0.0;

        [Description("Noise rating curves developed by the International Organization for Standardization (ISO) determine the acceptable indoor environment for hearing preservation, speech communication and annoyance. This requirement specifies the maximum noise rating for a space.")]
        public virtual int NoiseRating { get; set; } = 0;

        [Description("This specifies the required impact sound insulation performance for floors. The single figure target value is typically given in for in-situ field measurements (L'nTw) in decibels. The lower the L'nTw, the better the building element will attenuate impact noises.")]
        public virtual int ImpactSoundInsulation { get; set; } = 0;

        [Description("Speech transmission index (STI) is a metric that represents the transmission quality of speech with respect to intelligibility by a speech transmission channel. This acoustic requirement specifies the minimum STI ranging between 0 and 1.")]
        public virtual double SpeechTransmitionIndex { get; set; } = 0.0;

        [Description("This specifies the acoustic privacy requirements of a space. Acoustic privacy for a space is rated according to the noise sensitivity of a receiving room and the level of activity noise within a source room. It is typically denoted by terms Not Private, Moderate and Confidential, and is used to determine the suitable level of sound insulation (DnT,w) for partitions between spaces.")]
        public virtual string PrivacyRequirement { get; set; } = "";

        [Description("This acoustic criterion specifies the minimum sound pressure level required at an audience plane from a Public Address or Voice Alarm system, in decibels. ")]
        public virtual int MinimumSoundPressureLevel { get; set; } = 0;

        [Description("This acoustic criterion specifies the minimum coverage area of an audience plane that must attain the Public Address or Voice Alarm MinimumSoundPressureLevel requirement. Typically given as a proportion, input a requirement value between 0-1. e.g. 80% coverage = 0.8.")]
        public virtual double SoundPressureLevelCoverage { get; set; } = 0.0;

        [Description("By selecting 'True' this boolean indicates the areas of a development that must utilise acoustic underlay in order to attain a suitable impact sound insulation performance (considering the activity in the source rooms and the sensitivity of the receiver room).")]
        public virtual bool AcousticUnderlayRequirement { get; set; } = false;

        /***************************************************/
    }
}


