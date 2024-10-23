using BH.oM.Base;
using BH.oM.Verification.Conditions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.oM.Verification.Reporting
{
    public class ValueConditionReportingConfig : IValueConditionReportingConfig
    {
        /***************************************************/
        /****                Properties                 ****/
        /***************************************************/

        public virtual string ValueSourceLabelOverride { get; set; } = "";

        /***************************************************/
    }
}
