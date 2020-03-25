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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using BH.oM.Base;

using BH.oM.MEP.Parts;

namespace BH.oM.MEP.Equipment
{
    [Description("Air Handling Units are devices which house fans, filter, coils, and energy wheels which produce heated and cooled fresh/partially recirculated air to a building")]
    public class AirHandlingUnit : BHoMObject, IEquipment
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Type denotes the kind of Air Handling Unit (eg heat and ventilation, energy recovery)")]
        public string Type { get; set; } = "";
        
        [Description("Total Supply Airflow accounts for the total amount of air supplied to the building by the Air Handling Unit")]
        public double TotalSupplyAirFlow { get; set; } = 0.0;
        
        [Description("Total supply external static pressure denotes the resistance within the system that the supply fan has to overcome from filters, grilles, coils, etc")]
        public double TotalSupplyAirExternalStaticPressure { get; set; } = 0.0;
        
        [Description("Total Return Airflow accounts for the total amount of air returned from the building to the Air Handling Unit")]
        public double TotalReturnAirFlow { get; set; } = 0.0;
        
        [Description("Total return external static pressure denotes the resistance within the system that the return fan has to overcome from grilles, ducts, etc")]
        public double TotalReturnAirExternalStaticPressure { get; set; } = 0.0;
        
        [Description("Total Design Outdoor Airflow accounts for the total amount of outdoor air introduced to the supply air that goes to the building from the Air Handling Unit")]
        public double TotalDesignOutdoorAirFlow { get; set; } = 0.0;
        
        [Description("Demand Controlled Ventilation Minimum Outdoor Airflow denotes that amount of outdoor air that is required to be supplied to the building, at a minimum")]
        public double DemandControlledVentilationMinimumOutdoorAirFlow { get; set; } = 0.0;
        
        [Description("Total outdoor air external static pressure denotes the resistance within the system that the outdoor air intake fan has to overcome")]
        public double TotalOutdoorAirFlowExternalStaticPressure { get; set; } = 0.0;
        
        [Description("Total Relief Airflow accounts for the total amount of extract/exhaust air that is removed from the system and introduced to the atmosphere")]
        public double TotalReliefAirFlow { get; set; } = 0.0;
        [Description("Total Relief Airflow external static pressure denotes the resistance within the system that the relief/extract/exhaust fan has to overcome")]
        
        public double TotalReliefExternalStaticPressure { get; set; } = 0.0;

        
        [Description("Supply Air Economisers allow additional outdoor air to be introduced to the system when outdoor conditions are favorable (typically cool and dry)")]
        public bool SupplyAirEconomiser { get; set; } = false;
        
        [Description("Water Economisers allow returned fluids to be introduced to the system when conditions are favorable")]
        public bool WaterEconomiser { get; set; } = false;

        [Description("A collection of the parts (Fans, Coils, Energy Wheel, Filters, Electrical Connectors) that make up the Air Handling Unit")]
        public List<IPart> Parts { get; set; } = new List<IPart>();

        /***************************************************/
    }
}

