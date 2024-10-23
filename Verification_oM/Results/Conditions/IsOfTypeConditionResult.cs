using BH.oM.Verification.Conditions;
using System;

namespace BH.oM.Verification.Results
{
    public class IsOfTypeConditionResult : BaseConditionResult
    {
        /***************************************************/
        /****                Properties                 ****/
        /***************************************************/

        public virtual Type ExtractedType { get; } = null;


        /***************************************************/
        /****                Constructor                ****/
        /***************************************************/

        public IsOfTypeConditionResult(/*IsOfType condition,*/ bool? passes, Type extractedType) : base(/*condition,*/ passes)
        {
            ExtractedType = extractedType;
        }

        /***************************************************/
    }
}
