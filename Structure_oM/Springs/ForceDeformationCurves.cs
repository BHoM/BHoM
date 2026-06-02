/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2026, the respective contributors. All rights reserved.
 * ...
 */

using BH.oM.Base;
using System.Collections.Generic;
using System.ComponentModel;

namespace BH.oM.Structure.Springs
{
    [Description("Nonlinear force-deformation curves for each translational degree of freedom " +
                 "of a spring. Each list contains ordered ForceDeformationPoints defining the " +
                 "spring response in that global direction. An empty list means no nonlinear " +
                 "spring is active for that DOF.")]
    public class ForceDeformationCurves : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Force-deformation curve for translation in the global X direction. Deformation in [m], Force in [N].")]
        public virtual List<ForceDeformationPoint> TranslationX { get; set; } = new List<ForceDeformationPoint>();

        [Description("Force-deformation curve for translation in the global Y direction. Deformation in [m], Force in [N].")]
        public virtual List<ForceDeformationPoint> TranslationY { get; set; } = new List<ForceDeformationPoint>();

        [Description("Force-deformation curve for translation in the global Z direction. Deformation in [m], Force in [N].")]
        public virtual List<ForceDeformationPoint> TranslationZ { get; set; } = new List<ForceDeformationPoint>();

        [Description("Moment-rotation curve for rotation about global X [rad, N·m].")]
        public virtual List<ForceDeformationPoint> RotationX { get; set; } = new List<ForceDeformationPoint>();

        [Description("Moment-rotation curve for rotation about global Y [rad, N·m].")]
        public virtual List<ForceDeformationPoint> RotationY { get; set; } = new List<ForceDeformationPoint>();

        [Description("Moment-rotation curve for rotation about global Z [rad, N·m].")]
        public virtual List<ForceDeformationPoint> RotationZ { get; set; } = new List<ForceDeformationPoint>();

        /***************************************************/
    }
}