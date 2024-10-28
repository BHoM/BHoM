using BH.oM.Verification.Conditions;
using System.Collections.Generic;

namespace BH.oM.Verification.Results
{
    public class LogicalCollectionConditionResult : IConditionResult
    {
        /***************************************************/
        /****                Properties                 ****/
        /***************************************************/

        public virtual bool? Passed { get; } = false;

        public virtual List<IConditionResult> Results { get; } = new List<IConditionResult>();


        /***************************************************/
        /****                Constructor                ****/
        /***************************************************/

        public LogicalCollectionConditionResult(bool? passed, List<IConditionResult> results)
        {
            Passed = passed;
            Results = results;
        }

        /***************************************************/
    }
}
