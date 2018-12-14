using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;

namespace BH.oM.Environment.Interface
{
    public interface IMaterialProperties : IBHoMObject
    {
        double Conductivity { get; set; } //Watts per Meter Kelvin
        double SpecificHeat { get; set; }
        double Density { get; set; }
    }
}
