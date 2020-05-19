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

namespace BH.oM.LifeCycleAssessment
{
    [Description("The Foundations Scope object provides a template for expected objects commonly assessed within Life Cycle Assessments. Please provide as many objects with their corresponding Environmental Product Declaration data for the most accurate Life Cycle Assessment.")]
    public class FoundationsScope : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        
        [Description("Foundation footings (or pile caps) are mats below the buildings piles that help to distribute the load from the structure above")]
        public virtual List<IBHoMObject> FoundationsFootings { get; set; } = new List<IBHoMObject>();
        
        [Description("Foundation piles are structural supports that are driven into the ground below a building to support the building structure")]
        public virtual List<IBHoMObject> FoundationsPiles { get; set; } = new List<IBHoMObject>();
        
        [Description("Foundation walls are structural walls built below-grade")]
        public virtual List<IBHoMObject> FoundationsWalls { get; set; } = new List<IBHoMObject>();
        
        [Description("Foundation slabs are structural slabs upon which the building is constructed. This category expects any type of slab, but assumes no construction properties.")]
        public virtual List<IBHoMObject> FoundationsSlabs { get; set; } = new List<IBHoMObject>();

        /***************************************************/
    }
}
