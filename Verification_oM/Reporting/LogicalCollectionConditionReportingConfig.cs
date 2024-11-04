using BH.oM.Verification.Conditions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.oM.Verification.Reporting
{
    public class LogicalCollectionConditionReportingConfig : IConditionReportingConfig
    {
        /***************************************************/
        /****                Properties                 ****/
        /***************************************************/

        public virtual Dictionary<ICondition, IConditionReportingConfig> NestedConfigs { get; set; } = new Dictionary<ICondition, IConditionReportingConfig>();

        /***************************************************/
    }
}
