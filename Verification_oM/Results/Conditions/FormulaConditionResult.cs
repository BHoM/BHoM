using BH.oM.Verification.Conditions;
using System.Collections.Generic;

namespace BH.oM.Verification.Results
{
    public class FormulaConditionResult : BaseConditionResult
    {
        /***************************************************/
        /****                Properties                 ****/
        /***************************************************/

        public Dictionary<string, double> Components { get; } = new Dictionary<string, double>();


        /***************************************************/
        /****                Constructor                ****/
        /***************************************************/

        public FormulaConditionResult(/*FormulaCondition condition,*/ bool? passes, Dictionary<string, double> components) : base(/*condition,*/ passes)
        {
            Components = components;
        }

        /***************************************************/
    }
}
