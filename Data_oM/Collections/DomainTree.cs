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

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace BH.oM.Data.Collections
{
    [Description("A data tree which is traversed through DomainBoxes. " +
                 "Each node's DomainBox is assumed to be enclosed by its parent's DomainBox and to enclose its own data. " +
                 "All the tree's data is stored in its leaves.")]
    public class DomainTree<T> : INode<T>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("The child nodes of this node. All child nodes DomainBoxes are assumed to be enclosed by this nodes DomainBox. An empty list indicates this node as a leaf node")]
        public virtual List<DomainTree<T>> Children { get; set; } = new List<DomainTree<T>>();

        [Description("The data values stored on this node. The DomainTree assumes that only nodes with an empty list of children have values.")]
        public virtual List<T> Values { get; set; } = null;

        [Description("This nodes DomainBox, enclosing either all the child nodes' DomainBoxes or this node's Values.")]
        public virtual DomainBox DomainBox { get; set; } = null;

        /***************************************************/

    }

    /***************************************************/

}


