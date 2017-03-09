using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using BHoM.Base;


namespace BHoM.Structural.Properties
{
    public class CableSection : SectionProperty
    {

        private int m_numberOfCables;

        public CableSection()
        { }

        //public CableSection(double diameter, double areaOfOneCable, int numberOfCables = 1) : this(diameter, areaOfOneCable, BHoM.Materials.Material.Default(Materials.MaterialType.Cable), numberOfCables)
        //{   }

        //public CableSection(double diameter, double areaOfOneCable, BHoM.Materials.Material mat, int numberOfCables = 1)
        //{
        //    m_numberOfCables = numberOfCables;
        //    m_Area = areaOfOneCable;
        //    Material = mat;
        //    CreateEdgeCurves(diameter, numberOfCables);
        //    SectionData[(int)CableSectionData.D] = diameter;
        //    SectionData[(int)CableSectionData.A] = areaOfOneCable;
        //}

        //public override double GrossArea
        //{
        //    get
        //    {
        //        if (m_Area == 0)
        //            m_Area = SectionData[(int)CableSectionData.A];

        //        return m_Area * m_numberOfCables;
        //    }
        //}

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

        //private void CreateEdgeCurves(double diameter, int numberOfCables)
        //{
        //    //TODO: Add something for creation of multiple cables
        //    Edges = CreateGeometry(ShapeType.Circle, diameter, diameter, 0, 0, 0, 0);
            
        //}


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

        //protected string GenerateStandardName()
        //{
        //    return m_numberOfCables + "-CABLE LCØ"+SectionData[(int)CableSectionData.D] * 1000;
        //}

        //public double BreakingLoad
        //{
        //    get
        //    {
        //        return SectionData[(int)CableSectionData.BL]*NumberOfCables;
        //    }
        //}

        //public double MassPerMetre
        //{
        //    get
        //    {
        //        return SectionData[(int)CableSectionData.Weight] * NumberOfCables;
        //    }
        //}

        //public double WeightOpenSpelterSocket
        //{
        //    get
        //    {
        //        return SectionData[(int)CableSectionData.WeightEndOpen] * NumberOfCables;
        //    }
        //}

        //public double WeightOpenAdjustableSpelterSocket
        //{
        //    get
        //    {
        //        return SectionData[(int)CableSectionData.WeightEndAdjustable] * NumberOfCables;
        //    }
        //}

        public double WeightStyliteForkSocket
        {
            get
            {
                //object[] data = new SQLAccessor(Database.Cables, Project.ActiveProject.Config.StyliteForkSocketDataBase).GetDataRow("CableDia", SectionData[(int)CableSectionData.D].ToString());

                //if (data != null)
                //{
                //    return NumberOfCables * ((double)data[(int)CableSTFConnectorData.PinOCapsWeight] + (double)data[(int)CableSTFConnectorData.SocketWeight]);
                //}

                return -1;
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

                return -1;
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

                return -1;
            }
        }
    }
}
