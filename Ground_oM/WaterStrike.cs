/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2026, the respective contributors. All rights reserved.
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
using BH.oM.Base;
using BH.oM.Dimensional;
using BH.oM.Quantities.Attributes;
using BH.oM.Base.Attributes;
using BH.oM.Base.Attributes.Enums;

namespace BH.oM.Ground
{

    [Description("A water strike object containing the details of the water strike based on the AGS schema.")]
    public class WaterStrike : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        [Description("Location identifier relating the borehole to the strata (LOCA_ID).")]
        public virtual string Id { get; set; }

        [Length]
        [Description("Depth to the initial water strike (WSTG_DPTH).")]
        public virtual double Depth { get; set; }

        [Time]
        [Description("The time after strike. Note the BHoM stores time in SI units (i.e. seconds) \n " +
            "whereas this is defined in minutes in the AGS schema (WSTD_NMIN).")]
        public virtual double TimePostStrike { get; set; }

        [Length]
        [Description("Depth to water after TimePostStrike (WSTD_POST).")]
        public virtual string DepthPostStrike { get; set; }

        [Description("General remarks for the investigation (WSTD_REM).")]
        public virtual string Remarks { get; set; } = "";

        [Description("Associated file reference including instructions and photographs (FILE_FSET).")]
        public virtual string File { get; set; } = "";

        /***************************************************/
    }
}







