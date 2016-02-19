using System;

namespace BHoM.Geometry
{
    /// <summary>
    /// BHoM Line object
    /// </summary>
    [Serializable]
    public class Line : BHoM.Global.BHoMObject
    {
        /// <summary>Start point as BHoM point</summary>
        public Point StartPoint { get; set; }

        /// <summary>End point as BHoM point</summary>
        public Point EndPoint { get; set; }

        /// <summary>Length of the line</summary>
        public double Length
        {
            get
            {
                if (StartPoint.IsValid && EndPoint.IsValid)
                {
                    return StartPoint.DistanceTo(EndPoint);
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                this.Length = StartPoint.DistanceTo(EndPoint);
            }
        }

        /// <summary>
        /// Construct an empty line
        /// </summary>
        public Line()
        {
            this.StartPoint = new Point();
            this.EndPoint = new Point();
        }

        /// <summary>
        /// Construct line by start point and end point
        /// </summary>
        /// <param name="startpoint"></param>
        /// <param name="endpoint"></param>
        public Line(Point startpoint, Point endpoint) : this()
        {
            this.StartPoint = startpoint;
            this.EndPoint = endpoint;
        }

        /// <summary>
        /// Construct line by start and end point coordinates
        /// </summary>
        /// <param name="start_x"></param>
        /// <param name="start_y"></param>
        /// <param name="start_z"></param>
        /// <param name="end_x"></param>
        /// <param name="end_y"></param>
        /// <param name="end_z"></param>
        public Line(double start_x, double start_y, double start_z, double end_x, double end_y, double end_z) :this()
        {
            this.StartPoint = new Point(start_x, start_y, start_z);
            this.EndPoint = new Point(end_x, end_y, end_z);
        }

    }
}