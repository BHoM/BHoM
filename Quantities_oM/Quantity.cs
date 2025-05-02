using BH.oM.Base;
using BH.oM.Quantities.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;

namespace BH.oM.Quantities
{

    public class Quantity<T> : IQuantity, IObject where T : QuantityAttribute, new()
    {
        public virtual double Value { get; set; } = 0;


        /***************************************************/
        /**** Explicit Casting                          ****/
        /***************************************************/

        public static explicit operator Quantity<T>(double value)
        {
            return new Quantity<T> { Value = value };
        }

        /***************************************************/
    }

}
