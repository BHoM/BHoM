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

using BH.oM.Base;
using BH.oM.Humans.ViewQuality;

namespace BH.oM.Architecture.Theatron
{
    public class ProfileParameters : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public virtual double StartX { get; set; } = 0.0;

        public virtual double StartZ { get; set; } = 0.0;

        public virtual double RowWidth { get; set; } = 0.0;

        public virtual double TargetCValue { get; set; } = 0.0;

        public virtual int NumRows { get; set; } = 0;

        public virtual double SeatWidth { get; set; } = 0.0;

        public virtual double BoardHeight { get; set; } = 0.0;

        public virtual double RiserHeightRounding { get; set; } = 0.0;

        public virtual VomitoryParameters VomitoryParameters { get; set; } = new VomitoryParameters();

        public virtual SuperRiserParameters SuperRiserParameters { get; set; } = new SuperRiserParameters();

        public virtual EyePositionParameters EyePositionParameters { get; set; } = new EyePositionParameters();

        /***************************************************/
    }
}



