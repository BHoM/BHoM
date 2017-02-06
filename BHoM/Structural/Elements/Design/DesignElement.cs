using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHoM.Base;
using BHoM.Structural.Properties;
using BHoM.Geometry;

namespace BHoM.Structural.Elements
{
    public class DesignElement : BHoMObject
    {

        /******************************************/
        /************** Fields ********************/
        /******************************************/

        protected List<Bar> m_bars;

        //Spans used for buckling checks
        protected List<Span> m_majorAxisSpans;
        protected List<Span> m_minorAxisSpans;
        protected List<Span> m_LateralTorsionalSpans;

        /******************************************/
        /************** Constructors **************/
        /******************************************/

        public DesignElement()
        {
            m_bars = new List<Bar>();
            IsContinuous = false;
        }

        public DesignElement(Bar bar) :this()
        {
            AddBar(bar, false);
        }

        public DesignElement(IEnumerable<Bar> bars):this()
        {
            AddBars(bars);
        }

        /******************************************/
        /************** Properties ****************/
        /******************************************/


        public List<Bar> AnalyticBars
        {
            get
            {
                return m_bars;
            }
            set
            {
                m_bars = value;
                SortBars();
            }

        }

        public void AddBar(Bar bar, bool sort = true)
        {
            m_bars.Add(bar);

            if(sort)
                SortBars();
        }

        public void AddBars(IEnumerable<Bar> bars, bool sort = true)
        {
            foreach (Bar bar in bars)
            {
                m_bars.Add(bar);
            }

            if(sort)
                SortBars();
        }

        public List<SectionProperty> SectionProperty
        {
            get
            {
                return AnalyticBars.Select(x => x.SectionProperty).ToList();
            }
        }

        public BarStructuralUsage StructuralUsage
        {
            get;
            set;
        }
       
        /// <summary>
        /// True if all the analytic bars can be connected to one single continuous element
        /// </summary>
        public bool IsContinuous
        {
            get;
            private set;
        }

        public Node StartNode
        {
            get
            {
                if (m_bars.Count > 0)
                    return m_bars.First().StartNode;
                else
                    return new Node();
            }
        }

        public Node EndNode
        {
            get
            {
                if (m_bars.Count > 0)
                    return m_bars.Last().EndNode;
                else
                    return new Node();
            }
        }

        public Point StartPoint
        {
            get
            {
                return StartNode.Point;
            }
        }

        public Point EndPoint
        {
            get
            {
                return EndNode.Point;
            }
        }

        public double Length
        {
            get
            {
                return m_bars.Sum(x => x.Length);
            }
        }

        //Spans used for buckling checks
        public List<Span> MajorAxisSpan
        {
            set
            {
                m_majorAxisSpans = value;
            }
            get
            {
                if (m_majorAxisSpans == null || m_majorAxisSpans.Count < 1)
                {
                    List<Span> spans = new List<Span>();
                    spans.Add(Span.CreateDefaultSpan(this));
                    return spans;
                }
                return m_majorAxisSpans;
            }

        }

        public List<Span> MinorAxisSpan
        {
            set
            {
                m_majorAxisSpans = value;
            }
            get
            {
                if (m_minorAxisSpans == null || m_minorAxisSpans.Count < 1)
                {
                    List<Span> spans = new List<Span>();
                    spans.Add(Span.CreateDefaultSpan(this));
                    return spans;
                }
                return m_minorAxisSpans;
            }

        }
        public List<Span> LateralTorsionalSpan
        {
            set
            {
                m_majorAxisSpans = value;
            }
            get
            {
                if (m_LateralTorsionalSpans == null || m_LateralTorsionalSpans.Count < 1)
                {
                    List<Span> spans = new List<Span>();
                    spans.Add(Span.CreateDefaultSpan(this));
                    return spans;
                }
                return m_LateralTorsionalSpans;
            }

        }

        /******************************************/
        /************** Methods *******************/
        /******************************************/

