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

namespace BH.oM.MEP.Enums
{
    /***************************************************/

    [Description("A type of fitting used to transition from one segment of linear MEP object to another.")]
    public enum FittingType
    {
        Undefined,
        [Description("A fitting that allows you to change the size/shape of the linear MEP segment at a given juncture.")]
        Adapter,
        [Description("A fitting that is placed at the end of a linear MEP segment.")]
        Cap,
        [Description("A fitting that joins two linear MEP segments of the same size and shape.")]
        Coupling,
        [Description("A fitting that physically connects four different linear MEP segments, each at 90-degree angles.")]
        Cross,
        [Description("A fitting that physically connects two different linear MEP segments, and re-directs the segment at a 30,45,60 or 90-degree angle.")]
        Elbow,
        [Description("A fitting that allows you to change the size of the linear MEP segment at a given juncture, and gives additional reinforcement to both segments.")]
        Olet,
        [Description("A fitting that is placed at the end of a linear MEP segment, allowing future access for maintenance purposes (clean out).")]
        Plug,
        [Description("A fitting that allows you to change the size of the linear MEP segment at a given juncture.")]
        Reducer,
        [Description("A fitting that keeps the main linear MEP segment size the same and allows a 45-degree transition to a 90-degree branch.")]
        Tap,
        [Description("A fitting that allows you to change size and/or shape along the main linear MEP segment .")]
        Transition,
        [Description("A fitting that keeps the main linear MEP segment size the same and allows a branch at a 90-degree angle.")]
        Tee,
        [Description("A fitting that joins two linear MEP segments of the same size and shape, of which each end can be unscrewed independently.")]
        Union,
        [Description("A fitting that joins three linear MEP segments of differing sizes and shapes, also known as pants.")]
        Wye
    }

    /***************************************************/
}

