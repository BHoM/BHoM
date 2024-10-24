using System.Collections.Generic;

namespace BH.oM.Verification.Results
{
    public class FormulaConditionResult
    {
        /***************************************************/
        /****                Properties                 ****/
        /***************************************************/

        public virtual bool? Passed { get; } = false;

        public Dictionary<string, double> Components { get; } = new Dictionary<string, double>();

        /***************************************************/
        /****                Constructor                ****/
        /***************************************************/

        public FormulaConditionResult(bool? passed, Dictionary<string, double> components)
        {
            Passed = passed;
            Components = components;
        }

        /***************************************************/
    }
}
