using BHoM.Geometry;
using BHoM.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural
{
    public class Grid : BHoMObject
    {
        public Grid()
        {

        }

        public Grid(Line line)
        {
            Line = line;
            Plane = new Plane(line.StartPoint, Vector.CrossProduct(line.EndPoint - line.StartPoint, Vector.ZAxis()));
        }

        public Grid(string name, Point origin, Vector direction)
        {
            Plane = new Plane(origin, Vector.CrossProduct(direction, Vector.ZAxis()));
            Line = new Line(origin, origin + direction * 20);
        }

        public Plane Plane
        {
            get; set;
        }

        public Curve Line
        {
            get; set;
        }

    }
}
