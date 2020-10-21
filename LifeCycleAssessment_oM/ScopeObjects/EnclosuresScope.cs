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
using BH.oM.Physical.Elements;

namespace BH.oM.LifeCycleAssessment
{
    [Description("The Enclosures Scope object provides a template for expected objects commonly assessed within Life Cycle Assessments. Please provide as many objects with their corresponding Environmental Product Declaration data for the most accurate Life Cycle Assessment.")]
    public class EnclosuresScope : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Enclosure walls are inclusive of the opaque exterior wall assemblies of a building")]
        public virtual List<Wall> Walls { get; set; } = new List<Wall>();
        
        [Description("Enclosure curtain walls are large sheets of transparent glazing on the building exterior")]
        public virtual List<Wall> CurtainWalls { get; set; } = new List<Wall>();
        
        [Description("Enclosure windows are are openings in the building exterior, which consist of framing and glazing")]
        public virtual List<Window> Windows { get; set; } = new List<Window>();
        
        [Description("Enclosure doors are are openings in the building exterior, which consist of framing and panels")]
        public virtual List<Door> Doors { get; set; } = new List<Door>();

        [Description("List of additional user objects that either do not fit within the established categories, or are not explicitly modelled")]
        public virtual List<IElementM> AdditionalObjects { get; set; } = new List<IElementM>();

        /***************************************************/
    }
}