        public void GenerateDefaultSpans()
        {
            m_majorAxisSpans = new List<Span>();
            m_majorAxisSpans.Add(Span.CreateDefaultSpan(this));

            m_minorAxisSpans = new List<Span>();
            m_minorAxisSpans.Add(Span.CreateDefaultSpan(this));

            m_LateralTorsionalSpans = new List<Span>();
            m_LateralTorsionalSpans.Add(Span.CreateDefaultSpan(this));
        }

        public void GenerateSpans(IEnumerable<double> suportPositions, SpanDirection direction, bool positionAsLength = false)
        {
            List<Span> spans = new List<Span>();

            int highestAddedBarIndex = 0;

            double fullLength = this.Length;
            double addedLength = 0;

            foreach (double pos in suportPositions)
            {
                Span span = new Span();
                double length = positionAsLength ? pos : pos * fullLength;

                double effLength = 0;

                for (int i = highestAddedBarIndex; i < m_bars.Count; i++)
                {
                    double barLength = m_bars[i].Length;

                    if (barLength + addedLength <= length)
                    {
                        span.BarIndecies.Add(i);
                        addedLength += barLength;
                        effLength += barLength;
                        highestAddedBarIndex++;
                    }
                    else
                        break;
                }

                span.EffectiveLength = effLength;

                spans.Add(span);
            }

            switch (direction)
            {
                case SpanDirection.MajorAxis:
                    m_majorAxisSpans = spans;
                    break;
                case SpanDirection.MinorAxis:
                    m_minorAxisSpans = spans;
                    break;
                case SpanDirection.LateralTorsional:
                    m_LateralTorsionalSpans = spans;
                    break;
                case SpanDirection.All:
                    m_majorAxisSpans = spans;
                    m_minorAxisSpans = spans;
                    m_LateralTorsionalSpans = spans;
                    break;
            }

        }


        public override GeometryBase GetGeometry()
        {
            List<Curve> crvs = new List<Curve>();
            m_bars.ForEach(x => crvs.Add(x.Line));
            return new PolyCurve(crvs);           
        }

        /// <summary>
        /// Makes sure that the bars are aligned.
        /// </summary>
        public void SortBars()
        {
            int count = m_bars.Count;

            if (count < 2)
                return;

            List<Bar> temp = new List<Bar>();

            temp.Add(m_bars[0]);
            m_bars.RemoveAt(0);

            int n = 0;
            //TODO: Tolerance for checking if points are the same now taken as a fraction of the first analytic bar element length.
            //Is this the right approach?
            double tol = temp[0].Length / 10000;

            int bailOut = (int)Math.Pow(count, 2);
            int counter = 0;

            Point stPt = temp[0].StartPoint;
            Point endPt = temp[0].EndPoint;

            IsContinuous = true;

            while (m_bars.Count > 0)
            {

                Bar bar = m_bars[n];
                int j = -1;

                if (bar.StartPoint.SquareDistanceTo(stPt) < tol)
                {
                    bar.FlipNodes();
                    stPt = bar.StartPoint;
                    j = 0;
                }
                else if (bar.EndPoint.SquareDistanceTo(stPt) < tol)
                {
                    stPt = bar.StartPoint;
                    j = 0;
                }
                else if (bar.StartPoint.SquareDistanceTo(endPt) < tol)
                {
                    endPt = bar.EndPoint;
                    j = temp.Count;
                }
                else if (bar.EndPoint.SquareDistanceTo(endPt) < tol)
                {
                    bar.FlipNodes();
                    endPt = bar.EndPoint;
                    j = temp.Count;
                }


                if (j >= 0)
                {
                    temp.Insert(j, bar);
                    m_bars.RemoveAt(n);
                }
                else
                    n++;

                n = n == m_bars.Count ? 0 : n;

                counter++;

                //No possible ordering found. Add bars not fitted to the end of the list
                if (counter > bailOut)
                {
                    temp.AddRange(m_bars);
                    IsContinuous = false;
                    break;
                }
            }


            m_bars = temp;
        }
    }
}
