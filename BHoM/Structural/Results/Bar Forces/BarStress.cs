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
            Data = new object[15];
        }

        public BarStress(object[] data) { Data = data; }

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
                return (int)Data[4];
            }
            set
            {
                Data[4] = value;
            }
        }

        public int Divisions
        {
            get
            {
                return (int)Data[5];
            }
            set
            {
                Data[5] = value;
            }
        }

        public double Axial
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

        public double ShearY
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

        public double ShearZ
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

        public double BendingY_Top
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

        public double BendingY_Bot
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

        public double BendingZ_Top
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

        public double BendingZ_Bot
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

        public double CombAxialBendingPos
        {
            get
            {
                return (double)Data[13];
            }
            set
            {
                Data[13] = value;
            }
        }

        public double CombAxialBendingNeg
        {
            get
            {
                return (double)Data[14];
            }
            set
            {
                Data[14] = value;
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