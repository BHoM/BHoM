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

using System.ComponentModel;

namespace BH.oM.Structure.Results
{
    /***************************************************/

    [Description("Specifies which layer the results are extracted from or if it is a maxima/minima of the layers.")]
    public enum MeshResultType
    {
        [Description("Bending moments and shear forces out-of-plane, membrane forces in the plane of the mesh/element.")]
        Forces = 0,

        [Description("Stresses in the plane of the mesh/element.")]
        Stresses = 1,

        [Description("Displacements of the mesh/element nodes.")]
        Displacements = 2,

        [Description("Von Mises stresses and forces.")]
        VonMises = 3,

        [Description("Mode shape of the mesh/element nodes.")]
        MeshModeShape = 4,

    }

    /***************************************************/
}


