/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2023, the respective contributors. All rights reserved.
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

    [Description("Properties related to the analysis undertaken on the contaminant.")]
    public class AnalysisProperties : BHoMObject, IContaminantProperty
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Whether the specimen is total or dissolved (ERES_TORD).")]
        public virtual string TotalOrDissolved { get; set; } = "";

        [Description("Accrediting body and reference number (when appropriate) (ERES_CRED).")]
        public virtual string AccreditingBody { get; set; } = "";

        [Description("Name of testing labratory or organisation (ERES_LAB).")]
        public virtual string LabName { get; set; } = "";

        [Description("Percentage of material removed (ERES_PERP).")]
        public virtual double PercentageRemoved { get; set; } = double.NaN;

        [Length]
        [Description("Size of material removed prior to test. Value represents lowest sized material removed (ERES_SIZE).")]
        public virtual double SizeRemoved { get; set; } = double.NaN;

        [Description("Instrument reference number or identifier (ERES_IREF).")]
        public virtual string InstrumentReference { get; set; } = "";

        [Description("Leachate preperation date and time (ERES_LDTM).")]
        public virtual DateTime LeachateDate { get; set; } = default(DateTime);

        [Description("Leachate preperation method (ERES_LMTH).")]
        public virtual string LeachateMethod { get; set; } = "";

        [Description("Dilution factor (ERES_DIL).")]
        public virtual int DilutionFactor { get; set; } = 0;

        [Description("Basis (ERES_BAS).")]
        public virtual string Basis { get; set; } = "";

        [Description("Analysis location (ERES_LOCN).")]
        public virtual string Location { get; set; } = "";

        /***************************************************/
    }
}