using BHoM.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace BHoM.Materials
{
    /// <summary>
    /// Material class for use in all other object classes and namespaces
    /// </summary>
    public class Material : BHoMObject
    {
        //////////////////
        ////Properties////
        //////////////////
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

        [DefaultValue(null)]
        public double Density { get; set; }

        /// <summary>Calculate material values at construct</summary>
        //void CalculateValues();

        internal Material() { }

        public Material(string name)
        {
            Name = name;
        }

        public static Material LoadFromDB(string name)
        {
            //object[] data = Project.ActiveProject.Structure.MaterialDatabase.GetDataRow(new string[] { "Name" }, name);
            return null;
        }

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

        // <summary>
        // Creates a material class with material model
        // </summary>
        // <param name="material"></param>
        //public Material(DefaultMaterials material)
        //{
        //    MaterialModel = "MAT_ELAS_ISO"; 

        //    switch (material)
        //    {    
        //        case DefaultMaterials.Steel:
        //            Index = -(int)material;
        //            Name = material.ToString();
        //            E = 2.05e11;
        //            Nu = 0.3;
        //            G = E / (2 * (1 + Nu));
        //            Density = 7850;
        //            TempCoeff = 1.2e-5;
        //            DampingRatio = 0;
        //            Fy = (int)355e6;
        //            Fu = (int)490e6;
        //            break;
        //        case DefaultMaterials.ConcreteShortTerm:
        //            Index = -(int)material;
        //            Name = material.ToString();
        //            E = 28000e6;
        //            Nu = 0.2;
        //            G = E / (2 * (1 + Nu));
        //            Density = 2400;
        //            TempCoeff = 1e-5;
        //            DampingRatio = 0;
        //            break;
        //        case DefaultMaterials.ConcreteLongTerm:
        //            Index = -(int)material;
        //            Name = material.ToString();
        //            E = 14000e6;
        //            Nu = 0.2;
        //            G = E / (2 * (1 + Nu));
        //            Density = 2400;
        //            TempCoeff = 1e-5;
        //            DampingRatio = 0;
        //            break;
        //        case DefaultMaterials.Aluminium:
        //            Index = -(int)material;
        //            Name = material.ToString();
        //            E = 70000e6;
        //            Nu = 0.34;
        //            G = E / (2 * (1 + Nu));
        //            Density = 2710;
        //            TempCoeff = 2.3e-5;
        //            DampingRatio = 0;
        //            break;
        //        case DefaultMaterials.Glass:
        //            Index = -(int)material;
        //            Name = material.ToString();
        //            E = 70300e6;
        //            Nu = 0.22;
        //            G = E / (2 * (1 + Nu));
        //            Density = 2470;
        //            TempCoeff = 8e-6;
        //            DampingRatio = 0;
        //            break;
        //        default:
        //            break;
        //    }


        //}

    }
}
