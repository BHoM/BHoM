using System;

namespace BH.oM.Structural.Results
{
    public class NodeVelocity : NodeVelocity<int, int, int>
    {
        public NodeVelocity() : base() { }
        public NodeVelocity(int number, int loadcase, int timeStep, double fx, double fy, double fz, double mx, double my, double mz)
            //: base(number, loadcase, timeStep, fx, fy, fz, mx, my, mz)
        { }
    }

    public class NodeVelocity<TName, TLoadcase, TTimeStep> : Result<TName, TLoadcase, TTimeStep>
         where TName : IComparable
         where TLoadcase : IComparable
         where TTimeStep : IComparable
    { }
    
}
