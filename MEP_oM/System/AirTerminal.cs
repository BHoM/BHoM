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
using BH.oM.Quantities.Attributes;

namespace BH.oM.MEP.System
{
    [Description("A device used to regulate the volume of conditioned primary air from the central air handler to the occupied space.")]
    public class AirTerminal : BHoMObject, IElementM
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [VolumetricFlowRate]
        [Description("The volume of fluid being conveyed by the Duct per second (m3/s).")]
        public virtual double FlowRate { get; set; } = 0;

        [Description("The difference in total pressure between two points of a fluid carrying network measured in Millibar.")]
        public virtual double PressureDrop { get; set; } = 0;

        [Description("The DuctSectionProperties for the air terminal connected to the inlet of the unit.")]
        public virtual DuctSectionProperty InletDuctProperties { get; set; } = null;

        /***************************************************/
    }
}
