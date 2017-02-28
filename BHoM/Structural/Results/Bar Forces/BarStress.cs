using BHoM.Base;
using BHoM.Base.Results;
using BHoM.Global;
using BHoM.Structural.Loads;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BHoM.Structural.Results
{
    public class BarStress : BarStress<string, string, string>
    {
        public BarStress() : base() { }
        public BarStress(string number, string loadcase, int position, int divisions, string timeStep, double axial, double shearY, double shearZ, double bendingYTop, double bendingYBot, double bendingZTop, double bendingZBot, double combAxialBendingPos, double combAxialBendingNeg)
        : base(number, loadcase, position, divisions, timeStep, axial, shearY, shearZ, bendingYTop, bendingYBot, bendingZTop, bendingZBot, combAxialBendingPos, combAxialBendingNeg)
        { }
    }

    public class BarStress<TName, TLoadcase, TTimeStep> : Result<TName, TLoadcase, TTimeStep>
         where TName : IComparable
         where TLoadcase : IComparable
         where TTimeStep : IComparable
    {
        public BarStress()
        {
            m_data = new object[15];
        }

        public BarStress(object[] data) { m_data = data; }

        public BarStress(TName number, TLoadcase loadcase, int position, int divisions, TTimeStep timeStep, double axial, double shearY, double shearZ, double bendingYTop, double bendingYBot, double bendingZTop, double bendingZBot, double combAxialBendingPos, double combAxialBendingNeg) : this()
        {
            Name = number;
            ForcePosition = position;
            TimeStep = timeStep;
            Loadcase = loadcase;
            Id = Name + ":" + loadcase + ":" + ForcePosition + ":" + TimeStep;
            Divisions = divisions;
            Axial = axial;
            ShearY = shearY;
            ShearZ = shearZ;
            BendingY_Top = bendingYTop;
            BendingY_Bot = bendingYBot;
            BendingZ_Top = bendingZTop;
            BendingZ_Bot = bendingZBot;
            CombAxialBendingPos = combAxialBendingPos;
            CombAxialBendingNeg = combAxialBendingNeg;

        }

        public override string[] ColumnHeaders
        {
            get
            {
                return new string[] { "Id",
                    "Name",
                    "Loadcase",
                    "TimeStep",
                    "ForcePosition",
                    "Divisions",
                    "Axial",
                    "ShearY",
                    "ShearZ",
                    "BendingY_Top",
                    "BendingY_Bot",
                    "BendingZ_Top",
                    "BendingZ_Bot",
                    "CombAxialBendingPos",
                    "CombAxialBendingNeg"};
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

        public double Axial
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

        public double ShearY
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

        public double ShearZ
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

        public double BendingY_Top
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

        public double BendingY_Bot
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

        public double BendingZ_Top
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

        public double BendingZ_Bot
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

        public double CombAxialBendingPos
        {
            get
            {
                return (double)m_data[13];
            }
            set
            {
                m_data[13] = value;
            }
        }

        public double CombAxialBendingNeg
        {
            get
            {
                return (double)m_data[14];
            }
            set
            {
                m_data[14] = value;
            }
        }

        public int CompareTo(object obj)
        {
            var r2 = obj as BarStress<TName, TLoadcase, TTimeStep>;
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
                }
                else
                {
                    return n;
                }
            }
            return 1;
        }
    }
}