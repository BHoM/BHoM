using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;
using BH.oM.Environment.Interface;

namespace BH.oM.Environment.Elements
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
