using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;

namespace BH.oM.Environment.Results
{
    public class TimeIndexResult : BHoMObject
    {
        public virtual List<IAnalysisResult> Results { get; set; } = new List<IAnalysisResult>();

        public virtual double TimeIndex { get; set; } = new double();
    }
}
