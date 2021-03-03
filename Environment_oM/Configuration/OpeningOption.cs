using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;
using System.ComponentModel;
using BH.oM.Quantities.Attributes;

namespace BH.oM.Environment.Configuration
{
    [Description("Defines the design options for Openings.")]
    public class OpeningOption : BHoMObject
    {
        [Length]
        [Description("Defines the height the opening should be.")]
        public virtual double Height { get; set; } = 0;
        
        [Length]
        [Description("Defines the width the opening should be.")]
        public virtual double Width { get; set; } = 0;

        [Length]
        [Description("The distance between the base of the panel and the bottom of the opening.")]
        public virtual double SillHeight { get; set; } = 0;
    }
}
