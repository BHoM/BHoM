using BH.oM.Base;
using BH.oM.Verification.Conditions;

namespace BH.oM.Verification.Results
{
    public interface IConditionResult : IImmutable
    {
        /***************************************************/
        /****                Properties                 ****/
        /***************************************************/

        bool? Passed { get; }

        /***************************************************/
    }
}
