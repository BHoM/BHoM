using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Analytical.Elements
{
    public class ViewConfig : BHoMObject
    {
        public virtual List<string> GroupsToIgnore { get; set; } = new List<string>();

        public virtual double EntityBoxX { get; set; } = 10;

        public virtual double EntityBoxY { get; set; } = 5;

        public virtual double Padding { get; set; } = 1;
    }
}
