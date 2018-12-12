using System.ComponentModel;

namespace BH.oM.Structure.Results
{
    /***************************************************/

    [Description("Specifies which layer the results are extracted from or if it is a maxima/minima of the layers")]
    public enum MeshResultType
    {
        [Description("Bending moments and shear forces out-of-plane, membrane forces in the plane of the mesh/element")]
        Forces = 0,

        [Description("Stresses in the plane of the mesh/element")]
        Stresses = 1,

        [Description("Displacements of the mesh/element nodes")]
        Displacements = 2,

        [Description("Von Mises stresses and forces")]
        VonMises = 3,

    }

    /***************************************************/
}