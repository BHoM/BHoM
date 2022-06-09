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
using System.Collections.Generic;

namespace BH.oM.LifeCycleAssessment.Fragments
{
    [Description("A data fragment used to store irregular scaling values for EPDs. \n" +
        "Note this fragment is typically reserved for special circumstances requiring user override of documented EPD information. \n" +
        "Use AddFragment() to combine this information with any EPD for continuous integration.")]
    public class EPDDimension : IFragment
    {
        [Description("The standard dimension for the EPD being used for LCA calculations.")]
        public virtual double Dimension { get; set; } = 1;

        [Description("A user-provided scaling dimension that is derived from an EPD.")]
        public virtual double SpecifiedDimension { get; set; } = 1;
    }
}


