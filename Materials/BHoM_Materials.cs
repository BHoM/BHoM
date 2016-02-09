using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Materials
{
    /// <summary>
    /// Material class for use in all other object classes and namespaces
    /// </summary>
    public class Material 
    {
        /// <summary>Material index number</summary>   
        public int Index { get; private set; }
        /// <summary>Material name</summary>
        public string Name { get; set; }

        /// <summary></summary>
        public int Fy { get; set; } //Currently stored in sectionpropery
        /// <summary></summary>
        public int Fu { get; set; } //Currently stored in sectionpropery


        /// <summary></summary>
        public double E { get; private set; } //Young's Modulus
        /// <summary></summary>
        public double Nu { get; private set; } //Poisson's ratio
        /// <summary></summary>
        public double G { get; private set; } //Shear modulus
        /// <summary></summary>
        public double Density { get; private set; }
        /// <summary></summary>
        public double TempCoeff { get; private set; } //Temperature coefficient
        /// <summary></summary>
        public double DampingRatio { get; private set; }

        /////////////////////////
        //// CONSTRUCTOR ////////
        /////////////////////////

        /// <summary>
        /// Creates a material class
        /// </summary>
        /// <param name="i">Index</param>
        /// <param name="name"></param>
        /// <param name="e">Young's Modulus</param>
        /// <param name="nu">Poisson's ratio</param>
        /// <param name="g">Shear modulus</param>
        /// <param name="d">Density</param>
        /// <param name="tc">Temperature coefficient</param>
        public Material(int i, string name, double e, double nu, double g, double d, double tc)
        {
            Index = i;
            Name = name;
            E = e;
            Nu = nu;
            G = g;
            Density = d;
            TempCoeff = tc;
        }

     
        /// <summary>
        /// Creates a simple material class
        /// Try to use the full material constructor if possible.
        /// </summary>
        /// <param name="name"></param>
        public Material(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Creates a simple material class with index number
        /// </summary>
        /// <param name="index"></param>
        /// <param name="name"></param>
        public Material(int index, string name)
        {
            Name = name;
            Index = index;
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
