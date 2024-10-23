using BH.oM.Verification.Conditions;

namespace BH.oM.Verification.Results
{
    public class SingleLogicalConditionResult : BaseConditionResult
    {
        /***************************************************/
        /****                Properties                 ****/
        /***************************************************/

        public virtual IConditionResult Result { get; set; } = null;


        /***************************************************/
        /****                Constructor                ****/
        /***************************************************/

        public SingleLogicalConditionResult(/*ISingleLogicalCondition condition,*/ bool? passes, IConditionResult result) : base(/*condition,*/ passes)
        {
            Result = result;
        }

        /***************************************************/
    }
}
