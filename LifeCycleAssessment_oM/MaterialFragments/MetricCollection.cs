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
    public class MetricCollection<T> : BHoMObject, IMetricCollection where T : IMetric, new()
    {
        [Description("Enum indicating the metric type the object relates to.")]
        public virtual EnvironmentalMetrics MetricType { get; protected set; }

        public virtual IReadOnlyDictionary<LifeCycleAssessmentModule, T> Metrics { get; set; }
    }

    public interface IMetricCollection : IObject
    {

    }

    public class MetricCollection2<T> : Dictionary<LifeCycleAssessmentModule, T>, IMetricCollection<T> where T : EnvironmentalMetric
    {

    }

    public interface IMetricCollection<out T> : IMetricCollection, IDictionary, IEnumerable where T : EnvironmentalMetric
    {
        T this[LifeCycleAssessmentModule module] { get; }
    }



    //public class PhaseMetricPair<T> : IPhaseMetricPair<T>, IImmutable where T : EnvironmentalMetric
    //{ 
    //    public virtual LifeCycleAssessmentModule Module { get; }
    //    public virtual T Metric { get; }
    //}

    //public interface IPhaseMetricPair<out T> : IObject where T : EnvironmentalMetric
    //{
    //    LifeCycleAssessmentModule Module { get; }
    //    T Metric { get; }
    //}

    public abstract class QuantityValue<T> : IObject, IImmutable where T : QuantityValue<T>, new()
    {
        public abstract double Value { get; protected set; }

        public QuantityValue(double value)
        {
            Value = value;
        }

        public QuantityValue()
        {

        }

        public static explicit operator double(QuantityValue<T> value)
        {
            return value.Value;
        }

        public static explicit operator QuantityValue<T>(double value)
        {
            return new T { Value = value };
        }

        public static T operator +(QuantityValue<T> a, QuantityValue<T> b)
        {
            return new T { Value = a.Value + b.Value };
        }

        public static T operator -(QuantityValue<T> a, QuantityValue<T> b)
        {
            return new T { Value = a.Value - b.Value };
        }

        public static T operator *(QuantityValue<T> a, double factor)
        {
            return new T { Value = a.Value * factor };
        }

        public static T operator /(QuantityValue<T> a, double denominator)
        {
            return new T { Value = a.Value / denominator };
        }
    }

    public interface IMetric
    {
        double Value { get; }
    }

    public abstract class Metric<T> : QuantityValue<T>, IMetric where T : Metric<T>, new()
    {

    }

    public class ClimateChangeMetric : Metric<ClimateChangeMetric>
    {
        [ClimateChange]
        public override double Value { get; protected set; }

        private void Test()
        {
            ClimateChangeMetric a = (ClimateChangeMetric)6;
            ClimateChangeMetric b = (ClimateChangeMetric)7;

            ClimateChangeMetric c = a + b;
        }
    }


}
