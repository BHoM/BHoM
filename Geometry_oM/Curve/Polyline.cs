using System.Collections.Generic;

namespace BH.oM.Geometry
{
    public class Polyline : ICurve
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<Point> ControlPoints { get; set; } = new List<Point>();


        /***************************************************/
    }
}
        

