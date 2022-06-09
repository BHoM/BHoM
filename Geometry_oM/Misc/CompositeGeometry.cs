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
    [Description("A collection of multiple sets of Geometry of any or mixed type. Integrity, continuity and closure is not guaranteed. Discontinuous and/or mixed type definitions are possible, with no restrictions placed on how geometry can be combined.")]
    public class CompositeGeometry : IGeometry
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/


        [Description("A list of assorted geometry, which together define the composite shape.")]
        public virtual List<IGeometry> Elements { get; set; } = new List<IGeometry>();
        
        /***************************************************/
    }
}



