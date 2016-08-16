using BHoM.Base.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural.Results
{
    public class NodeAcceleration : Result
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
