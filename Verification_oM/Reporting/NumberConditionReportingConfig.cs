using System;
using System.Collections.Generic;
using System.Text;

namespace BH.oM.Verification.Reporting
{
    public class NumberConditionReportingConfig : ValueConditionReportingConfig
    {
        /***************************************************/
        /****                Properties                 ****/
        /***************************************************/

        public virtual string UnitLabel { get; set; } = "";

        public virtual double ValueMultiplier { get; set; } = double.NaN;

        public virtual double RoundingAccuracy { get; set; } = double.NaN;

        /***************************************************/
    }
}
