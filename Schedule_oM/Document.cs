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

using BH.oM.Schedule.Components;
using BH.oM.Schedule.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BH.oM.Schedule
{
    [Description("Acts as the programme schedule document")]
    public class Document
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public virtual string Name { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual SchedulerApplication ApplicationType { get; set; } = SchedulerApplication.Microsoft_Project_Online;
        public virtual IList<ElementTask> Tasks { get; set; } = new List<ElementTask>();
        public virtual IList<Phase> Phases { get; set; } = new List<Phase>();

        /***************************************************/

        public Document()
        { ; }

        public Phase PhaseById(string Id)
        {
            return Phases.FirstOrDefault(p => p.Guid == Id);
        }
    }
}