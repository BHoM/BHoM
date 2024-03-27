/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2024, the respective contributors. All rights reserved.
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
    public class SinusoidalCellularOpening : BHoMObject, ICellularOpening, IImmutable
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
        [Description("Width of the sinusoidal part of the opening.")]
        public virtual double SinusoidalLength { get; }

        [Length]
        [Description("Clear distance between openings.")]
        public virtual double WidthWebPost { get; }

        [Length]
        [Description("Centre to centre distance between openings.")]
        public virtual double Spacing { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public SinusoidalCellularOpening(double height, double width, double sinusoidalLength, double widthWebPost, double spacing)
        { 
            Height = height;
            SinusoidalLength = sinusoidalLength;
            WidthWebPost = widthWebPost;
            Spacing = spacing;
        }

        /***************************************************/
    }
}

