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
using BH.oM.Reflection.Attributes;
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

        public List<IBHoMObject> OnlySetB { get; }

        public List<IBHoMObject> Modified { get; }

        [Description("The Key is the modified object hash. The Value is another Dictionary, whose Key is the name of the modified property, while Value.Item1 is the property value in setA, Value.Item2 in setB.")]
        public Dictionary<string, Dictionary<string, Tuple<object, object>>> ModifiedPropsPerObject { get; }

        public Stream DiffingStream { get; } = null;

        public long Timestamp { get; }
        public string Author { get; }

        /***************************************************/

        /***************************************************/
        /**** Constructor                               ****/
        /***************************************************/

        [Description("Creates new Delta object with information on the new, old or modified object, and (if exists) the Diffing Stream that contains them.")]
        [Input("onlySetA", "Objects existing exclusively in the 'primary' set, e.g. the 'new' objects.")]
        [Input("onlySetB", "Objects existing exclusively in the 'secondary' set, e.g. the 'old' objects.")]
        [Input("modified", "Objects existing in both sets that have some differences in their properties.")]
        [Input("unModified", "Objects existing in both sets that hold no differences in their properties.")]
        [Input("modifiedPropsPerObject", "Dictionary holding the differences in properties of the 'modified' objects. See the corresponding property description for more info.")]
        [Input("diffingStream", "If the Delta is the result of a diffing in the context of a Stream, this is the stream that holds the objects. Otherwise null.")]
        public Delta(List<IBHoMObject> setA, List<IBHoMObject> setB, List<IBHoMObject> modified, Dictionary<string, Dictionary<string, Tuple<object, object>>> modifiedPropsPerObject = null, Stream diffingStream = null)
        {
            OnlySetA = setA;
            OnlySetB = setB;
            Modified = modified;

            Timestamp = DateTime.UtcNow.Ticks;
            Author = Environment.UserDomainName + "/" + Environment.UserName;

            ModifiedPropsPerObject = modifiedPropsPerObject;

            if (diffingStream != null)
            {
                DiffingStream = diffingStream;
                DiffingStream.Revision += 1;
            }
        }


        /***************************************************/


        /***************************************************/
        /**** Private methods                           ****/
        /***************************************************/

        private List<string> GetHashes(List<IBHoMObject> objs)
        {
            var hashes = objs.Select(obj => obj.Fragments.OfType<DiffHashFragment>().First().Hash).ToList();
            return hashes.Count == 0 ? null : hashes;
        }

        /***************************************************/

    }
}
