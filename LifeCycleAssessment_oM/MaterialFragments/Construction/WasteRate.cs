using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BH.oM.LifeCycleAssessment.MaterialFragments.Construction
{
    [Description("A class defining the waste rate associated with a construction material.")]
    public class WasteRate : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("The percentage of waste expected during construction, expressed as a value between 0 and 1.")]
        public virtual double Rate { get; set; }

        [Description("The name of the material to which the waste rate applies.")]
        public override string Name { get; set; }

        /***************************************************/
        /**** Explicit Casting                          ****/
        /***************************************************/

        [Description("Constructs a custom waste rate given jsut the rate. Usefull to be able to provide just the rate in UIs.")]
        public static explicit operator WasteRate(double rate)
        {
            return new WasteRate { Rate = rate, Name = "Custom" };
        }

        /***************************************************/
    }
}
