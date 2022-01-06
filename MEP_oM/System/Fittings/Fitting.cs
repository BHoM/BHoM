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
using System.ComponentModel;
using BH.oM.Base;
using BH.oM.Dimensional;
using BH.oM.Geometry;
using BH.oM.MEP.Enums;

namespace BH.oM.MEP.System.Fittings
{
    [Description("A fitting object used to describe interfaces between or along linear MEP elements.")]
    public class Fitting : BHoMObject, IElement0D
    {
        /***************************************************/
        /****                 Properties                ****/
        /***************************************************/

        [Description("The point at which the Fitting occurs.")]
        public virtual Point Location { get; set; } = null;
        
        [Description("The points at which the Fitting physically connects to other MEP segments.")]
        public virtual List<Point> ConnectionsLocation { get; set; } = null;

        [Description("The type of fitting connected to an element.")]
        public virtual FittingType Type { get; set; } = FittingType.Undefined;

        /***************************************************/
    }
}


