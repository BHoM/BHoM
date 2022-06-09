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
    [Description("Electrical Connectors are the devices (motors, disconnects/isolators) that serve as a source of power for mechanical equipment")]
    public class ElectricalConnector : BHoMObject, IPart
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Motor Horsepower indicates the power required for the electrical connector without any power losses")]
        public virtual double MotorHorsePower { get; set; } = 0.0;
        
        [Description("Brake Horsepower indicates the power required for the electrical connector including any power losses")]
        public virtual double BrakeHorsePower { get; set; } = 0.0;
        
        [Description("Full Load Amps indicates the amount of current drawn by the motor when running, and is used for sizing the conductors")]
        public virtual double FullLoadAmps { get; set; } = 0.0;
        
        [Description("Maximum Overcurrent Protection indicates the maximum size of the fuse or breaker")]
        public virtual double MaximumOvercurrentProtection { get; set; } = 0.0;
        
        [Description("Phase denotes the distribution of alternating current (example: single or three phase)")]
        public virtual double Phase { get; set; } = 0.0;
        
        [Description("Frequency is the rate of oscillation")]
        public virtual double Frequency { get; set; } = 0.0;
        
        [Description("Voltage denotes the electrical potential difference (120/208, 277/480 (US), 240, 415 (UK)")]
        public virtual double Voltage { get; set; } = 0.0;
        
        [Description("Emergency Power is a boolean value (true/false) that denotes whether a device requires backup from an emergency power source")]
        public virtual bool EmergencyPower { get; set; } = false;
        
        [Description("Optional Standby is a boolean value (true/false) that denotes whether a device requires backup from a secondary power source, for non-critical systems")]
        public virtual bool StandBy { get; set; } = false;


        /***************************************************/
    }
}


