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
    public enum MeshResultLayer
    {
        [Description("Lower surface/extreme fibre of the panel/mesh element.")]
        Lower = -1,

        [Description("Middle layer of the panel/mesh element.")]
        Middle = 0,

        [Description("Upper surface/extreme fibre of the panel/mesh element.")]
        Upper = 1,

        [Description("The minimum value of all layers in the panel/mesh element.")]
        Minimum = 2,

        [Description("The maximum value of all layers in the panel/mesh element.")]
        Maximum = 3,

        [Description("The absolute maximum value of all layers in the panel/mesh element.")]
        AbsoluteMaximum = 4,

        [Description("An arbitrary position within the thickness of the element.")]
        Arbitrary = 5
    }

    /***************************************************/
}



