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

using BH.oM.Base;
using BH.oM.Quantities.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BH.oM.LifeCycleAssessment.MaterialFragments.EndOfLife
{
    [Description("WasteAndDisposalFactors defines the end of life waste processing and disposal factors to be applied to the material fragment. These factors are applied in addition to any end of life factors provided by an Environmental Product Declaration, and can be used to fill gaps where no EPD data is available. If applied this will help populate all CLimate change metrics available, with LandUseFactor being set to 0.")]
    public class WasteAndDisposalFactors : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Factor used to compute the Fossil climate change impacts.")]
        public virtual FossilWasteFactor FossilWasteFactor { get; set; }

        [Description("Controls whether the value should override a potentially pre-existing value on the Environmental Product Declaration. If true, the factor above takes president, if false, the value above is only added if no C3 or C4 factors already have been computed.")]
        public virtual bool OverrideEpdValue { get; set; } = false;

        [Description("If true, the C3toC4 value for ClimateChangeBiogenic will be set to the negative value of A1 (if present) or A1toA3 to cancel out any benefits given in those phases. If false, this value will be assumed to be 0, and all emissions for the disposal modules related to Fossil. Works under the same premise as the OverrideEpdValue toggle.")]
        public virtual bool CancelOutBiogenicCarbon { get; set; } = true;

        /***************************************************/
    }
}

