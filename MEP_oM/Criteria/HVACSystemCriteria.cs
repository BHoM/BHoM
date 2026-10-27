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


using System.ComponentModel;
using BH.oM.Base;

namespace BH.oM.MEP.Criteria
{
    [Description("HVAC demand assumptions used when calculating service-level thermal requirements. These criteria do not define available equipment capacity.")]
    public class HVACSystemCriteria : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Factor applied to applicable connected sensible-cooling demand. A value of 1.0 means no reduction. Null means the factor has not been defined.")]
        public virtual double? SensibleCoolingDemandFactor { get; set; }
            = null;

        [Description("Factor applied to applicable connected latent-cooling demand. A value of 1.0 means no reduction. Null means the factor has not been defined.")]
        public virtual double? LatentCoolingDemandFactor { get; set; }
            = null;

        [Description("Factor applied to applicable connected heating demand. A value of 1.0 means no reduction. Null means the factor has not been defined.")]
        public virtual double? HeatingDemandFactor { get; set; }
            = null;

        [Description("Basis used to aggregate compatible space-load results.")]
        public virtual LoadAggregationBasis AggregationBasis { get; set; }
            = LoadAggregationBasis.Unspecified;

        /***************************************************/
    }
}
