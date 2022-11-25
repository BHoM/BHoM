using BH.oM.Analytical.Results;
using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BH.oM.LifeCycleAssessment.Results
{
    [Description("Result for a single element from a Life Cycle Assessment. Contains total value as well as breakdown per Material/Environmental Product Declaration evaluated.")]
    public class ElementResult : IResult, IObjectResult, IResultItem, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Id of the BHoMObject that this result belongs to.")]
        public virtual IComparable ObjectId { get; } = "";

        [Description("Scope the object this result was generated from belongs to, e.g. Foundation or Facade")]
        public virtual ScopeType Scope { get; } = ScopeType.Undefined;

        [Description("Category of the object this result was generated from, e.g. Beam or Wall")]
        public virtual ObjectCategory Category { get; } = ObjectCategory.Undefined;

        [Description("Phase of life abbreviation for the scope of the Environmental Product Declaration. A single EnvironmentalMetric can contain either a single Phase or a list of Phases i.e. A1, A2, A3.")]
        public virtual IReadOnlyList<LifeCycleAssessmentPhases> Phases { get; } = new List<LifeCycleAssessmentPhases>();

        [Description("The total quantity of the specified Field within the object.")]
        public virtual double Quantity { get; set; }

        [Description("The Environmental Product Declaration Field selected for evaluation.")]
        public virtual EnvironmentalProductDeclarationField Metric { get; }

        [Description("Result breakdown per material type.")]
        public virtual IReadOnlyList<MaterialResult> MaterialResults { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public ElementResult(IComparable objectId, ScopeType scope, ObjectCategory category, IReadOnlyList<LifeCycleAssessmentPhases> phases, double quantity, EnvironmentalProductDeclarationField metric, IReadOnlyList<MaterialResult> materialResults)
        {
            ObjectId = objectId;
            Scope = scope;
            Category = category;
            Phases = phases;
            Quantity = quantity;
            Metric = metric;
            MaterialResults = materialResults;
        }

        /***************************************************/
        /**** IComparable Interface                     ****/
        /***************************************************/

        public int CompareTo(IResult other)
        {
            ElementResult otherRes = other as ElementResult;

            if (otherRes == null)
                return this.GetType().Name.CompareTo(other.GetType().Name);

            int m = this.Metric.CompareTo(otherRes.Metric);
            if (m == 0)
            {
                int i = this.ObjectId.CompareTo(otherRes.ObjectId);
                if (i == 0)
                {
                    int s = this.Scope.CompareTo(otherRes.Scope);
                    if (s == 0)
                    {
                        return this.Category.CompareTo(otherRes.Category);
                    }
                    else
                    {
                        return s;
                    }
                }
                else
                {
                    return i;
                }
            }
            else
            {
                return m;
            }
        }

        /***************************************************/
    }
}
