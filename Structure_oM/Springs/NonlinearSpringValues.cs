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
using System.ComponentModel;

namespace BH.oM.Structure.Springs
{
    [Description("A value per degree of freedom, used to define a single parameter of a nonlinear spring behaviour " +
                 "(for example stiffness, gap opening or yield force). The meaning and units of the values are set by " +
                 "the behaviour property that holds this object. A value of zero for a degree of freedom means the " +
                 "parameter is not active in that direction.")]
    public class NonlinearSpringValues : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Value for translation along the global X axis.")]
        public virtual double TranslationX { get; set; } = 0;

        [Description("Value for translation along the global Y axis.")]
        public virtual double TranslationY { get; set; } = 0;

        [Description("Value for translation along the global Z axis.")]
        public virtual double TranslationZ { get; set; } = 0;

        [Description("Value for rotation about the global X axis.")]
        public virtual double RotationX { get; set; } = 0;

        [Description("Value for rotation about the global Y axis.")]
        public virtual double RotationY { get; set; } = 0;

        [Description("Value for rotation about the global Z axis.")]
        public virtual double RotationZ { get; set; } = 0;

        /***************************************************/
    }
}
