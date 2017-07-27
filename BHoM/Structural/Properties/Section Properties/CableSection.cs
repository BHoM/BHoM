using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHoM.Structural.Databases;
using BHoM.Global;
using BHoM.Base;


namespace BHoM.Structural.Properties
{
    public class CableSection : SectionProperty
    {

        private int m_numberOfCables;

        public CableSection()
        {
            this.SectionData = CreateSectionData(0, 0, 0, 0, 0, 0);
        }

        public CableSection(double diameter, double areaOfOneCable, int numberOfCables = 1) : this(diameter, areaOfOneCable, BHoM.Materials.Material.Default(Materials.MaterialType.Cable), numberOfCables)
        {   }

        public CableSection(double diameter, double areaOfOneCable, BHoM.Materials.Material mat, int numberOfCables = 1)
        {
            this.SectionData = CreateSectionData(0, 0, 0, 0, 0, 0);

            m_numberOfCables = numberOfCables;
            m_Area = areaOfOneCable;
            Material = mat;
            CreateEdgeCurves(diameter, numberOfCables);
            SectionData[(int)CableSectionData.D] = diameter;
            SectionData[(int)CableSectionData.A] = areaOfOneCable;
        }

        public override double GrossArea
        {
            get
            {
                if (m_Area == 0)
                    m_Area = SectionData[(int)CableSectionData.A];

                return m_Area * m_numberOfCables;
            }
        }

        public int NumberOfCables
        {
            get
            {
                return m_numberOfCables;
            }
            set
            {
                m_numberOfCables = value;
            }
        }

        private void CreateEdgeCurves(double diameter, int numberOfCables)
        {
            //TODO: Add something for creation of multiple cables
            Edges = CreateGeometry(ShapeType.Circle, diameter, diameter, 0, 0, 0, 0);
            
        }


        public override ShapeType Shape
        {
            get
            {
                return ShapeType.Cable;
            }

            set
            {
                base.Shape = ShapeType.Cable;
            }
        }

        protected override string GenerateStandardName()
        {
            return m_numberOfCables + "-CABLE LCØ"+SectionData[(int)CableSectionData.D] * 1000;
        }

        public double BreakingLoad
        {
            get
            {
                return SectionData[(int)CableSectionData.BL]*NumberOfCables;
            }
        }

        public double MassPerMetre
        {
            get
            {
                return SectionData[(int)CableSectionData.Weight] * NumberOfCables;
            }
        }

        public double WeightOpenSpelterSocket
        {
            get
            {
                return SectionData[(int)CableSectionData.WeightEndOpen] * NumberOfCables;
            }
        }

        public double WeightOpenAdjustableSpelterSocket
        {
            get
            {
                return SectionData[(int)CableSectionData.WeightEndAdjustable] * NumberOfCables;
            }
        }

        public double WeightStyliteForkSocket
        {
            get
            {
                //object[] data = new SQLAccessor(Database.Cables, Project.ActiveProject.Config.StyliteForkSocketDataBase).GetDataRow("CableDia", SectionData[(int)CableSectionData.D].ToString());

                //if (data != null)
                //{
                //    return NumberOfCables * ((double)data[(int)CableSTFConnectorData.PinOCapsWeight] + (double)data[(int)CableSTFConnectorData.SocketWeight]);
                //}
                double mass;
                return StyliteForkSocketWeightDict.TryGetValue(SectionData[(int)CableSectionData.D], out mass)? mass * NumberOfCables : -1;
            }
        }

        public double WeightStyliteAdjustableForkSocket
        {
            get
            {
                //object[] data = new SQLAccessor(Database.Cables, Project.ActiveProject.Config.StyliteAdjustableForkSocketDataBase).GetDataRow("CableDia", SectionData[(int)CableSectionData.D].ToString());

                //if (data != null)
                //{
                //    return NumberOfCables * (double)data[(int)CableSTAFConnectorData.Weight];
                //}
                double mass;
                return AdjustableStyliteForkSocketWeightDict.TryGetValue(SectionData[(int)CableSectionData.D], out mass) ? mass * NumberOfCables : -1;
            }
        }

        public double WeightStyliteRingConnector
        {
            get
            {
                //object[] data = new SQLAccessor(Database.Cables, Project.ActiveProject.Config.StyliteRingConnectorDataBase).GetDataRow("CableDia", SectionData[(int)CableSectionData.D].ToString());

                //if (data != null)
                //{
                //    return NumberOfCables * (double)data[(int)CableSTRCConnectorData.Weight];
                //}

                double mass;
                return StyliteRingConnectorWeightDict.TryGetValue(SectionData[(int)CableSectionData.D], out mass) ? mass * NumberOfCables : -1;

            }
        }

