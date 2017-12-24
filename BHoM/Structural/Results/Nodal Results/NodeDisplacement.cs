using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Structural.Results
{
    [Serializable]
    public class NodeDisplacement : NodeDisplacement<string, string, string>
    {
        public NodeDisplacement() : base() { }
        public NodeDisplacement(string number, string loadcase, string timeStep, double fx, double fy, double fz, double mx, double my, double mz)
            : base(number, loadcase, timeStep, fx, fy, fz, mx, my, mz)
        { }
    }

    [Serializable]
    public class NodeDisplacement<TName, TLoadcase, TTimeStep> : Result<TName, TLoadcase, TTimeStep>
         where TName : IComparable
         where TLoadcase : IComparable
         where TTimeStep : IComparable
    {
        public NodeDisplacement()
        { }


        public NodeDisplacement(TName number, TLoadcase loadcase, TTimeStep timeStep, double fx, double fy, double fz, double mx, double my, double mz) : this()
        {
            Name = number;
            TimeStep = timeStep;
            Loadcase = loadcase;
            Id = Name + ":" + loadcase + ":" + TimeStep;
            UX = fx;
            UY = fy;
            UZ = fz;
            RX = mx;
            RY = my;
            RZ = mz;
        }

        public double UX { get; set; }

        public double UY { get; set; }

        public double UZ { get; set; }

        public double RX { get; set; }

        public double RY { get; set; }

        public double RZ { get; set; }

    }
}
