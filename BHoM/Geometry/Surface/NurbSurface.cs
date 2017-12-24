using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Geometry
{
    [Serializable]
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
        /**** Constructors                              ****/
        /***************************************************/

        public NurbSurface() { }

        /***************************************************/

        public NurbSurface(IEnumerable<Point> controlPoints, int degree = 3)
        {
            int n = controlPoints.Count();
            int d = degree - 1;
            ControlPoints = controlPoints.ToList();
            Weights = Enumerable.Repeat(1.0, n).ToList();
            //Knots = Enumerable.Repeat(0, d).Concat(Enumerable.Range(0, n - d).Concat(Enumerable.Repeat(n - d - 1, d))).Select(x => (double)x).ToList();
            //TODO: Calculate the U-knots and V-knots
        }

        /***************************************************/

        public NurbSurface(IEnumerable<Point> controlPoints, IEnumerable<double> weights, int degree = 3)
        {
            int n = controlPoints.Count();
            int d = degree - 1;
            ControlPoints = controlPoints.ToList();
            Weights = weights.ToList();
            //Knots = Enumerable.Repeat(0, d).Concat(Enumerable.Range(0, n - d).Concat(Enumerable.Repeat(n - d - 1, d))).Select(x => (double)x).ToList();
            //TODO: Calculate the U-knots and V-knots
        }

        /***************************************************/

        public NurbSurface(IEnumerable<Point> controlPoints, IEnumerable<double> weights, IEnumerable<double> uKnots, IEnumerable<double> vKnots)
        {
            ControlPoints = controlPoints.ToList();
            Weights = weights.ToList();
            UKnots = uKnots.ToList();
            VKnots = vKnots.ToList();
        }


        /***************************************************/
        /**** Local Optimisation Methods                ****/
        /***************************************************/

        public int GetDegree()
        {
            return 1 + UKnots.Count + VKnots.Count - ControlPoints.Count; //TODO: Calculate degree properly
        }

    }
}

