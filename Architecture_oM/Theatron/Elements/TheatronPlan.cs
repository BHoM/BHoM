﻿/*
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
using BH.oM.Geometry.CoordinateSystem;
using BH.oM.Base;

namespace BH.oM.Architecture.Theatron
{
    public class TheatronPlan : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<ProfileOrigin> SectionOrigins { get; set; } =  new List<ProfileOrigin>();

        public ActivityArea ActivityArea { get; set; } = new ActivityArea();

        public Polyline FocalCurve { get; set; } = new Polyline();

        public List<ProfileOrigin> VomitoryOrigins { get; set; } =  new List<ProfileOrigin>();

        public List<ProfileOrigin> CombinedOrigins { get; set; } =  new List<ProfileOrigin>();

        public List<BayType> StructBayType { get; set; } =  new List<BayType>();

        public ProfileOrigin SectionClosestToFocalCurve { get; set; } = new ProfileOrigin();

        public double MinDistToFocalCurve { get; set; } = 0;

        public Point CValueFocalPoint { get; set; } = new Point();

        public ICurve TheatronFront { get; set; } = new Polyline();

        public SeatingBlockType SeatingBlockType { get; set; } = new SeatingBlockType();

        /***************************************************/
    }
}
