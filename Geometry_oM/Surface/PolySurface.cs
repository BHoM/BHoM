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
using System.Collections.Generic;

namespace BH.oM.Geometry
{
    [Description("A composite surface constructed by combining a collection of surfaces of any type. Whole PolySurface integrity, continuity and closure is not guaranteed at creation. Discontinuous and/or multi-region definitions are possible, although validity of some engine methods may vary depending on the PolySurface form.")]
    public class PolySurface : ISurface
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("A collection of surfaces, of any or mixed type, which together define the composite shape.")]
        public virtual List<ISurface> Surfaces { get; set; } = new List<ISurface>();
        
        /***************************************************/
    }
} 



