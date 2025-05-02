using BH.oM.Base;
using BH.oM.Quantities.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace BH.oM.LifeCycleAssessment.MaterialFragments
{
    [Description("Base interface for class storing Environmental Impact Factors of a specific type relating to modules.")]
    public interface IEnvironmentalMetricFactors : IObject
    {
        MetricType MetricType { get;  }
    }

}
