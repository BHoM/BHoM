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
    [Description("Class defined as per AECDeltas specification https://github.com/aecdeltas/aec-deltas-spec/wiki/Delta-Container-Specification#payload")]
    public class Delta : IObject, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        public string StreamId { get; } 

        public string Revision_from { get; }
        public string Revision_to { get; }

        public long Timestamp { get; }
        public string Author { get; }
        public string Comment { get; }

        public Diff Diff { get; }

        [Description("Default diffing settings for this Stream. Hashes of objects contained in this stream will be computed based on these configs.")]
        public DiffConfig StreamDiffConfig { get; } = new DiffConfig();


        [Description("The Key is the modified object hash. The Value is another Dictionary, whose Key is the name of the modified property, while Value.Item1 is the property value in setA, Value.Item2 in setB.")]
        public Dictionary<string, Dictionary<string, Tuple<object, object>>> ModifiedPropsPerObject { get; }

        /***************************************************/

        /***************************************************/
        /**** Constructor                               ****/
        /***************************************************/

        public Delta(Diff diff, DiffConfig streamDiffConfig = null, string streamId = null, string revision_from = null, string revision_to = null, string comment = null)
        {
            Diff = diff;

            StreamId = string.IsNullOrWhiteSpace(streamId) ? Guid.NewGuid().ToString("N") : StreamId;
            Revision_from = revision_from;
            Revision_to = revision_to;

            Comment = comment;

            Timestamp = DateTime.UtcNow.Ticks;
            Author = Environment.UserDomainName + "/" + Environment.UserName;

            StreamDiffConfig = streamDiffConfig;
        }

        /***************************************************/
    }
}

