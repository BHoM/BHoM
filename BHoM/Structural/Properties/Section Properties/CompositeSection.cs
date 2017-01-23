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
        public SteelSection SteelSection
        {
            get; set;
        }

        public ConcreteSection ConcreteSection
        {
            get; set;
        }

        public double SteelEmbedmentDepth { get; set; }
        public double StudDiameter { get; set; }
        public double StudHeight { get; set; }
        public double StudSpacing { get; set; }
        public int StudsPerGroup { get; set; }
        public CompositeSection()
        {

        }
    }
}
