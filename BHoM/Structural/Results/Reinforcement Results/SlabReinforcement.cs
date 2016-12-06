using BHoM.Base.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural.Results
{
    public class SlabReinforcement : SlabReinforcement<int, int, int>
    {
        public SlabReinforcement() : base() { }
        public SlabReinforcement(int number, int node, int loadcase, int timeStep, double Axm, double Axp, double Aym, double Ayp)
            : base(number, node, loadcase, timeStep, Axm, Axp, Aym, Ayp)
        { }
    }

    public class SlabReinforcement<TName, TLoadcase, TTimeStep> : Result<TName, TLoadcase, TTimeStep>
         where TName : IComparable
         where TLoadcase : IComparable
         where TTimeStep : IComparable
    {
        public override string[] ColumnHeaders
        {
            get
            {
                return GetColumnHeaders();
            }
        }

        // TODO: don't forget about PanelDirection
        public static string[] GetColumnHeaders()
        {
            return new string[] { "Id", "Name", "Loadcase", "TimeStep", "Node", "AXM", "AXP", "AYM", "AYP" };
        }

        public override ResultType ResultType
        {
            get
            {
                return ResultType.SlabReinforcement;
            }
        }

        public SlabReinforcement()
        {
            Data = new object[9];
        }

        public SlabReinforcement(object[] data) { Data = data; }

        public SlabReinforcement(TName number, TName node, TLoadcase loadcase, TTimeStep timeStep, double axm, double axp, double aym, double ayp) : this()
        {
            Name = number;
            TimeStep = timeStep;
            Loadcase = loadcase;
            Node = node;
            Id = Name + ":" + Node + ":" + loadcase + ":" + TimeStep;
            AXM = axm;
            AXP = axp;
            AYP = aym;
            AYP = ayp;
        }

        public TName Node
        {
            get
            {
                return (TName)Data[4];
            }
            set
            {
                Data[4] = value;
            }
        }

        public double AXM
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
        public double AXP
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
        public double AYM
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
        public double AYP
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
    }
}
