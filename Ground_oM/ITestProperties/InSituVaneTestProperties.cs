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

namespace BH.oM.Ground
{

    [Description("Properties related to the in-Situ Hand Vane Test.")]
    public class InSituVaneTestProperties : BHoMObject, ITestProperties
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Test reference (IVAN_TESN).")]
        public virtual string Reference { get; set; }

        [Description("Vane Type (IVAN_TYPE).")]
        public virtual string Type { get; set; }

        [Description("Test Method (IVAN_METH).")]
        public virtual string Method { get; set; }

        [Description("Name of testing organisation (IVAN_CONT).")]
        public virtual string Tester { get; set; }

        [Description("Accrediting body and reference number (IVAN_CRED).")]
        public virtual string AccreditingBody { get; set; }

        [Description("Test Status (TEST_STAT).")]
        public virtual string Status { get; set; }

        /***************************************************/
    }
}
