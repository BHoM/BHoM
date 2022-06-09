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

using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Inspection
{
    [Description("An audit that covers all information associated with a single inspection. This includes issues, areas inspected, project information, construction progress, and distribution information.")]
    public class Audit : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Title of Audit (typically the project name or name of a specific scope of the project)")]
        public virtual string Title { get; set; } = "";

        [Description("Filename of Audit used to identify it when saved to reports or other formats")]
        public virtual string Filename { get; set; } = "";

        [Description("Unique ID of Audit provided by the Audit's source")]
        public virtual string AuditID { get; set; } = "";

        [Description("Site Visit Number of the Audit (this is a sequential number corresponding to the amount of audits conducted for this project up to this point)")]
        public virtual int SiteVisitNumber { get; set; } = 0;

        [Description("Client for which the Audit is being recorded")]
        public virtual string Client { get; set; } = "";

        [Description("Revision Number of the Audit (typically 0, only used when the information related to a specific audit is revised)")]
        public virtual int RevisionNumber { get; set; } = 0;

        [Description("Date the Audit was conducted in local time.")]
        public virtual DateTime InspectionDate { get; set; } = new DateTime();

        [Description("Date the Audit was conducted in UTC time.")]
        public virtual DateTime InspectionDateUtc { get; set; } = new DateTime();

        [Description("Date the Audit was issued in local time.")]
        public virtual DateTime IssueDate { get; set; } = new DateTime();

        [Description("Date the Audit was issued in UTC time.")]
        public virtual DateTime IssueDateUtc { get; set; } = new DateTime();

        [Description("Creator of the Audit")]
        public virtual string Author { get; set; } = "";

        [Description("Project Number of the Project the Audit is for")]
        public virtual string ProjectNumber { get; set; } = "";

        [Description("Job leader of the Project the Audit is for")]
        public virtual string JobLeader { get; set; } = "";

        [Description("List of people the Audit is distributed to")]
        public virtual List<string> Distribution { get; set; } = new List<string>();

        [Description("List of people in attendance during audit")]
        public virtual List<string> Attendance { get; set; } = new List<string>();

        [Description("Reason(s) for visit and audit")]
        public virtual string VisitPurpose { get; set; } = "";

        [Description("List of areas inspected throughout the audit")]
        public virtual List<string> AreasInspected { get; set; } = new List<string>();

        [Description("Installation progress objects from the audit (Each of these corresponds to the status of a specific area inspected)")]
        public virtual List<InstallationProgress> InstallationProgressObjects { get; set; } = new List<InstallationProgress>();

        [Description("Issues from audit. These are reference IssueNumbers to corresponding issues identified during the audit for various areas that need to be addressed, which can include supporting images of the work as applicable.")]
        public virtual List<string> IssueNumbers { get; set; } = new List<string>();

        [Description("Score as a percentage. This represents the amount of issues / areas that have been resolved, and is an optional value not used by all audits.")]
        public virtual string Score { get; set; } = "";

        /***************************************************/
    }
}


