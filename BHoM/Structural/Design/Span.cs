using System.Collections.Generic;

namespace BH.oM.Structural.Design
{
    public class Span : Base.BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<int> BarIndices { get; set; } = new List<int>();

        public double EffectiveLength { get; set; }


        /***************************************************/
    }
}
