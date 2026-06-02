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
    [Description("A single point on a nonlinear force-deformation (or moment-rotation) curve, " +
                 "defined by a deformation value and a corresponding force value.")]
    public class ForceDeformationPoint : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Length]
        [Description("Deformation at this point on the curve. Metres [m] for translational DOFs, radians [rad] for rotational DOFs.")]
        public virtual double Deformation { get; set; } = 0;

        [Force]
        [Description("Force at this point on the curve. Newtons [N] for translational DOFs, Newton-metres [N·m] for rotational DOFs.")]
        public virtual double Force { get; set; } = 0;

        /***************************************************/
    }
}