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
using BH.oM.Quantities.Attributes;
using System.ComponentModel;

namespace BH.oM.Structure.Springs
{
    [Description("A point spring property defining translational and rotational stiffness at a single point, with optional nonlinear force-deformation behaviour. Used for assignment to Nodes.")]
    public class PointSpringProperty : BHoMObject, ISpringProperty
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("A unique Name is required for some structural packages to create and identify the object.")]
        public override string Name { get; set; }

        [ForcePerUnitLength]
        [Description("Effective linear spring stiffness in global X [N/m]. Used in linear and response-spectrum analyses.")]
        public virtual double TranslationalStiffnessX { get; set; } = 0;

        [ForcePerUnitLength]
        [Description("Effective linear spring stiffness in global Y [N/m]. Used in linear and response-spectrum analyses.")]
        public virtual double TranslationalStiffnessY { get; set; } = 0;

        [ForcePerUnitLength]
        [Description("Effective linear spring stiffness in global Z [N/m]. Used in linear and response-spectrum analyses.")]
        public virtual double TranslationalStiffnessZ { get; set; } = 0;

        [MomentPerUnitAngle]
        [Description("Effective linear rotational stiffness about global X [N·m/rad].")]
        public virtual double RotationalStiffnessX { get; set; } = 0;

        [MomentPerUnitAngle]
        [Description("Effective linear rotational stiffness about global Y [N·m/rad].")]
        public virtual double RotationalStiffnessY { get; set; } = 0;

        [MomentPerUnitAngle]
        [Description("Effective linear rotational stiffness about global Z [N·m/rad].")]
        public virtual double RotationalStiffnessZ { get; set; } = 0;

        [Description("Nonlinear force-deformation curves per global translational direction. An empty list for a direction means no nonlinear spring for that DOF.")]
        public virtual ForceDeformationCurves ForceDeformationCurves { get; set; } = new ForceDeformationCurves();

        /***************************************************/
    }
}
