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


using BH.oM.Quantities.Attributes;
using BH.oM.Structure.MaterialFragments;
using System.ComponentModel;
using BH.oM.Base;

namespace BH.oM.Structure.Fragments
{
    [Description("The reinforcement density of an element and its material.")]
    public class ReinforcementDensity : IFragment
    {
        [Density]
        [Description("The mass of reinforcement per unit volume of the element that owns this fragment.")]
        public virtual double Density { get; set; } = 0;

        [Description("Homogeneous material of the reinforcement.")]
        public virtual IMaterialFragment Material { get; set; } = null;
    }
}


