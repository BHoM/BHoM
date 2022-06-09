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
using BH.oM.Structure.MaterialFragments;
using BH.oM.Spatial.Layouts;
using BH.oM.Quantities.Attributes;
using System.ComponentModel;

namespace BH.oM.Structure.Reinforcement
{
    [Description("Defines any longitudinal reinforcement along a Bar.")]
    public class LongitudinalReinforcement : BHoMObject, IBarReinforcement
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Layout controlling the distribution of the rebars across the SectionProperty.")]
        public virtual ILayout2D RebarLayout { get; set; }

        [Length]
        [Description("Diameter of a single rebar.")]
        public virtual double Diameter { get; set; }

        public virtual IMaterialFragment Material { get; set; }

        [Description("Normalised length (0 means start, 1 means end) along the element where the rebars start.")]
        public virtual double StartLocation { get; set; } = 0;

        [Description("Normalised length (0 means start, 1 means end) along the element where the rebars ends.")]
        public virtual double EndLocation { get; set; } = 1;


        /***************************************************/
    }
}


