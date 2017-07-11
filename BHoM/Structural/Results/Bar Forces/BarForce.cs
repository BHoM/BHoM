using BH.oM.Base;

using BH.oM.Structural.Loads;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BH.oM.Structural.Results
{
    /// <summary>
    /// Bar force object contains a set of coexisting forces, bar reference
    /// and orientation information
    /// </summary>
    /// 
    public class BarForce : BarForce<string, string, string>
    {
        public BarForce() : base() { }
        public BarForce(string number, string loadcase, int position, int divisions, string timeStep, double fx, double fy, double fz, double mx, double my, double mz)
        : base(number, loadcase, position, divisions, timeStep, fx, fy, fz, mx, my, mz)
        { }
    }

    public class BarForce<TName, TLoadcase, TTimeStep> : Result<TName, TLoadcase, TTimeStep>
         where TName : IComparable
         where TLoadcase : IComparable
         where TTimeStep : IComparable
    {
        public BarForce()
        {
            m_data = new object[12];           
        }

        public BarForce(object[] data) { m_data = data; }

        public BarForce(TName number, TLoadcase loadcase, int position, int divisions, TTimeStep timeStep, double fx, double fy, double fz, double mx, double my, double mz) : this()
        {
            Name = number;
            ForcePosition = position;
            TimeStep = timeStep;
            Loadcase = loadcase;
            Id = Name + ":" + loadcase + ":" + ForcePosition + ":" + TimeStep;
            Divisions = divisions;
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
                return new string[] { "Id", "Name", "Loadcase", "TimeStep", "ForcePosition", "Divisions", "FX", "FY", "FZ", "MX", "MY", "MZ" };
            }
        }

        public override ResultType ResultType
        {
            get
            {
                return ResultType.BarForce;
            }
        }

        public int ForcePosition
        {
            get
            {
                return (int)m_data[4];
            }
            set
            {
                m_data[4] = value;
            }
        }

        public int Divisions
        {
            get
            {
                return (int)m_data[5];
            }
            set
            {
                m_data[5] = value;
            }
        }

        public double FX
        {
            get
            {
                return (double)m_data[6];
            }
            set
            {
                m_data[6] = value;
            }
        }

        public double FY
        {
            get
            {
                return (double)m_data[7];
            }
            set
            {
                m_data[7] = value;
            }
        }

        public double FZ
        {
            get
            {
                return (double)m_data[8];
            }
            set
            {
                m_data[8] = value;
            }
        }

        public double MX
        {
            get
            {
                return (double)m_data[9];
            }
            set
            {
                m_data[9] = value;
            }
        }

        public double MY
        {
            get
            {
                return (double)m_data[10];
            }
            set
            {
                m_data[10] = value;
            }
        }

        public double MZ
        {
            get
            {
                return (double)m_data[11];
            }
            set
            {
                m_data[11] = value;
            }
        }

        public override int CompareTo(object obj)
        {
            var r2 = obj as BarForce<TName, TLoadcase, TTimeStep>;
            if (r2 != null)
            {
                int n = this.Name.CompareTo(r2.Name);
                if (n == 0)
                {
                    int l = this.Loadcase.CompareTo(r2.Loadcase);
                    if (l == 0)
                    {
                        int f = this.ForcePosition.CompareTo(r2.ForcePosition);
                        return f == 0 ? this.TimeStep.CompareTo(r2.TimeStep) : f;
                    }
                    else
                    {
                        return l;
                    }
                }
                else
                {
                    return n;
                }
            }
            return 1;
        }
    }

    //public class BarForce : Result
    //{
    //    /// <summary>Associated bar number</summary>
    //    //public Guid Id { get; set; }

    //    /// <summary>Position along the bar of the force. Set 0 for 1 for end</summary>
    //    public int ForcePosition { get; set; }

    //    /// <summary>Loadcase</summary>
    //   // public BH.oM.Structural.Loads.Loadcase Loadcase { get; set; }

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
    //   // public BH.oM.Geometry.Plane OrientationPlane { get; set; }

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
    //    public BarForce(int barNumber, int forcePosition, BH.oM.Structural.Loads.Loadcase loadcase, BH.oM.Geometry.Plane orientationPlane)
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
