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

using System.Collections.Generic;
using BH.oM.Base;
using System.ComponentModel;
using BH.oM.LifeCycleAssessment;

namespace BH.oM.LifeCycleAssessment
{
    [Description("A classification of emission quantities and coefficients for a specific type of vehicle.")]
    public class TransporationMetric : BHoMObject // a dataset
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("The amount of the specified Field.")]
        public virtual ModeOfTransport ModeOfTransport { get; set; } = ModeOfTransport.Undefined;

        [Description("kg/unit of CO2 for the transportation type.")]
        public virtual double CO2Factor { get; set; } = double.NaN; // better name for this?

        [Description("g/unit of CH4 for the transportation type.")]
        public virtual double CH4Factor { get; set; } = double.NaN; // better name for this?

        [Description("g/unit of N20 for the transportation type.")]
        public virtual double N20Factor { get; set; } = double.NaN; // better name for this?

        [Description("kgCO2e/unit of CH4 for the transportation type.")]
        public virtual double globalWarmingPotential { get; set; } = double.NaN;

        /***************************************************/
    }
}



