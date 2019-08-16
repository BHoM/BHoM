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
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Diffing
{
    public class Delta : IObject, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<IBHoMObject> OnlySetA { get; }
        public List<string> OnlySetA_hashes { get; }

        public List<IBHoMObject> OnlySetB { get; }
        public List<string> OnlySetB_hashes { get; }

        public List<IBHoMObject> Modified { get; }
        public List<string> Modified_hashes { get; }

        public List<IBHoMObject> UnModified { get; }
        public List<string> UnModified_hashes { get; }

        [Description("The dict key is the modified object hash. Value is another dictionary whose key is the name of the modified property, while value.item1 is the property value in setA, value.item2 in setB")]
        public Dictionary<string, Dictionary<string, Tuple<object, object>>> ModifiedPropsPerObject { get; }

        public DiffProjFragment DiffingProject { get; }

        public long Timestamp { get; }
        public string Author { get; }

        /***************************************************/

        /***************************************************/
        /**** Constructor                               ****/
        /***************************************************/

        public Delta(DiffProjFragment diffingProject, List<IBHoMObject> toCreate, List<IBHoMObject> toDelete, List<IBHoMObject> toUpdate, List<IBHoMObject> unchanged)
        {
            OnlySetA = toCreate;
            OnlySetB = toDelete;
            Modified = toUpdate;
            UnModified = unchanged;

            if (OnlySetA_hashes == null)
                OnlySetA_hashes = GetHashes(toCreate);
            if (OnlySetB_hashes == null && toDelete != null)
                OnlySetB_hashes = GetHashes(toDelete);
            if (Modified_hashes == null && Modified != null)
                Modified_hashes = GetHashes(toUpdate);
            if (UnModified_hashes == null && UnModified != null)
                UnModified_hashes = GetHashes(UnModified);

            DiffingProject = diffingProject;
            DiffingProject.Revision += 1;

            Timestamp = DateTime.UtcNow.Ticks;
            Author = Environment.UserDomainName + "/" + Environment.UserName;
        }

        public Delta(DiffProjFragment diffingProject, List<IBHoMObject> toCreate, List<string> toCreate_hashes, List<IBHoMObject> toDelete, List<string> toDelete_hashes, List<IBHoMObject> toUpdate, List<string> toUpdate_hashes, List<IBHoMObject> unchanged, List<string> unchanged_hashes)
            : this(diffingProject, toCreate, toDelete, toUpdate, unchanged)
        {
            OnlySetA_hashes = toCreate_hashes;
            OnlySetB_hashes = toDelete_hashes;
            Modified_hashes = toUpdate_hashes;
            UnModified_hashes = unchanged_hashes;
        }

        public Delta(DiffProjFragment diffingProject, List<IBHoMObject> toCreate, List<string> toCreate_hashes, List<IBHoMObject> toDelete, List<string> toDelete_hashes, List<IBHoMObject> toUpdate, List<string> toUpdate_hashes, List<IBHoMObject> unchanged, List<string> unchanged_hashes, Dictionary<string, Dictionary<string, Tuple<object, object>>> modifiedPropsPerObject)
            : this(diffingProject, toCreate, toDelete, toUpdate, unchanged)
        {
            ModifiedPropsPerObject = modifiedPropsPerObject;
        }

        /***************************************************/


        /***************************************************/
        /**** Private methods                           ****/
        /***************************************************/

        private List<string> GetHashes(List<IBHoMObject> objs)
        {
            return objs.Select(obj => obj.Fragments.OfType<DiffHashFragment>().First().Hash).ToList();
        }

        /***************************************************/

    }
}
