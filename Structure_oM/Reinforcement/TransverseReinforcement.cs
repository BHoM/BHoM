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
using BH.oM.Geometry;
using System.Collections.Generic;

namespace BH.oM.Structure.Reinforcement
{
    [Description("Defines any transverse reinforcement along a Bar.")]
    public class TransverseReinforcement : BHoMObject, IBarReinforcement
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Layout controlling the reinforcement shape in relation to the bar's section.")]
        public virtual ICurveLayout CenterlineLayout { get; set; }

        [Length]
        [Description("Diameter of a single rebar.")]
        public virtual double Diameter { get; set; }

        public virtual IMaterialFragment Material { get; set; }

        [Length]
        [Description("Axial distance between consecutive rebars. If AdjustSpacingToFit is true it will become maximum spacing.")]
        public virtual double Spacing { get; set; }

        [Description("Toggles if provided spacing value should be fixed or adjusted to fit rebars from the host bar's start to end.")]
        public virtual  bool AdjustSpacingToFit { get; set; }

        [Description("Normalised length (0 means start, 1 means end) along the element where the rebars start.")]
        public virtual double StartLocation { get; set; } = 0;

        [Description("Normalised length (0 means start, 1 means end) along the element where the rebars ends.")]
        public virtual double EndLocation { get; set; } = 1;


        /***************************************************/
    }
}


