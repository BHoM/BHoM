using System.Collections.Generic;

namespace BH.oM.Structural.Design
{

    public class Span : BH.oM.Base.BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<int> BarIndices { get; set; } = new List<int>();

        public double EffectiveLength { get; set; }


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Span() { }

        /***************************************************/

        public Span(StructuralLayout elem, double effectiveLength = 0)
        {
            for (int i = 0; i < elem.AnalyticBars.Count; i++)
                BarIndices.Add(i);

            EffectiveLength = effectiveLength;
        }



    }
}
