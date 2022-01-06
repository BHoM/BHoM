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
using BH.oM.Dimensional;

namespace BH.oM.LifeCycleAssessment
{
    [Description("Electrical Scope provides a template for expected objects to be assessed within the MEPScope")]
    public class ElectricalScope : BHoMObject, IScope
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        [Description("Batteries include energy storage devices (e.g. lithium-ion batteries)")]
        public virtual List<IElementM> Batteries { get; set; } = new List<IElementM>();

        [Description("Cable trays are used to route electrical wiring throughout a building")]
        public virtual List<IElementM> CableTrays { get; set; } = new List<IElementM>();

        [Description("Conduit is used for electrical service routing of wires and includes tubing or channel")]
        public virtual List<IElementM> Conduit { get; set; } = new List<IElementM>();

        [Description("Electrical Equipment includes machines or devices that comprise the electrical infrastructure (e.g. switchgear, panels, transformers, automatic transfer switches).")]
        public virtual List<IElementM> Equipment { get; set; } = new List<IElementM>();

        [Description("Fire alarm devices detect and alert the presence of smoke, fire or carbon monoxide (e.g. smoke alarm, audio visual devices).")]
        public virtual List<IElementM> FireAlarmDevices { get; set; } = new List<IElementM>();

        [Description("Generators are devices that convert mechanical energy to electrical energy")]
        public virtual List<IElementM> Generators { get; set; } = new List<IElementM>();

        [Description("Information Communication devices provide a means of passing data (e.g. data outlets, wireless access points, racks, patch panels).")]
        public virtual List<IElementM> InformationCommunicationDevices { get; set; } = new List<IElementM>();

        [Description("Devices that provide and distribute illumination")]
        public virtual List<IElementM> LightFixtures { get; set; } = new List<IElementM>();

        [Description("Devices that provide control of lighting fixtures")]
        public virtual List<IElementM> LightingControls { get; set; } = new List<IElementM>();

        [Description("Meters are devices that measure electrical energy consumed.")]
        public virtual List<IElementM> Meters { get; set; } = new List<IElementM>();

        [Description("Security devices alert or prevent movement between areas of a building (e.g. CCTV cameras, door access control).")]
        public virtual List<IElementM> SecurityDevices { get; set; } = new List<IElementM>();

        [Description("Electrical sockets are devices that serve as outlets for electrical energy (e.g. receptacles, plugs).")]
        public virtual List<IElementM> Sockets { get; set; } = new List<IElementM>();

        [Description("Solar panels are panels that consist of photovoltaic cells that convert sunlight to electricity.")]
        public virtual List<IElementM> SolarPanels { get; set; } = new List<IElementM>();

        [Description("The system of distribution cabling that conveys electricity")]
        public virtual List<IElementM> WireSegments { get; set; } = new List<IElementM>();

        [Description("List of additional user objects that either do not fit within the established categories, or are not explicitly modelled")]
        public virtual List<IElementM> AdditionalObjects { get; set; } = new List<IElementM>();
        /***************************************************/
    }
}


