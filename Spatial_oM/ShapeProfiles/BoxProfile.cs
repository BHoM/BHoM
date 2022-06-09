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
using BH.oM.Geometry;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using BH.oM.Quantities.Attributes;

namespace BH.oM.Spatial.ShapeProfiles
{
    [Description("Rectangular hollow profile with constant thickness and optional corner radii.")]
    public class BoxProfile : BHoMObject, IProfile, IImmutable
    {

        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        public virtual ShapeType Shape { get; } = ShapeType.Box;

        [Length]
        [Description("Full depth between the extreme fibres of the flanges.")]
        public virtual double Height { get; }

        [Length]
        [Description("Full width between the extreme fibres of the webs.")]
        public virtual double Width { get; }

        [Length]
        [Description("Thickness of both webs and flanges.")]
        public virtual double Thickness { get; }

        [Length]
        [Description("Corner radius for all four corners of the outer bounding rectangle.")]
        public virtual double OuterRadius { get; }

        [Length]
        [Description("Corner radius for all four corners of the inner void rectangle.")]
        public virtual double InnerRadius { get; }

        [Description("Edge curves that matches the dimensions in the global XY-plane.")]
        public virtual ReadOnlyCollection<ICurve> Edges { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public BoxProfile(double height, double width, double thickness, double outerRadius, double innerRadius, IEnumerable<ICurve> edges)
        {
            Height = height;
            Width = width;
            Thickness = thickness;
            OuterRadius = outerRadius;
            InnerRadius = innerRadius;
            Edges = new ReadOnlyCollection<ICurve>(edges.ToList());
        }


        /***************************************************/
    }
}



