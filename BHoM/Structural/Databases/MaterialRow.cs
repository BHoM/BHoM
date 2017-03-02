using BHoM.Base.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural.Databases
{
    public class MaterialRow : IDataRow
    {
        public string Name
        {
            get;

            set;
        }

        public string Type
        {
            get;

            set;
        }

        public int Id { get; set; }   
        public string Grade { get; set; }
        public string IsDefault { get; set; }
        public double Weight { get; set; }
        public double Mass { get; set; }
        public double YoungsModulus { get; set; }
        public double PoissonsRatio { get; set; }
        public double CoefOfThermalExpansion { get; set; }
        public double MinimumYieldStress { get; set; }
        public double MinimumTensileStress { get; set; }
        public double EffectiveYieldStress { get; set; }
        public double EffectiveTensileStress { get; set; }
        public double CompressiveStrength { get; set; }
        public double StrainAtUltimate { get; set; }

    }
}
