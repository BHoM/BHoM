using BH.oM.Geometry;
using BH.oM.Base;

namespace BH.oM.Environmental.Elements
{
    public class Panel : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public string Type { get; set; } = "";

        public ISurface Surface { get; set; } = null;


        /***************************************************/
    }
}
