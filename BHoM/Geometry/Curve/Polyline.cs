using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Base;

namespace BH.oM.Geometry
{
    [Serializable] public class Polyline : ICurve
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
        

