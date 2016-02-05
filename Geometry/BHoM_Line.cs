using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Geometry
{
    [Serializable]
    public class Line
    {
        public Point StartPoint { get; private set; }
        public Point EndPoint { get; private set; }


        //Basic line type geometry object. 
        public Line(Point startpoint, Point endpoint)
        {
            this.StartPoint = startpoint;
            this.EndPoint = endpoint;
        }

        public Line(double start_x, double start_y, double start_z, double end_x, double end_y, double end_z)
        {
            this.StartPoint = new Point(start_x, start_y, start_z);
            this.EndPoint = new Point(end_x, end_y, end_z);
        }


    }


}