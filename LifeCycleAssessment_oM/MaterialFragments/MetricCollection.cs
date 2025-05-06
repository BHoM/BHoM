using BH.oM.Base;
using BH.oM.LifeCycleAssessment.MaterialFragments.EnvironmentalFactors;
using BH.oM.Quantities.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BH.oM.LifeCycleAssessment.MaterialFragments
{
    //public class MetricCollection<T> : BHoMObject, IMetricCollection where T : IMetric, new()
    //{
    //    [Description("Enum indicating the metric type the object relates to.")]
    //    public virtual EnvironmentalMetrics MetricType { get; protected set; }

    //    public virtual IReadOnlyDictionary<LifeCycleAssessmentModule, T> Metrics { get; set; }
    //}

    //public interface IMetricCollection : IObject
    //{

    //}

    public class Test<T> where T : class, IEnvironmentalFactor, new()
    {
        public virtual IReadOnlyDynamicProperties<Module, IEnvironmentalFactor> Factors { get; set; } = new DynamicProperties<Module, T>();
    }

    public class DynamicProperties<TKey, TValue> : Dictionary<TKey, TValue>, IReadOnlyDynamicProperties<TKey, TValue> where TKey : Enum
    {
        IEnumerator<IPair<TKey, TValue>> IEnumerable<IPair<TKey, TValue>>.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<TKey, TValue>>)this).Select(x => new Pair<TKey, TValue> { Key = x.Key, Value = x.Value }).GetEnumerator();
        }
    }

    public interface IReadOnlyDynamicProperties<TKey, out TValue> : IDictionary, IEnumerable<IPair<TKey, TValue>> where TKey : Enum
    {
        TValue this[TKey module] { get; }
        bool ContainsKey(TKey module);
    }

    public interface IPair<TKey, out TValue>
    { 
        TKey Key { get; }
        TValue Value { get; }
    }

    public class Pair<TKey, TValue> : IPair<TKey, TValue>
    { 
        public virtual TKey Key { get; set; }
        public virtual TValue Value { get; set; }
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
