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

    public class LocationLine: Location
    {
        private Line pLine;

        public LocationLine(Line Line)
        {
            pLine = Line;
        }

        public Line Line
        {
            get
            {
                return pLine;
            }
            set
            {
                pLine = value;
            }
        }

        public override string JSON()
        {
            string aResult = "{";
            aResult += string.Format("\"{0}\": \"{1}\", ", "primitive", "line");
            Point aPoint = pLine.StartPoint;
            string aPointString = string.Format("[{0},{1},{2}]", aPoint.X, aPoint.Y, aPoint.Z);
            aResult += string.Format("\"{0}\": {1},", "start", aPointString);
            aPoint = pLine.EndPoint;
            aPointString = string.Format("[{0},{1},{2}]", aPoint.X, aPoint.Y, aPoint.Z);
            aResult += string.Format("\"{0}\": {1}", "end", aPointString);
            aResult += "}";
            return aResult;
        }
    }
}
