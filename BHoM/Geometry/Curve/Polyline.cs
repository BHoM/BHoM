using System.Collections.Generic;
using System.Linq;

namespace BH.oM.Geometry
{
    public class Polyline : ICurve
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<Point> ControlPoints { get; set; } = new List<Point>();


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Polyline() { }

        /***************************************************/

        public Polyline(IEnumerable<Point> points)
        {
            ControlPoints = points.ToList();
        }
    }
}
        

