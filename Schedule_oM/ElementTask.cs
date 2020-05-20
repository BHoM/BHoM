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

using BH.oM.Architecture.Elements;
using BH.oM.Common.Materials;
using BH.oM.Geometry;
using BH.oM.Schedule.Components;
using BH.oM.Schedule.Enums;
using System.Collections.Generic;
using System.ComponentModel;

namespace BH.oM.Schedule
{
    [Description("Any additional programming bespoke information")]
    public class ElementTask
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public virtual Vendor3DApplication Vendor { get; set; }
        public virtual string Guid { get; set; }
        public virtual Phase PhaseCreated { get; set; }
        public virtual Phase PhaseDemolised { get; set; }
        public virtual PhaseType PhaseType { get; set; }
        public virtual WBSType HeadingType { get; set; }
        public virtual Level Level { get; set; }
        public virtual List<string> Names { get; set; } = new List<string>();
        public virtual string ElementId { get; set; }
        public virtual string TaskId { get; set; }
        public virtual string CostCodeId { get; set; }
        public virtual List<Material> Materials { get; set; }
        public virtual BoundingBox BoundingBox { get; set; }
        public virtual string ParentTask { get; set; }
        public virtual List<string> ChildrenTasks { get; set; } = new List<string>();
        public virtual List<CategorySpecificData> CategorySpecificData { get; set; } = new List<CategorySpecificData>();
        public virtual List<Connection> Connections { get; set; } = new List<Connection>();
        public virtual LocalTask LocalTask { get; set; }

        /***************************************************/

        public ElementTask()
        { ; }

        public bool TaskIdIsNumber()
        {
            long l = long.MinValue;
            long.TryParse(this.TaskId, out l);
            if (l > long.MinValue)
            { return true; }
            else
            { return false; }
        }

        public bool ElementIdIsNumber()
        {
            long l = long.MinValue;
            long.TryParse(this.ElementId, out l);
            if (l > long.MinValue)
            { return true; }
            else
            { return false; }
        }
    }
}
