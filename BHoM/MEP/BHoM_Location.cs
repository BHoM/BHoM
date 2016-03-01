using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHoM.Geometry;

namespace BHoM.MEP
{
    public abstract class Location
    {
        public abstract string JSON();
    }

    public class LocationPoint : Location
    {
        private Point pPoint;

        public LocationPoint(Point Point)
        {
            pPoint = Point;
        }

        public Point Point
        {
            get
            {
                return pPoint;
            }
            set
            {
                pPoint = value;
            }
        }

        public override string JSON()
        {
            return string.Format("[{0},{1},{2}],", pPoint.X, pPoint.Y, pPoint.Z);
        }
    }

    public abstract class LocationCurve : Location
    {
        private Curve pCurve;

        public Point StartPoint
        {
            get
            {
                return pCurve.StartPoint;
            }
            set
            {
                pCurve.StartPoint = value;
            }
        }

        public Point EndPoint
        {
            get
            {
                return pCurve.EndPoint;
            }
            set
            {
                pCurve.EndPoint = value;
            }
        }

        public Curve Curve
        {
            get
            {
                return pCurve;
            }
            set
            {
                pCurve = value;
            }
        }
    }

    public class LocationLine: LocationCurve
    {

        public LocationLine(Line Line)
        {
            this.Curve = Line;
        }

        public Line Line
        {
            get
            {
                return Curve as Line;
            }
            set
            {
                Curve = value;
            }
        }

        public override string JSON()
        {
            string aResult = "{";
            aResult += string.Format("\"{0}\": \"{1}\", ", "primitive", "line");
            Point aPoint = Curve.StartPoint;
            string aPointString = string.Format("[{0},{1},{2}]", aPoint.X, aPoint.Y, aPoint.Z);
            aResult += string.Format("\"{0}\": {1},", "start", aPointString);
            aPoint = Curve.EndPoint;
            aPointString = string.Format("[{0},{1},{2}]", aPoint.X, aPoint.Y, aPoint.Z);
            aResult += string.Format("\"{0}\": {1}", "end", aPointString);
            aResult += "}";
            return aResult;
        }
    }

    public class LocationArc : LocationCurve
    {
        public LocationArc(Arc Arc)
        {
            this.Curve = Arc;
        }

        public Arc Arc
        {
            get
            {
                return this.Curve as Arc;
            }
        }

        public override string JSON()
        {
            Arc aArc = this.Arc;
            string aResult = "{";
            aResult += string.Format("\"{0}\": \"{1}\", ", "primitive", "arc");
            Point aPoint = aArc.StartPoint;
            string aPointString = string.Format("[{0},{1},{2}]", aPoint.X, aPoint.Y, aPoint.Z);
            aResult += string.Format("\"{0}\": {1},", "start", aPointString);
            aPoint = aArc.Center;
            aPointString = string.Format("[{0},{1},{2}]", aPoint.X, aPoint.Y, aPoint.Z);
            aResult += string.Format("\"{0}\": {1},", "middle", aPointString);
            aPoint = aArc.EndPoint;
            aPointString = string.Format("[{0},{1},{2}]", aPoint.X, aPoint.Y, aPoint.Z);
            aResult += string.Format("\"{0}\": {1}", "end", aPointString);
            aResult += "}";
            return aResult;
        }
    }
}
