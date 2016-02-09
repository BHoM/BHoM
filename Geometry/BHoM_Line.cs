using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Geometry
{
    /// <summary>
    /// BHoM Line object
    /// </summary>
    [Serializable]
    public class Line
    {
        /// <summary>Start point as BHoM point</summary>
        public Point StartPoint { get; private set; }
        /// <summary>End point as BHoM point</summary>
        public Point EndPoint { get; private set; }


        /// <summary>
        /// Construct line by start point and end point
        /// </summary>
        /// <param name="startpoint"></param>
        /// <param name="endpoint"></param>
        public Line(Point startpoint, Point endpoint)
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
        public Line(double start_x, double start_y, double start_z, double end_x, double end_y, double end_z)
        {
            this.StartPoint = new Point(start_x, start_y, start_z);
            this.EndPoint = new Point(end_x, end_y, end_z);
        }
    }
}