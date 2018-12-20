/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2018, the respective contributors. All rights reserved.
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

namespace BH.oM.Planning
{
    public class PullRequest : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public string Creator { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public string HtmlUrl { get; set; }

        public string RepoName { get; set; }

        public string BranchName { get; set; }

        public int Number { get; set; }

        public DateTimeOffset CreationDate { get; set; }

        public string MilestoneName { get; set; }

        public int Additions { get; set; }

        public int Deletions { get; set; }

        public List<string> Reviewers { get; set; } = new List<string>();


        /***************************************************/
    }
}
