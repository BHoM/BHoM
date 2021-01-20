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

using System.ComponentModel;
using BH.oM.Base;
using BH.oM.MEP.System.SectionProperties;
using BH.oM.MEP.Enums;
using BH.oM.Dimensional;
using BH.oM.Quantities.Attributes;
using BH.oM.Geometry;

namespace BH.oM.MEP.System.Dampers
{
    [Description("A device used to control the flow within a piping system (ball valve, check valve, etc.)")]
    public class Valve : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        [Description("A type which describes the valve, more specifically whether it's a check valve, gate valve, etc.")]
        public virtual ValveType ValveType { get; set; } = ValveType.Undefined;

        [Description("The point in space for the location of the valve.")]
        public virtual Point Location { get; set; } = new Point();

        //pipe connection properties to be added at a later date

        [Pressure]
        [Description("The difference in total pressure between two points of a fluid carrying network.")]
        public virtual double PressureDrop { get; set; } = 0;

        /***************************************************/
    }
}
