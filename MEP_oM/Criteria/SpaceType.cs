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
    [Description("Reusable space-use template containing default HVAC calculation criteria.")]
    public class SpaceType : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Library or project code identifying this space type.")]
        public virtual string Code { get; set; } = "";

        [Description("Default HVAC calculation criteria for this space type. Null means criteria have not been assigned.")]
        public virtual HVACSpaceCriteria HVACCriteria { get; set; } = null;

        [Description("Default HVAC service strategy for spaces assigned this type. Null means no default strategy has been defined.")]
        public virtual SpaceServiceStrategy DefaultServiceStrategy { get; set; } = null;

        /***************************************************/
    }
}