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
using BH.oM.Reflection.Attributes;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Diffing
{
    [Description("Contains the Diff plus context information: parent Stream, Timestamp, etc.")]
    public class Delta : IObject, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        [Description("The Id of the owning Stream. It must be the same for both the Revision that this Delta targets and the Revision that it will produce.")]
        public Guid StreamId { get; }

        [Description("Represent the differences between two sets of objects.")]
        public Diff Diff { get; }

        [Description("Revision Id that this Delta targets.")]
        public Guid Revision_from { get; }

        [Description("Revision Id that this Delta produces.")]
        public Guid Revision_to { get; }

        [Description("In UTC ticks.")]
        public long Timestamp { get; } = DateTime.UtcNow.Ticks;

        [Description("Any descriptive string identifying either the Author and/or the software used.")]
        public string Author { get; }

        public string Comment { get; }

        /***************************************************/
        /**** Constructor                               ****/
        /***************************************************/

        public Delta(Guid streamId, Diff diff, Guid revision_from, Guid revision_to, long timestamp, string author, string comment = null)
        {
            StreamId = streamId;

            Diff = diff;

            Revision_from = revision_from;
            Revision_to = revision_to;

            Timestamp = timestamp;
            Author = author;

            Comment = comment;
        }

    }
}

