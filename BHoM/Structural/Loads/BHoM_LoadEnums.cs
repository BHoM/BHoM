using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural.Loads
{
    public enum CaseType
    {
        Simple = 0,
        Combination,
        Mobile,
        Envelope
    }

    public enum LoadNature
    {
        Dead = 0,
        Live,
        Wind,
        Seismic,
        Temperature,
        Snow,
        Other
    }

    public enum LoadType
    {
        Selfweight = 0,
        PointForce,
        PointMass,
        UniformLine,
        UniformArea,
        ThermalLine,
        ThermaleArea,
        Pressure
    }
}
