using BH.oM.Verification.Conditions;
using System;

namespace BH.oM.Verification.Results
{
    public class IsOfTypeConditionResult : IConditionResult
    {
        /***************************************************/
        /****                Properties                 ****/
        /***************************************************/

        public virtual bool? Passed { get; } = false;

        public virtual Type ExtractedType { get; } = null;


        /***************************************************/
        /****                Constructor                ****/
        /***************************************************/

        public IsOfTypeConditionResult(bool? passed, Type extractedType)
        {
            Passed = passed;
            ExtractedType = extractedType;
        }

        /***************************************************/
    }
}
