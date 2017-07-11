using BH.oM.Geometry.Curve;
using BH.oM.Geometry.Surface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Geometry
{
    public class NurbSurface : ISurface
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<Point> ControlPoints { get; set; } = new List<Point>();

        public List<double> Weights { get; set; } = new List<double>();

        public List<double> UKnots { get; set; } = new List<double>();

        public List<double> VKnots { get; set; } = new List<double>();


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public NurbSurface() { }

        /***************************************************/

        public NurbSurface(IEnumerable<Point> controlPoints, int degree = 3)
        {
            int n = controlPoints.Count();
            int d = degree - 1;
            ControlPoints = controlPoints.ToList();
            Weights = Enumerable.Repeat(1.0, n).ToList();
            //Knots = Enumerable.Repeat(0, d).Concat(Enumerable.Range(0, n - d).Concat(Enumerable.Repeat(n - d - 1, d))).Select(x => (double)x).ToList();
            //TODO: Calculate the U-knots and V-knots
        }

        /***************************************************/

        public NurbSurface(IEnumerable<Point> controlPoints, IEnumerable<double> weights, int degree = 3)
        {
            int n = controlPoints.Count();
            int d = degree - 1;
            ControlPoints = controlPoints.ToList();
            Weights = weights.ToList();
            //Knots = Enumerable.Repeat(0, d).Concat(Enumerable.Range(0, n - d).Concat(Enumerable.Repeat(n - d - 1, d))).Select(x => (double)x).ToList();
            //TODO: Calculate the U-knots and V-knots
        }

        /***************************************************/

        public NurbSurface(IEnumerable<Point> controlPoints, IEnumerable<double> weights, IEnumerable<double> uKnots, IEnumerable<double> vKnots)
        {
            ControlPoints = controlPoints.ToList();
            Weights = weights.ToList();
            UKnots = uKnots.ToList();
            VKnots = vKnots.ToList();
        }


        /***************************************************/
        /**** Local Methods                             ****/
        /***************************************************/

        public int GetDegree()
        {
            return 1 + UKnots.Count - ControlPoints.Count; //TODO: Calculate degree properly
        }


        /***************************************************/
        /**** IBHoMGeometry Interface                   ****/
        /***************************************************/

        public GeometryType GetGeometryType()
        {
            return GeometryType.NurbSurface;
        }

        /***************************************************/

        public BoundingBox GetBounds()
        {
            throw new NotImplementedException(); //TODO: Implement bounds for NurbsSurface
        }

        /***************************************************/

        public object Clone()
        {
            return new NurbSurface(ControlPoints.Select(x => x.Clone() as Point), Weights, UKnots, VKnots);
        }

        /***************************************************/

        public IBHoMGeometry GetTranslated(Vector t)
        {
            return new NurbSurface(ControlPoints.Select(x => x + t), Weights, UKnots, VKnots);
        }


        /***************************************************/
        /**** IBrep Interface                           ****/
        /***************************************************/

        public List<ICurve> GetExternalEdges()
        {
            throw new NotImplementedException(); //TODO: Get external edges
        }

        /***************************************************/

        public List<ICurve> GetInternalEdges()
        {
            return new List<ICurve>();
        }








        //public Group<Curve> TrimmingCurves
        //{
        //    get
        //    {
        //        return m_ExternalEdges;
        //    }
        //    set
        //    {
        //        m_ExternalEdges = value;
        //    }
        //}

        //public int PointColumns
        //{
        //    get
        //    {
        //        return m_Columns;
        //    }
        //    set
        //    {
        //        m_Columns = value;
        //    }
        //}

        //public int Degree
        //{
        //    get
        //    {
        //        return m_Order - 1;
        //    }
        //    set
        //    {
        //        m_Order = value + 1;
        //    }
        //}

        //public int Order
        //{
        //    get
        //    {
        //        return m_Order;
        //    }
        //}


        //public Surface()
        //{
        //    m_Dimensions = 3;
        //    m_ExternalEdges = new Group<Curve>();
        //}

        //internal virtual Point Max
        //{
        //    get
        //    {
        //        if (m_MaxMin == null)
        //        {
        //            m_MaxMin = CollectionUtils.MaxMinIndices(m_ControlPoints, m_Dimensions + 1);
        //        }
        //        return new Point(m_ControlPoints[m_MaxMin[0]], m_ControlPoints[m_MaxMin[1]], m_ControlPoints[m_MaxMin[2]]);
        //    }
        //}

        //internal virtual Point Min
        //{
        //    get
        //    {
        //        if (m_MaxMin == null)
        //        {
        //            m_MaxMin = CollectionUtils.MaxMinIndices(m_ControlPoints, m_Dimensions + 1);
        //        }
        //        return new Point(m_ControlPoints[m_MaxMin[3]], m_ControlPoints[m_MaxMin[4]], m_ControlPoints[m_MaxMin[5]]);
        //    }
        //}


        //public override void Update()
        //{
        //    m_MaxMin = null;
        //}

        //public Surface DuplicateSurface()
        //{
        //    Surface s = (Surface)Activator.CreateInstance(this.GetType(), true);
        //    s.m_ControlPoints =  CollectionUtils.Copy<double>(m_ControlPoints);
        //    s.m_Columns = m_Columns;
        //    s.m_Dimensions = m_Dimensions;
        //    s.m_Weights = CollectionUtils.Copy<double>(m_Weights);
        //    s.m_UKnots = CollectionUtils.Copy<double>(m_UKnots);
        //    s.m_VKnots = CollectionUtils.Copy<double>(m_VKnots);
        //    s.m_Order = m_Order;
        //    s.m_ExternalEdges = m_ExternalEdges.DuplicateGroup();

        //    return s;
        //}



        //#region Static Functions

        //public static Surface CreateFromPoints(Point p1, Point p2, Point p3, Point p4)
        //{
        //    Surface s = new Surface();
        //    //s.CreateFrom4Points(p1, p2, p3, p4);
        //    return s;
        //}   
        //#endregion
    }
}