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

using System.ComponentModel;

namespace BH.oM.Structure.Springs.NonLinearBehaviour
{
    [Description("Viscous damper behaviour. The force in each degree of freedom is rate-dependent, " +
                 "force = DampingCoefficient * velocity ^ DampingExponent, and so cannot be represented by a " +
                 "force-deformation curve. The effective (linear-analysis) stiffness and damping come from the " +
                 "PointSpringProperty (the inherited Constraint6DOF stiffnesses and its EffectiveDamping).")]
    public class DamperBehaviour : INonLinearBehaviour
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Nonlinear spring stiffness K acting in parallel with the damper, per degree of freedom. " +
                     "Translational in [N/m], rotational in [N·m/rad].")]
        public virtual NonlinearSpringValues InitialStiffness { get; set; } = new NonlinearSpringValues();

        [Description("Damping coefficient C per degree of freedom. Translational in [N·s/m], rotational in [N·m·s/rad].")]
        public virtual NonlinearSpringValues DampingCoefficient { get; set; } = new NonlinearSpringValues();

        [Description("Damping exponent per degree of freedom, applied to the velocity term. Unitless; a value of 1.0 " +
                     "gives linear viscous damping.")]
        public virtual NonlinearSpringValues DampingExponent { get; set; } = new NonlinearSpringValues();

        /***************************************************/
    }
}
