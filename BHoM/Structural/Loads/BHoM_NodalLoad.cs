using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHoM.Geometry;

namespace BHoM.Structural.Loads
{
    /// <summary>
    /// Nodal load class. Use NodalLoad() to construct an empty instance, then use the Set methods to set forces, moments etc. A second
    /// constructor allows for a default force and moment nodal load instance.
    /// </summary>
    public class NodalLoad : BHoM.Structural.Loads.Load
    {
        /// <summary>Loadcase as BHoM object</summary>
        public BHoM.Structural.Loads.Loadcase Loadcase { get; private set; }

        /// <summary>Force - fx, fy, fz defined as a BHoM.Geometry.Vector</summary>
        public BHoM.Geometry.Vector Force { get; private set; }

        /// <summary>Moment - mx, my, mz defined as a BHoM.Geometry.Vector</summary>
        public BHoM.Geometry.Vector Moment { get; private set; }

        /// <summary>Translation - ux, uy, uz defined as a BHoM.Geometry.Vector</summary>
        public BHoM.Geometry.Vector Translation { get; private set; }

        /// <summary>Rotation - rx, ry, rz defined as a BHoM.Geometry.Vector</summary>
        public BHoM.Geometry.Vector Rotation { get; private set; }

        /// <summary>TranslationalVelocity - vx, vy, vz defined as a BHoM.Geometry.Vector</summary>
        public BHoM.Geometry.Vector TranslationalVelocity { get; private set; }

        /// <summary>RotationalVelocity - vrx, vry, vrz defined as a BHoM.Geometry.Vector</summary>
        public BHoM.Geometry.Vector RotationalVelocity { get; private set; }

        /// <summary>TranslationalAcceleration - ax, ay, az defined as a BHoM.Geometry.Vector</summary>
        public BHoM.Geometry.Vector TranslationalAcceleration { get; private set; }

        /// <summary>RotationalAcceleration - arx, ary, arz defined as a BHoM.Geometry.Vector</summary>
        public BHoM.Geometry.Vector RotationalAcceleration { get; private set; }


        /// <summary>
        /// Create an empty nodal load as a placeholder
        /// </summary>
        public NodalLoad() { }

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
        public NodalLoad(BHoM.Structural.Loads.Loadcase loadcase, double fx, double fy, double fz, double mx, double my, double mz)
        {
            this.Loadcase = loadcase;
            this.Force = new Vector(fx, fy, fz);
            this.Moment = new Vector(mx, my, mz);
        }

        /// <summary>
        /// Create a new nodal load containing forces and moments. This is the only constructor that sets the nodal force
        /// values. For all other nodal load types (displacement, velocity etc) use the relevant Set method.
        /// </summary>
        /// <param name="loadcaseNumber"></param>
        /// <param name="loadcaseName"></param>
        /// <param name="fx"></param>
        /// <param name="fy"></param>
        /// <param name="fz"></param>
        /// <param name="mx"></param>
        /// <param name="my"></param>
        /// <param name="mz"></param>
        public NodalLoad(int loadcaseNumber, string loadcaseName, double fx, double fy, double fz, double mx, double my, double mz)
        {
            this.Loadcase = new Loadcase(loadcaseNumber, loadcaseName);
            this.Force = new Vector(fx, fy, fz);
            this.Moment = new Vector(mx, my, mz);
        }

        /// <summary>
        /// Sets the loadcase for the nodal force as a BHoM loadcase object
        /// </summary>
        /// <param name="loadcase"></param>
        public void SetLoadcase(BHoM.Structural.Loads.Loadcase loadcase)
        {
            this.Loadcase = loadcase;
        }

        /// <summary>
        /// Sets the loadcase for the nodal force as a BHoM loadcase object
        /// </summary>
        /// <param name="number"></param>
        /// <param name="name"></param>
        public void NewLoadcase(int number, string name)
        {
            this.Loadcase = new Loadcase(number, name);
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

        /// <summary>
        /// Set translations of a nodal load (imposed displacements)
        /// </summary>
        /// <param name="ux"></param>
        /// <param name="uy"></param>
        /// <param name="uz"></param>
        public void SetTranslation(double ux, double uy, double uz)
        {
            this.Translation = new Vector(ux, uy, uz);
        }

        /// <summary>
        /// Set the rotations of a nodal load (imposed rotations)
        /// </summary>
        /// <param name="rx"></param>
        /// <param name="ry"></param>
        /// <param name="rz"></param>
        public void SetRotation(double rx, double ry, double rz)
        {
            this.Rotation = new Vector(rx, ry, rz);
        }

        /// <summary>
        /// Set the translational velocities of a nodal load
        /// </summary>
        /// <param name="vx"></param>
        /// <param name="vy"></param>
        /// <param name="vz"></param>
        public void SetTranslationalVelocity(double vx, double vy, double vz)
        {
            this.TranslationalVelocity = new Vector(vx, vy, vz);
        }

        /// <summary>
        /// Set the rotational velocities of a nodal load
        /// </summary>
        /// <param name="vrx"></param>
        /// <param name="vry"></param>
        /// <param name="vrz"></param>
        public void SetRotationalVelocity(double vrx, double vry, double vrz)
        {
            this.RotationalVelocity = new Vector(vrx, vry, vrz);
        }

        /// <summary>
        /// Set the translational accelerations of a nodal load
        /// </summary>
        /// <param name="ax"></param>
        /// <param name="ay"></param>
        /// <param name="az"></param>
        public void SetTranslationalAcceleration(double ax, double ay, double az)
        {
            this.TranslationalAcceleration = new Vector(ax, ay, az);
        }

        /// <summary>
        /// Set the rotational accelerations of a nodal load
        /// </summary>
        /// <param name="arx"></param>
        /// <param name="ary"></param>
        /// <param name="arz"></param>
        public void SetRotationalAcceleration(double arx, double ary, double arz)
        {
            this.RotationalAcceleration = new Vector(arx, ary, arz);
        }

        /// <summary>
        /// Add a node number to the list. If first number, a new list will be created.
        /// </summary>
        /// <param name="number"></param>
        public void AddNodeNumber(int number)
        {
            if(this.ObjectNumbers != null)
            {
                this.ObjectNumbers.Add(number);
            }
            else
            {
                this.ObjectNumbers = new List<int>();
                this.ObjectNumbers.Add(number);
            }
        }

        /// <summary>
        /// Set a record number for Robot loads - to retrieve later (and prevent duplicated loads)
        /// </summary>
        /// <param name="number"></param>
        public void SetRobotLoadRecordNumber(int number)
        {
            this.RecordNumber = number;
        }

    }
}
