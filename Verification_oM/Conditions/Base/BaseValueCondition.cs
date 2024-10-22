﻿using BH.oM.Base;
using BH.oM.Data.Library;
using BH.oM.Verification.Conditions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BH.oM.Verification.Conditions
{
    public abstract class BaseValueCondition : BaseCondition, IValueCondition
    {
        /***************************************************/
        /****                Properties                 ****/
        /***************************************************/

        public virtual IValueSource ValueSource { get; set; } = null;

        /***************************************************/
    }
}
