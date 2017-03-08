using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural.Design
{
    public enum SpanDirection
    {
        MajorAxis,
        MinorAxis,
        LateralTorsional,
        MinorAndLateralTorsional,
        All
    }


    public class Span : BHoM.Base.BHoMObject
    {

        public Span()
        {
            BarIndices = new List<int>();
        }
        public List<int> BarIndices { get; set; }
        public double EffectiveLength { get; set; }

        public static Span CreateDefaultSpan(StructuralLayout elem)
        {
            Span span = new Span();
            for (int i = 0; i < elem.AnalyticBars.Count; i++)
                span.BarIndices.Add(i);

            span.EffectiveLength = elem.Length;

            return span;
        }
    }
}
