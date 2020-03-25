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
    [Description("Fans are devices that create a current of air (used for ventilation and cooling) by rotating blades")]
    public class Fan : BHoMObject, IPart
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Flow Rate denotes the amount of air that is drawn across the fan, measured in m3/s")]
        public double FlowRate { get; set; } = 0.0;
        
        [Description("External static pressure denotes the resistance within the system that the fan has to overcome from filters, grilles, coils, etc")]
        public double ExternalStaticPressure { get; set; } = 0.0;
        
        [Description("Speed denotes the rotational speed of the fan blades")]
        public double Speed { get; set; } = 0.0;
        
        [Description("Drive type denotes the drive type as either direct or belt")]
        public string DriveType { get; set; } = "";
        
        [Description("A device for controlling the fan speed.")]
        public string SpeedControl { get; set; } = "";
        
        public double BrakeHorsePower { get; set; } = 0.0;
        
        public double HorsePower { get; set; } = 0.0;
        
        [Description("Efficiency denotes the ratio between the power transferred to airflow produced by the fan and the power used by the fan")]
        public double Efficiency { get; set; } = 0.0;

        /***************************************************/
    }
}

