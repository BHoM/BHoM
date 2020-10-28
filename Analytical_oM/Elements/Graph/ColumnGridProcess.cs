using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Analytical.Elements
{
    public class ColumnGridProcess : BHoMObject, IProcess
    {
        public virtual double Tolerance { get; set; } = 1e-6;
    }
}
