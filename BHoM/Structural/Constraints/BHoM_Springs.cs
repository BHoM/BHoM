using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural.Constraints
{
    public class PointSpring : Global.BHoMObject
    {
        internal PointSpring() { }

        public double UX { get; set; }

        public double UY { get; set; }

        public double UZ { get; set; }

        public double RX { get; set; }

        public double RY { get; set; }

        public double RZ { get; set; }
    }

    public class LineSpring : Global.BHoMObject
    { }

    public class AreaSpring : Global.BHoMObject
    { }


}
