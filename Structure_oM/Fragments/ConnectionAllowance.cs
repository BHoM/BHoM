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


using BH.oM.Quantities.Attributes;
using BH.oM.Structure.MaterialFragments;
using System.ComponentModel;
using BH.oM.Base;
using BH.oM.Base.Attributes;
using BH.oM.Structure.Elements;

namespace BH.oM.Structure.Fragments
{
    [Description("The ConnectionAllowance of an element. Used when evaluating takeoffs to .")]
    public class ConnectionAllowance : IFragment
    {
        [Ratio]
        [Description("Additional connection allowance expressed as a ratio of the mass of the element. For example, a value of 0.1 means a connection allowance equal to 10% of the mass of the element to which this fragment is applied.")]
        public virtual double Allowance { get; set; } = 0;

        [Description("Optional material to be used for the connection. If null, the material of the element will be assumed.")]
        public virtual IMaterialFragment Material { get; set; } = null;

        [Description("Optional name for the connection allowance. Will be assigned as the name of the takeoff materials. If left empty, the name of the Material (or name of the material of the element) will be used instead.\n" +
                     "Can be useful if one wants to differentiate between connection and element contributions in the takeoff.")]
        public virtual string Name { get; set; } = "";
    }
}






