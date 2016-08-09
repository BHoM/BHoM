using BHoM.Base;
using BHoM.Base.Results;
using BHoM.Global;
using BHoM.Structural.Loads;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BHoM.Structural.Results
{
    /// <summary>
    /// Bar force object contains a set of coexisting forces, bar reference
    /// and orientation information
    /// </summary>
    /// 
    public class BarForce : Result
    {
        public BarForce()
        {
            Data = new object[11];
        }

        public BarForce(object[] data) { Data = data; }

        public BarForce(int number, int loadcase, int position, int timeStep, double fx, double fy, double fz, double mx, double my, double mz) : this()
        {
            Name = number;
            ForcePosition = position;
            TimeStep = timeStep;
            Loadcase = loadcase;
            Id = Name + ":" + loadcase + ":" + ForcePosition + ":" + TimeStep;
            FX = fx;
            FY = fy;
            FZ = fz;
            MX = mx;
            MY = my;
            MZ = mz;
        }

        public override string[] ColumnHeaders
        {
            get
            {
                return new string[] { "Id", "Name", "Loadcase", "TimeStep", "ForcePosition", "FX", "FY", "FZ", "MX", "MY", "MZ" };
            }
        }

        public int ForcePosition
        {
            get
            {
                return (int)Data[4];
            }
            set
            {
                Data[4] = value;
            }
        }

        public double FX
        {
            get
            {
                return (double)Data[5];
            }
            set
            {
                Data[5] = value;
            }
        }

        public double FY
        {
            get
            {
                return (double)Data[6];
            }
            set
            {
                Data[6] = value;
            }
        }

        public double FZ
        {
            get
            {
                return (double)Data[7];
            }
            set
            {
                Data[7] = value;
            }
        }

        public double MX
        {
            get
            {
                return (double)Data[8];
            }
            set
            {
                Data[8] = value;
            }
        }

        public double MY
        {
            get
            {
                return (double)Data[9];
            }
            set
            {
                Data[9] = value;
            }
        }

        public double MZ
        {
            get
            {
                return (double)Data[10];
            }
            set
            {
                Data[10] = value;
            }
        }
    }

    //public class BarForce : Result
    //{
    //    /// <summary>Associated bar number</summary>
    //    //public Guid Id { get; set; }

    //    /// <summary>Position along the bar of the force. Set 0 for 1 for end</summary>
    //    public int ForcePosition { get; set; }

    //    /// <summary>Loadcase</summary>
    //   // public BHoM.Structural.Loads.Loadcase Loadcase { get; set; }

    //    /// <summary>Associated loadcase number</summary>
    //    //public int LoadcaseNumber { get; private set; }

    //    /// <summary>Axial force, tension negative</summary>
    //    public double FX { get; set; }

    //    /// <summary>Shear force, minor axis</summary>
    //    public double FY { get; set; }

    //    /// <summary>Shear force, major axis</summary>
    //    public double FZ { get; set; }

    //    /// <summary>Torsion</summary>
    //    public double MX { get; set; }

    //    /// <summary>Bending moment, minor axis</summary>
    //    public double MY { get; set; }

    //    /// <summary>Bending moment, major axis</summary>
    //    public double MZ { get; set; }

    //    /// <summary>Maximum principle stress</summary>
    //    //public double SMax { get; set; }

    //    /// <summary>Minimum principle stress</summary>
    //    //public double SMin { get; set; }

    //    /// <summary>Orientation of bar forces inherited from bar</summary>
    //   // public BHoM.Geometry.Plane OrientationPlane { get; set; }

    //    /// <summary>User text field for any user data</summary>
    //    //public string UserData { get; set; }

    //    public static BarForce operator *(BarForce b, double factor)
    //    {
    //        return null;// new BarForce(b.Id, b.FX * factor, b.FY * factor, b.FZ * factor, b.MX * factor, b.MY * factor, b.MZ * factor);
    //    }

    //    public static BarForce operator +(BarForce b1, BarForce b2)
    //    {
    //        return null;// new BarForce(b1.Id, b1.FX + b2.FX, b1.FY + b2.FY, b1.FZ + b2.FZ, b1.MX + b2.MX, b1.MY + b2.MY, b1.MZ + b2.MZ);
    //    }

    //    //// CONSTRUCTORS ////

    //    /// <summary>Construct a bar force with loadcases</summary>
    //    public BarForce(int barNumber, int forcePosition, BHoM.Structural.Loads.Loadcase loadcase, BHoM.Geometry.Plane orientationPlane)
    //    {
    //        this.Name = barNumber;
    //        this.ForcePosition = forcePosition;
    //        //this.Loadcase = loadcase.Name;
    //        //this.LoadcaseNumber = loadcase.Number;
    //        // this.OrientationPlane = orientationPlane;
    //        this.Id = Name + ":" + loadcase.Name + ":" + ForcePosition + ":" + TimeStep;
    //    }

    //    public BarForce(int number, int loadcase, int position, int timeStep, double fx, double fy, double fz, double mx, double my, double mz)
    //    {
    //        Name = number;
    //        ForcePosition = position;
    //        TimeStep = timeStep;
    //        Loadcase = loadcase;
    //        Id = Name + ":" + loadcase + ":" + ForcePosition + ":" + TimeStep;
    //        FX = fx;
    //        FY = fy;
    //        FZ = fz;
    //        MX = mx;
    //        MY = my;
    //        MZ = mz;
    //    }
    //    public BarForce() { }

    //    public BarForce(Guid id, double fx, double fy, double fz, double mx, double my, double mz)
    //    {
    //        //Id = id;
    //        FX = fx;
    //        FY = fy;
    //        FZ = fz;
    //        MX = mx;
    //        MY = my;
    //        MZ = mz;
    //    }
    //}
}
