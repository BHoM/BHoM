using System.Collections.Generic;

namespace BH.oM.Geometry
{
    public class NurbSurface : ISurface
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<Point> ControlPoints { get; set; } = new List<Point>();

        public List<double> Weights { get; set; } = new List<double>();

        public List<double> UKnots { get; set; } = new List<double>();

        public List<double> VKnots { get; set; } = new List<double>();


        /***************************************************/
    }
}

