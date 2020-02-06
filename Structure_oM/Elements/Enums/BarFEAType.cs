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

using System.ComponentModel;

namespace BH.oM.Structure.Elements
{
    /***************************************************/

    [Description("Defines if the bar should be treated as a bending element or axial only in analysis packages.")]
    public enum BarFEAType
    {
        [Description("Full axial, flexural and torsional behaviour. 2 x 6 DOF:s")]
        Flexural = 0,
        [Description("Axial only behaviour. 2 x 3 DOF:s. Can be used to model pin-pin elements")]
        Axial,
        [Description("Axial only behaviour, compression only. 2 x 3 DOF:s")]
        CompressionOnly,
        [Description("Axial only behaviour, tension only. 2 x 3 DOF:s")]
        TensionOnly,
    }

    /***************************************************/
}

