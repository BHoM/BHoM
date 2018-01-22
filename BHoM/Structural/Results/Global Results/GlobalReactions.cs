using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Base;

namespace BH.oM.Structural.Results
{
    public class GlobalReactions : StructuralGlobalResult
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double FX { get; set; } = 0.0;

        public double FY { get; set; } = 0.0;

        public double FZ { get; set; } = 0.0;

        public double FTot { get; set; } = 0.0;

        public double MX { get; set; } = 0.0;

        public double MY { get; set; } = 0.0;

        public double MZ { get; set; } = 0.0;

        public double MTot { get; set; } = 0.0;

        /***************************************************/
    }
}
