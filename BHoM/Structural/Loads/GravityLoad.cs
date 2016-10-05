using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHB = BHoM.Base;
using BHG = BHoM.Geometry;

namespace BHoM.Structural.Loads
{
    public class GravityLoad : Load<BHB.BHoMObject>
    {

        public BHG.Vector GravityDriection { get; set; } = new BHG.Vector(0, 0, -1);

        public GravityLoad()
        {
        }

        public override LoadType LoadType
        {
            get
            {
                return LoadType.Selfweight;
            }
        }
    }
}
