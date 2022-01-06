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
using BH.oM.Geometry.CoordinateSystem;
using BH.oM.Base;
using System.ComponentModel;

namespace BH.oM.Architecture.Theatron
{
    public class TheatronPlan : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public virtual List<ProfileOrigin> SectionOrigins { get; set; } =  new List<ProfileOrigin>();

        [Description("Activity area is used for evaluating Avalue and Evalues")]
        public virtual ActivityArea ActivityArea { get; set; } = new ActivityArea();

        [Description("Focal curve is used for defining Cvalue focal points")]
        public virtual Polyline FocalCurve { get; set; } = new Polyline();

        public virtual List<ProfileOrigin> VomitoryOrigins { get; set; } =  new List<ProfileOrigin>();

        public virtual List<ProfileOrigin> CombinedOrigins { get; set; } =  new List<ProfileOrigin>();

        public virtual List<BayType> StructBayType { get; set; } =  new List<BayType>();

        public virtual ProfileOrigin SectionClosestToFocalCurve { get; set; } = new ProfileOrigin();

        public virtual double MinDistToFocalCurve { get; set; } = 0;

        public virtual Point CValueFocalPoint { get; set; } = new Point();

        public virtual ICurve TheatronFront { get; set; } = new Polyline();

        public virtual SeatingBlockType SeatingBlockType { get; set; } = new SeatingBlockType();

        /***************************************************/
    }
}



