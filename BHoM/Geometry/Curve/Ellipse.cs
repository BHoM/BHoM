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

        public Vector Axis1 { get; set; } = new Vector();

        public Vector Axis2 { get; set; } = new Vector();

        public double Radius1 { get; set; } = 0;

        public double Radius2 { get; set; } = 0;

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Ellipse() { }

        /***************************************************/

        public Ellipse(Point centre, Vector axis1, Vector axis2, double radius1, double radius2)
        {
            Centre = centre;
            Axis1 = axis1;
            Axis2 = axis2;
            Radius1 = radius1;
            Radius2 = radius2;
        }
    }
}