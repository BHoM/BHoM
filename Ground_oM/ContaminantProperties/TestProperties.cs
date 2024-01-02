/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2024, the respective contributors. All rights reserved.
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

    [Description("Properties related to the tests undertaken on the contaminant.")]
    public class TestProperties : BHoMObject, IContaminantProperty
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Labratory test name for the contaminant sample (ERES_TNAM).")]
        public virtual string LabTestName { get; set; } = "";

        [Description("Test reference (TEST_TESN).")]
        public virtual string Reference { get; set; } = "";

        [Description("Run type description, i.e. initial or reanalysis (ERES_RTYP).")]
        public virtual string RunType { get; set; } = "";

        [Description("Labratory test matrix (ERES_MATX).")]
        public virtual string TestMatrix { get; set; } = "";

        [Description("Test method (ERES_METH).")]
        public virtual string Method { get; set; } = "";

        [Description("Analysis time and date for the contaminant sample (ERES_DTIM).")]
        public virtual DateTime AnalysisDate { get; set; } = default(DateTime);

        [Description("Description of the specimen from the contaminant sample (SPEC_DESC).")]
        public virtual string Description { get; set; } = "";

        [Description("Remarks about the test or specimen from the contaminant sample (ERES_REM).")]
        public virtual string Remarks { get; set; } = "";

        [Description("The status of the test (TEST_STAT).")]
        public virtual string TestStatus { get; set; } = "";

        /***************************************************/
    }
}
