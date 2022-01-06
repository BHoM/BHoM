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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Test;
using System.ComponentModel;

namespace BH.oM.Test.Results
{
    [Description("Class to store an event raised during the execution on a TestResult.")]
    public class EventMessage : ITestInformation
    {
        [Description("Message raised during the execution.")]
        public virtual string Message { get; set; } = "";

        [Description("Severity of the message.")]
        public virtual TestStatus Status { get; set; } = TestStatus.Error;

        [Description("Provides the UTC time of when the event was raised.")]
        public virtual DateTime UTCTime { get; set; } = DateTime.UtcNow;

        [Description("Original location where the event was generated.")]
        public virtual string StackTrace { get; set; } = "";
    }
}

