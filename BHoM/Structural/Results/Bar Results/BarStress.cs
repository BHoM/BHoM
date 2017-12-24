using BH.oM.Base;

using BH.oM.Structural.Loads;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BH.oM.Structural.Results
{
    [Serializable]
    public class BarStress : BarStress<string, string, string>
    {
        public BarStress() : base() { }
        public BarStress(string number, string loadcase, int position, int divisions, string timeStep, double axial, double shearY, double shearZ, double bendingYTop, double bendingYBot, double bendingZTop, double bendingZBot, double combAxialBendingPos, double combAxialBendingNeg)
        : base(number, loadcase, position, divisions, timeStep, axial, shearY, shearZ, bendingYTop, bendingYBot, bendingZTop, bendingZBot, combAxialBendingPos, combAxialBendingNeg)
        { }
    }

    [Serializable]
    public class BarStress<TName, TLoadcase, TTimeStep> : Result<TName, TLoadcase, TTimeStep>
         where TName : IComparable
         where TLoadcase : IComparable
         where TTimeStep : IComparable
    {
        public BarStress()
        { }

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

        public int ForcePosition { get; set; }

        public int Divisions { get; set; }

        public double Axial { get; set; }

        public double ShearY { get; set; }

        public double ShearZ { get; set; }

        public double BendingY_Top { get; set; }

        public double BendingY_Bot { get; set; }

        public double BendingZ_Top { get; set; }

        public double BendingZ_Bot { get; set; }

        public double CombAxialBendingPos { get; set; }

        public double CombAxialBendingNeg { get; set; }


        //public override int CompareTo(object obj)
        //{
        //    var r2 = obj as BarStress<TName, TLoadcase, TTimeStep>;
        //    if (r2 != null)
        //    {
        //        int n = this.Name.CompareTo(r2.Name);
        //        if (n == 0)
        //        {
        //            int l = this.Loadcase.CompareTo(r2.Loadcase);
        //            if (l == 0)
        //            {
        //                int f = this.ForcePosition.CompareTo(r2.ForcePosition);
        //                return f == 0 ? this.TimeStep.CompareTo(r2.TimeStep) : f;
        //            }
        //        }
        //        else
        //        {
        //            return n;
        //        }
        //    }
        //    return 1;
        //}
    }
}