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
using System.ComponentModel;
using BH.oM.Base;

namespace BH.oM.MEP.Systems
{
    [Description("Assigns a service group to provide one declared HVAC service role to a space. This records service responsibility, not calculated duty or available equipment capacity.")]
    public class ServiceGroupAllocation : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("BHoM_Guid of the canonical space receiving the service. Guid.Empty means the space has not been assigned.")]
        public virtual Guid SpaceId { get; set; } = Guid.Empty;

        [Description("BHoM_Guid of the service group providing the service. Guid.Empty means the group has not been assigned.")]
        public virtual Guid ServiceGroupId { get; set; } = Guid.Empty;

        [Description("HVAC service responsibility provided by the group to the space.")]
        public virtual ServiceRole ServiceRole { get; set; }
            = ServiceRole.Unspecified;

        /***************************************************/
    }
}