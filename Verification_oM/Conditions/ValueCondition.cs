using System.ComponentModel;

namespace BH.oM.Verification.Conditions
{
    public class ValueCondition : IValueCondition
    {
        /***************************************************/
        /****                Properties                 ****/
        /***************************************************/

        public virtual IValueSource ValueSource { get; set; } = null;

        [Description("Reference Value that the property value should be compared to." +
            "\nIt can be a number, or a DateTime (e.g. ± 1 day), or anything comparable.")]
        public virtual object ReferenceValue { get; set; }

        [Description("Whether the property value should be smaller, greater, etc. than the ReferenceValue.")]
        public virtual ValueComparisonType ComparisonType { get; set; } = ValueComparisonType.EqualTo;

        [Description("If applicable, tolerance to be considered in the comparison." +
            "\nIt can be a number, or a DateTime (e.g. ± 1 day), or anything comparable with the property value.")]
        public virtual object Tolerance { get; set; } = null;

        /***************************************************/
    }
}
