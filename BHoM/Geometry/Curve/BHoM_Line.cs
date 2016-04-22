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
    public class Line : Curve
    {

        internal Line() { }     

        /// <summary>
        /// Construct line by start point and end point
        /// </summary>
        /// <param name="startpoint"></param>
        /// <param name="endpoint"></param>
        public Line(Point startpoint, Point endpoint)
        {
            m_Dimensions = 3;
            m_ControlPoints = Common.Utils.Merge<double>(startpoint, endpoint);     
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

        public override void CreateNurbForm()
        {
            m_Knots = new double[] { 0, 0, 1, 1 };
            m_Order = 2;
            m_Weights = new double[] { 1, 1 };
            m_Dimensions = 3;
            IsNurbForm = true;
        }

        public override double Length
        {
            get
            {
                return VectorUtils.Length(VectorUtils.Sub(m_ControlPoints, 0, m_Dimensions + 1, m_Dimensions));
            }
        }
    }
}