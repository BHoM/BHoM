using BHoM.Base.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural.Results
{
    public class NodeDisplacement : NodeDisplacement<string, string, string>
    {
        public NodeDisplacement() : base() { }
        public NodeDisplacement(string number, string loadcase, string timeStep, double fx, double fy, double fz, double mx, double my, double mz)
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
            m_data = new object[10];
        }

        public NodeDisplacement(object[] data) { m_data = data; }

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
                return (double)m_data[4];
            }
            set
            {
                m_data[4] = value;
            }
        }

        public double UY
        {
            get
            {
                return (double)m_data[5];
            }
            set
            {
                m_data[5] = value;
            }
        }

        public double UZ
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

        public double RX
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

        public double RY
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

        public double RZ
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
    }
}
