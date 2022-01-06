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
    [Description("Mechanical Scope provides a template for expected objects to be assessed within the MEPScope")]
    public class MechanicalScope : BHoMObject, IScope
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        [Description("Air terminals are the terminal devices for airflow systems (e.g. grilles, diffusers, registers)")]
        public virtual List<IElementM> AirTerminals { get; set; } = new List<IElementM>();

        [Description("Dampers are devices that control the flow within a mechanical duct system (e.g. fire smoke dampers, volume dampers)")]
        public virtual List<IElementM> Dampers { get; set; } = new List<IElementM>();

        [Description("Mechanical distribution system that convey airflow from heating, ventilation or cooling systems (e.g. supply air, extract air, return air)")]
        public virtual List<IElementM> Ducts { get; set; } = new List<IElementM>();

        [Description("Mechanical equipment includes machines and devices that provide heating, cooling, venting, pumping etc. (e.g. chillers, fans, AHUs, pumps)")]
        public virtual List<IElementM> Equipment { get; set; } = new List<IElementM>();

        [Description("Mechanical pipework includes distribution systems that convey fluids for mechanical heating or cooling (e.g. chilled water, heating hot water, refrigerant)")]
        public virtual List<IElementM> Pipes { get; set; } = new List<IElementM>();

        [Description("Refrigerant is a fluid conveyed in refrigeration systems, it is generally a CFC or HCFC laden material (e.g. R-410A, R-22)")]
        public virtual List<IElementM> Refrigerants { get; set; } = new List<IElementM>();

        [Description("Tanks are containers for mechanically conveyed fluids (e.g. diesel tanks that store fuel for generators).")]
        public virtual List<IElementM> Tanks { get; set; } = new List<IElementM>();

        [Description("Valves are devices that control the flow or pressure within a mechanical piping system (e.g. ball valve, globe valve, gate valve).")]
        public virtual List<IElementM> Valves { get; set; } = new List<IElementM>();

        [Description("List of additional user objects that either do not fit within the established categories, or are not explicitly modelled (e.g. hangers, brackets, filters)")]
        public virtual List<IElementM> AdditionalObjects { get; set; } = new List<IElementM>();
        /***************************************************/
    }
}


