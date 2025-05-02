/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2025, the respective contributors. All rights reserved.
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
using BH.oM.LifeCycleAssessment.MaterialFragments.EnvironmentalFactors;
using BH.oM.Quantities.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BH.oM.LifeCycleAssessment.MaterialFragments.Transport
{
    [Description("Class for storing emssions of a particular type of vehicle per mass transported and distance traveled.")]
    public class VehicleEmissions : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Name identifying the type of vehicle the emissions relate to.")]
        public override string Name { get; set; }

        [Description("Metrics relating to the emissions by the vehicle. All metrics assumed to be impact per mass and distance traveled.")]
        public virtual List<IEnvironmentalFactor> EnvironmentalFactors { get; set; } = new List<IEnvironmentalFactor>();

        [Description("Factor on the metrics acounting for the empty running of the vehicle returning from the site. Final impact of the metric computed by scling values by 1 + ReturTripFactor.")]
        public virtual double ReturnTripFactor { get; set; } = 0;

        /***************************************************/

    }
}


