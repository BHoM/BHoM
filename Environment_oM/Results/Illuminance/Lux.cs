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
using BH.oM.Base;


using BH.oM.Environment.Analysis;
using BH.oM.Environment.Results.Mesh;

using System.ComponentModel;

namespace BH.oM.Environment.Results.Illuminance
{
    [Description("Lux contains results for Lux analysis. Inherits from MeshElementResult which provides properties related to which node this Lux is recorded for")]
    public class Lux : MeshElementResult, IImmutable
    {
        [BH.oM.Quantities.Attributes.Illuminance]
        [Description("The amount of lux recorded for the given analysis node")]
        public virtual double LuxLevel { get; set; } = -1;

        public Lux(IComparable objectId, IComparable nodeId, IComparable resultCase, double timeStep, double luxLevel) : base(objectId, nodeId, resultCase, timeStep)
        {
            LuxLevel = luxLevel;
        }
    }
}


