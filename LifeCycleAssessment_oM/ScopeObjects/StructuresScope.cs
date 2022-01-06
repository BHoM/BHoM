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
    [Description("The Structures Scope object provides a template for expected objects commonly assessed within Life Cycle Assessments. Please provide as many objects with their corresponding Environmental Product Declaration data for the most accurate Life Cycle Assessment.")]
    public class StructuresScope : BHoMObject, IScope
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        [Description("Structural slabs are inclusive of the above-grade structural floors in a building")]
        public virtual List<IElementM> Slabs { get; set; } = new List<IElementM>();

        [Description("Structural core walls are inclusive of the above-grade, structural-grade walls surrounding the core (elevators, building services)")]
        public virtual List<IElementM> CoreWalls { get; set; } = new List<IElementM>();

        [Description("Structural beams are typically horizontal elements that carry the load of floors, roofs, and ceilings")]
        public virtual List<IElementM> Beams { get; set; } = new List<IElementM>();

        [Description("Structural columns are typically vertical elements that carry the load of floors, roofs, and ceilings")]
        public virtual List<IElementM> Columns { get; set; } = new List<IElementM>();

        [Description("Structural bracing are typically diagonal members that provide lateral support between structural bays")]
        public virtual List<IElementM> Bracing { get; set; } = new List<IElementM>();

        [Description("List of additional user objects that either do not fit within the established categories, or are not explicitly modelled")]
        public virtual List<IElementM> AdditionalObjects { get; set; } = new List<IElementM>();

        /***************************************************/
    }
}


