using BH.oM.Geometry;
using BH.oM.Structural.Elements;

namespace BH.oM.Structural.Loads
{
    public class PointDisplacement : Load<Node>
    {
        /// <summary>Translation - tx, ty, tz defined as a BH.oM.Geometry.Vector</summary>
        public BH.oM.Geometry.Vector Translation { get; set; }

        /// <summary>Rotation - rx, ry, rz defined as a BH.oM.Geometry.Vector</summary>
        public BH.oM.Geometry.Vector Rotation { get; set; }

        /// <summary>Stores a load record number specific to Robot</summary>
        public int RobotLoadRecordNumber { get; private set; }

        /// <summary>
        /// Create an empty nodal load as a placeholder
        /// </summary>
        public PointDisplacement() { }

        public override LoadType GetLoadType()
        {
            return LoadType.PointDisplacement;
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
        public PointDisplacement(BH.oM.Structural.Loads.Loadcase loadcase, double tx, double ty, double tz, double rx, double ry, double rz)
        {
            this.Loadcase = loadcase;
            this.Translation = new Vector(tx, ty, tz);
            this.Rotation = new Vector(rx, ry, rz);
        }
    }
}
