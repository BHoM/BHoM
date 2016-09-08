using BHoM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural.Properties
{
    public class ColumnReinforcement : BHoMObject, IDetail
    {
        public int LongitudinalCount { get; set; }
        public int LongitudinalDiameter { get; set; }
        public int TieSpacing { get; set; }
        public int TieLegs { get; set; }
        public int TieDiameter { get; set; }
        public int Cover { get; set; }
    }
}
