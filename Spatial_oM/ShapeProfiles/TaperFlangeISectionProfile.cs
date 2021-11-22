/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2021, the respective contributors. All rights reserved.
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
    [Description("I-shaped profile with tapered flanges.")]
    public class TaperFlangeISectionProfile : BHoMObject, IProfile, IImmutable
    {

        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public virtual ShapeType Shape { get; } = ShapeType.ISection;

        [Length]
        [Description("Full depth between the extreme fibres of the flanges.")]
        public virtual double Height { get; }

        [Length]
        [Description("Full width of both flanges between the extreme fibres of the flanges.")]
        public virtual double Width { get; }

        [Length]
        public virtual double WebThickness { get; }

        [Length]
        [Description("Mean thickness of the flange, taken at 1/4 of the flange width.")]
        public virtual double FlangeThickness { get; }

        [Ratio]
        [Description("Slope of the flange inner faces, generally from 0 to 1/6.")]
        public virtual double FlangeSlope { get; }

        [Length]
        [Description("Fillet radius between inner face of the flanges and faces of the web.")]
        public virtual double RootRadius { get; }

        [Length]
        [Description("Fillet radius at the end of the flanges. Value must be smaller or equal to the thickness of the flange at the tip.")]
        public virtual double ToeRadius { get; }

        [Description("Edge curves that matches the dimensions in the global XY-plane.")]
        public virtual ReadOnlyCollection<ICurve> Edges { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public TaperFlangeISectionProfile(double height, double width, double webthickness, double flangeThickness, double flangeSlope, double rootRadius, double toeRadius, IEnumerable<ICurve> edges)
        {
            Height = height;
            Width = width;
            WebThickness = webthickness;
            FlangeThickness = flangeThickness;
            FlangeSlope = flangeSlope;
            RootRadius = rootRadius;
            ToeRadius = toeRadius;
            Edges = new ReadOnlyCollection<ICurve>(edges.ToList());
        }

        /***************************************************/
    }
}


