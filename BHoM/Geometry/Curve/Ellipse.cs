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

        public Plane Plane { get; set; } = Plane.XY;

        public double Radius1 { get; set; } = 0;

        public double Radius2 { get; set; } = 0;

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Ellipse() { }

        /***************************************************/

        public Ellipse(Plane plane, double radius1 = 0, double radius2 = 0)
        {
            Plane = plane;
            Radius1 = radius1;
            Radius2 = radius2;
        }
    }
}