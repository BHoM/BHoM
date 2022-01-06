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

namespace BH.oM.Architecture.Theatron
{
    public class StadiaParameters : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public virtual double StructBayWidth { get; set; } = 0.0;

        public virtual double CornerRadius { get; set; } = 0.0;

        public virtual double SideBound { get; set; } = 0.0;

        public virtual double EndBound { get; set; } = 0.0;

        public virtual double SideRadius { get; set; } = 0.0;

        public virtual double EndRadius { get; set; } = 0.0;

        public virtual double TheatronRadius { get; set; } = 0.0;

        public virtual int NumCornerBays { get; set; } = 0;

        public virtual StadiaType TypeOfBowl { get; set; } = StadiaType.Undefined;

        public virtual double CornerFraction { get; set; } = 0.0;

        public virtual ActivityArea ActivityArea { get; set; } = new ActivityArea();

        public virtual double PitchLength { get; set; } = 0.0;

        public virtual double PitchWidth { get; set; } = 0.0;

        /***************************************************/
    }
}



