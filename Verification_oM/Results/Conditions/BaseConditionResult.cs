using BH.oM.Verification.Conditions;

namespace BH.oM.Verification.Results
{
    public abstract class BaseConditionResult : IConditionResult
    {
        /***************************************************/
        /****                Properties                 ****/
        /***************************************************/

        //public virtual ICondition Condition { get; } = null;

        public virtual bool? Passed { get; } = false;


        /***************************************************/
        /****                Constructor                ****/
        /***************************************************/

        public BaseConditionResult(/*ICondition condition,*/ bool? passed)
        {
            //Condition = condition;
            Passed = passed;
        }

        /***************************************************/
    }
}
