using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Structural.Results
{
    public class NodeReaction : NodeReaction<string, string, string>
    {
        public NodeReaction() : base() { }
        public NodeReaction(string number, string loadcase, string timeStep, double fx, double fy, double fz, double mx, double my, double mz)
            : base(number, loadcase, timeStep, fx, fy, fz, mx, my, mz)
        { }
    }

    public class NodeReaction<TName, TLoadcase, TTimeStep> : Result<TName, TLoadcase, TTimeStep>
         where TName : IComparable
         where TLoadcase : IComparable
         where TTimeStep : IComparable
    {
        public override string[] ColumnHeaders
        {
            get
            {
                return new string[] { "Id", "Name", "Loadcase", "TimeStep", "FX", "FY", "FZ", "MX", "MY", "MZ" };
            }
        }

        public override ResultType ResultType
        {
            get
            {
                return ResultType.NodeReaction;
            }
        }

        public NodeReaction()
        {
            m_data = new object[10];
        }

        public NodeReaction(object[] data) { m_data = data; }

        public NodeReaction(TName number, TLoadcase loadcase, TTimeStep timeStep, double fx, double fy, double fz, double mx, double my, double mz) : this()
        {
            Name = number;
            TimeStep = timeStep;
            Loadcase = loadcase;
            Id = Name + ":" + loadcase + ":" + TimeStep;
            FX = fx;
            FY = fy;
            FZ = fz;
            MX = mx;
            MY = my;
            MZ = mz;
        }

        public double FX
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

        public double FY
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

        public double FZ
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

        public double MX
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

        public double MY
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

        public double MZ
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
