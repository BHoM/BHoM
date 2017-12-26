namespace BH.oM.Common.Materials
{
    /***************************************************/

    public enum MaterialColumnData
    {
        Type = 1,
        Grade = 2,
        Name = 3,
        Weight = 5,
        Mass,
        YoungsModulus,
        PoissonRatio,
        CoefThermalExpansion,
        MinimumYieldStress,
        MinimumTensileStress,
        EffectiveYieldStress,
        EffectiveTensileStress,
        CompressiveStrength,
        StainAtUltimate
    }

    /***************************************************/

    public enum SteelGrade
    {
        S235 = 0,
        S275,
        S355,
        S420,
        S450,
        S460,
        unknown
    }

    /***************************************************/

    public enum MaterialType
    {
        Aluminium,
        Steel,
        Concrete,
        Timber,
        Rebar,
        Tendon,
        Glass,
        Cable
    }

    /***************************************************/

    public enum DefaultMaterials
    {
        Steel = 1,
        ConcreteShortTerm,
        ConcreteLongTerm,
        Aluminium,
        Glass
    }

    /***************************************************/

    public enum MaterialModel
    {
        MAT_ELAS_ISO = 0,   // Elastic isotropic
        MAT_ELAS_ORTHO,     // Elastic orthotropic
        MAT_ELAS_PLAS_ISO,  // Elasto-plastic isotropic
        MAT_FABRIC          // Fabric
    }

    /***************************************************/
}
