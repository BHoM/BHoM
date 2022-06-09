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

using BH.oM.Base;
using BH.oM.Base.Attributes;
using System;
using System.ComponentModel;

namespace BH.oM.Quantities.Attributes
{
    [Description("Dimensional quantity as defined by the International System of Quantities")]
    public abstract class QuantityAttribute : InputClassificationAttribute, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Length dimension")]
        public virtual int L { get; } = 0;

        [Description("Mass dimension")]
        public virtual int M { get; } = 0;

        [Description("Time dimension")]
        public virtual int T { get; } = 0;

        [Description("Electric current dimension")]
        public virtual int I { get; } = 0;

        [Description("Temperature dimension")]
        public virtual int Θ { get; } = 0;

        [Description("Amount of substance dimension")]
        public virtual int N { get; } = 0;

        [Description("Luminous intensity dimension")]
        public virtual int J { get; } = 0;

        [Description("SI derived unit symbol")]
        public abstract string SIUnit { get; }

        /***************************************************/
    }
}


