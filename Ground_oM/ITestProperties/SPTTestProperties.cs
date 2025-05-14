/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2025, the respective contributors. All rights reserved.
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
using System.ComponentModel;
using System.Collections.Generic;
using BH.oM.Base;
using BH.oM.Quantities.Attributes;

namespace BH.oM.Ground
{

    [Description("Properties related to the standard penetration test.")]
    public class SPTTestProperties : BHoMObject, ITestProperties
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Hammer number (ISPT_HAM).")]
        public virtual string HammerNumber { get; set; }

        [Description("Type of test (SPT_TYPE).")]
        public virtual string Type { get; set; }

        [Length]
        [Description("Depth to water at time of test, set to NaN if dry (ISPT_WAT).")]
        public virtual double WaterDepth { get; set; }

        [Length]
        [Description("Casing depth at time of test (ISPT_CAS).")]
        public virtual double CasingDepth { get; set; }

        [Description("True if the standard penetration test was carried out in soft rock. (ISPT_ROCK).")]
        public virtual bool SoftRock { get; set; }

        [Description("Weather conditons during test (ISPT_ENV).")]
        public virtual string WeatherConditions { get; set; }

        [Description("Test method (ISPT_METH).")]
        public virtual string Method { get; set; }

        [Description("Accrediting body (ISPT_CRED).")]
        public virtual string AccreditingBody { get; set; }

        [Description("Test Status (TEST_STAT)")]
        public virtual string Status { get; set; }

        /***************************************************/
    }
}
