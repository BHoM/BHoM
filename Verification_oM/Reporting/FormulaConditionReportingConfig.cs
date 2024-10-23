using System;
using System.Collections.Generic;
using System.Text;

namespace BH.oM.Verification.Reporting
{
    public class FormulaConditionReportingConfig : IConditionReportingConfig
    {
        /***************************************************/
        /****                Properties                 ****/
        /***************************************************/

        public Dictionary<string, NumberConditionReportingConfig> ComponentConfigs = new Dictionary<string, NumberConditionReportingConfig>();

        /***************************************************/
    }
}
