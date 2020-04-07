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
        public virtual double AirLeakagePercentage { get; set; } = 0.0;
        public virtual double FrostCoilOffTemperature { get; set; } = 0.0;
        public virtual double ReheatCoilOffTemperature { get; set; } = 0.0;

        //Peak Hour
        public virtual int SystemAHUSpaceSummerTotalCoolingPeakHour { get; set; } = 0;

        public virtual double MixCoditionTemperature { get; set; } = 0.0;
        public virtual int SystemAHUSpaceWinterHeatingPeakHour { get; set; } = 0;
        public virtual string RiserCooling { get; set; } = "";
        public virtual double FrostCoilOnTemperature { get; set; } = 0.0;
        public virtual double CoolingCoilFluidTemperature { get; set; } = 0.0;
        public virtual double SpecifiedSupplyAirflow { get; set; } = 0.0;
        public virtual string CoolingCoilCalcMethod { get; set; } = "";
        public virtual double SpecifiedReturnAirflow { get; set; } = 0.0;
        public virtual double FrostCoilSensLoad { get; set; } = 0.0;
        public virtual double SystemAHUSpaceLatWinterLoad { get; set; } = 0.0;
        public virtual double CoolingCoilOnTemperature { get; set; } = 0.0;
        public virtual double WinterHeatRecoveryOnTemperature { get; set; } = 0.0;
        public virtual double HeatRecoverySensEfficiency { get; set; } = 0.0;
        public virtual double NumberOfUnits { get; set; } = 0.0;
        public virtual string CoolingCoilOnEnthalpy { get; set; } = "";
        public virtual double CoolingCoilOnX { get; set; } = 0.0;
        public virtual double SystemAHUSpaceHeatingLoad { get; set; } = 0.0;
        public virtual string Description { get; set; } = "";
        public virtual double ReheatCoilSensLoad { get; set; } = 0.0;

        //Total Load sum from spaces assigned to AHU
        public virtual double SystemAHUSpaceSensCoolingLoad { get; set; } = 0.0;
        public virtual double CoolingCoilTotalLoad { get; set; } = 0.0;

        //Fefinition if AHU is 100% OutsideSupplyAir (OSA) or with recirculation TotalSupplyAir (TSA)
        public virtual string FreshAirType_OSAorTSA { get; set; } = "";

        public virtual double CoolingCoilSensLoad { get; set; } = 0.0;
        public virtual double CoolingCoilOffRH { get; set; } = 0.0;
        
        public virtual double SummerDesignTemperature { get; set; } = 0.0;
        public virtual double SummerDesignRH { get; set; } = 0.0;
        public virtual double CoolingCoilOffX { get; set; } = 0.0;
        public virtual double WinterSupplyTemperature { get; set; } = 0.0;
        public virtual double SystemAHUSpaceTotCoolingLoad { get; set; } = 0.0;

        //Reference of Riser
        public virtual string RiserHeating { get; set; } = "";

        public virtual double CoolingCoilOnRH { get; set; } = 0.0;
        public virtual double SummerSupplyTemperature { get; set; } = 0.0;
        public virtual double SystemAHUSpaceLatCoolingLoad { get; set; } = 0.0;
        public virtual double CoolingCoilOffTemperature { get; set; } = 0.0;
        public virtual string CoolingCoilOffEnthalpy { get; set; } = "";
        public virtual double SystemAHUSpaceWinterSensTotRatio { get; set; } = 0.0;
        public virtual double HeatingCoilFluidTemperature { get; set; } = 0.0;
        public virtual double SpecifiedOutsideSupplyAirflow { get; set; } = 0.0;
        public virtual double HeatRecoveryLatEfficiency { get; set; } = 0.0;
        public virtual double WinterDesignTemperature { get; set; } = 0.0;
        public virtual double WinterHeatRecoveryOffTemperature { get; set; } = 0.0;
        public virtual double ReheatCoilOnTemperature { get; set; } = 0.0;
        public virtual double CoolingCoilLatLoad { get; set; } = 0.0;
        public virtual double SystemAHUSpaceSummerSensTotRatio { get; set; } = 0.0;
        public virtual double SpecifiedOutsideSupplyAirRatio { get; set; } = 0.0;

        /***************************************************/
    }
}

