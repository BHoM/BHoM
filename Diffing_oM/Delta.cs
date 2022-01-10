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
using BH.oM.Base.Attributes;
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
        public virtual Guid StreamId { get; }

        [Description("Represent the differences between two sets of objects.")]
        public virtual Diff Diff { get; }

        [Description("Revision Id that this Delta targets.")]
        public virtual Guid Revision_from { get; }

        [Description("Revision Id that this Delta produces.")]
        public virtual Guid Revision_to { get; }

        [Description("In UTC ticks.")]
        public virtual long Timestamp { get; }

        [Description("Any descriptive string identifying either the Author and/or the software used.")]
        public virtual string Author { get; }

        public virtual string Comment { get; }

        /***************************************************/
        /**** Constructor                               ****/
        /***************************************************/

        public Delta(Guid streamId, Diff diff, Guid revision_from, Guid revision_to, long timestamp = default(long), string author = null, string comment = null)
        {
            StreamId = streamId == default(Guid) ? Guid.NewGuid() : streamId;

            Diff = diff;

            Revision_from = (revision_from == default(Guid)) ? Guid.NewGuid() : revision_from;
            Revision_to = (revision_to == default(Guid)) ? Guid.NewGuid() : revision_to;

            Timestamp = (timestamp == 0 || timestamp == default(long)) ? DateTime.UtcNow.Ticks : timestamp;
            Author = String.IsNullOrWhiteSpace(author) ? Environment.UserDomainName + "/" + Environment.UserName : author;

            Comment = comment;
        }

    }
}



