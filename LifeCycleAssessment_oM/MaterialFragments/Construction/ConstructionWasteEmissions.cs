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

using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BH.oM.LifeCycleAssessment.MaterialFragments.Construction
{
    [Description("Production, transportation, storage and end-of-life treatment and disposal of any material/waste on-site: transport, waste management and disposal of packaging materials.")]
    public class ConstructionWasteEmissions : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("The waste rate associated with the construction process, which will increase the amount of material required to be ordered and processed to account for waste. This factor is used to compute A5.3 emissions based on outputs available from either EPD and/or transport as well as disposal factors.")]
        public virtual WasteRate WasteRate { get; set; } = null;

        [Description("Whether the material is reused on site, which would reduce the emissions associated with transport and processing. Controls wether the C2 factor for the material should be included or not when computing the emissions based on the A5.3 (waste) factor. Defaults to false, meaning the C2 factor is included.")]
        public virtual bool ResuedOnSite { get; set; } = false;

        /***************************************************/
    }
}
