using BH.oM.Verification.Conditions;
using System;

namespace BH.oM.Verification.Results
{
    public class IsNotNullResult : IConditionResult
    {
        /***************************************************/
        /****                Properties                 ****/
        /***************************************************/

        public virtual bool? Passed { get; } = false;


        /***************************************************/
        /****                Constructor                ****/
        /***************************************************/

        public IsNotNullResult(bool? passed)
        {
            Passed = passed;
        }

        /***************************************************/
    }
}
