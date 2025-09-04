using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BH.oM.LifeCycleAssessment.MaterialFragments
{
    [Description("Class containing a set of pre-computed values per metric type for a particular module that can be used to override existing values or fill in missing values where they dont exist. Values should be the resulting total.")]
    public class PrecomputedModuleValues : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Dictionary containing resulting values per metric type for a particular module that can be used to override existing values or fill in missing values where they dont exist. Values should be the resulting total.")]
        public virtual Dictionary<MetricType, double> ModuleValues { get; set; } = new Dictionary<MetricType, double>();

        [Description("If true, any existing values for the module will be overwritten with the pre-computed values. If false, only missing values will be filled in.")]
        public virtual bool OverwriteExistingValues { get; set; } = true;
    }
}
