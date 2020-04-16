/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2020, the respective contributors. All rights reserved.
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

namespace BH.oM.LifeCycleAssessment
{
    [Description("The Tenant Improvement Scope object provides a template for expected objects to be assessed within this Life Cycle Assessments. Note that this category is not commonly assessed, but will provide for higher quality results. Please provide as many objects with their corresponding Environmental Product Declaration data for the most accurate Life Cycle Assessment.")]
    public class TenantImprovementScope : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        [Description("Tenant Improvement Ceiling is a material that creates an additional upper interior surface in a room")]
        public virtual TenantImprovementsCeiling TenantImprovementsCeiling { get; set; } = new TenantImprovementsCeiling();
        
        [Description("Tenant Improvements Flooring  is inclusive of the flooring materials placed on top of the structural floor (eg carpet, tile)")]
        public virtual TenantImprovementsFlooring TenantImprovementsFlooring { get; set; } = new TenantImprovementsFlooring();
        
        [Description("Tenant Improvements Finishes is inclusive of finishes (eg paint)")]
        public virtual TenantImprovementsFinishes TenantImprovementsFinishes { get; set; } = new TenantImprovementsFinishes();
        
        [Description("Tenant Improvements Interior Glazing is inclusive of windows in the interior of the building")]
        public virtual TenantImprovementsInteriorGlazing TenantImprovementsInteriorGlazing { get; set; } = new TenantImprovementsInteriorGlazing();
        
        [Description("Tenant Improvements Furniture includes furnishings (eg tables, chairs, desks)")]
        public virtual TenantImprovementsFurniture TenantImprovementsFurniture { get; set; } = new TenantImprovementsFurniture();
        
        [Description("Tenant Improvements Interior Doors includes doors in the interior of the building")]
        public virtual TenantImprovementsInteriorDoors TenantImprovementsInteriorDoors { get; set; } = new TenantImprovementsInteriorDoors();
        
        [Description("Tenant Improvements Partition Walls includes walls in the interior of the building")]
        public virtual TenantImprovementsPartitionWalls TenantImprovementsPartitionWalls { get; set; } = new TenantImprovementsPartitionWalls();

        /***************************************************/
    }
}
