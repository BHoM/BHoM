﻿/*
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
using BH.oM.Quantities.Attributes;
using BH.oM.Reflection.Attributes;

namespace BH.oM.Physical.Reinforcement
{
    [NoAutoConstructor]
    [Description("A reinforcement bar with shape code 56 to BS 8666:2020 in the XY Plane centred on the bisection of the B, aligned with the Y axis," +
        " and C, aligned with the X axis, parameters at the Origin.")]
    public class ShapeCode56 : BHoMObject, IShapeCode
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Length]
        public virtual double A { get; set; }

        [Length]
        public virtual double B { get; set; }

        [Length]
        public virtual double C { get; set; }

        [Length]
        public virtual double D { get; set; }

        [Length]
        public virtual double E { get; set; }

        [Length]
        public virtual double F { get; set; }

        /***************************************************/
    }
}

