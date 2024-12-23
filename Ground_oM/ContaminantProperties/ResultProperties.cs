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

    [Description("Properties related to the results based on the tests of the contaminant.")]
    public class ResultProperties : BHoMObject, IContaminantProperty
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("The result type for the contaminant sample (ERES_RTCD).")]
        public virtual string Type { get; set; } = "";

        [Description("The interepreted qualifier that shows whether a Result was lower than a detection threshold (ERES_IQLF).")]
        public virtual string Qualifier { get; set; } = "";

        [Description("Is the result reportable (ERES_RRES).")]
        public virtual bool Reportable { get; set; } = false;

        [Description("Detect flag (ERES_DETF).")]
        public virtual bool DetectFlag { get; set; } = false;

        [Description("Is the contaminant sample organic (ERES_ORG).")]
        public virtual bool Organic { get; set; } = false;


        /***************************************************/
    }
}

