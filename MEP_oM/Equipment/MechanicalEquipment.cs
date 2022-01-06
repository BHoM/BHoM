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
using BH.oM.Dimensional;
using BH.oM.MEP.Enums;
using BH.oM.MEP.Equipment.Parts;
using BH.oM.MEP.System;
using BH.oM.Quantities.Attributes;
using System.Collections.Generic;
using System.ComponentModel;

namespace BH.oM.MEP.Equipment
{
    public class MechanicalEquipment : BHoMObject, IEquipment, IElement0D
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("The point in space for the location of the object.")]
        public virtual Node Location { get; set; } = new Node();

        [Angle]
        [Description("Controls the local plan orientation of the object.")]
        public virtual double OrientationAngle { get; set; } = 0;

        [Description("A type which describes the mechanical equipment more specifically whether it's an air handling unit, fan coil unit, boiler or chiller.")]
        public virtual MechanicalEquipmentType MechanicalEquipmentType { get; set; } = MechanicalEquipmentType.Undefined;

        [Description("A collection of the parts (Air Handling Unit, Fans, Coils, Energy Wheel, Filters, Electrical Connectors) that make up the Air Handling Unit")]
        public virtual List<IPart> Parts { get; set; } = new List<IPart>();

        [VolumetricFlowRate]
        [Description("The primary volume of fluid being conveyed by the mechanical equipment per second (m3/s). For an air handling unit it would be the largest air volume (supply air for example.)")]
        public virtual double FlowRate { get; set; } = 0;

        [Description("The power of the mechanical equipment described in kilowatts.")]
        public virtual double Power { get; set; } = 0;

        /***************************************************/
    }
}


