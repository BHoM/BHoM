using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.oM.Verification.Conditions
{
    public interface ILogicalCollectionCondition : ILogicalCondition
    {
        /***************************************************/
        /****                Properties                 ****/
        /***************************************************/

        List<ICondition> Conditions { get; set; }

        /***************************************************/
    }
}
