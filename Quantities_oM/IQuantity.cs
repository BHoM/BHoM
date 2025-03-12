using BH.oM.Base;
using BH.oM.Quantities.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.oM.Quantities
{
    public interface IQuantity : IObject
    {
        double Value { get; set; }
    }
}
