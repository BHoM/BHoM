using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;
using BH.oM.Environment.Interface;

namespace BH.oM.Environment.Properties
{
    public class BuildingPanelProperties : BHoMObject
    {
        //Detail Surface Results
        public double ApertureFlowIn { get; set; } = 0.0;
        public double ApertureFlowOut { get; set; } = 0.0;
        public double ApertureOpening { get; set; } = 0.0;
        public double ExternalCondensation { get; set; } = 0.0;
        public double ExternalConduction { get; set; } = 0.0;
        public double ExternalConvection { get; set; } = 0.0;
        public double ExternalLongWave { get; set; } = 0.0;
        public double ExternalSolar { get; set; } = 0.0;
        public double ExternalTemperature { get; set; } = 0.0;
        public double InternalCondensation { get; set; } = 0.0;
        public double InternalConduction { get; set; } = 0.0;
        public double InternalConvection { get; set; } = 0.0;
        public double InternalLongWave { get; set; } = 0.0;
        public double InternalSolar { get; set; } = 0.0;
        public double InternalTemperature { get; set; } = 0.0;
        public double InterstitialCondensation { get; set; } = 0.0;

        //Boolean to toggle detail surface output
        public bool SurfaceOutput { get; set; } = true;
    }
}
