using BH.oM.Verification.Conditions;

namespace BH.oM.Verification.Results
{
    public class SingleLogicalConditionResult : IConditionResult
    {
        /***************************************************/
        /****                Properties                 ****/
        /***************************************************/

        public virtual bool? Passed { get; } = false;

        public virtual IConditionResult Result { get; set; } = null;


        /***************************************************/
        /****                Constructor                ****/
        /***************************************************/

        public SingleLogicalConditionResult(bool? passed, IConditionResult result)
        {
            Passed = passed;
            Result = result;
        }

        /***************************************************/
    }
}
