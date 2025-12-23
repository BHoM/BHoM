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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BH.oM.LifeCycleAssessment.MaterialFragments
{
    [Description("Class containing a set of pre-computed values per metric type for a particular module that can be used to override existing values or fill in missing values where they dont exist. Values should be the resulting total.")]
    public class PrecomputedModuleValues : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Dictionary containing resulting values per metric type for a particular module that can be used to override existing values or fill in missing values where they dont exist. Values should be the resulting total.")]
        public virtual Dictionary<MetricType, double> ModuleValues { get; set; } = new Dictionary<MetricType, double>();

        [Description("If true, any existing values for the module will be overwritten with the pre-computed values. If false, only missing values will be filled in.")]
        public virtual bool OverwriteExistingValues { get; set; } = true;
    }
}

