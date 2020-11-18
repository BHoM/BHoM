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
using BH.oM.Dimensional;
using BH.oM.Geometry;
using BH.oM.Quantities.Attributes;
using BH.oM.Analytical.Elements;


namespace BH.oM.MEP.Fixtures
{
    [Description("A device used to regulate the volume of air to or from an air handling unit, variable air volume device or similar, to or from the occupied space. These devices may be ducted or connect directly to a plenum, in which case no duct connection will be present.")]
    public class AirTerminal : BHoMObject, IElementM, INode
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("The point in space for the location of the Air Terminal.")]
        public virtual Point Position { get; set; } = new Point();

        [VolumetricFlowRate]
        [Description("The volume of air being conveyed by the Duct per second (m3/s).")]
        public virtual double FlowRate { get; set; } = 0;

        [Pressure]
        [Description("The difference in total pressure between two points of a system measured in Pascals.")]
        public virtual double PressureDrop { get; set; } = 0;

        [Description("The DuctSectionProperties for the duct connected to the air terminal.")]
        public virtual DuctSectionProperty ConnectedDuctProperties { get; set; } = null;

        /***************************************************/
    }
}
