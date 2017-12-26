using System.Collections.Generic;

namespace BH.oM.Geometry
{
    [Serializable]
    public class PolySurface : ISurface
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<ISurface> Surfaces { get; set; } = new List<ISurface>();


        /***************************************************/
    }
}

