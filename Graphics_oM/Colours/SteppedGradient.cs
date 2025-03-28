/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2025, the respective contributors. All rights reserved.
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace BH.oM.Graphics
{
    [Description("Gradient for extracting colours in specific range bands, this is, a single colour for a specific range.")]
    public class SteppedGradient : BHoMObject, IGradient
    {
        /***************************************************/
        /****            Public Properties              ****/
        /***************************************************/

        [Description("A SortedDictionary of 'Color's using a 'decimal' between 0 and 1 as Key. Decimal of marker indicates the lower limit for the range of that colour.")]
        public virtual SortedDictionary<decimal, Color> Markers { get; set; } = new SortedDictionary<decimal, Color>();

        /***************************************************/

    }
}






