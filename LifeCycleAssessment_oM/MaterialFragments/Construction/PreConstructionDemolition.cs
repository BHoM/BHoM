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
using BH.oM.Quantities.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BH.oM.LifeCycleAssessment.MaterialFragments.Construction
{
    [Description("A class defining the environmental impacts associated with the demolition of existing buildings prior to construction of a new building.")]
    public class PreConstructionDemolition : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("List of environmental factors associated with the demolition process. The default values are indicative only and should be replaced with project specific data where available. All factors stated per unit area.")]
        public virtual List<IEnvironmentalFactor> EnvironmentalFactors { get; set; } = new List<IEnvironmentalFactor>() { new ClimateChangeFossilFactor { Value = 35 }, new ClimateChangeBiogenicFactor { Value = 0 }, new ClimateChangeLandUseFactor { Value = 0 }, new ClimateChangeTotalFactor { Value = 35 }, new ClimateChangeTotalNoBiogenicFactor { Value = 35 } };

        [Area]
        [Description("The area of floor that is demolished prior to construction of the new building. This is used to scale the environmental factors above.")]
        public virtual double DemolishedFloorArea { get; set; } = 0;

        /***************************************************/
    }
}

