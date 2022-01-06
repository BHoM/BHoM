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
using BH.oM.Geometry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Inspection
{
    [Description("An issue belonging to an audit")]
    public class Issue : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Issue number to identify this specific issue. This is typically a combination of the audit number and the issue number within its audit.")]
        public virtual string IssueNumber { get; set; } = "";

        [Description("Date the issue was initially created")]
        public virtual DateTime DateCreated { get; set; } = new DateTime();

        [Description("Date the issue was Closed")]
        public virtual DateTime DateClosed { get; set; } = new DateTime();

        [Description("Priority tag to better categorize your issue  identifying its urgency")]
        public virtual string Priority { get; set; } = "";

        [Description("Status description of the issue (eg open, in progress, closed)")]
        public virtual string Status { get; set; } = "";

        [Description("A list of assignees for the issue. These are the individuals / companies responsible for resolving the issue.")]
        public virtual List<string> Assign { get; set; } = new List<string>();

        [Description("Issue type (eg For Information)")]
        public virtual string Type { get; set; } = "unassigned";

        [Description("The scope and nature of the issue")]
        public virtual string Description { get; set; } = "";

        [Description("Filenames of the images associated with the issue." +
            "These must include the file extension.")]
        public virtual List<string> Media { get; set; } = new List<string>();

        [Description("Location of the issue in 3D space in terms of the project's coordinate system")]
        public virtual Point Position { get; set; } = new Point();

        [Description("List of comments made on the issue, identifying either the nature of the issue, the actions being taken to resolve the issue, or the approval / rejection of actions taken.")]
        public virtual List<Comment> Comments { get; set; } = new List<Comment>();

        [Description("Unique ID of Audit the Issue was originally recorded within.")]
        public virtual string AuditID { get; set; } = "";

        /***************************************************/
    }
}

