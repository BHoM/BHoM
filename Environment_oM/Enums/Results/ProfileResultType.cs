/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2018, the respective contributors. All rights reserved.
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

namespace BH.oM.Environment.Results
{
    //Refer to https://github.com/BuroHappoldEngineering/BHoM/issues/332 for details of each result type
    //TODO: Change above link to a wiki link for Environment_oM...
    public enum ProfileResultType
    {
        Undefined,
        RadiationGlobal,
        RadiationDiffuse,
        CloudCover,
        TemperatureExternal,
        HumidityExternal,
        WindSpeed,
        WindDirection,
        TemperatureDryBulb,
        TemperatureMeanRadiant,
        TemperatureResultant,
        LoadSensible,
        LoadHeating,
        LoadCooling,
        GainSolar,
        GainLighting,
        GainInfiltrationVentilation,
        GainAirMovement,
        HeatTransferBuilding,
        ConductionExternalOpaque,
        ConductionExternalGlazing,
        GainOccupantSensible,
        GainEquipmentSensible,
        HumidityRatio,
        HumidityRelative,
        GainOccupancyLatent,
        GainEquipmentLatent,
        LoadLatent,
        LoadLatentRemoval,
        LoadLatentAddition,
        PressureVapour,
        ApertureFlowIn,
        ApertureFlowOut,
        Infiltration,
        Ventilation,
        IZAMIn,
        IZAMOut,
        PressureRelative,
        Pollutant,
        CondensationInternal,
        CondensationInterstitial,
        CondensationExternal,
        ConductionInternal,
        ConductionExternal,
        ApertureOpening,
        LongWaveInternal,
        LongWaveExternal,
        ConvectionInternal,
        ConvectionExternal,
        GainInternalSolar,
    }
}
