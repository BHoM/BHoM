/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2019, the respective contributors. All rights reserved.
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;

using BH.oM.MEP.Parts;

namespace BH.oM.MEP.Equipment
{
    public class AirHandlingUnit : BHoMObject, IEquipment
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public string Type { get; set; } = "";
        public double TotalSupplyAirFlow { get; set; } = 0.0;
        public double TotalSupplyAirExternalStaticPressure { get; set; } = 0.0;
        public double TotalReturnAirFlow { get; set; } = 0.0;
        public double TotalReturnAirExternalStaticPressure { get; set; } = 0.0;

        public double TotalDesignOutdoorAirFlow { get; set; } = 0.0;
        public double DemandControlledVentilationMinimumOutdoorAirFlow { get; set; } = 0.0;
        public double TotalOutdoorAirFlowExternalStaticPressure { get; set; } = 0.0;
        public double TotalReliefAirFlow { get; set; } = 0.0;
        public double TotalReliefExternalStaticPressure { get; set; } = 0.0;

        public bool SupplyAirEconomiser { get; set; } = false;
        public bool WaterEconomiser { get; set; } = false;

        public List<IPart> Parts { get; set; } = new List<IPart>();

        /***************************************************/
    }
}
