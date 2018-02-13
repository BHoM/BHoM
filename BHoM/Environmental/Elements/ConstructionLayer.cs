using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;
using BH.oM.Environmental.Interface;

namespace BH.oM.Environmental.Elements
{
    public class ConstructionLayer: BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public IMaterial Material { get; set; } = new OpaqueMaterial();
        public double Thickness { get; set; } = 0.0;

        /***************************************************/
    }
}
