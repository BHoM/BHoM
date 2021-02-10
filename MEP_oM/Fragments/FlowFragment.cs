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

using BH.oM.Base;
using BH.oM.MEP.Enums;
using System.ComponentModel;
using BH.oM.Quantities.Attributes;

namespace BH.oM.MEP.Fragments
{
    public class FlowFragment : IFragment
    {
        [Description("The type of Consumption being utilised by the object.")]
        public virtual FlowType Type { get; set; } = FlowType.Undefined;

        [Description("The rate of which the material is flowing through the object.")]
        public virtual double FlowRate { get; set; } = 0;

        [Pressure]
        [Description("The difference in total pressure between two points of a fluid carrying network.")]
        public virtual double PressureDrop { get; set; } = 0;
    }
}


