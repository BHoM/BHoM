using System;
using System.Collections.Generic;
using System.Text;

namespace BH.oM.Verification.Reporting
{
    public interface IValueConditionReportingConfig : IConditionReportingConfig
    {
        /***************************************************/
        /****                Properties                 ****/
        /***************************************************/

        string ValueSourceLabelOverride { get; set; }

        /***************************************************/
    }
}
