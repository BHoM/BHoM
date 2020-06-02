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

using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using BH.oM.Base;

namespace BH.oM.Data.Collections
{
    public class DomainTree<T> : INode<T>//, IEnumerable<T>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public virtual List<DomainTree<T>> Children { get; set; } = new List<DomainTree<T>>();

        public virtual List<T> Values { get; set; } = null;

        public virtual DomainBox Relation { get; set; } = null;

        /***************************************************/
        /**** IEnumerators                              ****/
        /***************************************************

        public IEnumerator<T> GetEnumerator()
        {
            if (Values != null)
            {
                // Get all values in current node
                foreach (T v in Values)
                {
                    yield return v;
                }
            }
            if (Children != null)
            {
                // Get all values in child nodes
                foreach (DomainTree<T> child in Children)
                {
                    foreach (T v in child)
                    {
                        yield return v;
                    }
                }
            }
        }

        /***************************************************

        IEnumerator IEnumerable.GetEnumerator()
        {
            // Should point to the generic one
            return this.GetEnumerator();
        }

        /***************************************************/

    }

    /***************************************************/


}



