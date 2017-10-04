using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Base;
using BH.oM.Geometry;
using BH.oM.Structural.Elements;

namespace BH.oM.Structural.Loads
{
    /// <summary>
    /// Nodal load class. Use NodalLoad() to construct an empty instance, then use the Set methods to set forces, moments etc. A second
    /// constructor allows for a default force and moment nodal load instance.
    /// </summary>
    public class PointForce : Load<Node> //TODO: one class per file
    {
        /// <summary>Force - fx, fy, fz defined as a BH.oM.Geometry.Vector</summary>
        public BH.oM.Geometry.Vector Force { get;  set; }

        /// <summary>Moment - mx, my, mz defined as a BH.oM.Geometry.Vector</summary>
        public BH.oM.Geometry.Vector Moment { get;  set; }

        public override LoadType GetLoadType()
        {
            return LoadType.PointForce;
        }
        /// <summary>
        /// Create an empty nodal load as a placeholder
        /// </summary>
        public PointForce() { }

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
        public PointForce(BH.oM.Structural.Loads.Loadcase loadcase, double fx, double fy, double fz, double mx, double my, double mz)
        {
            this.Loadcase = loadcase;
            this.Force = new Vector(fx, fy, fz);
            this.Moment = new Vector(mx, my, mz);
        }

        /// <summary>
        /// Set the forces of a nodal load
        /// </summary>
        /// <param name="fx"></param>
        /// <param name="fy"></param>
        /// <param name="fz"></param>
        public void SetForce(double fx, double fy, double fz)
        {
            this.Force = new Vector(fx, fy, fz);
        }

        /// <summary>
        /// Set the moments of a nodal load
        /// </summary>
        /// <param name="mx"></param>
        /// <param name="my"></param>
        /// <param name="mz"></param>
        public void SetMoment(double mx, double my, double mz)
        {
            this.Moment = new Vector(mx, my, mz);
        }
    }
}
