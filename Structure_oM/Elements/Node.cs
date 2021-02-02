/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2021, the respective contributors. All rights reserved.
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
using BH.oM.Structure.Constraints;
using BH.oM.Analytical.Elements;
using System.ComponentModel;

namespace BH.oM.Structure.Elements
{
    [Description("0D finite element for structural analysis. Node class contains positional information as well as orientation and support.")]
    public class Node : BHoMObject, IElement0D, INode
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Position of the node in global Cartesian 3D space.")]
        public virtual Point Position { get; set; } = null;

        [Description("Local x, y, and z axes of the node as a vector Basis. Defaults to null which is interpretated to defaults when pushed to software and world axes in BHoM.")]
        public virtual Basis Orientation { get; set; } = null;

        [Description("Defines the Support property of the Node. If not set, the Node will be assumed to be free to translate and rotate.")]
        public virtual Constraint6DOF Support { get; set; } = null;


        /***************************************************/
        /**** Explicit Casting                          ****/
        /***************************************************/

        [Description("Converts a Point to a Node, setting the position to the provided point. All other properties are set to default values.")]
        public static explicit operator Node(Point point)
        {
            return new Node { Position = point };
        }

        /***************************************************/

        [Description("Converts a Cartesian Coordinatesystem to a Node, setting the position to the origin of the CS and the orientation aligned with the axes of the CS.")]
        public static explicit operator Node(Geometry.CoordinateSystem.Cartesian coordinateSystem)
        {
            return new Node { Position = coordinateSystem.Origin, Orientation = (Basis)coordinateSystem };
        }

        /***************************************************/
    }
}
    


