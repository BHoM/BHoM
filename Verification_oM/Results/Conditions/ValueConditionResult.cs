using BH.oM.Verification.Conditions;

namespace BH.oM.Verification.Results
{
    public class ValueConditionResult : BaseConditionResult
    {
        /***************************************************/
        /****                Properties                 ****/
        /***************************************************/

        public virtual object ExtractedValue { get; } = null;


        /***************************************************/
        /****                Constructor                ****/
        /***************************************************/

        public ValueConditionResult(IValueCondition condition, bool? passes, object extractedValue) : base(condition, passes)
        {
            ExtractedValue = extractedValue;
        }
    }
}
