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
    [Description("T-shaped profile with constant flange thickness.")]
    public class TSectionProfile : BHoMObject, IProfile, IImmutable
    {

        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        public virtual ShapeType Shape { get; } = ShapeType.Tee;

        [Length]
        [Description("Full depth between extreme fibres of the web and flange.")]
        public virtual double Height { get; }

        [Length]
        [Description("Full width of the flange.")]
        public virtual double Width { get; }

        [Length]
        public virtual double WebThickness { get; }

        [Length]
        public virtual double FlangeThickness { get; }

        [Length]
        [Description("Fillet radius between inner face of flanges and faces of the web.")]
        public virtual double RootRadius { get; }

        [Length]
        [Description("Fillet radius at the outer edge of the flanges. Value need to be smaller or equal than the flange thickness.")]
        public virtual double ToeRadius { get; }

        [Description("If true, the section is mirrored about its local y-axis, resulting in upside down T-shape.")]
        public virtual bool MirrorAboutLocalY { get; }

        [Description("Edge curves that matches the dimensions in the global XY-plane.")]
        public virtual ReadOnlyCollection<ICurve> Edges { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public TSectionProfile(double height, double width, double webthickness, double flangeThickness, double rootRadius, double toeRadius, bool mirrorAboutLocalY, IEnumerable<ICurve> edges)
        {
            Height = height;
            Width = width;
            WebThickness = webthickness;
            FlangeThickness = flangeThickness;
            RootRadius = rootRadius;
            ToeRadius = toeRadius;
            MirrorAboutLocalY = mirrorAboutLocalY;
            Edges = new ReadOnlyCollection<ICurve>(edges.ToList());
        }

        /***************************************************/
    }
}



