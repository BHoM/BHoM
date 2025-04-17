using BH.oM.Base;
using BH.oM.Quantities.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BH.oM.Quantities
{
    [Description("Represents a numerical value with an SI unit attached to it.")]
    public interface IQuantity : IObject
    {
        double Value { get; set; }
    }
}
