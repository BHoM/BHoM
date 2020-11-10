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

using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Analytical.Elements
{
    [Description("Class for Relation Process objects.")]
    public class Process : BHoMObject
    {
        [Description("The process method. For BHoM methods this can be extracted from the BHoMMethodList method in the Reflection_Engine.")]
        public virtual MethodBase Method { get; set; } = null;

        [Description("List of input/output pairs to test the method for. Each ProcessData item corresponds to one run of the method.")]
        public virtual List<ProcessData> Data { get; set; } = new List<ProcessData>();

        [Description("Index of the source in the method parameters. Default is 0. Set to -1 if the source is not used as a parameter.")]
        public virtual int SourceParameterIndex { get; set; } = 0;

        [Description("Index of the target in the method parameters. Default is 1. Set to -1 if the target is not used as a parameter.")]
        public virtual int TargetParameterIndex { get; set; } = 1;
    }
}
