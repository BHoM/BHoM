using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Structural.Results
{
    public class NodeAcceleration : NodeAcceleration<int, int, int>
    {
        public NodeAcceleration() : base() { }
        public NodeAcceleration(int number, int loadcase, int timeStep, double fx, double fy, double fz, double mx, double my, double mz)
            //: base(number, loadcase, timeStep, fx, fy, fz, mx, my, mz)
        { }
    }

    public class NodeAcceleration<TName, TLoadcase, TTimeStep> : Result<TName, TLoadcase, TTimeStep>
         where TName : IComparable
         where TLoadcase : IComparable
         where TTimeStep : IComparable
    {
        public override string[] ColumnHeaders
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override ResultType ResultType
        {
            get
            {
                return ResultType.NodeAcceleration;
            }
        }
    }
}
