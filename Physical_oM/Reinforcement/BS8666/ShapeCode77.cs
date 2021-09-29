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
using BH.oM.Quantities.Attributes;

namespace BH.oM.Physical.Reinforcement.BS8666
{
    [Description("A reinforcement bar with shape code 77 to BS 8666:2020 centred on the Origin and XY Plane, the turns are about the Z axis in the negative direction. " +
        "The bar starts at the highest point of the circle (in the Y diretion) after laps have been accounted for.")]
    public class ShapeCode77 : BHoMObject, IShapeCode, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Length]
        public virtual double A { get;  }

        [Length]
        public virtual double B { get;  }

        [Length]
        public virtual double C { get;  }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public ShapeCode77(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        /***************************************************/

    }
}

