using BH.oM.Verification.Conditions;

namespace BH.oM.Verification.Results
{
    public class ValueConditionResult : IConditionResult
    {
        /***************************************************/
        /****                Properties                 ****/
        /***************************************************/

        public virtual bool? Passed { get; } = false;

        public virtual object ExtractedValue { get; } = null;


        /***************************************************/
        /****                Constructor                ****/
        /***************************************************/

        public ValueConditionResult(bool? passed, object extractedValue)
        {
            Passed = passed;
            ExtractedValue = extractedValue;
        }

        /***************************************************/
    }
}
