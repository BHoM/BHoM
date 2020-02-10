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

using BH.oM.Environment.Fragments;
using BH.oM.Base;

using System.Collections.Generic;

namespace BH.oM.Environment.Equipment
{
    public class AirHandlingUnit : BHoMObject, IEquipment
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        //Properties of Air Handling Units
        public double AirLeakagePercentage { get; set; } = 0.0;
        public double FrostCoilOffTemperature { get; set; } = 0.0;
        public double ReheatCoilOffTemperature { get; set; } = 0.0;

        //Peak Hour
        public int SystemAHUSpaceSummerTotalCoolingPeakHour { get; set; } = 0;

        public double MixCoditionTemperature { get; set; } = 0.0;
        public int SystemAHUSpaceWinterHeatingPeakHour { get; set; } = 0;
        public string RiserCooling { get; set; } = "";
        public double FrostCoilOnTemperature { get; set; } = 0.0;
        public double CoolingCoilFluidTemperature { get; set; } = 0.0;
        public double SpecifiedSupplyAirflow { get; set; } = 0.0;
        public string CoolingCoilCalcMethod { get; set; } = "";
        public double SpecifiedReturnAirflow { get; set; } = 0.0;
        public double FrostCoilSensLoad { get; set; } = 0.0;
        public double SystemAHUSpaceLatWinterLoad { get; set; } = 0.0;
        public double CoolingCoilOnTemperature { get; set; } = 0.0;
        public double WinterHeatRecoveryOnTemperature { get; set; } = 0.0;
        public double HeatRecoverySensEfficiency { get; set; } = 0.0;
        public double NumberOfUnits { get; set; } = 0.0;
        public string CoolingCoilOnEnthalpy { get; set; } = "";
        public double CoolingCoilOnX { get; set; } = 0.0;
        public double SystemAHUSpaceHeatingLoad { get; set; } = 0.0;
        public string Description { get; set; } = "";
        public double ReheatCoilSensLoad { get; set; } = 0.0;

        //Total Load sum from spaces assigned to AHU
        public double SystemAHUSpaceSensCoolingLoad { get; set; } = 0.0;
        public double CoolingCoilTotalLoad { get; set; } = 0.0;

        //Fefinition if AHU is 100% OutsideSupplyAir (OSA) or with recirculation TotalSupplyAir (TSA)
        public string FreshAirType_OSAorTSA { get; set; } = "";

        public double CoolingCoilSensLoad { get; set; } = 0.0;
        public double CoolingCoilOffRH { get; set; } = 0.0;
        
        public double SummerDesignTemperature { get; set; } = 0.0;
        public double SummerDesignRH { get; set; } = 0.0;
        public double CoolingCoilOffX { get; set; } = 0.0;
        public double WinterSupplyTemperature { get; set; } = 0.0;
        public double SystemAHUSpaceTotCoolingLoad { get; set; } = 0.0;

        //Reference of Riser
        public string RiserHeating { get; set; } = "";

        public double CoolingCoilOnRH { get; set; } = 0.0;
        public double SummerSupplyTemperature { get; set; } = 0.0;
        public double SystemAHUSpaceLatCoolingLoad { get; set; } = 0.0;
        public double CoolingCoilOffTemperature { get; set; } = 0.0;
        public string CoolingCoilOffEnthalpy { get; set; } = "";
        public double SystemAHUSpaceWinterSensTotRatio { get; set; } = 0.0;
        public double HeatingCoilFluidTemperature { get; set; } = 0.0;
        public double SpecifiedOutsideSupplyAirflow { get; set; } = 0.0;
        public double HeatRecoveryLatEfficiency { get; set; } = 0.0;
        public double WinterDesignTemperature { get; set; } = 0.0;
        public double WinterHeatRecoveryOffTemperature { get; set; } = 0.0;
        public double ReheatCoilOnTemperature { get; set; } = 0.0;
        public double CoolingCoilLatLoad { get; set; } = 0.0;
        public double SystemAHUSpaceSummerSensTotRatio { get; set; } = 0.0;
        public double SpecifiedOutsideSupplyAirRatio { get; set; } = 0.0;

        /***************************************************/
    }
}

