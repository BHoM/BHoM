using BH.oM.Verification.Conditions;
using System.Collections.Generic;

namespace BH.oM.Verification.Results
{
    public class LogicalCollectionConditionResult : BaseConditionResult
    {
        /***************************************************/
        /****                Properties                 ****/
        /***************************************************/

        public virtual List<IConditionResult> Results { get; } = new List<IConditionResult>();


        /***************************************************/
        /****                Constructor                ****/
        /***************************************************/

        public LogicalCollectionConditionResult(/*ILogicalCollectionCondition condition,*/ bool? passes, List<IConditionResult> results) : base(/*condition,*/ passes)
        {
            Results = results;
        }

        /***************************************************/
    }
}
