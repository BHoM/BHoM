using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BHoM.Structural
{
    [Serializable]
    public class Release
    {
        public string Name { get; private set; }
        public DOF X { get; set; }
        public DOF Y { get; set; }
        public DOF Z { get; set; }
        public DOF XX { get; set; }
        public DOF YY { get; set; }
        public DOF ZZ { get; set; }
              
        public Release()
        {
        }


    }

  
}
