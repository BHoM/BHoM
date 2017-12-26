using BH.oM.Geometry;
using BH.oM.Structural.Elements;

namespace BH.oM.Structural.Loads
{
    public class PointVelocity : Load<Node>
    {
        /// <summary>TranslationalVelocity - vx, vy, vz defined as a BH.oM.Geometry.Vector</summary>
        public BH.oM.Geometry.Vector TranslationalVelocity { get; set; }

        /// <summary>RotationalVelocity - vrx, vry, vrz defined as a BH.oM.Geometry.Vector</summary>
        public BH.oM.Geometry.Vector RotationalVelocity { get; set; }

        /// <summary>Stores a load record number specific to Robot</summary>
        public int RobotLoadRecordNumber { get; private set; }

        /// <summary>
        /// Create an empty nodal load as a placeholder
        /// </summary>
        public PointVelocity() { }

        public override LoadType GetLoadType()
        {
            return LoadType.PointVelocity;
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
        public PointVelocity(BH.oM.Structural.Loads.Loadcase loadcase, double vx, double vy, double vz, double vrx, double vry, double vrz)
        {
            this.Loadcase = loadcase;
            this.TranslationalVelocity = new Vector { X = vx, Y = vy, Z = vz };
            this.RotationalVelocity = new Vector { X = vrx, Y = vry, Z = vrz };
        }
    }
}
