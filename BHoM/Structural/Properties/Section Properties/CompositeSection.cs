using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHoM.Geometry;
namespace BHoM.Structural.Properties
{
    public class CompositeSection : SectionProperty
    {
        private SteelSection m_SteelSection;
        private ConcreteSection m_ConcreteSection;
        private double m_SteelEmbedmentDepth;
        public SteelSection SteelSection
        {
            get
            {
                return m_SteelSection;
            }
            set
            {
                m_SteelSection = value;
                SetEdges();              
            }
        }

        public ConcreteSection ConcreteSection
        {
            get
            {
                return m_ConcreteSection;
            }
            set
            {
                m_ConcreteSection = value;
                SetEdges();
            }
        }

        private void SetEdges()
        {
            if (m_ConcreteSection != null && m_SteelSection != null)
            {
                double n = m_ConcreteSection.Material.YoungsModulus / m_SteelSection.Material.YoungsModulus;
                Group<Curve> concreteRectangle = m_ConcreteSection.Edges.DuplicateGroup();
                concreteRectangle.Transform(Transform.Scale(Point.Origin, new Vector(n, 1, 1)));
                Group<Curve> steelSection = m_SteelSection.Edges.DuplicateGroup();

                double topSteel = steelSection.Bounds().Max.Y;
                double botConcrete = concreteRectangle.Bounds().Min.Y;
                double steelOffset = topSteel - botConcrete - SteelEmbedmentDepth;

                steelSection.Translate(Vector.YAxis(-steelOffset));

                if (SteelEmbedmentDepth > 0)
                {
                    Curve perimeter = Curve.Join(steelSection)[0];
                    if (perimeter != null)
                    {
                        List<Curve> curves = perimeter.Split(Plane.YZ(botConcrete), true);
                        if (curves.Count == 2)
                        {
                            if (curves[0].Bounds().Centre.Y < botConcrete)
                            {
                                concreteRectangle.Add(curves[0]);
                            }
                            else
                            {
                                concreteRectangle.Add(curves[1]);
                            }
                        }
                    }
                }
                else
                {
                    concreteRectangle.AddRange(steelSection);
                }
                Edges = concreteRectangle;
            }
        }

        public double SteelEmbedmentDepth
        {
            get
            {
                return m_SteelEmbedmentDepth;
            }
            set
            {
                bool valueChanged = value != m_SteelEmbedmentDepth;
                m_SteelEmbedmentDepth = value;
                if (valueChanged) SetEdges();
            }
        }

        public double StudDiameter { get; set; }
        public double StudHeight { get; set; }
        public double StudSpacing { get; set; }
        public int StudsPerGroup { get; set; }
        public CompositeSection()
        {

        }

        public CompositeSection(SteelSection steel, ConcreteSection concrete, double steelEmbedmentDepth)
        {
            m_SteelSection = steel;
            m_ConcreteSection = concrete;
            m_SteelEmbedmentDepth = steelEmbedmentDepth;
            SetEdges();
        }
    }
}
