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

using BH.oM.Base.Attributes;
using System.ComponentModel;

namespace BH.oM.Spatial.ShapeProfiles
{
    /***************************************************/

    public enum Symmetry
    {
        [Description("The geometry is not symmetrical.")]
        [DisplayText("Non-symmetric")]
        Asymmetric = 0,
        [Description("The geometry is singly-symmetrical about the y-axis.")]
        [DisplayText("Singly Symmetric Major")]
        SingleSymmetricMajor = 1,
        [Description("The geometry is singly-symmetrical about the z-axis.")]
        [DisplayText("Singly Symmetric Minor")]
        SinglySymmetricMinor = 2,
        [Description("The geometry is doubly symmetrical about both the major (y-axis) and minor (z-axis).")]
        [DisplayText("Doubly-symmetrical")]
        DoublySymmetric = 3,
    }

    /***************************************************/

}