        /******************************************************************/
        /************** Cable connection dictionaries *********************/
        /*********Placed here until a proper system is in place ***********/
        /******************* Data from Bridon cables **********************/
        /******************************************************************/

        private static Dictionary<double, double> StyliteForkSocketWeightDict
        {
            get
            {
                var dict = new Dictionary<double, double>();
                dict.Add(0.025, 9.7);
                dict.Add(0.030, 18.4);
                dict.Add(0.035, 27.2);
                dict.Add(0.040, 38.1);
                dict.Add(0.045, 51.4);
                dict.Add(0.050, 67.0);
                dict.Add(0.055, 74.0);
                dict.Add(0.060, 92.0);
                dict.Add(0.065, 118.0);
                dict.Add(0.070, 147.0);
                dict.Add(0.075, 175.0);
                dict.Add(0.080, 209.0);
                dict.Add(0.085, 260.0);
                dict.Add(0.090, 306.0);
                dict.Add(0.095, 363.0);
                dict.Add(0.100, 439.0);
                dict.Add(0.105, 490.0);
                dict.Add(0.110, 569.0);
                dict.Add(0.115, 645.0);
                dict.Add(0.120, 722.0);
                dict.Add(0.125, 813.0);
                dict.Add(0.130, 918.0);
                dict.Add(0.135, 1017.0);
                dict.Add(0.140, 1135.0);
                dict.Add(0.145, 1248.0);
                dict.Add(0.150, 1364.0);
                return dict;
            }
        }

        private static Dictionary<double, double> AdjustableStyliteForkSocketWeightDict
        {
            get
            {
                var dict = new Dictionary<double, double>();
                dict.Add(0.025, 20);
                dict.Add(0.03, 36);
                dict.Add(0.035, 49);
                dict.Add(0.04, 69);
                dict.Add(0.045, 87);
                dict.Add(0.05, 112);
                dict.Add(0.055, 131);
                dict.Add(0.06, 163);
                dict.Add(0.065, 210);
                dict.Add(0.07, 260);
                dict.Add(0.075, 309);
                dict.Add(0.08, 365);
                dict.Add(0.085, 447);
                dict.Add(0.09, 514);
                dict.Add(0.095, 591);
                dict.Add(0.1, 700);
                dict.Add(0.105, 816);
                dict.Add(0.11, 942);
                dict.Add(0.115, 1084);
                dict.Add(0.12, 1224);
                dict.Add(0.125, 1364);
                dict.Add(0.13, 1513);
                dict.Add(0.135, 1741);
                dict.Add(0.14, 1929);
                dict.Add(0.145, 2147);
                dict.Add(0.15, 2340);
                return dict;
            }

        }

        private static Dictionary<double, double> StyliteRingConnectorWeightDict
        {
            get
            {
                var dict = new Dictionary<double, double>();
                dict.Add(0.025, 16);
                dict.Add(0.030, 29);
                dict.Add(0.035, 39);
                dict.Add(0.040, 53);
                dict.Add(0.045, 66);
                dict.Add(0.050, 79);
                dict.Add(0.055, 105);
                dict.Add(0.060, 128);
                dict.Add(0.065, 166);
                dict.Add(0.070, 205);
                dict.Add(0.075, 244);
                dict.Add(0.080, 281);
                dict.Add(0.085, 343);
                dict.Add(0.090, 376);
                dict.Add(0.095, 432);
                dict.Add(0.100, 512);
                dict.Add(0.105, 590);
                dict.Add(0.110, 675);
                dict.Add(0.115, 772);
                dict.Add(0.120, 866);
                dict.Add(0.125, 951);
                dict.Add(0.130, 1071);
                dict.Add(0.135, 1161);
                dict.Add(0.140, 1280);
                dict.Add(0.145, 1434);
                dict.Add(0.150, 1567);
                return dict;
            }
        }

        /*************************************************************/
        /***** Property overrides Setting properties to 0 ************/
        /*************************************************************/

        public override double Asy
        {
            get
            {
                return 0;
            }
        }

        public override double Asz
        {
            get
            {
                return 0;
            }
        }

        public override double Iy
        {
            get
            {
                return 0;
            }
        }

        public override double Iz
        {
            get
            {
                return 0;
            }
        }

        public override double J
        {
            get
            {
                return 0;
            }
        }

        public override double Sy
        {
            get
            {
                return 0;
            }
        }
        public override double Sz
        {
            get
            {
                return 0;
            }
        }
        public override double Vpy
        {
            get
            {
                return 0;
            }
        }
        public override double Vpz
        {
            get
            {
                return 0;
            }
        }

        public override double Vy
        {
            get
            {
                return 0;
            }
        }

        public override double Vz
        {
            get
            {
                return 0;
            }
        }

        public override double Zy
        {
            get
            {
                return 0;
            }
        }

        public override double Zz
        {
            get
            {
                return 0;
            }
        }
    }
}
