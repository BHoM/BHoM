using System.Collections.Generic;

namespace BH.oM.Geometry
{
    [Serializable]
    public class Polyline : ICurve
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<Point> ControlPoints { get; set; } = new List<Point>();


        /***************************************************/
    }
}


