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

namespace BH.oM.LifeCycleAssessment
{
    [Description("Mechanical Scope")]
    public class MechanicalScope : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        [Description("MEP Ductwork is a material (eg sheet metal) that helps to convey airflow from heating, ventilation or cooling systems")]
        public virtual List<Duct> Ducts { get; set; } = new List<Duct>();

        [Description("MEP Equipment is a machine that processes mechanical, electrical or plumbing loads (eg Fan, Electrical Panel, Pump")]
        public virtual List<IBHoMObject> Equipment { get; set; } = new List<IBHoMObject>();
        
        [Description("MEP Piping is a material (eg copper) that helps to convey fluids (eg water, waste) within a building")]
        public virtual List<Pipe> Pipes { get; set; } = new List<Pipe>();

        [Description("List of additional user objects that either do not fit within the established categories, or are not explicitly modelled")]
        public virtual List<IBHoMObject> AdditionalObjects { get; set; } = new List<IBHoMObject>();
        /***************************************************/
    }
}
