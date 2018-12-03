using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;
using BH.oM.Environment.Interface;
using BH.oM.Environment.Materials;
using BH.oM.Environment.Properties;

namespace BH.oM.Environment.Elements
{
    public class Construction : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<IMaterial> Materials { get; set; } = new List<IMaterial>();
        public double Thickness { get; set; } = 0.0;
        public List<double> UValues { get; set; } = new List<double>();
        public ConstructionType ConstructionType { get; set; } = ConstructionType.Opaque;
        public double AdditionalHeatTransfer { get; set; } = 0.0;
        public double FFactor { get; set; } = 0.0; //Watts per Meter per Degrees Celsius (w/m degC)

        /***************************************************/
    }
}
