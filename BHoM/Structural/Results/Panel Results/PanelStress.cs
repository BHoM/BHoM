using System;

namespace BH.oM.Structural.Results
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

        public PanelStress()
        { }

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

        public TName Node { get; set; }

        public double SXX_Top { get; set; }
        
        public double SYY_Top { get; set; }
        
        public double SXY_Top { get; set; }
        
        public double SXX_Bot { get; set; }
        
        public double SYY_Bot { get; set; }
        
        public double SXY_Bot { get; set; }
        
        public double TX { get; set; }

        public double TY { get; set; }      
    }
}
