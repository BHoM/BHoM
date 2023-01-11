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

namespace BH.oM.Physical.Reinforcement.BS8666
{
    [Description("A reinforcement bar with shape code 00 to BS 8666:2020 in the XY Plane centred on the Origin and the A parameter aligned with the X axis.")]
    public class ShapeCode00 : BHoMObject, IShapeCode, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Length]
        public virtual double A { get;  }

        [Length]
        [Description("The diameter of the reinforcement bar.")]
        public virtual double Diameter { get; }

        [Length]
        [Description("Bend radius used for any discontinuities in the CentreCurve.")]
        public virtual double BendRadius { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public ShapeCode00(double a, double diameter, double bendRadius)
        {
            A = a;
            Diameter = diameter;
            BendRadius = bendRadius;
        }

        /***************************************************/
    }
}

