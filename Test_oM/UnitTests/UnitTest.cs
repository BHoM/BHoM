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

using BH.oM.Base;
using System.Collections.Generic;
using System.Reflection;
using System.ComponentModel;

namespace BH.oM.Test.UnitTests
{
    [Description("Defines a data-driven unit test for a specific method. Class defines inputs, method to be run and expected output.")]
    public class UnitTest : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("The method to be tested. For BHoM methods this can be extracted from the BHoMMethodList method in the Reflection_Engine.")]
        public virtual MethodBase Method { get; set; } = null;

        [Description("List of input/output pairs to test the method for. Each TestData item corresponds to one run of the method.")]
        public virtual List<TestData> Data { get; set; } = new List<TestData>();


        /***************************************************/
    }
}
