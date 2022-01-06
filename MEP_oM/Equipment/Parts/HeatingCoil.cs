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
    [Description("Heating coils allow fluids (air) to raise their temperature as they pass through the coil")]
    public class HeatingCoil : BHoMObject, IPart
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        [Description("Sensible capacity indicates the ability for the heating coil to change the temperature of the fluid (air).")]
        public virtual double SensibleCapacity { get; set; } = 0.0;
        
        [Description("Entering Dry Bulb Air Temperature indicates the heat intensity of the air entering the system in degrees Celsius")]
        public virtual double EnteringDryBulbAirTemperature { get; set; } = 0.0;
        
        [Description("Leaving Dry Bulb Air Temperature indicates the heat intensity of the air leaving the system in degrees Celsius")]
        public virtual double LeavingDryBulbAirTemperature { get; set; } = 0.0;
        
        [Description("Entering Water Temperature indicates the heat intensity of the water entering the system in degrees Celsius")]
        public virtual double EnteringWaterTemperature { get; set; } = 0.0;
        
        [Description("Leaving Water Temperature indicates the heat intensity of the water leaving the system in degrees Celsius")]
        public virtual double LeavingWaterTemperature { get; set; } = 0.0;
        
        [Description("Pressure Drop indicates the amount of resistance created by the coil which creates a loss in pressure of the fluid (air)")]
        public virtual double PressureDrop { get; set; } = 0.0;
        
        [Description("Number of Rows indicates the number of rows of coils that the fluid (air) passes through")]
        public virtual int NumberOfRows { get; set; } = 0;

        /***************************************************/
    }
}



