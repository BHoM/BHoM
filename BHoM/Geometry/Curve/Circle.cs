using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Geometry
{
    [Serializable] public class Circle : ICurve
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Point Centre { get; set; } = new Point();

        public Vector Normal { get; set; } = new Vector(0, 0, 1);

        public double Radius { get; set; } = 0;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Circle() { }

        /***************************************************/

        public Circle(Point centre, double radius = 0)
        {
            Centre = centre;
            Radius = radius;
        }

        /***************************************************/

        public Circle(Point centre, Vector normal, double radius = 0)
        {
            Centre = centre;
            Normal = normal;
            Radius = radius;
        }
    }
}
        
