using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural
{
    [Serializable]
    public class Restraint
    {
       public string Name { get; private set; }
        public DOF X { get; set; }
        public DOF Y { get; set; }
        public DOF Z { get; set; }
        public DOF XX { get; set; }
        public DOF YY { get; set; }
        public DOF ZZ { get; set; }
        public double[] Values { get; private set; }
        public string[] Descriptions { get; private set; }

        public Restraint()
        {
        }
     
    }
}
