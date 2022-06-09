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

using BH.oM.Base;
using System;

namespace BH.oM.Acoustic
{
    public class SoundLevel : BHoMObject, IAcousticParameter
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public virtual double Value { get; set; } = 0.0;

        public virtual int ReceiverID { get; set; } = 0;

        public virtual int SpeakerID { get; set; } = -1;

        public virtual Frequency Frequency { get; set; } = Frequency.Hz1000;


        /***************************************************/
        /**** Static Operators Override                 ****/
        /***************************************************/

        public static SoundLevel operator +(SoundLevel a, SoundLevel b)
        {
            return new SoundLevel()
            {
                Value = 10 * Math.Log10(Math.Pow(10, a.Value / 10) + (Math.Pow(10, b.Value / 10))),
                ReceiverID = a.ReceiverID,
                SpeakerID = - 1,
                Frequency = a.Frequency
            };
        }
        
        /***************************************************/

        public static SoundLevel operator -(SoundLevel a, SoundLevel b)
        {
            return new SoundLevel()
            {
                Value = 10 * Math.Log10(Math.Pow(10, a.Value / 10) - (Math.Pow(10, b.Value / 10))),
                ReceiverID = a.ReceiverID,
                SpeakerID = -1,
                Frequency = a.Frequency
            };
        }
    }
}


