using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;
using BH.oM.Environment.Interface;

namespace BH.oM.Environment.Properties
{
    public class EmitterProperties : BHoMObject, IEquipmentProperties
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double RadiantProportion { get; set; } = 0.0;
        public double ViewCoefficient { get; set; } = 0.0;
        public double MaxOutsideTemp { get; set; } = 0.0;
        public double SwitchOffOutsideTemp { get; set; } = 0.0;

        /***************************************************/
    }
}
