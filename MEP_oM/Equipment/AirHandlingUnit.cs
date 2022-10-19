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

using System.Collections.Generic;
using System.ComponentModel;
using BH.oM.Base;
using BH.oM.Geometry;
using BH.oM.MEP.Equipment.Parts;
using BH.oM.MEP.System;

namespace BH.oM.MEP.Equipment
{
    [Description("Air Handling Units are devices which house fans, filter, coils, and energy wheels which produce heated and cooled fresh/partially recirculated air to a building")]
    public class AirHandlingUnit : BHoMObject, IFlowEquipment
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public virtual Point Location { get; set ; }
        public virtual List<FlowNode> Connections { get; set; }
        
        [Description("A collection of the parts (Air Handling Unit, Fans, Coils, Energy Wheel, Filters, Electrical Connectors) that make up the Air Handling Unit")]
        public virtual List<IPart> Parts { get; set; } = new List<IPart>();

        /***************************************************/
    }
}



