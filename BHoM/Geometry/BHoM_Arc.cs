using System;

namespace BHoM.Geometry
{
    /// <summary>
    /// Arc object
    /// </summary>
    [Serializable]
    public abstract class Arc
    {
        /// <summary>Base plane for arc</summary>
        public abstract Plane Plane { get; set; }

        /// <summary>Start point as BHoM point</summary>
        public abstract Point StartPoint { get; set; }

        /// <summary>End point as BHoM point</summary>
        public abstract Point EndPoint { get; set; }

        /// <summary>Radius</summary>
        public abstract double Radius { get; set; }

        /// <summary>Angle in radians</summary>
        public abstract double Angle { get; set; }

        /// <summary>
        /// Constructs an arc in default global XY plane
        /// </summary>
        /// <param name="startpoint"></param>
        /// <param name="endpoint"></param>
        /// <param name="radius"></param>
        public Arc(Point startpoint, Point endpoint, double radius)
        {
            this.Plane = new Plane();
            this.StartPoint = startpoint;
            this.EndPoint = endpoint;
            this.Radius = radius;
        }

        /// <summary>
        /// Construct an arc using start point, end point and base plane
        /// </summary>
        /// <param name="startpoint"></param>
        /// <param name="endpoint"></param>
        /// <param name="radius"></param>
        /// <param name="plane"></param>
        public Arc(Point startpoint, Point endpoint, double radius, Plane plane)
        {
            this.Plane = plane;
            this.StartPoint = startpoint;
            this.EndPoint = endpoint;
            this.Radius = radius;
        }
    }
}