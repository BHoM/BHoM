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
    public class DiffHashFragment : IBHoMFragment
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public string Hash { get; private set; }
        public string PreviousHash { get; private set; } = null;

        public DiffProjFragment DiffingProject { get; private set; }

        /***************************************************/


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public DiffHashFragment(string hash, DiffProjFragment diffingProject)
        {
            Hash = hash;
            DiffingProject = diffingProject;
        }

        public DiffHashFragment(string hash, string previousHash, DiffProjFragment diffingProject)
            : this(hash, diffingProject)
        {
            PreviousHash = previousHash;
        }

        /***************************************************/

        /***************************************************/
        /**** IBHoMFragment stuff (not needed)          ****/
        /***************************************************/

        public Guid BHoM_Guid { get; set; } = Guid.NewGuid();

        public string Name { get; set; } = "";

        public List<IBHoMFragment> Fragments { get; set; } = new List<IBHoMFragment>();

        public HashSet<string> Tags { get; set; } = new HashSet<string>();

        public Dictionary<string, object> CustomData { get; set; } = new Dictionary<string, object>();

        public IBHoMObject GetShallowClone(bool newGuid = false)
        {
            return null;
        }

        /***************************************************/


    }
}
