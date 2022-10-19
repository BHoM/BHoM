/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2022, the respective contributors. All rights reserved.
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

using System.ComponentModel;
using BH.oM.Base;

namespace BH.oM.MEP.Equipment.Parts
{
    public interface IFilter : IBHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        [Description("Entering Dry Bulb Air Temperature indicates the heat intensity of the air entering the system in degrees Celsius, without taking humidity into consideration")]
        double EnteringDryBulbAirTemperature { get; set; }

        [Description("Entering Wet Bulb Air Temperature indicates the heat intensity of the air entering the system in degrees Celsius, while taking humidity into consideration")]
        double EnteringWetBulbAirTemperature { get; set; }

        [Description("Leaving Dry Bulb Air Temperature indicates the heat intensity of the air leaving the system in degrees Celsius, without taking humidity into consideration")]
        double LeavingDryBulbAirTemperature { get; set; }

        [Description("Leaving Wet Bulb Air Temperature indicates the heat intensity of the air leaving the system in degrees Celsius, while taking humidity into consideration")]
        double LeavingWetBulbAirTemperature { get; set; }
    /***************************************************/
}
}



