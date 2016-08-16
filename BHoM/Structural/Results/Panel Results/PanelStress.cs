using BHoM.Base.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural.Results
{
    public class PanelStress : Result
    {
        public override string[] ColumnHeaders
        {
            get
            {
                return new string[] { "Id", "Name", "Loadcase", "TimeStep", "Node", "SXX", "SYY", "SXY", "TX", "TY"};
            }
        }

        public override ResultType ResultType
        {
            get
            {
                return ResultType.PanelStress;
            }
        }

        public PanelStress()
        {
            Data = new object[10];
        }

        public PanelStress(object[] data) { Data = data; }

        public PanelStress(int number, int node, int loadcase, int timeStep, double sx, double sy, double sxy, double tx, double ty) : this()
        {
            Name = number;
            TimeStep = timeStep;
            Loadcase = loadcase;
            Node = node;
            Id = Name + ":" + Node + ":" + loadcase + ":" + TimeStep;
            SXX = sx;
            SYY = sy;
            SXY = sxy;
            TX = tx;
            TY = ty;
        }

        public int Node
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

        public double SXX
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

        public double SYY
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

        public double SXY
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

        public double TX
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

        public double TY
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
