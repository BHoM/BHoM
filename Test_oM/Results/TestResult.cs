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
using BH.oM.Analytical.Results;
using System.ComponentModel;
using BH.oM.Base;
using System.Collections.ObjectModel;

namespace BH.oM.Test.Results
{
    public class TestResult : ITestInformation
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Describes the focus of the test that this Test Result answers. This is typically for CI processes but should be human readable for ease of use.")]
        public virtual string Description { get; set; } = "";

        [Description("States whether the test was a success or not. Defaults to Error to ensure any defaults are investigated appropriately.")]
        public virtual TestStatus Status { get; set; } = TestStatus.Error;

        [Description("Information generated during the test.")]
        public virtual List<ITestInformation> Information { get; set; } = new List<ITestInformation>();

        [Description("A human readable message explaining why this Test Result has turned out the way it has, with potential solutions or links to associated wiki pages.")]
        public virtual string Message { get; set; } = "";

        [Description("Provides the UTC time of when the Test Result was executed.")]
        public virtual DateTime UTCTime { get; set; } = DateTime.UtcNow;

        [Description("Machine readable identifier for the Test Result.")]
        public virtual string ID { get; set; } = "";

    }
}


