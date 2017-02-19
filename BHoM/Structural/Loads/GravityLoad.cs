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
        public BHG.Vector GravityDirection { get; set; } = new BHG.Vector(0, 0, -1);

        public GravityLoad()
        {
        }

        public GravityLoad(Loadcase loadcase, double Gx, double gy, double gz)
        {
            GravityDirection = new Geometry.Vector(Gx, gy, gz);
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
