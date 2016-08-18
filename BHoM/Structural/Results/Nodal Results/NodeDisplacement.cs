using BHoM.Base.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural.Results
{
    public class NodeDisplacement : NodeDisplacement<int, int, int>
    {
        public NodeDisplacement() : base() { }
        public NodeDisplacement(int number, int loadcase, int timeStep, double fx, double fy, double fz, double mx, double my, double mz)
            : base(number, loadcase, timeStep, fx, fy, fz, mx, my, mz)
        { }
    }

   public class NodeDisplacement<TName, TLoadcase, TTimeStep> : Result<TName, TLoadcase, TTimeStep>
        where TName : IComparable
        where TLoadcase : IComparable
        where TTimeStep : IComparable
    {
        public override string[] ColumnHeaders
        {
            get
            {
                return new string[] { "Id", "Name", "Loadcase", "TimeStep", "UX", "UY", "UZ", "RX", "RY", "RZ" };
            }
        }

        public override ResultType ResultType
        {
            get
            {
                return ResultType.NodeDisplacement;
            }
        }

        public NodeDisplacement()
        {
            Data = new object[10];
        }

        public NodeDisplacement(object[] data) { Data = data; }

        public NodeDisplacement(TName number, TLoadcase loadcase, TTimeStep timeStep, double fx, double fy, double fz, double mx, double my, double mz) : this()
        {
            Name = number;
            TimeStep = timeStep;
            Loadcase = loadcase;
            Id = Name + ":" + loadcase + ":" + TimeStep;
            UX = fx;
            UY = fy;
            UZ = fz;
            RX = mx;
            RY = my;
            RZ = mz;
        }

        public double UX
        {
            get
            {
                return (double)Data[4];
            }
            set
            {
                Data[4] = value;
            }
        }

        public double UY
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

        public double UZ
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

        public double RX
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

        public double RY
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

        public double RZ
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
    }
}
