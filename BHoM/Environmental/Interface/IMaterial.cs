using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;
using BH.oM.Environmental.Elements;

namespace BH.oM.Environmental.Interface
{
    public interface IMaterial: IBHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        double Thickness { get; set; }
        string Description { get; set; }

        /***************************************************/
    }
}
