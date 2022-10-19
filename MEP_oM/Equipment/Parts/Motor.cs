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
using BH.oM.MEP.Enums;

namespace BH.oM.MEP.Equipment.Parts
{
    [Description("")]
    public class Motor : BHoMObject, IPart, IMotor, IElectrical
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        public virtual double Speed { get; set; } = 0.0;
        public virtual MotorDriveType DriveType { get; set; } = MotorDriveType.Undefined;  
        public virtual double BrakeHorsePower { get; set; } = 0.0;
        public virtual double Efficiency { get; set; } = 0.0;
        public virtual double Size { get; set; } = 0.0;
        public virtual double Phase { get; set; } = 0.0;
        public virtual double Voltage { get; set; } = 0.0;
        public virtual double Frequency { get; set; } = 0.0;
        public virtual double FullLoadAmps { get; set; } = 0.0;
        public virtual double MaximumOverCurrentProtection { get; set; } = 0.0;
        public virtual MotorSpeedControlType SpeedControl { get; set; } = MotorSpeedControlType.Undefined;

        /***************************************************/
    }
}



