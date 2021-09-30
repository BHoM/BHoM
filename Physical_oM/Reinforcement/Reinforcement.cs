/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2021, the respective contributors. All rights reserved.
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
using System.ComponentModel;
using BH.oM.Base;
using BH.oM.Geometry.CoordinateSystem;
using BH.oM.Quantities.Attributes;
using BH.oM.Reflection.Attributes;

namespace BH.oM.Physical.Reinforcement
{
    [NoAutoConstructor]
    [Description("The physical reinforcement object containing the ShapeCode(and it's parameters), the diameter and coodinate system. This can be used with a number of Engine methods such" +
        "as Centreline and Length.")]
    public class Reinforcement : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Position and orientation of the Reinforcement in Space. Refer to the description of the shape codes for how they relate to the coordinate system.")]
        public virtual Cartesian CoordinateSystem { get; set; }

        [Description("The ShapeCode object containing the geometrical parameters of the reinforcement bar.")]
        public virtual IShapeCode ShapeCode { get; set; }

        /***************************************************/
    }
}

