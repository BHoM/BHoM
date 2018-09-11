using System.ComponentModel;

namespace BH.oM.Structure.Results
{
    /***************************************************/

    [Description("Specifies which layer the results are extracted from or if it is a maxima/minima of the layers")]
    public enum MeshResultType
    {
        [Description("Lower surface/extreme fibre of the panel/mesh element")]
        Lower = -1,

        [Description("Middle layer of the panel/mesh element")]
        Middle = 0,

        [Description("Upper surface/extreme fibre of the panel/mesh element")]
        Upper = 1,

        [Description("The minimum value of all layers in the panel/mesh element")]
        Minimum = 2,

        [Description("The maximum value of all layers in the panel/mesh element")]
        Maximum = 3,

        [Description("The absolute maximum value of all layers in the panel/mesh element")]
        AbsoluteMaximum = 4,

        [Description("An arbitrary position within the thickness of the element")]
        Arbitrary = 5
    }

    /***************************************************/
}
