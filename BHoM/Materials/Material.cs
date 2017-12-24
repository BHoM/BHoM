﻿using BH.oM.Base;
using System.ComponentModel;


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

        /// <summary>Young's Modulus (MPa)</summary>
        [DefaultValue(null)]
        public double YoungsModulus { get; set; }

        /// <summary>Poissons ratio</summary>
        [DefaultValue(null)]
        public double PoissonsRatio { get; set; }

        /// <summary>Shear modulus (MPa)</summary>
        [DefaultValue(null)]
        public double ShearModulus { get; set; }

        /// <summary>Dry density</summary>
        [DefaultValue(null)]
        public double DryDensity { get;  set; }

        /// <summary>Coefficient of thermal expansion</summary>
        [DefaultValue(null)]
        public double CoeffThermalExpansion { get; set; }

        /// <summary>Damping ratio</summary>
        [DefaultValue(null)]
        public double DampingRatio { get; set; }
        
        /// <summary>
        /// Material Density of the material in [kg/m^3] 
        /// </summary>
        [DefaultValue(null)]
        public double Density { get; set; }

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





///// <summary>
///// Returns the weight of the material in [kN/m^3] 
///// Calulated as Density * g / 1000, where g = 9.80665
///// </summary>
//public double GetWeight()
//{
//    return Density * 9.80665 / 1000;
//}
