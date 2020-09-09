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
using BH.oM.Dimensional;

namespace BH.oM.LifeCycleAssessment
{
    [Description("The MEP Scope object provides a template for expected objects to be assessed within this Life Cycle Assessments. Note that this category is not commonly assessed, but will provide for higher quality results. Please provide as many objects with their corresponding Environmental Product Declaration data for the most accurate Life Cycle Assessment.")]
    public class MEPScope : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        [Description("MEP Equipment is a machine that processes mechanical, electrical or plumbing loads (eg Fan, Electrical Panel, Pump")]
        public virtual List<IBHoMObject> Equipment { get; set; } = new List<IBHoMObject>();
        
        [Description("MEP Ductwork is a material (eg sheet metal) that helps to convey airflow from heating, ventilation or cooling systems")]
        public virtual List<IBHoMObject> Ductwork { get; set; } = new List<IBHoMObject>();
        
        [Description("MEP Generators are devices that convert mechanical energy to electrical power")]
        public virtual List<IBHoMObject> Generators { get; set; } = new List<IBHoMObject>();
        
        [Description("MEP Conduit is a tube used to route electrical wiring")]
        public virtual List<IBHoMObject> Conduit { get; set; } = new List<IBHoMObject>();
        
        [Description("MEP Wiring is a flexible conductor of electricity")]
        public virtual List<IBHoMObject> Wiring { get; set; } = new List<IBHoMObject>();
        
        [Description("MEP Lighting is inclusive of all light fixtures")]
        public virtual List<IBHoMObject> Lighting { get; set; } = new List<IBHoMObject>();
        
        [Description("MEP Piping is a material (eg copper) that helps to convey fluids (eg water, waste) within a building")]
        public virtual List<IBHoMObject> Piping { get; set; } = new List<IBHoMObject>();
        
        [Description("MEP Batties are energy storage devices (eg photovoltaic panels)")]
        public virtual List<IBHoMObject> Batteries { get; set; } = new List<IBHoMObject>();

        [Description("List of additional user objects that either do not fit within the established categories, or are not explicitly modelled")]
        public virtual List<IBHoMObject> AdditionalObjects { get; set; } = new List<IBHoMObject>();

        /***************************************************/
    }
}
