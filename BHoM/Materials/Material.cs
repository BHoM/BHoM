using BH.oM.Base;


namespace BH.oM.Materials
{
    /// <summary>
    /// Material class for use in all other object classes and namespaces
    /// </summary>
    public class Material : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public MaterialType Type { get; set; }

        public double YoungsModulus { get; set; } = 0.0; // in (MPa)

        public double PoissonsRatio { get; set; }

        public double ShearModulus { get; set; } = 0.0; // in (MPa)

        public double DryDensity { get;  set; }

        public double CoeffThermalExpansion { get; set; }

        public double DampingRatio { get; set; }

        public double Density { get; set; } = 0.0; //in [kg/m^3] 

        public double CompressiveYieldStrength { get; set; }

        public double TensileYieldStrength { get; set; }

        public double StainAtYield { get; set; }


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Material() { }

        /***************************************************/

        public Material(string name)
        {
            Name = name;
        }

        /***************************************************/

        public Material(string name, MaterialType type, double E, double v, double tC, double G, double denisty)
        {
            Name = name;
            Type = type;
            YoungsModulus = E;
            PoissonsRatio = v;
            CoeffThermalExpansion = tC;
            ShearModulus = G;
            Density = denisty;
        }

    }
}




