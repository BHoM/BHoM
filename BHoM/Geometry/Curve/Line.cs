using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Base;


namespace BH.oM.Geometry
{
    /// <summary>
    /// BHoM Line object
    /// </summary>
    public class Line : ICurve
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Point Start { get; set; } = new Point();

        public Point End { get; set; } = new Point();

        public bool Infinite { get; set; } = false;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Line() { }

        /***************************************************/

        public Line(Point start, Point end)
        {
            Start = start;
            End = end;
        }

        /***************************************************/

        public Line(Point start, Vector direction)
        {
            Start = start;
            End = start + direction;
            Infinite = true;
        }

    }
}











        //public Vector GetDirection()
        //{
        //    return new Vector(End.X - Start.X, End.Y - Start.Y, End.Z - Start.Z).GetNormalised();
        //}


        ///***************************************************/
        ///**** IBHoMGeometry Interface                   ****/
        ///***************************************************/

        //public GeometryType GetGeometryType()
        //{
        //    return GeometryType.Line;
        //}

        ///***************************************************/

        //public BoundingBox GetBounds()
        //{
        //    Point min = new Point(Math.Min(End.X, Start.X), Math.Min(End.Y, Start.Y), Math.Min(End.Z, Start.Z));
        //    Point max = new Point(Math.Max(End.X, Start.X), Math.Max(End.Y, Start.Y), Math.Max(End.Z, Start.Z));

        //    return new BoundingBox(min, max);
        //}

        ///***************************************************/

        //public object Clone()
        //{
        //    return new Line(Start.Clone() as Point, End.Clone() as Point);
        //}

        ///***************************************************/

        //public IBHoMGeometry GetTranslated(Vector t)
        //{
        //    return new Line(Start + t, End + t);
        //}


        ///***************************************************/
        ///**** ICurve Interface                          ****/
        ///***************************************************/

        //public Point GetStart()
        //{
        //    return Start;
        //}

        ///***************************************************/

        //public Point GetEnd()
        //{
        //    return End;
        //}

        ///***************************************************/

        //public Vector GetStartDir()
        //{
        //    return new Vector(End.X - Start.X, End.Y - Start.Y, End.Z - Start.Z).GetNormalised();
        //}

        ///***************************************************/

        //public Vector GetEndDir()
        //{
        //    return new Vector(End.X - Start.X, End.Y - Start.Y, End.Z - Start.Z).GetNormalised();
        //}

        ///***************************************************/

        //public bool IsClosed()
        //{
        //    return Start == End;
        //}
