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

using System.ComponentModel;
using BH.oM.Base;
using BH.oM.Quantities.Attributes;

namespace BH.oM.LifeCycleAssessment.Fragments
{
    [Description("A data fragment used to store Density values if provided from the EPD source. \n" +
        "Density is a required property for all Evaluations of EPDs with Mass-QuantityType." +
        "Density can be changed by the user by adding this fragment to an EPD. \n" +
        "The user accepts responsibility for any changes beyond the given dataset information as not all EPDs will contain Density values.")]
    public class EPDDensity : IFragment
    {
        [Density]
        [Description("The material density in kg/m^3.")]
        public virtual double Density { get; set; } = 0;
    }
}


