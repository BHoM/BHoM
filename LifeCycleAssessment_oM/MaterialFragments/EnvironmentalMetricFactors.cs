using BH.oM.Base;
using BH.oM.LifeCycleAssessment.MaterialFragments.EnvironmentalFactors;
using BH.oM.Quantities.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace BH.oM.LifeCycleAssessment.MaterialFragments
{
    public class EnvironmentalMetricFactors<T> : BHoMObject, IEnvironmentalMetricFactors, IImmutable //,IDynamicObject
        where T : class, IEnvironmentalFactor, new()
    {
        [Description("Enum indicating the metric type the object relates to.")]
        public virtual MetricType MetricType { get; protected set; }

        //[DynamicProperty]
        [Description("Set of factors per module.")]
        public virtual DynamicProperties<LifeCycleAssessmentModule, T> Factors { get; set; } = new DynamicProperties<LifeCycleAssessmentModule, T>();

        public EnvironmentalMetricFactors()
        {
            MetricType = new T().MetricType;
        }
    }

}

