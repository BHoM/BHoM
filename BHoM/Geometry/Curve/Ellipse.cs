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

        public Vector Vector1 { get; set; } = new Vector();

        public Vector Vector2 { get; set; } = new Vector();

        public double Radius1 { get; set; } = 0;

        public double Radius2 { get; set; } = 0;

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Ellipse() { }

        /***************************************************/

        public Ellipse(Point centre, Vector vector1 = null, Vector vector2 = null, double radius1 = 0, double radius2 = 0)
        {
            Centre = centre;
            Vector1 = vector1;
            Vector2 = vector2;
            Radius1 = radius1;
            Radius2 = radius2;
        }
    }
}