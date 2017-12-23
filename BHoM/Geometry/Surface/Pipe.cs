using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Geometry
{
    [Serializable] public class Pipe : ISurface
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public ICurve Centreline { get; set; } = new Line();

        public double Radius { get; set; } = 0;

        public bool Capped { get; set; } = true;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Pipe() { }

        /***************************************************/

        public Pipe(ICurve centreline, double radius, bool capped = true)
        {
            Centreline = centreline;
            Radius = radius;
            Capped = capped;
        }

    }
}

