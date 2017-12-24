using System.Collections.Generic;
using System.Linq;

namespace BH.oM.Geometry
{
    public class PolySurface : ISurface
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<ISurface> Surfaces { get; set; } = new List<ISurface>();


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public PolySurface() { }

        /***************************************************/

        public PolySurface(IEnumerable<ISurface> surfaces)
        {
            Surfaces = surfaces.ToList();
        }

    }
} 

