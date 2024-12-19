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
    public class DetectionProperties : BHoMObject, IContaminantProperty
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Reporting detection limit (ERES_RDLM).")]
        public virtual double DetectionLimit { get; set; } = double.NaN;

        [Description("Method detection limit (ERES_MDLM).")]
        public virtual double MethodDetectionLimit { get; set; } = double.NaN;

        [Description("Quanification limit (ERES_QLM).")]
        public virtual double QuantificationLimit { get; set; } = double.NaN;

        [Description("Tentatively Identified Compound (TIC) probability (ERES_TICP).")]
        public virtual double TICProbability { get; set; } = double.NaN;

        [Description("Tentatively Identified Compound (ERES_TICT) retention time.")]
        public virtual double TICRetention { get; set; } = double.NaN;


        /***************************************************/
    }
}

