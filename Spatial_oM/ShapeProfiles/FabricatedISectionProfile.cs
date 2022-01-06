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
    [Description("I-shaped profile with parallel flanges that allows for different thicknesses of the web, top flange and bottom flange as well as different top and bottom flange widths.")]
    public class FabricatedISectionProfile : BHoMObject, IProfile, IImmutable
    {

        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        public virtual ShapeType Shape { get; } = ShapeType.ISection;

        [Length]
        [Description("Full depth between the extreme fibres of the flanges.")]
        public virtual double Height { get; }

        [Length]
        [Description("Full width of the top flange.")]
        public virtual double TopFlangeWidth { get; }

        [Length]
        [Description("Full width of the bottom flange.")]
        public virtual double BotFlangeWidth { get; }

        [Length]
        public virtual double WebThickness { get; }

        [Length]
        public virtual double TopFlangeThickness { get; }

        [Length]
        public virtual double BotFlangeThickness { get; }

        [Length]
        [Description("Fillet weld size between web and flanges. Measured as the distance between intersection of web and flange perpendicular to the edge of the weld.")]
        public virtual double WeldSize { get; }

        [Description("Edge curves that matches the dimensions in the global XY-plane.")]
        public virtual ReadOnlyCollection<ICurve> Edges { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public FabricatedISectionProfile(double height, double topFlangeWidth, double botFlangeWidth, double webThickness, double topFlangeThickness, double botFlangeThickness, double weldSize, IEnumerable<ICurve> edges)
        {
            Height = height;
            TopFlangeWidth = topFlangeWidth;
            BotFlangeWidth = botFlangeWidth;
            WebThickness = webThickness;
            BotFlangeThickness = botFlangeThickness;
            TopFlangeThickness = topFlangeThickness;
            WeldSize = weldSize;
            Edges = new ReadOnlyCollection<ICurve>(edges.ToList());
        }


        /***************************************************/
    }
}



