using BH.oM.Base;
using System.ComponentModel;

namespace BH.oM.Structure.FloorSystem
{
    public class PopulateOptions : IObject
    {
        /***************************************************/
        /****            Public Properties              ****/
        /***************************************************/

        [Description("Output all objects in one plane, best for FE. Defaults to false; objects will be output at their physical elevations.")]
        public virtual bool AtCenterLine { get; set; } = false;

        [Description("Include south primary girder; true by default.")]
        public virtual bool IncludeSGirder { get; set; } = true;

        [Description("Include west secondary girder; true by default.")]
        public virtual bool IncludeWGirder { get; set; } = true;

        [Description("Include north primary girder; false by default.")]
        public virtual bool IncludeNGirder { get; set; } = false;

        [Description("Include east secondary girder; false by default.")]
        public virtual bool IncludeEGirder { get; set; } = false;

        [Description("If true, bar centrelines are offset based on the element they are connecting to. For Primary beams, and secondary end beams, this relates to the column size. For other secondary beams, relates to thickness of Primary beams, and tertiary beams cutoff by secondary beams.")]
        public virtual bool OffsetBarsFromConnectingElements { get; set; } = false;

        [Description("Include Columns; false by default.")]
        public virtual bool IncludeColumns { get; set; } = false;

        [Description("The number of stories that the column data should be evaluated for. If a negative value is provided, the median configuration will be assumed ordered by number of stories.")]
        public virtual int NumberOfStories { get; set; } = -1;

        [Description("The height of a populated column. By default, the value on the picked column configuration will be used.")]
        public virtual double FloorHeight { get; set; } = double.NaN;

        /***************************************************/

    }
}
