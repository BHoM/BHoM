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
    [Description("C-shaped profile with tapered flanges of the same length and thickness.")]
    public class TaperFlangeChannelProfile : BHoMObject, IProfile, IImmutable
    {

        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        public virtual ShapeType Shape { get; } = ShapeType.Channel;

        [Length]
        [Description("Full depth between the extreme fibres of the flanges.")]
        public virtual double Height { get; }

        [Length]
        [Description("Full width between the extreme fibres of the web to the toe of the flange.")]
        public virtual double FlangeWidth { get; }

        [Length]
        public virtual double WebThickness { get; }

        [Length]
        [Description("Mean thickness of the flange, taken at 1/2 the flange width")]
        public virtual double FlangeThickness { get; }

        [Ratio]
        [Description("Slope of the flange inner faces, generally from 0 to 1/6.")]
        public virtual double FlangeSlope { get; }

        [Length]
        [Description("Fillet radius between inner face of the flanges and the inner face of web.")]
        public virtual double RootRadius { get; }

        [Length]
        [Description("Fillet radius at the end of the flanges. Value must be smaller or equal to the thickness of the flange at the tip.")]
        public virtual double ToeRadius { get; }

        [Description("If true, the section is mirrored about its local z-axis, resulting in a backwards facing C-shape.")]
        public virtual bool MirrorAboutLocalZ { get; }

        [Description("Edge curves that match the dimensions in the global XY-plane.")]
        public virtual ReadOnlyCollection<ICurve> Edges { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public TaperFlangeChannelProfile(double height, double flangeWidth, double webthickness, double flangeThickness, double flangeSlope, double rootRadius, double toeRadius, bool mirrorAboutLocalZ, IEnumerable<ICurve> edges)
        {
            Height = height;
            FlangeWidth = flangeWidth;
            WebThickness = webthickness;
            FlangeThickness = flangeThickness;
            FlangeSlope = flangeSlope;
            RootRadius = rootRadius;
            ToeRadius = toeRadius;
            MirrorAboutLocalZ = mirrorAboutLocalZ;
            Edges = new ReadOnlyCollection<ICurve>(edges.ToList());
        }


        /***************************************************/
    }
}



