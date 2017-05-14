using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHoM.Base;
using BHoM.Geometry;

namespace BHoM.Acoustic
{
    public class Ray
    {

        public Polyline Path { get; set; }
        public string Source { get; set; }
        public string Target { get; set; }
        public List<string> BouncingPattern { get; set; }

        #region Constructor

        public Ray(Polyline path = null, string source = null, string target = null, List<string> bouncingPattern = null)
        {
            Path = path;
            Source = source;
            Target = target;
            BouncingPattern = bouncingPattern;
        }

        #endregion

        #region Properties

        public double Length()
        {
            return Path.Length;         // Remember to fix Polyline.Length method
        }

        public double ToF()             // Time of Flight
        {
            return Path.Length / 343;
        }

        public int Order()
        {
            return BouncingPattern.Count;
        }

        public Point Origin()
        {
            return Path.EndPoint;
        }
        #endregion
    }
}
