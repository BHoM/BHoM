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
using BH.oM.Geometry;
using BH.oM.Base;

namespace BH.oM.Architecture.Theatron
{
    public class TierProfile : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public virtual int TotalPoints { get; set; }=0;

        public virtual List<Point> FloorPoints { get; set; } = new List<Point>();

        public virtual List<Point> EyePoints { get; set; } = new List<Point>();

        public virtual Point FocalPoint { get; set; } = new Point();

        public virtual List<Line> Sightlines { get; set; } = new List<Line>();

        public virtual Polyline Profile { get; set; } =new Polyline();

        public virtual ProfileOrigin SectionOrigin { get; set; } = new ProfileOrigin();
        
        public virtual double MappingAngle { get; set; } = 0;

        /***************************************************/
    }
}



