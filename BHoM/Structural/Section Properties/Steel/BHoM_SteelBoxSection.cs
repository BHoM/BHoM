using System;
using System.Collections.Generic;
using BHoM.Materials;

namespace BHoM.Structural.SectionProperties 
{
    /// <summary>
    /// 
    /// </summary>
     public class SteelBoxSection : SectionProperty
    {
        
        /// <summary></summary>
        internal SteelBoxSection(string name) : base()
        {
            this.Type = ShapeType.SteelI;
            this.Name = name;
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
        public double WebThicknessLeft { get; set; }

        /// <summary></summary>
        public double WebThicknessRight { get; set; }

        /// <summary></summary>
        public double Width { get; set; }

        //////////////
        ////Methods///
        //////////////

        /// <summary>Method which gets a properties dictionary for simple downstream deconstruct</summary>
        public Dictionary<string, object> GetProperties()
        {
            Dictionary<string, object> PropertiesDictionary = new Dictionary<string, object>();
            foreach (var prop in this.GetType().GetProperties())
            {
                PropertiesDictionary.Add(prop.Name, prop.GetValue(this));
            }
            return PropertiesDictionary;
        }
    }
}