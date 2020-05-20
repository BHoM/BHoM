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
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BH.oM.Schedule.Microsoft.Project.Desktop.Components
{
    [Description("Mock MS Project Desktop task object")]
    public class Task
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public virtual bool Active { get; set; }
        public virtual decimal ActualCost { get; set; }
        public virtual Duration ActualDuration { get; set; }
        public virtual DateTime ActualFinish { get; set; }
        public virtual decimal ActualOvertimeCost { get; }
        public virtual decimal ActualOvertimeWork { get; }
        public virtual decimal ActualOvertimeWorkProtected { get; set; }
        public virtual DateTime ActualStart { get; set; }
        public virtual decimal ActualWork { get; set; }
        public virtual decimal ActualWorkProtected { get; set; }
        public virtual decimal ACWP { get; }
        public virtual IList<Baseline> Baselines { get; set; } = new List<Baseline>();
        public virtual decimal BCWP { get; }
        public virtual decimal BCWS { get; }
        public virtual decimal BudgetCost { get; set; }
        public virtual decimal BudgetWork { get; set; }
        public virtual string Calendar { get; set; }
        public virtual string CalendarGuid { get; }
        public virtual bool Confirmed { get; }
        public virtual DateTime ConstraintDate { get; set; }
        public virtual ConstraintType ConstraintType { get; set; }
        public virtual string Contact { get; set; }
        public virtual decimal Cost { get; set; }
        public virtual decimal Cost1 { get; set; }
        public virtual decimal Cost10 { get; set; }
        public virtual decimal Cost2 { get; set; }
        public virtual decimal Cost3 { get; set; }
        public virtual decimal Cost4 { get; set; }
        public virtual decimal Cost5 { get; set; }
        public virtual decimal Cost6 { get; set; }
        public virtual decimal Cost7 { get; set; }
        public virtual decimal Cost8 { get; set; }
        public virtual decimal Cost9 { get; set; }
        public virtual decimal CostVariance { get; }
        public virtual double CPI { get; }
        public virtual DateTime Created { get; }
        public virtual bool Critical { get; }
        public virtual decimal CV { get; }
        public virtual decimal CVPercent { get; }
        public virtual DateTime Date1 { get; set; }
        public virtual DateTime Date10 { get; set; }
        public virtual DateTime Date2 { get; set; }
        public virtual DateTime Date3 { get; set; }
        public virtual DateTime Date4 { get; set; }
        public virtual DateTime Date5 { get; set; }
        public virtual DateTime Date6 { get; set; }
        public virtual DateTime Date7 { get; set; }
        public virtual DateTime Date8 { get; set; }
        public virtual DateTime Date9 { get; set; }
        public virtual DateTime Deadline { get; set; }
        public virtual DateTime DeliverableFinish { get; set; }
        public virtual string DeliverableGuid { get; set; }
        public virtual string DeliverableName { get; set; }
        public virtual DateTime DeliverableStart { get; set; }
        public virtual short DeliverableType { get; set; }
        public virtual Duration Duration { get; set; }
        public virtual Duration Duration1 { get; set; }
        public virtual Duration Duration10 { get; set; }
        public virtual Duration Duration10Estimated { get; set; }
        public virtual Duration Duration1Estimated { get; set; }
        public virtual Duration Duration2 { get; set; }
        public virtual Duration Duration2Estimated { get; set; }
        public virtual Duration Duration3 { get; set; }
        public virtual Duration Duration3Estimated { get; set; }
        public virtual Duration Duration4 { get; set; }
        public virtual Duration Duration4Estimated { get; set; }
        public virtual Duration Duration5 { get; set; }
        public virtual Duration Duration5Estimated { get; set; }
        public virtual Duration Duration6 { get; set; }
        public virtual Duration Duration6Estimated { get; set; }
        public virtual Duration Duration7 { get; set; }
        public virtual Duration Duration7Estimated { get; set; }
        public virtual Duration Duration8 { get; set; }
        public virtual Duration Duration8Estimated { get; set; }
        public virtual Duration Duration9 { get; set; }
        public virtual Duration Duration9Estimated { get; set; }
        public virtual string DurationText { get; set; }
        public virtual decimal DurationVariance { get; }
        public virtual decimal EAC { get; }
        public virtual DateTime EarlyFinish { get; }
        public virtual DateTime EarlyStart { get; }
        public virtual bool EffortDriven { get; set; }
        public virtual string ErrorMessage { get; }
        public virtual bool Estimated { get; set; }
        public virtual bool ExternalTask { get; }
        public virtual DateTime Finish { get; set; }
        public virtual DateTime Finish1 { get; set; }
        public virtual DateTime Finish10 { get; set; }
        public virtual DateTime Finish2 { get; set; }
        public virtual DateTime Finish3 { get; set; }
        public virtual DateTime Finish4 { get; set; }
        public virtual DateTime Finish5 { get; set; }
        public virtual DateTime Finish6 { get; set; }
        public virtual DateTime Finish7 { get; set; }
        public virtual DateTime Finish8 { get; set; }
        public virtual DateTime Finish9 { get; set; }
        public virtual decimal FinishSlack { get; }
        public virtual string FinishText { get; set; }
        public virtual decimal FinishVariance { get; }
        public virtual decimal FixedCost { get; set; }
        public virtual Duration FixedDuration { get; set; }
        public virtual bool Flag1 { get; set; }
        public virtual bool Flag10 { get; set; }
        public virtual bool Flag11 { get; set; }
        public virtual bool Flag12 { get; set; }
        public virtual bool Flag13 { get; set; }
        public virtual bool Flag14 { get; set; }
        public virtual bool Flag15 { get; set; }
        public virtual bool Flag16 { get; set; }
        public virtual bool Flag17 { get; set; }
        public virtual bool Flag18 { get; set; }
        public virtual bool Flag19 { get; set; }
        public virtual bool Flag2 { get; set; }
        public virtual bool Flag20 { get; set; }
        public virtual bool Flag3 { get; set; }
        public virtual bool Flag4 { get; set; }
        public virtual bool Flag5 { get; set; }
        public virtual bool Flag6 { get; set; }
        public virtual bool Flag7 { get; set; }
        public virtual bool Flag8 { get; set; }
        public virtual bool Flag9 { get; set; }
        public virtual decimal FreeSlack { get; }
        public virtual bool GroupBySummary { get; }
        public virtual string Guid { get; }
        public virtual bool HideBar { get; set; }
        public virtual string Hyperlink { get; set; }
        public virtual string HyperlinkAddress { get; set; }
        public virtual string HyperlinkHREF { get; set; }
        public virtual string HyperlinkScreenTip { get; set; }
        public virtual string HyperlinkSubAddress { get; set; }
        public virtual int ID { get; }
        public virtual bool IgnoreResourceCalendar { get; set; }
        public virtual bool IgnoreWarnings { get; set; }
        public virtual int Index { get; }
        public virtual bool IsDurationValid { get; }
        public virtual bool IsFinishValid { get; }
        public virtual bool IsPublished { get; set; }
        public virtual bool IsStartValid { get; }
        public virtual DateTime LateFinish { get; }
        public virtual DateTime LateStart { get; }
        public virtual bool LevelIndividualAssignments { get; set; }
        public virtual bool LevelingCanSplit { get; set; }
        public virtual decimal LevelingDelay { get; set; }
        public virtual bool LinkedFields { get; }
        public virtual bool Manual { get; set; }
        public virtual bool Marked { get; set; }
        public virtual bool Milestone { get; set; }
        public virtual string Name { get; set; }
        public virtual string Notes { get; set; }
        public virtual double Number1 { get; set; }
        public virtual double Number10 { get; set; }
        public virtual double Number11 { get; set; }
        public virtual double Number12 { get; set; }
        public virtual double Number13 { get; set; }
        public virtual double Number14 { get; set; }
        public virtual double Number15 { get; set; }
        public virtual double Number16 { get; set; }
        public virtual double Number17 { get; set; }
        public virtual double Number18 { get; set; }
        public virtual double Number19 { get; set; }
        public virtual double Number2 { get; set; }
        public virtual double Number20 { get; set; }
        public virtual double Number3 { get; set; }
        public virtual double Number4 { get; set; }
        public virtual double Number5 { get; set; }
        public virtual double Number6 { get; set; }
        public virtual double Number7 { get; set; }
        public virtual double Number8 { get; set; }
        public virtual double Number9 { get; set; }
        public virtual string OutlineCode1 { get; set; }
        public virtual string OutlineCode10 { get; set; }
        public virtual string OutlineCode2 { get; set; }
        public virtual string OutlineCode3 { get; set; }
        public virtual string OutlineCode4 { get; set; }
        public virtual string OutlineCode5 { get; set; }
        public virtual string OutlineCode6 { get; set; }
        public virtual string OutlineCode7 { get; set; }
        public virtual string OutlineCode8 { get; set; }
        public virtual string OutlineCode9 { get; set; }
        public virtual short OutlineLevel { get; set; }
        public virtual string OutlineNumber { get; }
        //public virtual Task OutlineParent { get; }
        public virtual bool Overallocated { get; }
        public virtual decimal OvertimeCost { get; }
        public virtual decimal OvertimeWork { get; }
        public virtual Guid Parent { get; set; }
        public virtual bool PathDrivenSuccessor { get; }
        public virtual bool PathDrivingPredecessor { get; }
        public virtual bool PathPredecessor { get; }
        public virtual bool PathSuccessor { get; }
        public virtual decimal PercentComplete { get; set; }
        public virtual decimal PercentWorkComplete { get; set; }
        public virtual decimal PhysicalPercentComplete { get; set; }
        public virtual bool Placeholder { get; }
        public virtual string Predecessors { get; set; }
        public virtual DateTime PreleveledFinish { get; }
        public virtual DateTime PreleveledStart { get; }
        public virtual int Priority { get; set; }
        public virtual string Project { get; }
        public virtual int RecalcFlags { get; }
        public virtual bool Recurring { get; }
        public virtual decimal RegularWork { get; }
        public virtual decimal RemainingCost { get; }
        public virtual Duration RemainingDuration { get; set; }
        public virtual decimal RemainingOvertimeCost { get; }
        public virtual decimal RemainingOvertimeWork { get; }
        public virtual decimal RemainingWork { get; set; }
        public virtual string ResourceGroup { get; }
        public virtual string ResourceInitials { get; set; }
        public virtual string ResourceNames { get; set; }
        public virtual string ResourcePhonetics { get; }
        public virtual bool ResponsePending { get; }
        public virtual bool Resume { get; set; }
        public virtual bool ResumeNoEarlierThan { get; set; }
        public virtual bool Rollup { get; set; }
        public virtual Duration ScheduledDuration { get; }
        public virtual DateTime ScheduledFinish { get; }
        public virtual DateTime ScheduledStart { get; }
        public virtual double SPI { get; }
        public virtual DateTime Start { get; set; }
        public virtual DateTime Start1 { get; set; }
        public virtual DateTime Start10 { get; set; }
        public virtual DateTime Start2 { get; set; }
        public virtual DateTime Start3 { get; set; }
        public virtual DateTime Start4 { get; set; }
        public virtual DateTime Start5 { get; set; }
        public virtual DateTime Start6 { get; set; }
        public virtual DateTime Start7 { get; set; }
        public virtual DateTime Start8 { get; set; }
        public virtual DateTime Start9 { get; set; }
        public virtual decimal StartSlack { get; }
        public virtual string StartText { get; set; }
        public virtual decimal StartVariance { get; }
        public virtual string StatusManagerName { get; set; }
        public virtual bool Stop { get; set; }
        public virtual string Subproject { get; set; }
        public virtual bool SubProjectReadOnly { get; set; }
        public virtual string Successors { get; set; }
        public virtual bool Summary { get; }
        public virtual decimal SV { get; }
        public virtual decimal SVPercent { get; }
        public virtual double TCPI { get; }
        public virtual bool TeamStatusPending { get; }
        public virtual string Text1 { get; set; }
        public virtual string Text10 { get; set; }
        public virtual string Text11 { get; set; }
        public virtual string Text12 { get; set; }
        public virtual string Text13 { get; set; }
        public virtual string Text14 { get; set; }
        public virtual string Text15 { get; set; }
        public virtual string Text16 { get; set; }
        public virtual string Text17 { get; set; }
        public virtual string Text18 { get; set; }
        public virtual string Text19 { get; set; }
        public virtual string Text2 { get; set; }
        public virtual string Text20 { get; set; }
        public virtual string Text21 { get; set; }
        public virtual string Text22 { get; set; }
        public virtual string Text23 { get; set; }
        public virtual string Text24 { get; set; }
        public virtual string Text25 { get; set; }
        public virtual string Text26 { get; set; }
        public virtual string Text27 { get; set; }
        public virtual string Text28 { get; set; }
        public virtual string Text29 { get; set; }
        public virtual string Text3 { get; set; }
        public virtual string Text30 { get; set; }
        public virtual string Text4 { get; set; }
        public virtual string Text5 { get; set; }
        public virtual string Text6 { get; set; }
        public virtual string Text7 { get; set; }
        public virtual string Text8 { get; set; }
        public virtual string Text9 { get; set; }
        public virtual decimal TotalSlack { get; }
        public virtual int UniqueID { get; }
        public virtual string UniqueIDPredecessors { get; set; }
        public virtual string UniqueIDSuccessors { get; set; }
        public virtual bool UpdateNeeded { get; }
        public virtual decimal VAC { get; }
        public virtual bool Warning { get; }
        public virtual string WBS { get; set; }
        public virtual string WBSPredecessors { get; }
        public virtual string WBSSuccessors { get; }
        public virtual decimal Work { get; set; }
        public virtual decimal WorkVariance { get; }

        /***************************************************/

        public Task()
        { ; }
    }
}
