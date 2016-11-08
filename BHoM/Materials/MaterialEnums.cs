using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Materials
{
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

    /// <summary>Steel grade</summary>
    public enum SteelGrade
    {
        /// <summary>UK S235</summary>
        S235 = 0,
        /// <summary>UK S275</summary>
        S275,
        /// <summary>UK S355</summary>
        S355,
        /// <summary>UK S420</summary>
        S420,
        /// <summary>UK S450</summary>
        S450,
        /// <summary>UK S460</summary>
        S460,
        /// <summary>Not known</summary>
        unknown
    }
    /// <summary>
    /// 
    /// </summary>
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

    /// <summary>
    /// Default materials
    /// </summary>
    public enum DefaultMaterials
    {
        /// <summary>Steel</summary>
        Steel = 1,
        /// <summary>Concrete - short term properties</summary>
        ConcreteShortTerm,
        /// <summary>Concrete - long term properties</summary>
        ConcreteLongTerm,
        /// <summary>Aluminium</summary>
        Aluminium,
        /// <summary>Glass</summary>
        Glass
    }

    /// <summary>
    /// Material analytical model
    /// </summary>
    public enum MaterialModel
    {
        /// <summary>Elastic isotropic</summary>
        MAT_ELAS_ISO = 0,
        /// <summary>Elastic orthotropic</summary>
        MAT_ELAS_ORTHO,
        /// <summary>Elasto-plastic isotropic</summary>
        MAT_ELAS_PLAS_ISO,
        /// <summary>Fabric</summary>
        MAT_FABRIC 
    }
       
}
