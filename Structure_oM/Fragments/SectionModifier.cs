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
using System.ComponentModel;
using BH.oM.Base;

namespace BH.oM.Structure.Fragments
{
    [Description("Sets modifiers to a SectionProperty. The modifiers are used to scale one or more of the property constants for analysis. Constants are multiplied with the modifiers, hence a modifier value of 1 means no change.")]
    public class SectionModifier : IFragment
    {
        [Ratio]
        [Description("Modifies the Area of the SectionProperty. Value of the SectionProperty is multiplied by this value, hence 1 means no scaling applied.")]
        public virtual double Area { get; set; } = 1;

        [Ratio]
        [Description("Modifies the Moment of Inertia about the local y-Axis of the SectionProperty. Value of the SectionProperty is multiplied by this value, hence 1 means no scaling applied.")]
        public virtual double Iy { get; set; } = 1;

        [Ratio]
        [Description("Modifies the Moment of Inertia about the local z-Axis of the SectionProperty. Value of the SectionProperty is multiplied by this value, hence 1 means no scaling applied.")]
        public virtual double Iz { get; set; } = 1;

        [Ratio]
        [Description("Modifies the Torsion Constant of the SectionProperty. Value of the SectionProperty is multiplied by this value, hence 1 means no scaling applied.")]
        public virtual double J { get; set; } = 1;

        [Ratio]
        [Description("Modifies the Shear Area in the local y direction of the SectionProperty. Value of the SectionProperty is multiplied by this value, hence 1 means no scaling applied.")]
        public virtual double Asy { get; set; } = 1;

        [Ratio]
        [Description("Modifies the Shear Area in the local z direction of the SectionProperty. Value of the SectionProperty is multiplied by this value, hence 1 means no scaling applied.")]
        public virtual double Asz { get; set; } = 1;
    }
}


