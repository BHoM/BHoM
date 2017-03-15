using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BHoM.Base;

namespace BHoM.Geometry
{
    /// <summary>
    /// BHoM Line object
    /// </summary>
    [Serializable]
    public class Line : Curve
    {

        public Line()
        {
            m_Dimensions = 3;
            m_ControlPoints = new double[8];
        }

        /// <summary>
        /// Construct line by start point and end point
        /// </summary>
        /// <param name="startpoint"></param>
        /// <param name="endpoint"></param>
        public Line(Point startpoint, Point endpoint)
        {
            m_Dimensions = 3;
            m_ControlPoints = CollectionUtils.Merge<double>(startpoint, endpoint);
        }

        public Line(double[] startpoint, double[] endpoint)
        {
            m_Dimensions = 3;
            m_ControlPoints = new double[8];
            Array.Copy(startpoint, m_ControlPoints, startpoint.Length);
            Array.Copy(endpoint, 0, m_ControlPoints, 4, endpoint.Length);
            m_ControlPoints[3] = 1;
            m_ControlPoints[7] = 1;
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
            m_Dimensions = 3;
            m_ControlPoints = new double[] { start_x, start_y, start_z, 1, end_x, end_y, end_z, 1 };
        }

        public override GeometryType GeometryType
        {
            get
            {
                return GeometryType.Line;
            }
        }

        public new Point StartPoint
        {
            get
            {
                return base.StartPoint;
            }
            set
            {
                Array.Copy(value, 0, m_ControlPoints, 0, m_Dimensions + 1);
            }
        }

        public new Point EndPoint
        {
            get
            {
                return base.StartPoint;
            }
            set
            {
                Array.Copy(value, 0, m_ControlPoints, m_Dimensions + 1, m_Dimensions + 1);
            }
        }

        public Vector Direction
        {
            get
            {
                return EndPoint - StartPoint;
            }
        }      
    }
}