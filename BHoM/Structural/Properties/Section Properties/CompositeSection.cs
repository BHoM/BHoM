using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHoM.Geometry;
namespace BHoM.Structural.Properties.Section_Properties
{
    public class CompositeSection : SectionProperty
    {
        public List<SectionProperty> Sections { get; set; }

        public CompositeSection()
        {

        }

        public SteelSection GetSteelSection()
        {
            foreach (SectionProperty property in Sections)
            {
                if (property is SteelSection)
                {
                    return property as SteelSection;
                }
            }
            return null;
        }

        public ConcreteSection GetConcreteSection()
        {
            foreach (SectionProperty property in Sections)
            {
                if (property is ConcreteSection)
                {
                    return property as ConcreteSection;
                }
            }
            return null;
        }

    }
}
