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

using BH.oM.Base;

namespace BH.oM.MEP.Parts
{
    public class EnergyWheel : BHoMObject, IPart
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double OutdoorSummerEnteringDryBulbTemperature { get; set; } = 0.0;
        public double OutdoorSummerEnteringWetBulbTemperature { get; set; } = 0.0;
        public double OutdoorSummerLeavingDryBulbTemperature { get; set; } = 0.0;
        public double OutdoorSummerLeavingWetBulbTemperature { get; set; } = 0.0;

        public double ReliefSummerEnteringDryBulbTemperature { get; set; } = 0.0;
        public double ReliefSummerEnteringWetBulbTemperature { get; set; } = 0.0;
        public double ReliefSummerLeavingDryBulbTemperature { get; set; } = 0.0;
        public double ReliefSummerLeavingWetBulbTemperature { get; set; } = 0.0;

        public double SummerSensibleEffectiveness { get; set; } = 0.0;
        public double SummerTotalEffectiveness { get; set; } = 0.0;

        public double OutdoorWinterEnteringDryBulbTemperature { get; set; } = 0.0;
        public double OutdoorWinterEnteringWetBulbTemperature { get; set; } = 0.0;
        public double OutdoorWinterLeavingDryBulbTemperature { get; set; } = 0.0;
        public double OutdoorWinterLeavingWetBulbTemperature { get; set; } = 0.0;

        public double ReliefWinterEnteringDryBulbTemperature { get; set; } = 0.0;
        public double ReliefWinterEnteringWetBulbTemperature { get; set; } = 0.0;
        public double ReliefWinterLeavingDryBulbTemperature { get; set; } = 0.0;
        public double ReliefWinterLeavingWetBulbTemperature { get; set; } = 0.0;

        public double WinterSensibleEffectiveness { get; set; } = 0.0;
        public double WinterTotalEffectiveness { get; set; } = 0.0;

        public string Type { get; set; } = "";
        public string Control { get; set; } = "";

        /***************************************************/
    }
}

