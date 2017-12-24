using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Geometry
{
    [Serializable]
    public struct IntegrationSlice
    {
        public double Width;
        public double Length;
        public double Centre;
        public double[] Placement;

        public IntegrationSlice(double width, double length, double centre, double[] placement)
        {
            Width = width;
            Length = length;
            Centre = centre;
            Placement = placement;
        }
    }
}
