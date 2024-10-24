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

        //TODO: write explicitly that it also calls methods and looks at fragments (??)
        public virtual string PropertyName { get; set; } = "";

        /***************************************************/
    }
}
