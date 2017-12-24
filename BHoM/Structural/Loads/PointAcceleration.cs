using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Geometry;
using BH.oM.Structural.Elements;

namespace BH.oM.Structural.Loads
{
    [Serializable]
    public class PointAcceleration : Load<Node>
    {
        /// <summary>TranslationalAcceleration - ax, ay, az defined as a BH.oM.Geometry.Vector</summary>
        public BH.oM.Geometry.Vector TranslationalAcceleration { get; set; }

        /// <summary>RotationalAcceleration - arx, ary, arz defined as a BH.oM.Geometry.Vector</summary>
        public BH.oM.Geometry.Vector RotationalAcceleration { get; set; }

        /// <summary>Stores a load record number specific to Robot</summary>
        public int RobotLoadRecordNumber { get; private set; }

        /// <summary>
        /// Create an empty nodal load as a placeholder
        /// </summary>
        public PointAcceleration() { }

        public override LoadType GetLoadType()
        {
            return LoadType.PointAcceleration;
        }
        /// <summary>
        /// Create a new nodal load containing forces and moments. This is the only constructor that sets the nodal force
        /// values. For all other nodal load types (displacement, velocity etc) use the relevant Set method.
        /// </summary>
        /// <param name="loadcase"></param>
        /// <param name="fx"></param>
        /// <param name="fy"></param>
        /// <param name="fz"></param>
        /// <param name="mx"></param>
        /// <param name="my"></param>
        /// <param name="mz"></param>
        public PointAcceleration(BH.oM.Structural.Loads.Loadcase loadcase, double ax, double ay, double az, double arx, double ary, double arz)
        {
            this.Loadcase = loadcase;
            this.TranslationalAcceleration = new Vector(ax, ay, az);
            this.RotationalAcceleration = new Vector(arx, ary, arz);
        }
    }
}
