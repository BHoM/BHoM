using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Geometry
{
    [Serializable] public class PolySurface : ISurface
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

