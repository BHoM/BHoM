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
using BH.oM.Analytical.Elements;
using BH.oM.Base;
using System.ComponentModel;
using BH.oM.Quantities.Attributes;

namespace BH.oM.Structure.Elements
{
    [Description("Face of an FEMesh. The face is defined by the indices of its nodes in the node list. Geometrical information about position in space is stored on the host FEMesh.")]
    public class FEMeshFace : BHoMObject, IFace
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("List of which node indices in the host FEMesh node list that this face is connecting.")]
        public virtual List<int> NodeListIndices { get; set; } = new List<int>();

        [Angle]
        [Description("Defines the angle that the local x and y axes are rotated around the normal (i.e. local z) of the FEMeshFace.\n" +
                     "The normal of the FEMeshFace is determined by the curl right hand rule dictated by the order of the node list.\n" +
                     "Local x is found by projecting the global X to the plane of the FEMeshFace and is then rotated with the OrientationAngle, " +
                     "except for the case when the Normal is parallel with the global X. " +
                     "For this case the local y is instead found by projecting global Y to the plane of the FEMeshFace and is then rotated with the OrientationAngle.\n" +
                     "The remaining local axis is determined by the right hand rule.")]
        public virtual double OrientationAngle { get; set; } = 0;

        /***************************************************/
    }
}
     



