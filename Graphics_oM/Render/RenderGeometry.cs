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

using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Geometry;

namespace BH.oM.Graphics
{
    [Description("Render geometry with a specific colour.")]
    public class RenderGeometry : IRender
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("A geometry (or many geometry objects collected into a single `CompositeGeometry` object).")]
        public virtual IGeometry Geometry { get; set; }

        [Description("Colour used to render the Geometry. Default is BHoM Coral with a subtle transparency (Color.FromArgb(80, 255, 41, 105)).")]
        public virtual Color Colour { get; set; } = Color.FromArgb(80, 255, 41, 105);

        /***************************************************/

    }
}
