using System.Collections.Generic;

namespace BH.oM.Structure.Design
{
    public class Span : Base.BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<int> BarIndices { get; set; } = new List<int>();

        public double EffectiveLength { get; set; } = 0.0;


        /***************************************************/
    }
}
