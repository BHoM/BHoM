using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural.Results.Nodal_Results
{
    public class NodeReaction : Result
    {
        public override string[] ColumnHeaders
        {
            get
            {
                return new string[] { "Id", "Name", "Loadcase", "TimeStep", "FX", "FY", "FZ", "MX", "MY", "MZ" };
            }
        }

        public NodeReaction()
        {
            Data = new object[10];
        }

        public NodeReaction(object[] data) { Data = data; }

        public NodeReaction(int number, int loadcase, int timeStep, float fx, float fy, float fz, float mx, float my, float mz) : this()
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

        public float FX
        {
            get
            {
                return (float)Data[4];
            }
            set
            {
                Data[5] = value;
            }
        }

        public float FY
        {
            get
            {
                return (float)Data[5];
            }
            set
            {
                Data[5] = value;
            }
        }

        public float FZ
        {
            get
            {
                return (float)Data[6];
            }
            set
            {
                Data[6] = value;
            }
        }

        public float MX
        {
            get
            {
                return (float)Data[7];
            }
            set
            {
                Data[7] = value;
            }
        }

        public float MY
        {
            get
            {
                return (float)Data[8];
            }
            set
            {
                Data[8] = value;
            }
        }

        public float MZ
        {
            get
            {
                return (float)Data[9];
            }
            set
            {
                Data[9] = value;
            }
        }
    }
}
