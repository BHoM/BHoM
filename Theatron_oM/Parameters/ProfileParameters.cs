/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2018, the respective contributors. All rights reserved.
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
using BH.oM.Geometry;
using BH.oM.Base;

namespace Theatron_oM.Parameters
{
    class ProfileParameters : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double startX { get; set; } = 0.0;

        public double startZ { get; set; } = 0.0;

        public double rowWidth { get; set; } = 0.0;

        public double cValue { get; set; } = 0.0;

        public int rows { get; set; } = 0;

        public bool superR { get; set; } = false;

        public int superStart { get; set; } = 0;

        public bool vomitory { get; set; } = false;

        public int vomitoryStart { get; set; } = 0;

        public double seatWidth { get; set; } = 0.0;

        public double eyeLevel { get; set; } = 0.0;

        public double eyeHoriz { get; set; } = 0.0;

        public double boardHeight { get; set; } = 0.0;

        public double aisleWidth { get; set; } = 0.0;

        public double superNib { get; set; } = 0.0;

        public double superEyeHoriz { get; set; } = 0.0;

        public double superEyeVert { get; set; } = 0.0;

        public double standingVert { get; set; } = 0.0;

        public double standingHoriz { get; set; } = 0.0;

        /***************************************************/
    }
}
