using BH.oM.Base;


namespace BH.oM.Common.Materials
{
    /// <summary>
    /// Material class for use in all other object classes and namespaces
    /// </summary>
    public class Material : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public MaterialType Type { get; set; } = MaterialType.Aluminium; // TODO: Check the default values for this class

        public double YoungsModulus { get; set; } = 0.0; // in (MPa)

        public double PoissonsRatio { get; set; } = 0.0;

        public double ShearModulus { get; set; } = 0.0; // in (MPa)

        public double DryDensity { get;  set; } = 0.0;

        public double CoeffThermalExpansion { get; set; } = 0.0;

        public double DampingRatio { get; set; } = 0.0;

        public double Density { get; set; } = 0.0; //in [kg/m^3] 

        public double CompressiveYieldStrength { get; set; } = 0.0;

        public double TensileYieldStrength { get; set; } = 0.0;

        public double StainAtYield { get; set; } = 0.0;


        /***************************************************/
    }
}




