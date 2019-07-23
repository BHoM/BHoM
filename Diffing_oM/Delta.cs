/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2019, the respective contributors. All rights reserved.
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Diffing
{
    public class Delta : IDiffingProject, IObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<object> ToCreate { get; private set; }
        public List<string> ToCreate_hashes { get; private set; }

        public List<object> ToDelete { get; private set; }
        public List<string> ToDelete_hashes { get; private set; }

        public List<object> ToUpdate { get; private set; }
        public List<string> ToUpdate_hashes { get; private set; }

        public string ProjectName { get; private set; }
        public string ProjectId { get; private set; }
        public int Revision { get; private set; } = 0;
        public long Timestamp { get; private set; }
        public string Author { get; private set; }


        /***************************************************/

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Delta(List<object> toCreate, List<object> toDelete, List<object> toUpdate, string projectName)
        {
            ProjectName = String.IsNullOrWhiteSpace(projectName) ? "UnnamedProject-createdOn" + DateTime.Now.ToString() + "localTime" : projectName;
            ToCreate = toCreate;
            ToDelete = toDelete;
            ToUpdate = toUpdate;
            ProjectName = "UnnamedProject-createdOn" + DateTime.Now.ToString() + "localTime";
            ProjectId = Guid.NewGuid().ToString("N");
            Revision = Revision + 1;
            Timestamp = DateTime.UtcNow.Ticks;
            Author = Environment.UserDomainName + "/" + Environment.UserName;
        }

        public Delta(List<object> toCreate, List<object> toDelete, List<object> toUpdate, string projectName, string projectId) 
            : this(toCreate, toDelete, toUpdate, projectName)
        {
            ProjectId = projectId;
        }

        public Delta(List<object> toCreate, List<string> toCreate_hashes, List<object> toDelete, List<string> toDelete_hashes, List<object> toUpdate, List<string> toUpdate_hashes, string projectName) 
            : this(toCreate, toDelete, toUpdate, projectName)
        {
            ToCreate_hashes = toCreate_hashes;
            ToDelete_hashes = toDelete_hashes;
            ToUpdate_hashes = toUpdate_hashes;
        }

        public Delta(List<object> toCreate, List<string> toCreate_hashes, List<object> toDelete, List<string> toDelete_hashes, List<object> toUpdate, List<string> toUpdate_hashes, string projectName, string projectId)
             : this(toCreate, toCreate_hashes, toDelete, toDelete_hashes, toUpdate, toUpdate_hashes, projectName)
        {
            ProjectId = projectId;
        }

        /***************************************************/

    }
}
