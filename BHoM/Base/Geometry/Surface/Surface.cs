using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Geometry
{
    /// <summary>
    /// BHoM Surface object
    /// </summary>
    [Serializable]
    public class Surface : Brep
    {
        private double[] m_ControlPoints;
        private double[] m_Weights;
        private double[] m_UKnots;
        private double[] m_VKnots;
        private int m_Order;
        private int m_Dimensions;
        private int m_Columns;
        protected int[] m_MaxMin;

        public override GeometryType GeometryType
        {
            get
            {
                return GeometryType.Surface;
            }
        }


        public virtual int PointCount
        {
            get
            {
                return m_ControlPoints.Length / (m_Dimensions + 1);
            }
        }

        public List<Point> ControlPoints
        {
            get
            {
                List<Point> cPnts = new List<Point>();
                for (int i = 0; i < PointCount; i++)
                {
                    cPnts.Add(new Point(m_ControlPoints, (m_Dimensions + 1) * i));
                }
                return cPnts;
            }
        }

        public Group<Curve> TrimmingCurves
        {
            get
            {
                return m_ExternalEdges;
            }
            set
            {
                m_ExternalEdges = value;
            }
        }


        public double[] ControlPointVector
        {
            get
            {
                return m_ControlPoints;
            }
            set
            {
                m_ControlPoints = value;
            }
        }

        public double[] uKnots
        {
            get
            {
                return m_UKnots;
            }
            set
            {
                m_UKnots = value;
            }
        }

        public double[] vKnots
        {
            get
            {
                return m_VKnots;
            }
            set
            {
                m_VKnots = value;
            }
        }

        public int PointColumns
        {
            get
            {
                return m_Columns;
            }
            set
            {
                m_Columns = value;
            }
        }


        public double[] Weights
        {
            get
            { 
                return m_Weights;
            }
            set
            {
                m_Weights = value;
            }
        }

        public int Degree
        {
            get
            {
                return m_Order - 1;
            }
            set
            {
                m_Order = value + 1;
            }
        }

        public int Order
        {
            get
            {
                return m_Order;
            }
        }

        public int Dimensions
        {
            get
            {
                return m_Dimensions;
            }
        }


        public override BoundingBox Bounds()
        {
            return new BoundingBox(Max, Min);          
        }

        public Surface()
        {
            m_Dimensions = 3;
            m_ExternalEdges = new Group<Curve>();
        }

        internal virtual Point Max
        {
            get
            {
                if (m_MaxMin == null)
                {
                    m_MaxMin = CollectionUtils.MaxMinIndices(m_ControlPoints, m_Dimensions + 1);
                }
                return new Point(m_ControlPoints[m_MaxMin[0]], m_ControlPoints[m_MaxMin[1]], m_ControlPoints[m_MaxMin[2]]);
            }
        }

        internal virtual Point Min
        {
            get
            {
                if (m_MaxMin == null)
                {
                    m_MaxMin = CollectionUtils.MaxMinIndices(m_ControlPoints, m_Dimensions + 1);
                }
                return new Point(m_ControlPoints[m_MaxMin[3]], m_ControlPoints[m_MaxMin[4]], m_ControlPoints[m_MaxMin[5]]);
            }
        }


        public override void Update()
        {
            m_MaxMin = null;
        }

        public Surface DuplicateSurface()
        {
            Surface s = (Surface)Activator.CreateInstance(this.GetType(), true);
            s.m_ControlPoints =  CollectionUtils.Copy<double>(m_ControlPoints);
            s.m_Columns = m_Columns;
            s.m_Dimensions = m_Dimensions;
            s.m_Weights = CollectionUtils.Copy<double>(m_Weights);
            s.m_UKnots = CollectionUtils.Copy<double>(m_UKnots);
            s.m_VKnots = CollectionUtils.Copy<double>(m_VKnots);
            s.m_Order = m_Order;
            s.m_ExternalEdges = m_ExternalEdges.DuplicateGroup();

            return s;
        }


        public override BHoMGeometry Duplicate()
        {
            return DuplicateSurface();
        }

        #region Static Functions

        public static Surface CreateFromPoints(Point p1, Point p2, Point p3, Point p4)
        {
            Surface s = new Surface();
            //s.CreateFrom4Points(p1, p2, p3, p4);
            return s;
        }   
        #endregion
    }
}