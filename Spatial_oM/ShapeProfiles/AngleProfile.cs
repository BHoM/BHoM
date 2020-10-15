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

using BH.oM.Base;
using BH.oM.Geometry;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using BH.oM.Quantities.Attributes;

namespace BH.oM.Spatial.ShapeProfiles
{
    [Description("L-shaped profile")]
    public class AngleProfile : BHoMObject, IProfile, IImmutable
    {

        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        public virtual ShapeType Shape { get; } = ShapeType.Angle;

        [Length]
        [Description("Full depth of the profile from bottom of flange to top of the web.")]
        public virtual double Height { get; }

        [Length]
        [Description("Full width of the profile from the furthest side of the web to the end of the flange.")]
        public virtual double Width { get; }

        [Length]
        [Description("Thickness of the stem of the L-shape.")]
        public virtual double WebThickness { get; }

        [Length]
        [Description("Thickness of the base of the L-shape.")]
        public virtual double FlangeThickness { get; }

        [Length]
        [Description("Fillet radius between inner face of the flange and inner face of the web.")]
        public virtual double RootRadius { get; }

        [Length]
        [Description("Fillet radius at the outer edge of the flange and web. Value need to be smaller or equal than the Flange and Web thicknesses")]
        public virtual double ToeRadius { get; }

        [Description("If true, the section is mirrored about its local z-axis, resulting in a backwards facing L-shape.")]
        public virtual bool MirrorAboutLocalZ { get; }

        [Description("If true, the section is mirrored about its local y-axis, resulting in upside down L-shape.")]
        public virtual bool MirrorAboutLocalY { get; }

        [Description("Edge curves that matches the dimensions in the global XY-plane.")]
        public virtual ReadOnlyCollection<ICurve> Edges { get; }


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public AngleProfile(double height, double width, double webthickness, double flangeThickness, double rootRadius, double toeRadius, bool mirrorAboutLocalZ, bool mirrorAboutLocalY, IEnumerable<ICurve> edges)
        {
            Height = height;
            Width = width;
            WebThickness = webthickness;
            FlangeThickness = flangeThickness;
            RootRadius = rootRadius;
            ToeRadius = toeRadius;
            MirrorAboutLocalZ = mirrorAboutLocalZ;
            MirrorAboutLocalY = mirrorAboutLocalY;
            Edges = new ReadOnlyCollection<ICurve>(edges.ToList());
        }

        /***************************************************/
    }
}

