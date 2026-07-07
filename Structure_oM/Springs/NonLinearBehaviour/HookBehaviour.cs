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
    [Description("Tension-only (hook) behaviour. A degree of freedom carries no force until its initial opening is " +
                 "taken up in tension, after which it responds with the given stiffness. The effective (linear-analysis) " +
                 "stiffness is taken from the inherited Constraint6DOF stiffnesses.")]
    public class HookBehaviour : INonLinearBehaviour
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Nonlinear stiffness per degree of freedom, mobilised once the hook engages. " +
                     "Translational in [N/m], rotational in [N·m/rad].")]
        public virtual NonlinearSpringValues InitialStiffness { get; set; } = new NonlinearSpringValues();

        [Description("Initial hook opening per degree of freedom. The degree of freedom carries no force until this " +
                     "deformation is taken up in tension. Translational in [m], rotational in [rad].")]
        public virtual NonlinearSpringValues InitialOpening { get; set; } = new NonlinearSpringValues();

        /***************************************************/
    }
}
