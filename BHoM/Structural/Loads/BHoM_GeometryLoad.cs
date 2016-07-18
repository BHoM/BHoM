using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural.Loads
{
    public class GeometricalLoad : Load<BHoM.Geometry.GeometryBase>
    {
        /// <summary>Force - fx, fy, fz defined as a BHoM.Geometry.Vector</summary>
        public Geometry.Vector Force { get; set; }

        /// <summary>Moment - mx, my, mz defined as a BHoM.Geometry.Vector</summary>
        public Geometry.Vector Moment { get; set; }

        public Global.Units.LoadUnit Unit { get; set; }

        public GeometricalLoad(BHoM.Geometry.Curve contour, Geometry.Vector force, Geometry.Vector moment = null)
        {
            Objects.Add(contour);
            Force = force;
            Moment = (moment != null) ? moment : new Geometry.Vector(0, 0, 0);
        }
    }
}
