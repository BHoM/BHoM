using System;

using System.Collections.Generic;
using BHoM.Base;

namespace BHoM.Geometry
{
    /// <summary>
    /// Arc object
    /// </summary>
    public class Arc : Curve
    {
        double[] m_Centre;
        double m_Radius;

        public override GeometryType GeometryType
        {
            get
            {
                return GeometryType.Arc;
            }
        }

        public Arc()
        {
            m_Dimensions = 3;
            m_ControlPoints = new double[(m_Dimensions + 1) * 3];
        }

        /// <summary>
        /// Arc from 3 points
        /// </summary>
        /// <param name="startpoint"></param>
        /// <param name="endpoint"></param>
        /// <param name="internalpoint"></param>
        public Arc(Point startpoint, Point endpoint, Point internalpoint)
        {
            m_ControlPoints = new double[12];
            Array.Copy(startpoint, m_ControlPoints, 4);
            Array.Copy(endpoint, 0, m_ControlPoints, 4 * 2, 4);
            Array.Copy(internalpoint, 0, m_ControlPoints, 4, 4);
            m_Dimensions = 3;
        }

        public Point InternalPoint
        {
            get
            {
                return new Point(Utils.SubArray<double>(m_ControlPoints, 4, 4));
            }
            set
            {
                Array.Copy(value, 0, m_ControlPoints, m_Dimensions + 1, m_Dimensions + 1);
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
                Array.Copy(value, 0, m_ControlPoints, m_ControlPoints.Length - (m_Dimensions + 1) - 1, m_Dimensions + 1);
            }
        }   
    }
}