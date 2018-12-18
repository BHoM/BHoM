using System.Collections.Generic;

namespace BH.oM.Geometry
{
    public class NurbsCurve : ICurve
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<Point> ControlPoints { get; set; } = new List<Point>();

        public List<double> Weights { get; set; } = new List<double>();

        public List<double> Knots { get; set; } = new List<double>();
        
        /***************************************************/
    }
}
