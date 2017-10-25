﻿using BH.oM.Geometry;
using BH.oM.Base;
using System;
using System.Reflection;
using BH.oM.Structural.Loads;
using System.Collections.Generic;
using System.ComponentModel;

namespace BH.oM.Structural.Elements
{
    /// <summary>
    /// 
    /// </summary>
    public class Beam : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<Bar> AnalyticBars { get; set; } = new List<Bar>();

        public ICurve LocationCurve { get; set; }

        public Properties.SectionProperty SectionProperty { get; set; } = null;

        public BarStructuralUsage StructuralUsage { get; set; }

        /// <summary>
        /// Bar orientation angle in radians. For non-vertical bars, angle is measured in the bar YZ plane
        /// betwen the Y axis and the Y vector projected one a vertical plane defined by the start and end
        /// nodes. For vertical bars, angle is measured between the bar Y axis and global Y axis. A bar is 
        /// vertical if the distance between end points projected to a horizontal plane is less than 0.0001
        /// </summary>
        public double OrientationAngle { get; set; } = 0;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Beam() { }

        /***************************************************/

        public Beam(ICurve locationCurve)
        {
            this.LocationCurve = locationCurve;
        }

    }
}
