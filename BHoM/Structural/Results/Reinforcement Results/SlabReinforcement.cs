using System;

namespace BH.oM.Structural.Results
{
    public class SlabReinforcement : SlabReinforcement<int, int, int>
    {
        public SlabReinforcement() : base() { }
        public SlabReinforcement(int number, int node, int loadcase, int timeStep, double Axp, double Axm, double Ayp, double Aym)
            : base(number, node, loadcase, timeStep, Axp, Axm, Ayp, Aym)
        { }
    }

    public class SlabReinforcement<TName, TLoadcase, TTimeStep> : Result<TName, TLoadcase, TTimeStep>
         where TName : IComparable
         where TLoadcase : IComparable
         where TTimeStep : IComparable
    {

        public SlabReinforcement()
        { }

        public SlabReinforcement(TName number, TName node, TLoadcase loadcase, TTimeStep timeStep, double axp, double axm, double ayp, double aym) : this()
        {
            Name = number;
            TimeStep = timeStep;
            Loadcase = loadcase;
            Node = node;
            Id = Name + ":" + Node + ":" + loadcase + ":" + TimeStep;
            AXP = axp;
            AXM = axm;
            AYP = ayp;
            AYM = aym;
            //DirX = dirx;
        }

        public TName Node { get; set; }
        
        public double AXP { get; set; }
        
        public double AXM { get; set; }
        
        public double AYP { get; set; }
        
        public double AYM { get; set; }

        //public override int CompareTo(object obj)
        //{
        //    var r2 = obj as SlabReinforcement<TName, TLoadcase, TTimeStep>;
        //    if (r2 != null)
        //    {
        //        int n = this.Name.CompareTo(r2.Name);
        //        if (n == 0)
        //        {
        //            int l = this.Loadcase.CompareTo(r2.Loadcase);
        //            if (l == 0)
        //            {
        //                int no = this.Node.CompareTo(r2.Node);
        //                return no == 0 ? this.TimeStep.CompareTo(r2.TimeStep) : no;
        //            }
        //            else
        //            {
        //                return l;
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

