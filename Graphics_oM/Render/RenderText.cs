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
using BH.oM.Geometry.CoordinateSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Graphics
{
    [Description("Render text at a location and orientation in space with specified height, font and colour.")]
    public class RenderText : IRender
    {

        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("The text to render.")]
        public virtual string Text { get; set; } = "";

        [Description("Cartesian to locate and orientate the text.")]

        public virtual Cartesian Cartesian { get; set; } = new Cartesian();

        [Description("Height of the text. Default is 1. Units will be determined by the setting of the user interface that renders the text.")]

        public virtual double Height { get; set; } = 1;

        [Description("Font used to render the text. Default is Arial.")]

        public virtual string FontName { get; set; } = "Arial";

        [Description("Colour used to render the text. Default is BHoM Coral with a subtle transparency (Color.FromArgb(80, 255, 41, 105)).")]

        public virtual Color Colour { get; set; } = Color.FromArgb(80, 255, 41, 105);

        /***************************************************/
    }
}
