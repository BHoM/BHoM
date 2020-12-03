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
    [Description("A device used to control the flow within a duct system (fire smoke damper, volume damper, etc.)")]
    public class Damper : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        [Description("A type which describes the damper more specifically whether it's a fire smoke damper, volume damper or balancing damper.")]
        public virtual DamperType DamperType { get; set; } = DamperType.Undefined;

        [Description("The point in space for the location of the damper.")]
        public virtual Point Location { get; set; } = new Point();

        [Description("The DuctSectionProperties for the duct connected to the inlet face of the damper.")]
        public virtual DuctSectionProperty InletDuctProperties { get; set; } = null;

        [Description("The DuctSectionProperties for the duct connected to the outlet face of the damper.")]
        public virtual DuctSectionProperty OutletDuctProperties { get; set; } = null;

        [Pressure]
        [Description("The difference in total pressure between two points of a fluid carrying network.")]
        public virtual double PressureDrop { get; set; } = 0;

        /***************************************************/
    }
}
