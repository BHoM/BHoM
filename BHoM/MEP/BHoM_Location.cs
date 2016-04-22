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

    }

    public class LocationPoint : Location
    {
        private Point pPoint;

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
    }

    public class LocationLine: Location
    {
        private Line pLine;

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
    }
}
