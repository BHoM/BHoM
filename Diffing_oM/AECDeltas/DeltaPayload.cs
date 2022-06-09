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
using BH.oM.Diffing;

namespace BH.oM.AECDeltas
{
    [Description("Class defined as per AECDeltas specification https://github.com/aecdeltas/aec-deltas-spec/wiki/Delta-Container-Specification#payload")]
    public class DeltaPayload : IObject, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        public Guid StreamId { get; }

        public Dictionary<string, object> Diff { get; }

        public string Revision_from { get; }
        public string Revision_to { get; }

        public long Timestamp { get; }
        public string Signature { get; }
        public string Sender { get; }
        public string Comment { get; }


        /***************************************************/
        /**** Constructor                               ****/
        /***************************************************/

        public DeltaPayload(Guid streamId, Dictionary<string, object> diff, string revision_from, string revision_to, long timestamp, string signature, string sender, string comment)
        {
            StreamId = streamId;
            Diff = diff;
            Revision_from = revision_from;
            Revision_to = revision_to;
            Timestamp = timestamp;
            Signature = signature;
            Sender = sender;
            Comment = comment;
        }

        public DeltaPayload(Delta delta)
        {
            Diff = new Dictionary<string, object>()
            {
                { "toBeCreated" , delta.Diff.AddedObjects },
                { "toBeDeleted" , delta.Diff.RemovedObjects },
                { "toBeUpdated" , delta.Diff.ModifiedObjects },
            };

            StreamId = delta.StreamId;
            Revision_from = delta.Revision_from.ToString();
            Revision_to = delta.Revision_to.ToString();

            Comment = delta.Comment;

            Timestamp = delta.Timestamp;
            Signature = delta.Author;
        }

        /***************************************************/
    }
}



