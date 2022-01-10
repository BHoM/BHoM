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
using BH.oM.Base.Attributes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Diffing
{
    public class Revision : BHoMObject, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Id of the Stream that owns this Revision.")]
        public virtual Guid StreamId { get; }

        [Description("Unique GUID of this Revision.")]
        public virtual Guid RevisionId { get; } = Guid.NewGuid();

        [Description("Name assigned to this Revision. It may be descriptive of the changes included in this Revision, e.g. AddedBasementColumns.")]
        public virtual string RevisionName { get; }

        [Description("In UTC.Now ticks. Automatically defined when creating a new Revision.")]
        public virtual long Timestamp { get; } 

        [Description("Author of the Stream Revision. Automatically calculated as it should be univocally defined.")]
        public virtual string Author { get; }

        [Description("Any comment to be added on this this Revision.")]
        public virtual string Comment { get; }

        [Description("Objects to be included in this Revision.")]
        public virtual IEnumerable<object> Objects { get; }

        [Description("Diffing settings for this Revision. Hashes of objects contained in this stream will be computed based on these configs.")]
        public virtual DiffingConfig RevisionDiffConfing { get; }

        /***************************************************/
        /**** Constructor                               ****/
        /***************************************************/


        public Revision(IEnumerable<object> objects, Guid streamId, DiffingConfig revisionDiffConfing = null, string revisionName = null, string comment = null, Guid revisionId = default(Guid),  long timestamp = default(long), string author = null)
        {
            StreamId = streamId;
            RevisionId = (revisionId == default(Guid)) ? Guid.NewGuid() : revisionId;
            RevisionName = revisionName;
            Timestamp = (timestamp == 0 || timestamp == default(long)) ? DateTime.UtcNow.Ticks : timestamp;
            Author = String.IsNullOrWhiteSpace(author) ? Environment.UserDomainName + "/" + Environment.UserName : author;
            Comment = comment;
            Objects = objects;
            RevisionDiffConfing = revisionDiffConfing == null ? new DiffingConfig() : revisionDiffConfing;
        }

        /***************************************************/


    }
}


