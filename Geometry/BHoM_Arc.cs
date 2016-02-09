using System;

namespace BHoM.Geometry
{
    /// <summary>
    /// Arc object
    /// </summary>
    [Serializable]
    public class Arc
    {
        /// <summary>Base plane for arc</summary>
        public Plane Plane { get; private set; }
        /// <summary>Start point as BHoM point</summary>
        public Point StartPoint { get; private set; }
        /// <summary>End point as BHoM point</summary>
        public Point EndPoint { get; private set; }
        /// <summary>Radius</summary>
        public double Radius { get; private set; }
        /// <summary>Angle in radians</summary>
        public double Angle { get; private set; }


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