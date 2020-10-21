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

using System.Collections.Generic;
using System.ComponentModel;
using BH.oM.Base;
using BH.oM.MEP.Elements;
using BH.oM.Dimensional;

namespace BH.oM.LifeCycleAssessment
{
    [Description("Electrical Scope provides a template for expected objects to be assessed within the MEPScope")]
    public class ElectricalScope : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        [Description("Batteries include energy storage devices (e.g. lithium-ion batteries)")]
        public virtual List<IElementM> Batteries { get; set; } = new List<IElementM>();

        [Description("Cable trays that are used to route electrical wiring throughout a building")]
        public virtual List<IElementM> CableTrays { get; set; } = new List<IElementM>();

        [Description("Conduit used for electrical service routing includes tubing or channel")]
        public virtual List<IElementM> Conduit { get; set; } = new List<IElementM>();

        [Description("Equipment includes machines or devices that comprise the electrical infrastructure (e.g. meters, switchboards, transformers, solar panels)")]
        public virtual List<IElementM> Equipment { get; set; } = new List<IElementM>();

        [Description("Devices that convert mechanical energy to electrical energy")]
        public virtual List<IElementM> Generators { get; set; } = new List<IElementM>();

        [Description("Devices that provide and distribute illumination")]
        public virtual List<IElementM> LightFixtures { get; set; } = new List<IElementM>();

        [Description("The system of distribution cabling that conveys electricy")]
        public virtual List<WireSegment> WireSegments { get; set; } = new List<WireSegment>();

        [Description("List of additional user objects that either do not fit within the established categories, or are not explicitly modelled")]
        public virtual List<IElementM> AdditionalObjects { get; set; } = new List<IElementM>();
        /***************************************************/
    }
}
