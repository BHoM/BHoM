using BH.oM.Base.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BH.oM.Facade.Enums
{
    public enum BuildingCode
    {
        [DisplayText("BS EN 1990:2002")]
        BSEN19902002,
        ASCE705,
        ASCE710,
        ASCE716 
    }
}
