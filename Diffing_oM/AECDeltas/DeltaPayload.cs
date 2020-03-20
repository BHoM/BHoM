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
using BH.oM.Diffing;

namespace BH.oM.AECDeltas
{
    [Description("Class defined as per AECDeltas specification https://github.com/aecdeltas/aec-deltas-spec/wiki/Delta-Container-Specification#payload")]
    public class DeltaPayload : IObject, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        public string StreamId { get; }

        public Dictionary<string, object> Diff { get; }

        public string Revision_from { get; }
        public string Revision_to { get; }

        public long Timestamp { get; }
        public string Signature { get; }
        public string Sender { get; }
        public string Comment { get; }

        /***************************************************/

        /***************************************************/
        /**** Constructor                               ****/
        /***************************************************/

        public DeltaPayload(Delta delta)
        {
            Diff = new Dictionary<string, object>()
            {
                { "toBeCreated" , delta.Diff.NewObjects },
                { "toBeDeleted" , delta.Diff.OldObjects },
                { "toBeUpdated" , delta.Diff.ModifiedObjects },
            };

            StreamId = delta.StreamId;
            Revision_from = delta.Revision_from;
            Revision_to = delta.Revision_to;

            Comment = delta.Comment;

            Timestamp = delta.Timestamp;
            Signature = delta.Author;
        }

        /***************************************************/
    }
}
