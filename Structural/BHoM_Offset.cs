using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHoM.Materials; 

namespace BHoM.Structural
{
    [Serializable]
    public class Offset
    {
        public string Name { get; private set; }
        public double[] Offsets { get; private set; }

        public Offset(double x, double y, double z, double xx, double yy, double zz)
        {
            this.Offsets = new double[6] { x, y, z, xx, yy, zz };
        }

        public void SetName(string name)
        {
            this.Name = name;
        }
     }
}
