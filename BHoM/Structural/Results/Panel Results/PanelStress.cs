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
            m_data = new object[13];
        }

        public PanelStress(object[] data) { m_data = data; }

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
                return (TName)m_data[4];
            }
            set
            {
                m_data[4] = value;
            }
        }

        public double SXX_Top
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

        public double SYY_Top
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

        public double SXY_Top
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

        public double SXX_Bot
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

        public double SYY_Bot
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

        public double SXY_Bot
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

        public double TX
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

        public double TY
        {
            get
            {
                return (double)m_data[12];
            }
            set
            {
                m_data[12] = value;
            }
        }      
    }
}
