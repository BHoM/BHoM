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
    [Description("Rectangular hollow profile that allows for different thicknesses of the webs, top flange and bottom flange as well as defined outstands of the top and bottom flange")]
    public class GeneralisedFabricatedBoxProfile : BHoMObject, IProfile, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public virtual ShapeType Shape { get; } = ShapeType.Box;

        [Length]
        [Description("Full depth between the extreme fibres of the flanges.")]
        public virtual double Height { get; }

        [Length]
        [Description("Width between the extreme fibres of the webs, excluding corbel widths.")]
        public virtual double Width { get; }

        [Length]
        public virtual double WebThickness { get; }

        [Length]
        public virtual double TopFlangeThickness { get; }

        [Length]
        public virtual double BotFlangeThickness { get; }

        [Length]
        [Description("The additional width added to the left side of the top flange, measured from the outside edge of the web.")]
        public virtual double TopLeftCorbelWidth { get; }

        [Length]
        [Description("The additional width added to the right side of the top flange, measured from the outside edge of the web.")]
        public virtual double TopRightCorbelWidth { get; }

        [Length]
        [Description("The additional width added to the left side of the bottom flange, measured from the outside edge of the web.")]
        public virtual double BotLeftCorbelWidth { get; }

        [Length]
        [Description("The additional width added to the right side of the bottom flange, measured from the outside edge of the web.")]
        public virtual double BotRightCorbelWidth { get; }

        [Description("Edge curves that matches the dimensions in the global XY-plane.")]
        public virtual ReadOnlyCollection<ICurve> Edges { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public GeneralisedFabricatedBoxProfile(double height, double width, double webThickness, double topFlangeThickness, double botFlangeThickness, double topLeftCorbelWidth, double topRightCorbelWidth, double botLeftCorbelWidth, double botRightCorbelWidth, IEnumerable<ICurve> edges)
        {
            Height = height;
            Width = width;
            WebThickness = webThickness;
            TopFlangeThickness = topFlangeThickness;
            BotFlangeThickness = botFlangeThickness;
            TopLeftCorbelWidth = topLeftCorbelWidth;
            TopRightCorbelWidth = topRightCorbelWidth;
            BotLeftCorbelWidth = botLeftCorbelWidth;
            BotRightCorbelWidth = botRightCorbelWidth;
            Edges = new ReadOnlyCollection<ICurve>(edges.ToList());
        }

        /***************************************************/
    }
}



