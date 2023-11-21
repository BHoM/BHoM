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


using System;
using System.ComponentModel;
using System.Collections.Generic;
using BH.oM.Base;
using BH.oM.Quantities.Attributes;

namespace BH.oM.Ground
{

    [Description("An object containing the thresholds for a result.")]
    public class Limit : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("The value for the threshold.")]
        public virtual double Value { get; set; }

        [Description("The reference for the .")]
        public virtual string Reference { get; set; }

        [Description("The threshold for the property to test against.")]
        public virtual string Author { get; set; }

        [Description("Is the value a maxima? True for a maxima and false for a minima.")]
        public virtual bool Maxima { get; set; }

        /***************************************************/
    }
}