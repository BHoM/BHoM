using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Geometry
{
    public class PolyLoop
    {
        private List<Point> pPoints;

        public List<Point> Points
        {
            get
            {
                return pPoints;
            }
            set
            {
                pPoints = value;
            }
        }
    }
}
