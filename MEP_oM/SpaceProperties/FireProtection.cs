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

using BH.oM.Quantities.Attributes;
using BH.oM.Base;
using System.ComponentModel;

namespace BH.oM.MEP

{
    [Description("The Fire Protection object defines the fire protection criteria for a space or building.")]
    public class FireProtection : BHoMObject
    {
        [Description("The prescribed hazard type of the space/building (e.g. light, ordinary or extra")]
        public virtual string OccupancyHazardType { get; set; } = "";

        [Area]
        [Description("The amount of area that a sprinkler head is able to cover in the space or building, this value should be represented as m2 per sprinkler head")]
        public virtual double SprinklerCoverage { get; set; } = 0.0;

    }
}