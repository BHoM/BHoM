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

    [Description("Properties related to the references of the in Situ Hand Vane Test.")]
    public class InSituVaneReferenceProperties : BHoMObject, ITestProperties
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Details of vane test and vane size (IVAN_REM).")]
        public virtual string Details { get; set; }

        [Description("Details of weather and environmental conditions during test (IVAN_ENV).")]
        public virtual string Weather { get; set; }

        [Description("Test date (IVAN_DATE).")]
        public virtual DateTime Date { get; set; }

        [Description("Stratum refrence shown on trial pit or traverse sketch (GEOL_STAT).")]
        public virtual string StratumReference { get; set; }

        [Description("Associated file references (FILE_FSET).")]
        public virtual string FileReference { get; set; }

        /***************************************************/
    }
}
