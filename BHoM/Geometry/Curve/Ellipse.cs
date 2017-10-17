using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Geometry
{
    public class Ellipse : ICurve
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Point Centre { get; set; } = new Point();

        public Vector Normal { get; set; } = new Vector(0, 0, 1);

        public double XRadius { get; set; } = 0;

        public double YRadius { get; set; } = 0;

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Ellipse() { }

        /***************************************************/

        public Ellipse(Point centre, double xRadius = 0, double yRadius = 0)
        {
            Centre = centre;
            XRadius = xRadius;
            YRadius = yRadius;
        }

        /***************************************************/

        public Ellipse(Point centre, Vector normal, double xRadius = 0, double yRadius = 0)
        {
            Centre = centre;
            Normal = normal;
            XRadius = xRadius;
            YRadius = yRadius;
        }
    }
}

