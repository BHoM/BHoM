/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2023, the respective contributors. All rights reserved.
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
using BH.oM.Quantities.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BH.oM.Spatial.ShapeProfiles.CellularOpenings
{
    public class HexagonalOpening : BHoMObject, ICellularOpening, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Length]
        [Description("Total height of the opening.")]
        public virtual double Height { get; }

        [Length]
        [Description("Total width of the opening.")]
        public virtual double Width { get; }

        [Length]
        [Description("Length of the intermidiate web post as well as top of the opening.")]
        public virtual double WidthWebPost { get; }

        [Length]
        [Description("Height of any spacer plate between the two profile sides.")]
        public virtual double SpacerHeight { get; }


        [Length]
        [Description("Length of the end web post.")]
        public virtual double LengthEndPost { get; }

        [Length]
        [Description("Centre distance between openings.")]
        public virtual double Spacing { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public HexagonalOpening(double height, double width, double spacerHeight, double widthWebPost, double lengthEndPost, double spacing)
        { 
            Height = height;
            Width = width;
            SpacerHeight = spacerHeight;
            WidthWebPost = widthWebPost;
            LengthEndPost = lengthEndPost;
            Spacing = spacing;
        }

        /***************************************************/
    }
}
