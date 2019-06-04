/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2019, the respective contributors. All rights reserved.
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;
using BH.oM.Geometry;
using BH.oM.Common.Properties;

using BH.oM.Reflection.Attributes;

namespace BH.oM.Common.Interface
{
    [Deprecated("2.3", "Replaced by ISurface interface in Phsyical_oM")]
    public interface IObject2D : IBHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        //  1. Bottom surface for Roof
        //  2. Top surface for Floor
        //  3. Mid surface for Wall
        ISurface Surface { get; set; }
        Object2DProperties Properties { get; set; }

        //Move IBHoMExtendedProperties to Common_oM and implement ExtendedProperties
        //public List<IBHoMExtendedProperties> ExtendedProperties { get; set; };

        /***************************************************/
    }
}
