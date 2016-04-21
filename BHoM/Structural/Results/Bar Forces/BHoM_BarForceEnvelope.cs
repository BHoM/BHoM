using System;

namespace BHoM.Structural.Results.Bars
{
    /// <summary>
    /// Envelope of bar forces representing the minima and maxima forces and principle
    /// stresses of a collection of bar forces
    /// </summary>
    public class BarForceEnvelope 
    {
        /// <summary>Associated bar number</summary>
        public int[] BarNumbers { get; set; }

        /// <summary>Position along the bar of the force</summary>
        public double[] ForcePositions { get; set; }

        /// <summary>Associated loadcase number</summary>
        public int[] LoadcaseNumbers { get; set; }

        /// <summary>Associated loadcase name</summary>
        public string[] LoadcaseNames { get; private set; }

        /// <summary>Governing case number</summary>

        /// <summary>Maximum axial force, tension negative</summary>
        public double FXMax { get; set; }

        /// <summary>Minimum axial force, tension negative</summary>
        public double FXMin { get; set; }

        /// <summary>Maximum shear force, minor axis</summary>
        public double FYMax { get; set; }

        /// <summary>Minimum shear force, minor axis</summary>
        public double FYMin { get; set; }

        /// <summary>Maximum shear force, major axis</summary>
        public double FZMax { get; set; }

        /// <summary>Minimum shear force, major axis</summary>
        public double FZMin { get; set; }

        /// <summary>Maximum torsion</summary>
        public double MXMax { get; set; }

        /// <summary>Minimum torsion</summary>
        public double MXMin { get; set; }

        /// <summary>Maximum bending moment, minor axis</summary>
        public double MYMax { get; set; }

        /// <summary>Minimum bending moment, minor axis</summary>
        public double MYMin { get; set; }

        /// <summary>Maximum bending moment, major axis</summary>
        public double MZMax { get; set; }

        /// <summary>Minimum bending moment, major axis</summary>
        public double MZMin { get; set; }

        /// <summary>Maximum principle stress</summary>
        public double SMax { get; set; }

        /// <summary>Minimum principle stress</summary>
        public double SMin { get; set; }

        /// <summary>Orientation of bar forces inherited from bar</summary>
        public BHoM.Geometry.Plane[] OrientationPlane { get; set; }

        /// <summary>User text field for any user data</summary>
        public string UserData { get; set; }


    }
}
