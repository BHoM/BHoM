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

namespace BH.oM.MEP.Parts
{
    [Description("Energy wheels are devices that capture sensible and/or latent heat from air which would otherwise be lost to the atmosphere")]
    public class EnergyWheel : BHoMObject, IPart
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Outdoor Summer Entering Dry Bulb Temperature indicates the temperature of the air entering the system in degrees Celsius, without taking humidity into consideration")]
        public double OutdoorSummerEnteringDryBulbTemperature { get; set; } = 0.0;
        
        [Description("Outdoor Summer Entering Wet Bulb Temperature indicates the temperature of the air entering the system in degrees Celsius, while taking humidity into consideration")]
        public double OutdoorSummerEnteringWetBulbTemperature { get; set; } = 0.0;

        [Description("Outdoor Summer Leaving Dry Bulb Temperature indicates the temperature of the air leaving the system in degrees Celsius, without taking humidity into consideration")]        
        public double OutdoorSummerLeavingDryBulbTemperature { get; set; } = 0.0;
        
        [Description("Outdoor Summer Leaving Wet Bulb Temperature indicates the temperature of the air leaving the system in degrees Celsius, while taking humidity into consideration")]
        public double OutdoorSummerLeavingWetBulbTemperature { get; set; } = 0.0;

        [Description("Relief Summer Entering Dry Bulb Temperature indicates the temperature of the air entering the system in degrees Celsius, without taking humidity into consideration")]
        public double ReliefSummerEnteringDryBulbTemperature { get; set; } = 0.0;
        
        [Description("Relief Summer Entering Wet Bulb Temperature indicates the temperature of the air entering the system in degrees Celsius, while taking humidity into consideration")]
        public double ReliefSummerEnteringWetBulbTemperature { get; set; } = 0.0;
        
        [Description("Relief Summer Leaving Dry Bulb Temperature indicates the temperature of the air leaving the system in degrees Celsius, without taking humidity into consideration")]
        public double ReliefSummerLeavingDryBulbTemperature { get; set; } = 0.0;
        
        [Description("Relief Summer Leaving Wet Bulb Temperature indicates the temperature of the air leaving the system in degrees Celsius, while taking humidity into consideration")]
        public double ReliefSummerLeavingWetBulbTemperature { get; set; } = 0.0;

        [Description("Summer Sensible Effectiveness denotes the wheel's ability to extract sensible heat as a percentage")]
        public double SummerSensibleEffectiveness { get; set; } = 0.0;
        
        [Description("Summer Sensible Effectiveness denotes the wheel's ability to extract sensible and latent heat (also known as the total) as a percentage")]
        public double SummerTotalEffectiveness { get; set; } = 0.0;

        [Description("Outdoor Winter Entering Dry Bulb Temperature indicates the temperature of the air entering the system in degrees Celsius, without taking humidity into consideration")]
        public double OutdoorWinterEnteringDryBulbTemperature { get; set; } = 0.0;
        
        [Description("Outdoor Winter Entering Wet Bulb Temperature indicates the temperature of the air entering the system in degrees Celsius, while taking humidity into consideration")]
        public double OutdoorWinterEnteringWetBulbTemperature { get; set; } = 0.0;
        
        [Description("Outdoor Winter Leaving Dry Bulb Temperature indicates the temperature of the air leaving the system in degrees Celsius, without taking humidity into consideration")]
        public double OutdoorWinterLeavingDryBulbTemperature { get; set; } = 0.0;
        
        [Description("Outdoor Winter Leaving Wet Bulb Temperature indicates the temperature of the air leaving the system in degrees Celsius, while taking humidity into consideration")]
        public double OutdoorWinterLeavingWetBulbTemperature { get; set; } = 0.0;

        [Description("Relief Winter Entering Dry Bulb Temperature indicates the temperature of the air entering the system in degrees Celsius, without taking humidity into consideration")]
        public double ReliefWinterEnteringDryBulbTemperature { get; set; } = 0.0;
        
        [Description("Relief Winter Entering Wet Bulb Temperature indicates the temperature of the air entering the system in degrees Celsius, while taking humidity into consideration")]
        public double ReliefWinterEnteringWetBulbTemperature { get; set; } = 0.0;
        
        [Description("Relief Winter Leaving Dry Bulb Temperature indicates the temperature of the air leaving the system in degrees Celsius, without taking humidity into consideration")]
        public double ReliefWinterLeavingDryBulbTemperature { get; set; } = 0.0;
        
        [Description("Relief Winter Leaving Wet Bulb Temperature indicates the temperature of the air leaving the system in degrees Celsius, while taking humidity into consideration")]
        public double ReliefWinterLeavingWetBulbTemperature { get; set; } = 0.0;

        [Description("Winter Sensible Effectiveness denotes the wheel's ability to extract sensible heat as a percentage")]
        public double WinterSensibleEffectiveness { get; set; } = 0.0;
        
        [Description("Winter Sensible Effectiveness denotes the wheel's ability to extract sensible and latent heat (also known as the total) as a percentage")]
        public double WinterTotalEffectiveness { get; set; } = 0.0;

        [Description("Type indicates the type of wheel (eg air-to-air enthalpy or heat recovery")]
        public string Type { get; set; } = "";
        
        [Description("Control indicates the means of controlling the unit (eg variable frequency controller)")]
        public string Control { get; set; } = "";

        /***************************************************/
    }
}

