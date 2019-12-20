using BH.oM.Base;
using BH.oM.Data.Library;
using System;
using System.Collections.Generic;

namespace BH.oM.Data.Library
{
    public class DataPoint : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Source SourceInformation { get; set; }

        public System.DateTime TimeOfCreation { get; set; }

        public object Value { get; set; }

    }
}
