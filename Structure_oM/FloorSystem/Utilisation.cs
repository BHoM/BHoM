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

using System.Collections.Generic;
using BH.oM.Structure.SectionProperties;
using BH.oM.Structure.SurfaceProperties;
using BH.oM.Structure.Reinforcement;
using BH.oM.Base;
using System.ComponentModel;
using BH.oM.Structure.Elements;
using BH.oM.Quantities.Attributes;

namespace BH.oM.Structure.FloorSystem
{
    [Description("Utilisation of a structural element, giving the governing limit state and optionally the utilisations of the constituent elements.")]
    public class Utilisation : BHoMObject, IImmutable
    {
        /***************************************************/
        /****            Public Properties              ****/
        /***************************************************/
        [Description("Name of the structural element.")]
        public virtual string Element { get; } = null;

        [Description("Utilisation ratio of the structural element, i.e. the ratio of demand to capacity for the governing limit state.")]
        [Ratio]
        public virtual double Ratio { get; } = 0;

        [Description("The failure mode corresponding to the utilisation ratio.")]
        public virtual string LimitState { get; } = null;

        [Description("Design assumptions made to determine the utilisation of the element.")]
        public virtual string Assumptions { get; } = null;

        [Description("Utilisations of constitutive elements, i.e. non-governing limit states.")]
        public virtual IReadOnlyList<Utilisation> Utilisations { get; } = null;

        /***************************************************/

        public Utilisation(string element, double ratio, string limitState, string assumptions, IReadOnlyList<Utilisation> utilisations)
        {
            Element = element;
            Ratio = ratio;
            LimitState = limitState;
            Assumptions = assumptions;
            Utilisations = utilisations;
        }

    }
}
