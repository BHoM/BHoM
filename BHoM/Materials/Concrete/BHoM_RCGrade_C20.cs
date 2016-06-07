
using System;

namespace BHoM.Materials.Concrete
{
    /// <summary>
    /// Material class for use in all other object classes and namespaces
    /// </summary>


    public class Grade_C20 : IConcrete
    {
        //////////////////
        ////Properties////
        //////////////////

        /// <summary>Index</summary>
        public int Index { get { return Index; } set { } }

        /// <summary>Name</summary>
        public string Name { get { return Name; } set { Name = "Concrete_Grade_C20"; } }

        /// <summary>Damping ratio</summary>
        public double DampingRatio { get {return DampingRatio;} set { DampingRatio = 0; } }

        /// <summary>Dry density</summary>
        public double DryDensity { get { return DryDensity; } set { DryDensity = 2400; } }

        /// <summary>Youngs Modulus</summary>
        public double YoungsModulus { get { return YoungsModulus; } set { YoungsModulus = 30e9; } }

        /// <summary>Poissons ratio</summary>
        public double PoissonsRatio { get { return PoissonsRatio; } set { PoissonsRatio = 0.2; } }

        /// <summary>Shear modulus</summary>
        public double ShearModulus { get { return ShearModulus; } set { CalculateShearModulus(); } }

        /// <summary>Coefficient of thermal expansion</summary>
        public double CoeffThermalExpansion { get { return CoeffThermalExpansion; } set { CoeffThermalExpansion = 1e-5; } }

        ////////////////////
        ////Constructors////
        ////////////////////

        /// <summary>Construct the material</summary>
        public Grade_C20()
        {
            CalculateValues();
        }
        
        ///////////////
        ////Methods////
        ///////////////

        /// <summary>Calculate values at construct stage</summary>
        public void CalculateValues()
        {
            CalculateShearModulus();
        }

        /// <summary>Calculate shear modulus</summary>
        public void CalculateShearModulus()
        {
            this.ShearModulus = YoungsModulus / (2 * (1 + PoissonsRatio));
        }
    }
}
