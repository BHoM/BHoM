using BHoM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using BHoM.Structural.Properties;
using BHoM.Global;

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
        
        /// <summary>
        /// Material Density of the material in [kg/m^3] 
        /// </summary>
        [DefaultValue(null)]
        public double Density { get; set; }

        /// <summary>
        /// Returns the weight of the material in [kN/m^3] 
        /// Calulated as Density * g / 1000, where g = 9.80665
        /// </summary>
        public double Weight
        {
            get
            {
                return Density * 9.80665 / 1000;
            }
        }

        public double CompressiveYieldStrength
        {
            get;
            set;
        }

        public double TensileYieldStrength
        {
            get;
            set;
        }

        public double StainAtYield
        {
            get;
            set;
        }

        /// <summary>Calculate material values at construct</summary>
        //void CalculateValues();

        internal Material() { }

        public Material(string name)
        {
            Name = name;
        }

        public static Material LoadFromDB(string name)
        {
            object[] data = new SQLAccessor(Database.Material, Project.ActiveProject.Config.MaterialDatabase).GetDataRow("Name", name);
            if (data != null)
            {
                MaterialType type = (MaterialType)Enum.Parse(typeof(MaterialType), data[(int)MaterialColumnData.Type].ToString(), true);

                double e = (double)data[(int)MaterialColumnData.YoungsModulus];
                double v = (double)data[(int)MaterialColumnData.PoissonRatio];
                double tC = (double)data[(int)MaterialColumnData.CoefThermalExpansion];
                double density = (double)data[(int)MaterialColumnData.Mass];
                double g = e / (2 * (1 + v));

                Material m = new Material(name, type, e, v, tC, g, density);

                switch (type)
                {
                    case MaterialType.Concrete:
                        m.CompressiveYieldStrength = (double)data[(int)MaterialColumnData.CompressiveStrength];
                        break;
                    case MaterialType.Steel:
                        m.TensileYieldStrength = (double)data[(int)MaterialColumnData.MinimumYieldStress];
                        m.CompressiveYieldStrength = m.TensileYieldStrength;
                        break;
                    case MaterialType.Rebar:
                        m.TensileYieldStrength = (double)data[(int)MaterialColumnData.EffectiveTensileStress];
                        m.CompressiveYieldStrength = (double)data[(int)MaterialColumnData.EffectiveYieldStress];
                        break;
                }
                return m;
            }
            return null;
        }

        //public static Material Default(SectionType type)
        //{
        //    return Default(MaterialType.Concrete);
        //    switch (type)
        //    {
        //        case SectionType.Aluminium:
        //            return Default(MaterialType.Aluminium);
        //        case SectionType.ConcreteBeam:
        //        case SectionType.ConcreteColumn:
        //        case SectionType.Steel:
        //            return Default(MaterialType.Steel);
        //        case SectionType.Timber:
        //            return Default(MaterialType.Timber);
        //        case SectionType.Glass:
        //            return Default(MaterialType.Glass);
        //        default:
        //            return null;
        //    }
        //}

        public static Material Default(MaterialType type)
        {
            object[] data = new SQLAccessor(Database.Material, Project.ActiveProject.Config.MaterialDatabase).GetDataRow(new string[] { "Type", "IsDefault" }, new string[] { type.ToString(), "true" }, true);

            if (data != null)
            {
                double e = (double)data[(int)MaterialColumnData.YoungsModulus];
                double v = (double)data[(int)MaterialColumnData.PoissonRatio];
                double tC = (double)data[(int)MaterialColumnData.CoefThermalExpansion];
                double density = (double)data[(int)MaterialColumnData.Mass];
                double g = e / (2 * (1 + v));
                string name = data[(int)MaterialColumnData.Name].ToString().Trim();
                return new Material(name, type, e, v, tC, g, density);
            }
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
    }
}
