using BH.oM.Data.Library;
using BH.oM.Verification.Conditions;
using BH.oM.Verification.Requirements;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.oM.Verification.Extraction
{
    public interface IConditionBasedFilter : IExtraction
    {
        /***************************************************/
        /****                Properties                 ****/
        /***************************************************/

        ICondition Condition { get; set; }

        /***************************************************/
    }
}
