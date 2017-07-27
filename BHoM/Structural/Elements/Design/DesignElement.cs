﻿using System;
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

        public List<SectionProperty> SectionProperties
        {
            get
            {
                return AnalyticBars.Select(x => x.SectionProperty).ToList();
            }
        }

        public SectionProperty SectionProperty
        {
            get
            {
                return AnalyticBars.First().SectionProperty;
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
                    m_majorAxisSpans = spans;
                }
                return m_majorAxisSpans;
            }

        }

        public List<Span> MinorAxisSpan
        {
            set
            {
                m_minorAxisSpans = value;
            }
            get
            {
                if (m_minorAxisSpans == null || m_minorAxisSpans.Count < 1)
                {
                    List<Span> spans = new List<Span>();
                    spans.Add(Span.CreateDefaultSpan(this));
                    m_minorAxisSpans = spans;
                }
                return m_minorAxisSpans;
            }
        }

        public List<Span> LateralTorsionalSpan
        {
            set
            {
                m_LateralTorsionalSpans = value;
            }
            get
            {
                if (m_LateralTorsionalSpans == null || m_LateralTorsionalSpans.Count < 1)
                {
                    List<Span> spans = new List<Span>();
                    spans.Add(Span.CreateDefaultSpan(this));
                    m_LateralTorsionalSpans = spans;
                }
                return m_LateralTorsionalSpans;
            }
        }

        /******************************************/
        /************** Methods *******************/
        /******************************************/

        /// <summary>
        /// Sets the section property for all the analytical bars
        /// </summary>
        public void SetSectionProperty(SectionProperty property)
        {
            if (m_bars == null)
                return;

            for (int i = 0; i < m_bars.Count; i++)
            {
                m_bars[i].SectionProperty = property;
            }
        }
        public void GenerateDefaultSpans()
        {
            m_majorAxisSpans = new List<Span>();
            m_majorAxisSpans.Add(Span.CreateDefaultSpan(this));

            m_minorAxisSpans = new List<Span>();
            m_minorAxisSpans.Add(Span.CreateDefaultSpan(this));

            m_LateralTorsionalSpans = new List<Span>();
            m_LateralTorsionalSpans.Add(Span.CreateDefaultSpan(this));
        }

        public List<Span> SetEffectiveLength(double length, SpanDirection direction = SpanDirection.All)
        {
            Span span = Span.CreateDefaultSpan(this);
            span.EffectiveLength = length;
            List<Span> spans = new List<Span>();
            spans.Add(span);
            SetSpans(spans, direction);
            return spans;
        }
        
        public List<Span> GenerateSpans(List<double> suportPositions, SpanDirection direction = SpanDirection.All, bool positionAsLength = false)
        {

            //Assumes that suport positions are placed on analytic bar nodes

            List<Span> spans = new List<Span>();

            int highestAddedBarIndex = 0;

            double fullLength = this.Length;
            double addedLength = 0;

            suportPositions = suportPositions.OrderBy(x => x).ToList();

            double last = positionAsLength ? suportPositions.Last() : suportPositions.Last() * fullLength;

            bool unsuportedEnd;
            if (unsuportedEnd = last < fullLength)
                suportPositions.Add(positionAsLength ? fullLength : 1);

            foreach (double pos in suportPositions)
            {
                if (pos == 0)
                    continue;

                Span span = new Span();
                double length = positionAsLength ? pos : pos * fullLength;

                double effLength = 0;

                for (int i = highestAddedBarIndex; i < m_bars.Count; i++)
                {
                    double barLength = m_bars[i].Length;

                    if (barLength + addedLength <= length)
                    {
                        span.BarIndices.Add(i);
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

            //if unsuported at start, double the effective length
            if (suportPositions.First() > 0)
                spans[0].EffectiveLength *= 2;

            //if unsupported at end, double the effective length
            if (unsuportedEnd)
                spans[spans.Count - 1].EffectiveLength *= 2;

            SetSpans(spans, direction);
            return spans;
        }

        public List<Span> GenerateSpans(List<int> supportedNodes, SpanDirection direction = SpanDirection.All)
        {
            if (supportedNodes.Count < 1)
                return null;

            supportedNodes.Sort();

            double firstSpanFactor = 2;
            double lastSpanFactor = 1;

            if (supportedNodes[0] == 0)
            {
                firstSpanFactor = 1;
                supportedNodes.RemoveAt(0);
            }
            if (supportedNodes.Last() != AnalyticBars.Count)
            {
                lastSpanFactor = 2;
                supportedNodes.Add(AnalyticBars.Count);
            }

            int startBarIndex = 0;

            List<Span> spans = new List<Span>();

            for (int i = 0; i < supportedNodes.Count; i++)
            {
                List<int> barIndecies = new List<int>();
                for (int j = startBarIndex; j < Math.Min(supportedNodes[i], AnalyticBars.Count); j++)
                {
                    barIndecies.Add(j);
                }

                if (barIndecies.Count > 0)
                {
                    Span span = new Span();
                    span.BarIndices = barIndecies;
                    span.EffectiveLength = barIndecies.Select(x => AnalyticBars[x].Length).Sum();
                    spans.Add(span);
                }
                startBarIndex = supportedNodes[i];
            }

            if (spans.Count < 1)
                return null;

            spans[0].EffectiveLength *= firstSpanFactor;
            spans[spans.Count - 1].EffectiveLength *= lastSpanFactor;

            SetSpans(spans, direction);
            return spans;
        }

        public void SetSpans(List<Span> spans, SpanDirection direction)
        {
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
                case SpanDirection.MinorAndLateralTorsional:
                    m_minorAxisSpans = spans;
                    m_LateralTorsionalSpans = spans;
                    break;
                case SpanDirection.All:
                    m_majorAxisSpans = spans;
                    m_minorAxisSpans = spans;
                    m_LateralTorsionalSpans = spans;
                    break;
            }
        }

        public double GetBarPosition(Span span, int barIdx)
        {
            double x = 0;
            for (int i = 0; i < span.BarIndices.Count; i++)
            {
                if (span.BarIndices[i] == barIdx) break;
                x += m_bars[span.BarIndices[i]].Length;
            }
            return x;
        }

        public double GetBarPosition(int barIdx, SpanDirection direction, out double spanLength)
        {
            spanLength = 0;
            foreach (Span span in GetSpans(direction))
            {
                if (span.BarIndices.Contains(barIdx))
                {
                    for (int i = 0; i < span.BarIndices.Count; i++)
                    {
                        spanLength += m_bars[span.BarIndices[i]].Length;
                    }
                    return GetBarPosition(span, barIdx);
                }
            }
            return 0;
        }

        public List<Span> GetSpans(SpanDirection direction)
        {
            switch (direction)
            {
                case SpanDirection.MajorAxis:
                    return MajorAxisSpan;
                case SpanDirection.MinorAxis:
                    return MinorAxisSpan;
                case SpanDirection.LateralTorsional:
                    return LateralTorsionalSpan;
                default: 
                    return MajorAxisSpan;
            }           
        }

        public Span GetSpan(int barIdx, SpanDirection direction)
        {
            switch (direction)
            {
                case SpanDirection.MajorAxis:
                    return MajorAxisSpan.Where(x => x.BarIndices.Contains(barIdx)).First();
                case SpanDirection.MinorAxis:
                    return MinorAxisSpan.Where(x => x.BarIndices.Contains(barIdx)).First();
                case SpanDirection.LateralTorsional:
                    return LateralTorsionalSpan.Where(x => x.BarIndices.Contains(barIdx)).First();
                default:
                    return MajorAxisSpan.Where(x => x.BarIndices.Contains(barIdx)).First();
            }
        }

        public override GeometryBase GetGeometry()
        {
            BHoM.Geometry.Group<Curve> crvs = new BHoM.Geometry.Group<Curve>();
            m_bars.ForEach(x => crvs.Add(x.Line));
            return crvs;        
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
            List<bool> tempFlip = new List<bool>();

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

        /// <summary>
        /// Joins a list of connected bars with the same cross-section and outputs the result as design elements
        /// </summary>
        /// <param name="bars"></param>
        /// <returns></returns>
        public static List<DesignElement> CreateFromConnectedBars(List<Bar> bars, double tolerance = 0.01)
        {
            List<DesignElement> results = new List<DesignElement>();
            Dictionary<Guid, int> nodeCount = new Dictionary<Guid, int>();
            int count = 0;
            for (int i = 0; i < bars.Count; i++)
            {
                results.Add(new DesignElement(bars[i]));
                if (nodeCount.TryGetValue(bars[i].StartNode.BHoM_Guid, out count))
                {
                    nodeCount[bars[i].StartNode.BHoM_Guid] = count + 1;
                }
                else
                {
                    nodeCount.Add(bars[i].StartNode.BHoM_Guid, 1);
                }
                if (nodeCount.TryGetValue(bars[i].EndNode.BHoM_Guid, out count))
                {
                    nodeCount[bars[i].EndNode.BHoM_Guid] = count + 1;
                }
                else
                {
                    nodeCount.Add(bars[i].EndNode.BHoM_Guid, 1);
                }
            }

            int counter = 0;
            while (counter < results.Count)
            {
                double[] ps1 = results[counter].StartPoint;
                double[] pe1 = results[counter].EndPoint;
                for (int j = counter + 1; j < results.Count; j++)
                {
                    if (results[counter].SectionProperty.Name == results[j].SectionProperty.Name)
                    {
                        double[] ps2 = results[j].StartPoint;
                        double[] pe2 = results[j].EndPoint;
                        if (VectorUtils.Equal(pe1, ps2, tolerance) && nodeCount[results[counter].EndNode.BHoM_Guid] == 2)
                        {
                            results[j].AddBars(results[counter].AnalyticBars);
                            results.RemoveAt(counter--);
                            break;
                        }
                        else if (VectorUtils.Equal(pe1, pe2, tolerance) && nodeCount[results[counter].EndNode.BHoM_Guid] == 2)
                        {
                            results[j].AddBars(results[counter].AnalyticBars);
                            results.RemoveAt(counter--);
                            break;
                        }
                        else if (VectorUtils.Equal(ps1, ps2, tolerance) && nodeCount[results[counter].StartNode.BHoM_Guid] == 2)
                        {
                            results[j].AddBars(results[counter].AnalyticBars);
                            results.RemoveAt(counter--);
                            break;
                        }
                        else if (VectorUtils.Equal(ps1, pe2, tolerance) && nodeCount[results[counter].StartNode.BHoM_Guid] == 2)
                        {
                            results[j].AddBars(results[counter].AnalyticBars);
                            results.RemoveAt(counter--);
                            break;
                        }
                    }
                    
                }
                counter++;
            }

            for (int i = 0; i < results.Count; i++) results[i].GenerateDefaultSpans();
            return results;
        }
    }
}
