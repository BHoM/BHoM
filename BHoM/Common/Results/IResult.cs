using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Common
{
    public interface IResult : IComparable<IResult>
    {
        string ObjectId { get; set; }

        string Case { get; set; }

        double TimeStep { get; set; }
    }
}
