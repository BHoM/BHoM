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

        [Description("Issue number supplied to audit")]
        public virtual int IssueNumber { get; set; }

        [Description("Priority tag to better categorize your issue")]
        public virtual string Priority { get; set; } // this could be an enum of options

        [Description("Status description at time of observation")]
        public virtual string Status { get; set; }

        [Description("Provide a list of assignees for the issue")]
        public virtual string Assign { get; set; }

        [Description("Issue type. E.g. `for_information`.")]
        public virtual string Type { get; set; } = "unassigned";

        [Description("Provide a description for the scope of the issue")]
        public virtual string Description { get; set; }

        [Description("FileName of the Media associated with the issue." +
            "It must NOT include the folder where it is located. It must include the extension.")]
        public virtual List<string> Media { get; set; }

        [Description("Location of the issue. X, Y, Z coordinates.")]
        public virtual Point Position { get; set; } = new Point();

        [Description("List of comments made on the issue")]
        public virtual List<Comment> Comments { get; set; }

        /***************************************************/
    }
}