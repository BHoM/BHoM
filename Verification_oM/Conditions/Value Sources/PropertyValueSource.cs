using BH.oM.Verification.Conditions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.oM.Verification.Conditions
{
    public class PropertyValueSource : IValueSource
    {
        /***************************************************/
        /****                Properties                 ****/
        /***************************************************/

        public virtual string PropertyName { get; set; } = "";

        /***************************************************/
    }
}
