using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Structural.Results
{
    [Serializable] public class NodeReaction : NodeReaction<string, string, string>
    {
        public NodeReaction() : base() { }
        public NodeReaction(string number, string loadcase, string timeStep, double fx, double fy, double fz, double mx, double my, double mz)
            : base(number, loadcase, timeStep, fx, fy, fz, mx, my, mz)
        { }
    }

    [Serializable] public class NodeReaction<TName, TLoadcase, TTimeStep> : Result<TName, TLoadcase, TTimeStep>
         where TName : IComparable
         where TLoadcase : IComparable
         where TTimeStep : IComparable
    {

        public NodeReaction()
        { }

        public NodeReaction(TName number, TLoadcase loadcase, TTimeStep timeStep, double fx, double fy, double fz, double mx, double my, double mz) : this()
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

        public double FX { get; set; }
        
        public double FY { get; set; }
        
        public double FZ { get; set; }
        
        public double MX { get; set; }
        
        public double MY { get; set; }
        
        public double MZ { get; set; }
        
    }
}
