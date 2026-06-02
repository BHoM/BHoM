/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2026, the respective contributors. All rights reserved.
 * ...
 */

using BH.oM.Base;
using BH.oM.Quantities.Attributes;
using System.ComponentModel;

namespace BH.oM.Structure.Springs
{
    public class NonLinearSpring : BHoMObject, IProperty
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

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