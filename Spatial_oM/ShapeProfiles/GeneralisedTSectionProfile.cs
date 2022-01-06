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
using System.Collections.ObjectModel;
using System.Linq;
using BH.oM.Base;
using BH.oM.Geometry;
using System.ComponentModel;
using BH.oM.Quantities.Attributes;

namespace BH.oM.Spatial.ShapeProfiles
{
    [Description("T-shaped profile that allows for different outsand widths and thicknesses. Outstands with different thicknesses are aligned by their top edge.\n" + 
                 "The full width of the top flange can be calculated as LeftOutstandWidth + WebThickness + RightOutstandWidth.")]
    public class GeneralisedTSectionProfile : BHoMObject, IProfile, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public virtual ShapeType Shape { get; } = ShapeType.Tee;

        [Length]
        [Description("Full depth between the extreme fibre of the outstand and the web.")]
        public virtual double Height { get; }

        [Length]
        public virtual double WebThickness { get; }

        [Length]
        [Description("Outstand width on the left side, measured from the outside edge of the web.")]
        public virtual double LeftOutstandWidth { get; }

        [Length]
        public virtual double LeftOutstandThickness { get; }

        [Length]
        [Description("Outstand width on the right side, measured from the outside edge of the web.")]
        public virtual double RightOutstandWidth { get; }

        public virtual double RightOutstandThickness { get; }

        [Description("If true, the section is mirrored about its local y-axis, resulting in upside down T-shape.")]
        public virtual bool MirrorAboutLocalY { get; }

        [Description("Edge curves that matches the dimensions in the global XY-plane.")]
        public virtual ReadOnlyCollection<ICurve> Edges { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public GeneralisedTSectionProfile(double height, double webThickness, double leftOutstandWidth, double leftOutstandThickness, double rightOutstandWidth, double rightOutstandThickness, bool mirrorAboutLocalY, IEnumerable<ICurve> edges)
        {
            Height = height;
            WebThickness = webThickness;
            LeftOutstandWidth = leftOutstandWidth;
            LeftOutstandThickness = leftOutstandThickness;
            RightOutstandWidth = rightOutstandWidth;
            RightOutstandThickness = rightOutstandThickness;
            MirrorAboutLocalY = mirrorAboutLocalY;
            Edges = new ReadOnlyCollection<ICurve>(edges.ToList());
        }

        /***************************************************/
    }
}                                                   


