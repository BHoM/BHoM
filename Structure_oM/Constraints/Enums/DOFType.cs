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

namespace BH.oM.Structure.Constraints
{

    /***************************************************/

    /// <summary>
    /// Enumerator of types of degrees of freedom
    /// </summary>
    public enum DOFType
    {
        /// <summary>Free - all DOF's released</summary>
        Free = 0,
        /// <summary>Fixed - all DOF's blocked</summary>
        Fixed = 1,
        /// <summary>Zero stiffness in the positive direction</summary>
        FixedNegative = 2,
        /// <summary>Zero stiffness in the negative direction</summary>
        FixedPositive = 3,
        /// <summary>Linear spring constant</summary>
        Spring = 4,
        /// <summary>Non-linear, zero stiffnss in positive direction</summary>
        SpringNegative = 5,
        /// <summary>Non-linear, zero stiffness in negative direction</summary>
        SpringPositive = 6,
        /// <summary>Spring stiffness between 0-1 relates to the element to which the DOF applies (e.g. bar end stiffness)</summary>
        SpringRelative = 7,
        /// <summary>As spring negative, but relative stiffness</summary>
        SpringRelativeNegative = 8,
        /// <summary>As spring positive but relative stiffness</summary>
        SpringRelativePositive = 9,
        /// <summary>Non-linear spring model</summary>
        NonLinear = 10,
        /// <summary>Friction model (relative to the load applied)</summary>
        Friction = 11,
        /// <summary>Damped velocities/accelerations</summary>
        Damped = 12,
        /// <summary>Gap model</summary>
        Gap = 13
    }

    /***************************************************/
}

