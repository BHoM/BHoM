using System;

using System.Collections.Generic;
using BH.oM.Base;


namespace BH.oM.Geometry
{
    /// <summary>
    /// Arc object
    /// </summary>
    public class Arc : ICurve
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Point Start { get; set; } = new Point();

        public Point End { get; set; } = new Point();

        public Point Centre { get; set; } = new Point();


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Arc() { }

        /***************************************************/

        public Arc(Point start, Point end, Point centre)
        {
            Start = start;
            End = end;
            Centre = centre;
        }

        /***************************************************/
        /**** Local Methods                             ****/
        /***************************************************/



        /***************************************************/
        /**** IBHoMGeometry Interface                   ****/
        /***************************************************/

        public GeometryType GetGeometryType()
        {
            return GeometryType.Arc;
        }

        /***************************************************/

        public BoundingBox GetBounds()
        {
            throw new NotImplementedException(); //TODO: implement Bounds for Arc.
        }

        /***************************************************/

        public object Clone()
        {
            return new Arc(Start.Clone() as Point, End.Clone() as Point, Centre.Clone() as Point);
        }

        /***************************************************/

        public IBHoMGeometry GetTranslated(Vector t)
        {
            return new Arc(Start+t, End+t, Centre+t);
        }


        /***************************************************/
        /**** ICurve Interface                          ****/
        /***************************************************/

        public Point GetStart()
        {
            return Start;
        }

        /***************************************************/

        public Point GetEnd()
        {
            return End;
        }

        /***************************************************/

        public Vector GetStartDir()
        {
            throw new NotImplementedException(); //TODO: get start dir of arc
        }

        /***************************************************/

        public Vector GetEndDir()
        {
            throw new NotImplementedException(); //TODO: get end dir of arc
        }

        /***************************************************/

        public bool IsClosed()
        {
            return Start == End;
        }





        ///// <summary>
        ///// Arc from 3 points
        ///// </summary>
        ///// <param name="startpoint"></param>
        ///// <param name="endpoint"></param>
        ///// <param name="internalpoint"></param>
        //public Arc(Point startpoint, Point endpoint, Point internalpoint)
        //{
        //    m_ControlPoints = new double[12];
        //    Array.Copy(startpoint, m_ControlPoints, 4);
        //    Array.Copy(endpoint, 0, m_ControlPoints, 4 * 2, 4);
        //    Array.Copy(internalpoint, 0, m_ControlPoints, 4, 4);
        //    m_Dimensions = 3;
        //}



    }
}