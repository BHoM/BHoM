using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Geometry
{
    public partial class Loft : ISurface
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<ICurve> Curves { get; set; } = new List<ICurve>();


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Loft() { }

        /***************************************************/

        public Loft(IEnumerable<ICurve> curves)
        {
            Curves = curves.ToList();
        }
    }
}


