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
    [Description("Fans are devices that create a current of air (used for ventilation and cooling) by rotating blades")]
    public class Fan : BHoMObject, IPart
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Flow Rate denotes the amount of air that is drawn across the fan, measured in m3/s")]
        public virtual double FlowRate { get; set; } = 0.0;
        
        [Description("External static pressure denotes the resistance within the system that the fan has to overcome from filters, grilles, coils, etc")]
        public virtual double ExternalStaticPressure { get; set; } = 0.0;
        
        [Description("Speed denotes the rotational speed of the fan blades")]
        public virtual double Speed { get; set; } = 0.0;
        
        [Description("Drive type denotes the drive type as either direct or belt")]
        public virtual string DriveType { get; set; } = "";
        
        [Description("A device for controlling the fan speed.")]
        public virtual string SpeedControl { get; set; } = "";
        
        public virtual double BrakeHorsePower { get; set; } = 0.0;
        
        public virtual double HorsePower { get; set; } = 0.0;
        
        [Description("Efficiency denotes the ratio between the power transferred to airflow produced by the fan and the power used by the fan")]
        public virtual double Efficiency { get; set; } = 0.0;

        /***************************************************/
    }
}



