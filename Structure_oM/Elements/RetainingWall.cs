﻿using System;
using System.ComponentModel;
using BH.oM.Base;
using BH.oM.Dimensional;
using BH.oM.Geometry;

namespace BH.oM.Structure.Elements
{
    public class RetainingWall : BHoMObject, IElementM //Question if this should be a bhomobject or a compisiteobject. Cant be both. Settled on BHoMObject for now.
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Stem of the retaining wall.")]
        public virtual Stem Stem { get; set; } = new Stem();

        [Description("Footing of the retaining wall.")]
        public virtual Footing Footing { get; set; } = new Footing();

        [Description("The retained height of soil measured from the bottom of the wall Footing.")]
        public virtual double RetainedHeight { get; set; } = 0.0;

        [Description("The distance from top of Footing to finished floor level on the exposed face.")]
        public virtual double CoverDepth { get; set; } = 0.0;

        [Description("The distance from the base of the Footing to ground water level.")]
        public virtual double GroundWaterDepth { get; set; } = 0.0;

        [Description("Angle of retention between wall and ground. Measured at top of wall in radians.")] 
        public virtual double RetentionAngle { get; set; } = 0.0;

        /***************************************************/
    }
}