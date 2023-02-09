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
using BH.oM.Dimensional;
using BH.oM.Geometry;
using BH.oM.Quantities.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BH.oM.Physical.Elements
{
    [Description("Object representing a physical element, defined by a geometrical mesh that represents that element in 3-dimensional space.\n" +
                 "Can commonly store properties and parameters in fragments corresponding to the software from which the element was extracted.")]
    public class MeshElement : BHoMObject, IElement, IPhysical
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Mesh defining the full 3-dimensional geometry of the element.")]
        public virtual Mesh Mesh { get; set; } = null;

        /***************************************************/

    }
}



