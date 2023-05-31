/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2023, the respective contributors. All rights reserved.
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

namespace BH.oM.LifeCycleAssessment.Configs
{
    [Description("Config for evaluation of climate change metrics using methodology from IStructE.")]
    public class IStructEEvaluationConfig : BHoMObject, IEvaluationConfig
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Total cost of the project.")]
        public virtual double ProjectCost { get; set; } = 0;

        [Area]
        [Description("Total floor area for the project.")]
        public virtual double FloorArea { get; set; } = 0;

        [Mass]
        [Description("Total mass for the project.")]
        public virtual double TotalWeight { get; set; } = 0;

        [ClimateChangePerQuantity]
        [Description("Carbon factor for installation for the project. Gives an additional factor based on project cost and element weight.")]
        public virtual double A5CarbonFactor { get; set; } = 0.007;

        [ClimateChangePerQuantity]
        [Description("Carbon factor for De-construction Demolition for the project. C1 for each element is computed based on this value and total floor area times elements proportional weight to the total.")]
        public virtual double C1CarbonFactor { get; set; } = 3.4;

        /***************************************************/

    }
}


