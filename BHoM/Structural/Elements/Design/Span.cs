using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural.Elements
{
    public enum SpanDirection
    {
        MajorAxis,
        MinorAxis,
        LateralTorsional,
        All
    }


    public class Span
    {

        public Span()
        {
            BarIndecies = new List<int>();
        }
        public List<int> BarIndecies { get; set; }
        public double EffectiveLength { get; set; }

        public static Span CreateDefaultSpan(DesignElement elem)
        {
            Span span = new Span();
            for (int i = 0; i < elem.AnalyticBars.Count; i++)
                span.BarIndecies.Add(i);

            span.EffectiveLength = elem.Length;

            return span;
        }
    }
}
