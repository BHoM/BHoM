/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2026, the respective contributors. All rights reserved.
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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BH.oM.LifeCycleAssessment.MaterialFragments.Construction
{
    [Description("A class defining the waste rate associated with a construction material.")]
    public class WasteRate : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("The percentage of waste expected during construction, expressed as a value between 0 and 1.")]
        public virtual double Rate { get; set; }

        [Description("The name of the material to which the waste rate applies.")]
        public override string Name { get; set; }

        /***************************************************/
        /**** Explicit Casting                          ****/
        /***************************************************/

        [Description("Constructs a custom waste rate given jsut the rate. Usefull to be able to provide just the rate in UIs.")]
        public static explicit operator WasteRate(double rate)
        {
            return new WasteRate { Rate = rate, Name = "Custom" };
        }

        /***************************************************/
    }
}

