/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2021, the respective contributors. All rights reserved.
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
using BH.oM.Analytical.Results;
using System.ComponentModel;
using BH.oM.Base;
using System.Collections.ObjectModel;
using BH.oM.Reflection.Debugging;

namespace BH.oM.Test.Results
{
    public class TestResult : IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Describes the focus of the test.")]
        public virtual string Description { get; } = "";

        [Description("States whether the test was a success or not.")]
        public virtual ResultStatus Status { get; } = ResultStatus.Undefined;

        [Description("Events generated during the test.")]
        public virtual List<Event> Events { get; }


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public TestResult(ResultStatus status, List<Event> events, string description = "")
        {
            Status = status;
            Events = events;
            Description = description;
        }

        /***************************************************/
    }
}

