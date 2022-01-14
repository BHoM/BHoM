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

using BH.oM.Base.Attributes;
using System.Collections.Generic;

namespace BH.oM.Data.Collections
{
    [ToBeRemoved("3.3", "Graph representations should use node classes that implement BH.oM.Analytical.Elements.INode")]
    public class GraphNode<T> : IDataStructure
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public virtual T Value { get; set; } = default(T);

        public virtual Dictionary<string, object> Attributes { get; set; } = new Dictionary<string, object>();

        /***************************************************/
        /**** Explicit Casting                          ****/
        /***************************************************/

        public static explicit operator GraphNode<T>(T value)
        {
            return new GraphNode<T> { Value = value };
        }

        /***************************************************/
    }
}



