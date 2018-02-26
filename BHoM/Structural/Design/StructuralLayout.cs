using System.Collections.Generic;
using BH.oM.Base;
using BH.oM.Structural.Elements;

namespace BH.oM.Structural.Design
{
    public class StructuralLayout : BHoMObject, IDesignable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<Bar> AnalyticBars { get; set; } = new List<Bar>();

        public List<Span> MajorAxisSpans { get; set; } = new List<Span>();

        public List<Span> MinorAxisSpans { get; set; } = new List<Span>();

        public List<Span> LateralTorsionalSpans { get; set; } = new List<Span>();

        public BarStructuralUsage StructuralUsage { get; set; } = new BarStructuralUsage();


        /***************************************************/
    }
}

