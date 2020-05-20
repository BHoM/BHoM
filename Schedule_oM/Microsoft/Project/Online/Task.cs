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

using BH.oM.Schedule.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;

namespace BH.oM.Schedule.Microsoft.Project.Online.Components
{
    [Description("Mock MS Project Online task object")]
    public class Task
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public virtual bool IsActive { get; set; }
        public virtual bool IsEffortDriven { get; set; }
        public virtual bool IsLockedByManager { get; set; }
        public virtual bool IsManual { get; set; }
        public virtual bool IsMarked { get; set; }
        public virtual bool IsMilestone { get; set; }
        public virtual bool LevelingAdjustsAssignments { get; set; }
        public virtual bool LevelingCanSplit { get; set; }
        public virtual bool UsePercentPhysicalWorkComplete { get; set; }
        public virtual Calendar Calendar { get; set; }
        public virtual ConstraintType ConstraintType { get; set; }
        public virtual DateTime ActualFinish { get; set; }
        public virtual DateTime ActualStart { get; set; }
        public virtual DateTime Completion { get; set; }
        public virtual DateTime ConstraintStartEnd { get; set; }
        public virtual DateTime Deadline { get; set; }
        public virtual DateTime Finish { get; set; }
        public virtual DateTime Start { get; set; }
        public virtual Dictionary<string, object> FieldValues { get; }
        public virtual double ActualCost { get; set; }
        public virtual double Cost { get; set; }
        public virtual double FixedCost { get; set; }
        //public virtual DraftAssignmentCollection Assignments { get; }
        public virtual Task Parent { get; }
        //public virtual DraftTaskLinkCollection Predecessors { get; }
        //public virtual DraftTaskLinkCollection Successors { get; }
        public virtual int OutlineLevel { get; set; }
        public virtual int PercentComplete { get; set; }
        public virtual int PercentPhysicalWorkComplete { get; set; }
        public virtual int Priority { get; set; }
        public virtual string ActualWork { get; set; }
        public virtual string BudgetWork { get; set; }
        public virtual string Duration { get; set; }
        public virtual string FinishText { get; set; }
        public virtual string Name { get; set; }
        public virtual string RemainingDuration { get; set; }
        public virtual string StartText { get; set; }
        public virtual string Work { get; set; }
        public virtual TaskType TaskType { get; set; }
        public virtual TimeSpan ActualWorkTimeSpan { get; set; }
        public virtual TimeSpan BudgetWorkTimeSpan { get; set; }
        public virtual TimeSpan DurationTimeSpan { get; set; }
        public virtual TimeSpan RemainingDurationTimeSpan { get; set; }
        public virtual TimeSpan WorkTimeSpan { get; set; }
        public virtual User StatusManager { get; set; }

        /***************************************************/

        public Task()
        { ; }
    }
}
