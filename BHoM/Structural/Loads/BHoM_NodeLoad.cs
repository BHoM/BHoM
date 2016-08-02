using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHoM.Geometry;
using BHoM.Global;

namespace BHoM.Structural.Loads
{
    /// <summary>
    /// Nodal load class. Use NodalLoad() to construct an empty instance, then use the Set methods to set forces, moments etc. A second
    /// constructor allows for a default force and moment nodal load instance.
    /// </summary>
    public class PointForce : Load<Node>
    {
        /// <summary>Force - fx, fy, fz defined as a BHoM.Geometry.Vector</summary>
        public BHoM.Geometry.Vector Force { get; private set; }

        /// <summary>Moment - mx, my, mz defined as a BHoM.Geometry.Vector</summary>
        public BHoM.Geometry.Vector Moment { get; private set; }

        public override LoadType LoadType
        {
            get
            {
                return LoadType.PointForce;
            }
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
        public PointForce(BHoM.Structural.Loads.Loadcase loadcase, double fx, double fy, double fz, double mx, double my, double mz)
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
    /// <summary>
    /// Point Displacement class
    /// </summary>
    public class PointDisplacement : Load<Node>
    {
        /// <summary>Translation - tx, ty, tz defined as a BHoM.Geometry.Vector</summary>
        public BHoM.Geometry.Vector Translation { get; set; }

        /// <summary>Rotation - rx, ry, rz defined as a BHoM.Geometry.Vector</summary>
        public BHoM.Geometry.Vector Rotation { get; set; }
        
        /// <summary>Stores a load record number specific to Robot</summary>
        public int RobotLoadRecordNumber { get; private set; }
      
        /// <summary>
        /// Create an empty nodal load as a placeholder
        /// </summary>
        public PointDisplacement() { }

        public override LoadType LoadType
        {
            get
            {
                return LoadType.PointDisplacement;
            }
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
        public PointDisplacement(BHoM.Structural.Loads.Loadcase loadcase, double tx, double ty, double tz, double rx, double ry, double rz)
        {
            this.Loadcase = loadcase;
            this.Translation = new Vector(tx, ty, tz);
            this.Rotation = new Vector(rx, ry, rz);
        }
    }

    /// <summary>
    /// Point Velocity class
    /// </summary>
    public class PointVelocity : Load<Node>
    {
        /// <summary>TranslationalVelocity - vx, vy, vz defined as a BHoM.Geometry.Vector</summary>
        public BHoM.Geometry.Vector TranslationalVelocity { get; private set; }

        /// <summary>RotationalVelocity - vrx, vry, vrz defined as a BHoM.Geometry.Vector</summary>
        public BHoM.Geometry.Vector RotationalVelocity { get; private set; }

        /// <summary>Stores a load record number specific to Robot</summary>
        public int RobotLoadRecordNumber { get; private set; }
        
        /// <summary>
        /// Create an empty nodal load as a placeholder
        /// </summary>
        public PointVelocity() { }

        public override LoadType LoadType
        {
            get
            {
                return LoadType.PointVelocity;
            }
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
        public PointVelocity(BHoM.Structural.Loads.Loadcase loadcase, double vx, double vy, double vz, double vrx, double vry, double vrz)
        {
            this.Loadcase = loadcase;
            this.TranslationalVelocity = new Vector(vx, vy, vz);
            this.RotationalVelocity = new Vector(vrx, vry, vrz);
        }
    }

    /// <summary>
    /// Point Acceleration class
    /// </summary>
    public class PointAcceleration : Load<Node>
    {
        /// <summary>TranslationalAcceleration - ax, ay, az defined as a BHoM.Geometry.Vector</summary>
        public BHoM.Geometry.Vector TranslationalAcceleration { get; private set; }

        /// <summary>RotationalAcceleration - arx, ary, arz defined as a BHoM.Geometry.Vector</summary>
        public BHoM.Geometry.Vector RotationalAcceleration { get; private set; }

        /// <summary>Stores a load record number specific to Robot</summary>
        public int RobotLoadRecordNumber { get; private set; }

        /// <summary>
        /// Create an empty nodal load as a placeholder
        /// </summary>
        public PointAcceleration() { }

        public override LoadType LoadType
        {
            get
            {
                return LoadType.PointAcceleration;
            }
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
        public PointAcceleration(BHoM.Structural.Loads.Loadcase loadcase, double ax, double ay, double az, double arx, double ary, double arz)
        {
            this.Loadcase = loadcase;
            this.TranslationalAcceleration = new Vector(ax, ay, az);
            this.RotationalAcceleration = new Vector(arx, ary, arz);
        }
    }
}
