using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;

namespace BH.oM.Environment.Results
{
    public class IAnalysisResult : BHoMObject
    {
        public virtual double Result { get; set; } = new double();
    }
}
