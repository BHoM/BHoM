using System;
using BHoM.Materials;

namespace BHoM.Structural.SectionProperties 
{
    /// <summary>
    /// 
    /// </summary>
     public class SteelISection : SectionProperty, ISteelISection, ISectionFactory
    {
        
        /// <summary></summary>
        public SteelISection() : base()
        {
            this.Type = ShapeType.SteelI;
        }

        /// <summary></summary>
        public double BottomFlangeThickness { get; set; }
        
        /// <summary></summary>
        public double BottomFlangeWidth { get; set; }

        /// <summary></summary>
        public double Depth { get; set; }

        /// <summary></summary>
        public double RootRadius { get; set; }

        /// <summary></summary>
        public double TopFlangeThickness { get; set; }

        /// <summary></summary>
        public double TopFlangeWidth { get; set; }

        /// <summary></summary>
        public double WebThickness { get; set; }

        /// <summary></summary>
        public SectionProperty Create(ShapeType shapeType)
        {
            return new SteelISection();
        }

        //////////////
        ////Methods///
        //////////////

        /// <summary>Method which gets a properties dictionary for simple downstream deconstruct</summary>
        public BHoM.Collections.Dictionary<string, object> GetProperties()
        {
            BHoM.Collections.Dictionary<string, object> PropertiesDictionary = new BHoM.Collections.Dictionary<string, object>();
            foreach (var prop in this.GetType().GetProperties())
            {
                PropertiesDictionary.Add(prop.Name, prop.GetValue(this));
            }
            return PropertiesDictionary;
        }
    }
}