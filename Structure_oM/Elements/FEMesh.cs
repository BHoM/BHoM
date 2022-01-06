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

using System.Collections.Generic;
using BH.oM.Structure.SurfaceProperties;
using BH.oM.Analytical.Elements;
using System.ComponentModel;

namespace BH.oM.Structure.Elements
{
    [Description("2D finite element mesh for structural analysis. Defined by a list of nodes and faces.")]
    public class FEMesh : Base.BHoMObject, IAreaElement, IMesh<Node, FEMeshFace>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("The nodes of the FEMesh. Mesh faces reference these nodes by their position in this list, so it is important to maintain the order.")]
        public virtual List<Node> Nodes { get; set; } = new List<Node>();
    
        [Description("The faces of the FEMesh. Each face contains a list of indices referring to the nodes in the node list it is connecting.")]
        public virtual List<FEMeshFace> Faces { get; set; } = new List<FEMeshFace>();

        [Description("Defines the thickness property and material of the FEMesh.")]
        public virtual ISurfaceProperty Property { get; set; } = null;

        /***************************************************/
    }
}



