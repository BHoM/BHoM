using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Structural.Results
{
    public class ModalDynamics : StructuralGlobalResult
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public int ModeNumber { get; set; } = 0;

        public double Frequency { get; set; } = 0.0;

        public double ModalMass { get; set; } = 0.0;

        public double ModalStiffness { get; set; } = 0.0;

        public double ModalDamping { get; set; } = 0.0;

        public double MassRatioX { get; set; } = 0.0;

        public double MassRatioY { get; set; } = 0.0;

        public double MassRatioZ { get; set; } = 0.0;

        public double InertiaRatioX { get; set; } = 0.0;

        public double InertiaRatioY { get; set; } = 0.0;

        public double InertiaRatioZ { get; set; } = 0.0;

        /***************************************************/
    }
}
