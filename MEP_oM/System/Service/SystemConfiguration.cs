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

namespace BH.oM.MEP.Systems
{
    [Description("Defines the intended operating provision, equipment allocation and calculation criteria for a service group. Equipment may remain unallocated during early design.")]
    public class SystemConfiguration : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("BHoM_Guid of the service group configured by this object. Guid.Empty means the group has not been assigned.")]
        public virtual Guid ServiceGroupId { get; set; } = Guid.Empty;

        [Description("Declared connection arrangement of the providing equipment.")]
        public virtual EquipmentConnectionArrangement ConnectionArrangement
        {
            get;
            set;
        } = EquipmentConnectionArrangement.Unspecified;

        [Description("Number of equipment items required to operate at the design condition. Null means this requirement has not been defined.")]
        public virtual int? RequiredOperatingCount { get; set; } = null;

        [Description("Additional equipment items required for standby provision. Zero explicitly means no standby provision. Null means the requirement has not been defined.")]
        public virtual int? RequiredStandbyCount { get; set; } = null;

        [Description("Method used to share applicable service duty between the required operating equipment items.")]
        public virtual DutySharingMethod DutySharingMethod { get; set; }
            = DutySharingMethod.Unspecified;

        [Description("BHoM_Guid identifiers of equipment allocated to provide this service. An empty collection means equipment has not yet been allocated.")]
        public virtual List<Guid> EquipmentIds { get; set; }
            = new List<Guid>();

        [Description("HVAC demand criteria applicable to this configuration. Null means criteria have not been assigned.")]
        public virtual HVACSystemCriteria HVACCriteria { get; set; } = null;

        /***************************************************/
    }
}