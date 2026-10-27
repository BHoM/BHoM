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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using BH.oM.Base;
using BH.oM.MEP.Criteria;

namespace BH.oM.MEP.Results
{
    [Description("Calculated thermal demand for a service group using a selected system configuration and compatible space-load results. Records connected demands, factored requirements and applied calculation settings. This is not an equipment capacity or coil-selection result.")]
    public class HVACServiceLoadResult : BHoMObject
    {
        /***************************************************/
        /**** Input References                          ****/
        /***************************************************/

        [Description("BHoM_Guid of the service group represented by this result.")]
        public virtual Guid ServiceGroupId { get; set; } = Guid.Empty;

        [Description("BHoM_Guid of the system configuration used for this calculation.")]
        public virtual Guid SystemConfigurationId { get; set; } = Guid.Empty;

        [Description("BHoM_Guid identifiers of the individual space-load results contributing to this calculation. The Engine must prevent duplicate counting.")]
        public virtual List<Guid> ContributingSpaceResultIds { get; set; }
            = new List<Guid>();

        /***************************************************/
        /**** Connected Thermal Demands                 ****/
        /***************************************************/

        [Description("Applicable connected sensible-cooling demand before applying the sensible-cooling demand factor, in watts [W]. Null means no valid value has been established; it must not be interpreted as zero.")]
        public virtual double? ConnectedSensibleCoolingLoad { get; set; }
            = null;

        [Description("Applicable connected latent-cooling demand before applying the latent-cooling demand factor, in watts [W]. Null means no valid value has been established; it must not be interpreted as zero.")]
        public virtual double? ConnectedLatentCoolingLoad { get; set; }
            = null;

        [Description("Applicable connected heating demand before applying the heating demand factor, in watts [W]. Null means no valid value has been established; it must not be interpreted as zero.")]
        public virtual double? ConnectedHeatingLoad { get; set; }
            = null;

        /***************************************************/
        /**** Required Thermal Demands                  ****/
        /***************************************************/

        [Description("Required sensible-cooling demand after applying the selected sensible-cooling demand factor, in watts [W]. This is a service demand, not a selected equipment capacity.")]
        public virtual double? RequiredSensibleCoolingLoad { get; set; }
            = null;

        [Description("Required latent-cooling demand after applying the selected latent-cooling demand factor, in watts [W]. This is a service demand, not a selected equipment capacity.")]
        public virtual double? RequiredLatentCoolingLoad { get; set; }
            = null;

        [Description("Required total-cooling demand, equal to the sum of the resolved required sensible and latent cooling demands, in watts [W]. Null where either required component is unresolved. A component confirmed as zero must be recorded explicitly as zero.")]
        public virtual double? RequiredTotalCoolingLoad { get; set; }
            = null;

        [Description("Required heating demand after applying the selected heating demand factor, in watts [W]. This is a service demand, not a selected equipment capacity.")]
        public virtual double? RequiredHeatingLoad { get; set; }
            = null;

        /***************************************************/
        /**** Applied Calculation Settings              ****/
        /***************************************************/

        [Description("Sensible-cooling demand factor actually applied when producing this result. A value of 1.0 means no reduction. This records the calculation-time value rather than referencing a potentially changed criteria value.")]
        public virtual double? AppliedSensibleCoolingDemandFactor
        {
            get;
            set;
        } = null;

        [Description("Latent-cooling demand factor actually applied when producing this result. A value of 1.0 means no reduction.")]
        public virtual double? AppliedLatentCoolingDemandFactor
        {
            get;
            set;
        } = null;

        [Description("Heating demand factor actually applied when producing this result. A value of 1.0 means no reduction.")]
        public virtual double? AppliedHeatingDemandFactor { get; set; }
            = null;

        [Description("Aggregation basis actually used when producing this result. SumOfRoomPeaks does not imply time-coincident demand.")]
        public virtual LoadAggregationBasis AggregationBasis { get; set; }
            = LoadAggregationBasis.Unspecified;

        /***************************************************/
        /**** Calculation Completeness                  ****/
        /***************************************************/

        [Description("BHoM_Guid identifiers of member spaces for which a required compatible space-load result was unavailable. This collection records missing results, not intentionally excluded service roles.")]
        public virtual List<Guid> MissingSpaceIds { get; set; }
            = new List<Guid>();

        [Description("Calculation messages describing unresolved components, intentionally excluded duties, assumptions and limitations. This is an initial reporting collection, not a replacement for a future structured ValidationIssue implementation.")]
        public virtual List<string> CalculationMessages { get; set; }
            = new List<string>();

        /***************************************************/
    }
}

