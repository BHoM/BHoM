using System;
using System.Collections.Generic;
using System.Text;

namespace BH.oM.Verification.Conditions
{
    public interface IValueCondition : ICondition
    {
        /***************************************************/
        /****                Properties                 ****/
        /***************************************************/

        IValueSource ValueSource { get; set; }

        /***************************************************/
    }
}
