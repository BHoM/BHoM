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

using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Inspection
{
    public class Audit : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Title of Audit")]
        public virtual string Title { get; set; }

        [Description("Filename of Audit")]
        public virtual string Filename { get; set; }

        [Description("ID of Audit")]
        public virtual string AuditID { get; set; }

        [Description("Site Visit Number of Audit")]
        public virtual int SiteVisitNumber { get; set; }

        [Description("Client for which the Audit is being recorded")]
        public virtual string Client { get; set; }

        [Description("Revision Number of Audit")]
        public virtual int RevisionNumber { get; set; }

        [Description("Date of inspection for Audit in local time.")]
        public virtual DateTime InspectionDate { get; set; }

        [Description("Date of inspection for Audit in UTC time.")]
        public virtual DateTime InspectionDateUtc { get; set; }

        [Description("Date of issue corresponding to Audit in local time.")]
        public virtual DateTime IssueDate { get; set; }

        [Description("Date of issue corresponding to Audit in UTC time.")]
        public virtual DateTime IssueDateUtc { get; set; }

        [Description("Creator of Audit")]
        public virtual string Author { get; set; }

        [Description("Project Number of Audit")]
        public virtual string ProjectNumber { get; set; }

        [Description("Job leader of Audit")]
        public virtual string JobLeader { get; set; }

        [Description("List of people Audit is distributed to")]
        public virtual List<string> Distribution { get; set; }

        [Description("List of people in attendance during Audit")]
        public virtual List<string> Attendance { get; set; }

        [Description("Reason(s) for visit and Audit")]
        public virtual string VisitPurpose { get; set; }

        [Description("List of areas inspected throughout the Audit")]
        public virtual List<string> AreasInspected { get; set; }

        [Description("Installation progress objects from Audit")]
        public virtual List<InstallationProgress> InstallationProgressObjects { get; set; }

        [Description("Issues from Audit")]
        public virtual List<Issue> Issues { get; set; }

        [Description("Score as a percentage")]
        public virtual string Score { get; set; }

        /***************************************************/
    }
}
