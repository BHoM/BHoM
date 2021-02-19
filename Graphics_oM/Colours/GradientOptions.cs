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

using BH.oM.Base;
using BH.oM.Graphics.Enums;
using System.ComponentModel;

namespace BH.oM.Graphics.Colours
{
    public class GradientOptions : IObject
    {
        /***************************************************/
        /****            Public Properties              ****/
        /***************************************************/

        [Description("The Gradient to colour by")]
        public virtual Gradient Gradient { get; set; } = null;

        [Description("Lower bound of colour gradient, auto-generated if 'NaN'")]
        public virtual double From { get; set; } = double.NaN;

        [Description("Upper bound of colour gradient, auto-generated if 'NaN'")]
        public virtual double To { get; set; } = double.NaN;

        [Description("Either centre to & from around 0, or make the midpoint of the gradient relate to 0 while the ends still relate to to & from")]
        public virtual GradientCenteringOptions GradientCenteringOptions { get; set; } = GradientCenteringOptions.None;

        /***************************************************/

    }
}

