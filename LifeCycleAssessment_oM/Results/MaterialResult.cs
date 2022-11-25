using BH.oM.Analytical.Results;
using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BH.oM.LifeCycleAssessment.Results
{
    [Description("Life Cycle Assessment result for a Material/Environmental Product Declaration evaluated.")]
    public class MaterialResult : IResult, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Name of the physical material evaluated.")]
        public virtual string MaterialName { get; }

        [Description("Name of the Environmental Product Declaration evaluated.")]
        public virtual string EnvironmentalProductDeclarationName { get; }

        [Description("The total quantity of the specified Field within the object.")]
        public virtual double Quantity { get; }

        [Description("Phase of life abbreviation for the scope of the Environmental Product Declaration. A single EnvironmentalMetric can contain either a single Phase or a list of Phases i.e. A1, A2, A3.")]
        public virtual IReadOnlyList<LifeCycleAssessmentPhases> Phases { get; }

        [Description("The Environmental Product Declaration Field selected for evaluation.")]
        public virtual EnvironmentalProductDeclarationField Metric { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public MaterialResult(string materialName, string environmentalProductDeclarationName, IReadOnlyList<LifeCycleAssessmentPhases> phases, double quantity, EnvironmentalProductDeclarationField metric)
        {
            MaterialName = materialName;
            EnvironmentalProductDeclarationName = environmentalProductDeclarationName;
            Phases = phases;
            Quantity = quantity;
            Metric = metric;
        }

        /***************************************************/
        /**** IComparable Interface                     ****/
        /***************************************************/

        public int CompareTo(IResult other)
        {
            MaterialResult otherRes = other as MaterialResult;

            if (otherRes == null)
                return this.GetType().Name.CompareTo(other.GetType().Name);

            int n = this.Metric.CompareTo(otherRes.Metric);
            if (n == 0)
            {
                int l = this.MaterialName.CompareTo(otherRes.MaterialName);
                if (l == 0)
                {
                    return this.MaterialName.CompareTo(otherRes.MaterialName);
                }
                else
                {
                    return l;
                }
            }
            else
            {
                return n;
            }
        }

        /***************************************************/
    }
}
