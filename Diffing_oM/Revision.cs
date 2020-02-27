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
using BH.oM.Reflection.Attributes;
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

        public string StreamId { get; }
        public string RevisionId { get; }
        public long Timestamp { get; }
        public string Author { get; }
        public string Comment { get; }
        public IEnumerable<IBHoMObject> Objects { get; }

        [Description("Default diffing settings for this Stream Revision. Hashes of objects contained in this stream will be computed based on these configs.")]
        public DiffConfig RevisionDiffConfing { get; } = new DiffConfig();


        /***************************************************/

        /***************************************************/
        /**** Constructor                               ****/
        /***************************************************/

        [Description("Creates new Stream Revision.")]
        [Input("objects", "Objects to be included in the Stream")]
        [Input("streamDiffConfig", "Default diffing settings for this Stream.")]
        [Input("streamId", "If not specified, streamId will be a GUID.Revision is initally 0")]
        [Input("revision", "If not specified, revision is initially set to 0")]
        [Input("comment", "Any comment to be added for this stream.")]
        public Revision(IEnumerable<IBHoMObject> objects, DiffConfig streamDiffConfig = null, string streamId = null, string revisionId = null, string comment = null)
        {
            Objects = objects;

            StreamId = string.IsNullOrWhiteSpace(streamId) ? Guid.NewGuid().ToString("N") : StreamId;
            RevisionId = revisionId;
            Comment = comment;

            Timestamp = DateTime.UtcNow.Ticks;
            Author = Environment.UserDomainName + "/" + Environment.UserName;

            RevisionDiffConfing = streamDiffConfig;
        }

        /***************************************************/
    }
}
