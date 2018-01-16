using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Common;

namespace BH.oM.Structural.Results
{
    interface IStructuralResult : IResult
    {
        string LoadCase { get; set; }

        double TimeStep { get; set; }
    }
}
