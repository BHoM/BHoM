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


namespace BH.oM.Theatron_oM.Elements
{
    public class SeatingBlock : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Plane OriginPlane { get; set; } = new Plane();

        public Plane VomitoryPlane { get; set; } = new Plane();

        public Plane EndPlane { get; set; } = new Plane();

        public List<ProfileGeometry> Sections = new List<ProfileGeometry>();

        public Mesh Floor = new Mesh();

        public List<Point> Eyes = new List<Point>();

        public List<Vector> ViewDirections = new List<Vector>();

        public Line FrontRow { get; set; }=new Line();

        public double SeatWidth { get; set; } =0.0;

        public double AisleWidth { get; set; } =0.0;

        public SeatingBlockType TypeOfSeatignBlock { get; set; }=SeatingBlockType.Undefined;

        /***************************************************/
    }
}
