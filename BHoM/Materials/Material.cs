using BHoM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using BHoM.Structural.Properties;
using BHoM.Global;
using BHoM.Structural.Databases;
using BHoM.Base.Data;

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
            IDataAdapter database = Project.ActiveProject.GetDatabase<MaterialRow>(Database.Material);
            database.TableName = Project.ActiveProject.Config.MaterialDatabase;
            MaterialRow data = (MaterialRow)database.GetDataRow("Name", name);
            if (data != null)
            {
                return FromDataRow(data);
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
            IDataAdapter database = Project.ActiveProject.GetDatabase<MaterialRow>(Database.Material);
            database.TableName = Project.ActiveProject.Config.MaterialDatabase;
            MaterialRow data = (MaterialRow)database.GetDataRow(new string[] { "Type", "IsDefault" }, new string[] { type.ToString(), "true" });
            if (data != null)
            {
                return FromDataRow(data);
            }
            return null;
        }

        private static Material FromDataRow(MaterialRow data)
        {
            MaterialType type = (MaterialType)Enum.Parse(typeof(MaterialType), data.Type.ToString(), true);
            string name = data.Name.Trim();
            double e = data.YoungsModulus;
            double v = data.PoissonsRatio;
            double tC = data.CoefOfThermalExpansion;
            double density = data.Mass;
            double g = e / (2 * (1 + v));

            Material m = new Material(name, type, e, v, tC, g, density);

            switch (type)
            {
                case MaterialType.Concrete:
                    m.CompressiveYieldStrength = data.CompressiveStrength;
                    break;
                case MaterialType.Steel:
                    m.TensileYieldStrength = data.EffectiveTensileStress;
                    m.CompressiveYieldStrength = m.TensileYieldStrength;
                    break;
                case MaterialType.Rebar:
                    m.TensileYieldStrength = data.EffectiveTensileStress;
                    m.CompressiveYieldStrength = data.CompressiveStrength;
                    break;
            }
            return m;
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
