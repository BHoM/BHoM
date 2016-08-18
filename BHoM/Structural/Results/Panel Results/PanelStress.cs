using BHoM.Base.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural.Results
{
    public class PanelStress : PanelStress<int, int, int>
    {
        public PanelStress() : base() { }
        public PanelStress(int number, int node, int loadcase, int timeStep, double sxTop, double syTop, double sxyTop, double sxBot, double syBot, double sxyBot, double tx, double ty)
            : base(number, node, loadcase, timeStep, sxTop, syTop, sxyTop, sxBot, syBot, sxyBot, tx, ty)
        { }
    }

    public class PanelStress<TName, TLoadcase, TTimeStep> : Result<TName, TLoadcase, TTimeStep>
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

        public static string[] GetColumnHeaders()
        {            
            return new string[] { "Id", "Name", "Loadcase", "TimeStep", "Node", "SXX_Top", "SYY_Top", "SXY_Top", "SXX_Bot", "SYY_Bot", "SXY_Bot", "TX", "TY"};           
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
            Data = new object[13];
        }

        public PanelStress(object[] data) { Data = data; }

        public PanelStress(TName number, TName node, TLoadcase loadcase, TTimeStep timeStep, double sxTop, double syTop, double sxyTop, double sxBot, double syBot, double sxyBot, double tx, double ty) : this()
        {
            Name = number;
            TimeStep = timeStep;
            Loadcase = loadcase;
            Node = node;
            Id = Name + ":" + Node + ":" + loadcase + ":" + TimeStep;
            SXX_Top = sxTop;
            SYY_Top = syTop;
            SXY_Top = sxyTop;
            SXX_Bot = sxBot;
            SYY_Bot = syBot;
            SXY_Bot = sxyBot;
            TX = tx;
            TY = ty;
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

        public double SXX_Top
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

        public double SYY_Top
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

        public double SXY_Top
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

        public double SXX_Bot
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

        public double SYY_Bot
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

        public double SXY_Bot
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

        public double TX
        {
            get
            {
                return (double)Data[11];
            }
            set
            {
                Data[11] = value;
            }
        }

        public double TY
        {
            get
            {
                return (double)Data[12];
            }
            set
            {
                Data[12] = value;
            }
        }      
    }
}
