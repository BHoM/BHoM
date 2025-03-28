/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2025, the respective contributors. All rights reserved.
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
using BH.oM.Dimensional;
using BH.oM.Geometry;
using BH.oM.Analytical.Elements;
using System.ComponentModel;

namespace BH.oM.MEP.System
{
    [Description("0D finite element for structural analysis. Node class contains positional information as well as orientation and support.")]
    public class Node : BHoMObject, IElement0D, INode
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Position of the node in global Cartesian 3D space.")]
        public virtual Point Position { get; set; } = null;


        /***************************************************/
        /**** Explicit Casting                          ****/
        /***************************************************/

        [Description("Converts a Point to a Node, setting the position to the provided point. All other properties are set to default values.")]
        public static explicit operator Node(Point point)
        {
            return new Node { Position = point };
        }

        /***************************************************/
    }
}
    






