using BHoM.Geometry;
using BHoM.Base;
using BHoM.Materials;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using BHoM.Global;
using BHoM.Structural.Databases;

namespace BHoM.Structural.Properties
{
    /// <summary>
    /// Section property class, the parent abstract class for all structural 
    /// sections (RC, steel, PT beams, columns, bracing). Properties defined in this 
    /// parent class are those that would populate a multi category section database only
    /// </summary>

    public abstract class SectionProperty : BHoMObject
    {
        protected double m_Area;
        protected double m_Asx;
        protected double m_Asy;
        protected double m_Ix;
        protected double m_Iy;
        protected double m_J;
        protected double m_Sx;
        protected double m_Sy;
        protected double m_Zx;
        protected double m_Zy;

        protected double m_Vx;
        protected double m_Vpx;
        protected double m_Vy;
        protected double m_Vpy;


        public double[] SectionData { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public SectionProperty()
        {
            SectionData = new double[15];
        }

        

        /// <summary>
        /// Geometry of the cross section
        /// </summary>
        [DefaultValue(null)]
        public BHoM.Geometry.Group<Curve> Edges { get; set; }

        /// <summary>Mass per metre based on section properties</summary>
        [DefaultValue(null)]
        public double MassPerMetre { get; set; }

        /// <summary>Material of the section property</summary>
        [DisplayName("Material")]
        [Description("Bar Material assigned to the bar object")]
        public BHoM.Materials.Material Material { get; set; }



        /************************************************/
        /********* Steel sections from data base ********/
        /************************************************/

        public static SectionProperty LoadFromSteelSectionDB(string name)
        {
            return LoadFromSteelSectionDB(Project.ActiveProject, name);
        }

        /// <summary>
        /// Searches for the input name in the selected database and returns the corresponding section
        /// </summary>
        /// <param name="name">Name of section to search for</param>
        /// <returns></returns>
        public static SectionProperty LoadFromSteelSectionDB(Project project, string name)
        {
            if (name.EndsWith(".0")) name = name.Substring(0, name.Length - 2);
            object[] data = new SQLAccessor(Database.SteelSection, project.Config.SectionDatabase).GetDataRow(new string[] { "Name", "Name1", "Name2" }, new string[] { name });

            if (data != null)
            {
                ShapeType shape = (ShapeType)data[(int)SteelSectionData.Shape];
                double mass = (double)data[(int)SteelSectionData.Mass];
                double breadth = (double)data[(int)SteelSectionData.Width];
                double height = (double)data[(int)SteelSectionData.Height];
                double tw = (double)data[(int)SteelSectionData.TW];
                double tf1 = (double)data[(int)SteelSectionData.TF1];
                double tf2 = (double)data[(int)SteelSectionData.TF2];
                double b1 = (double)data[(int)SteelSectionData.B1];
                double b2 = (double)data[(int)SteelSectionData.B2];
                double b3 = (double)data[(int)SteelSectionData.B3];
                double s = (double)data[(int)SteelSectionData.Spacing];
                double r1 = (double)data[(int)SteelSectionData.r1];
                double r2 = (double)data[(int)SteelSectionData.r2];
                
                double[] sectionData = new double[(int)SteelSectionData.Spacing + 1];
                for (int i = (int)SteelSectionData.Mass; i < (int)SteelSectionData.Spacing + 1; i++)
                {
                    sectionData[i] = (double)data[i];
                }
                BHoM.Geometry.Group<Curve> edges = CreateGeometry(shape, height, breadth, tw, tf1, r1, r2, b1, b2, tf2, b3);
                SectionProperty property = new SteelSection(edges, shape);//, SectionType.Undefined);
                property.Name = name;
                property.SectionData = sectionData;
                return edges != null ? property : null;
            }
            return null;
        }

        /************************************************/
        /********* Cable sections from data base ********/
        /************************************************/

        public static SectionProperty LoadFromCableSectionDBName(string name, int numberOfCables = 1)
        {
            return LoadFromCableSectionDBName(Project.ActiveProject, name, numberOfCables);
        }

        public static SectionProperty LoadFromCableSectionDBName(Project project, string name, int numberOfCables = 1)
        {
            object[] data = new SQLAccessor(Database.Cables, project.Config.CableDataBase).GetDataRow("Name", name);

            if (data != null)
            {
                return CreateCableSectionFromDB(data, numberOfCables);
            }

            return null;
        }

        public static SectionProperty LoadFromCableSectionDBDiameter(double diameter, int numberOfCables = 1)
        {
            return LoadFromCableSectionDBDiameter(Project.ActiveProject, diameter, numberOfCables);
        }

        public static SectionProperty LoadFromCableSectionDBDiameter(Project project, double diameter, int numberOfCables = 1)
        {
            object[] data = new SQLAccessor(Database.Cables, project.Config.CableDataBase).GetDataRow("Diameter", diameter.ToString());

            if (data != null)
            {
                return CreateCableSectionFromDB(data, numberOfCables);
            }

            return null;
        }

        private static SectionProperty CreateCableSectionFromDB(object[] data, int numberOfCables)
        {
            double d = (double)data[(int)CableSectionData.D];
            double A = (double)data[(int)CableSectionData.A];
            string name = (string)data[(int)CableSectionData.Name];
            CableSection sec = new CableSection(d, A, numberOfCables);

            return sec;
        }

        /*****************************************************/
        /*********** Static steel section constructors *******/
        /*****************************************************/


        public static SectionProperty CreateTee(double totalHeight, double totalwidth, double flangeThickness, double webThickness, double r1 = 0, double r2 = 0)
        {
            return null;
        }

        /// <summary>
        /// Create an I Shaped section property
        /// </summary>
        /// <param name="mType"></param>
        /// <param name="widthTopFlange"></param>
        /// <param name="widthBotFlange"></param>
        /// <param name="totalDepth"></param>
        /// <param name="flangeThicknessTop"></param>
        /// <param name="flangeThicknessBot"></param>
        /// <param name="webThickness"></param>
        /// <param name="webRadius"></param>
        /// <param name="toeRadius"></param>
        /// <returns></returns>
        public static SectionProperty CreateISection(/*(SectionType mType,*/ double widthTopFlange, double widthBotFlange, double totalDepth, double flangeThicknessTop, double flangeThicknessBot, double webThickness, double webRadius, double toeRadius)
        {
            return new SteelSection(ShapeType.ISection, /*mType,*/ totalDepth, Math.Max(widthTopFlange, widthBotFlange), webThickness, flangeThicknessTop, webRadius, toeRadius, 0, widthTopFlange, widthBotFlange, flangeThicknessBot);
        }

        /// <summary>
        /// Create a rectangular shaped section
        /// </summary>
        /// <param name="mType"></param>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <param name="outerRadius"></param>
        /// <returns></returns>
        public static SectionProperty CreateRectangularSection(/*SectionType mType,*/ double height, double width, double outerRadius = 0)
        {
            return new SteelSection(ShapeType.Rectangle, /*mType,*/ height, width, 0, 0, outerRadius, 0);
        }

        /// <summary>
        /// Create a rectangular shaped section
        /// </summary>
        /// <param name="mType"></param>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <param name="outerRadius"></param>
        /// <returns></returns>
        public static SectionProperty CreateBoxSection(double height, double width, double tf, double tw, double outerRadius = 0, double innerRadius = 0)
        {
            return new SteelSection(ShapeType.Box, height, width, tw, tf, outerRadius, innerRadius);
        }

        /// <summary>
        /// Create an angle section
        /// </summary>
        /// <param name="mType"></param>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <param name="flangeThickness"></param>
        /// <param name="webThickness"></param>
        /// <returns></returns>
        public static SectionProperty CreateAngleSection(double height, double width, double flangeThickness, double webThickness, double webRadius, double toeRadius)
        {
            return new SteelSection(ShapeType.Angle, height, width, webThickness, flangeThickness, webRadius, toeRadius);
        }

        /// <summary>
        /// create a circular section
        /// </summary>
        /// <param name="mType"></param>
        /// <param name="diameter"></param>
        /// <returns></returns>
        public static SectionProperty CreateCircularSection(double diameter)
        {
            return new SteelSection(ShapeType.Circle, diameter, diameter, 0, 0, 0, 0);
        }

        /// <summary>
        /// create a circular section
        /// </summary>
        /// <param name="mType"></param>
        /// <param name="diameter"></param>
        /// <returns></returns>
        public static SectionProperty CreateTubeSection(double diameter, double thickness)
        {
            return new SteelSection(ShapeType.Tube, diameter, diameter, thickness, 0, 0, 0);
        }


        protected static BHoM.Geometry.Group<Curve> CreateGeometry(ShapeType shapeType, double height, double breadth, double tw, double tf1, double r1, double r2, double b1 = 0, double b2 = 0, double tf2 = 0, double b3 = 0)
        {
            BHoM.Geometry.Group<Curve> edges = null;

            switch (shapeType)
            {
                case ShapeType.ISection:
                    edges = ShapeBuilder.CreateISecction(tf1, b1 == 0 ? breadth : b1, tf2 == 0 ? tf1 : tf2, b2 == 0 ? breadth : b2, tw, height - 2 * tf1, r1, r2);
                    break;
                case ShapeType.Tee:
                    edges = ShapeBuilder.CreateTee(tf1, b1 == 0 ? breadth : b1, tw, height - tf1, r1, r2);
                    break;
                case ShapeType.Box:
                    edges = ShapeBuilder.CreateBox(breadth, height, tw, r1, r2);
                    break;
                case ShapeType.Angle:
                    edges = ShapeBuilder.CreateAngle(breadth, height, tf1, tw, r1, r2);
                    break;
                case ShapeType.Circle:
                    edges = ShapeBuilder.CreateCircle(breadth / 2);
                    break;
                case ShapeType.Rectangle:
                    edges = ShapeBuilder.CreateRectangle(breadth, height, r1);
                    break;
                case ShapeType.Tube:
                    edges = ShapeBuilder.CreateTube(breadth, tw);
                    break;
            }
            return edges;
        }

        protected virtual string GenerateStandardName()
        {
            string name = null;
            switch (Shape)
            {
                case ShapeType.ISection:
                    name = "UB " + (SectionData[(int)SteelSectionData.Height] * 1000).ToString() + "x" + (SectionData[(int)SteelSectionData.Width] * 1000).ToString() + "x" + (SectionData[(int)SteelSectionData.TW] * 1000).ToString();
                    break;
                case ShapeType.Tee:
                    name = "TUB " + (SectionData[(int)SteelSectionData.Width] * 1000).ToString() + "x" + (SectionData[(int)SteelSectionData.Height] * 1000).ToString() + "x" + (SectionData[(int)SteelSectionData.TW] * 1000).ToString();
                    break;
                case ShapeType.Box:
                    name = "RHS " + (SectionData[(int)SteelSectionData.Height] * 1000).ToString() + "x" + (SectionData[(int)SteelSectionData.Width] * 1000).ToString() + "x" + (SectionData[(int)SteelSectionData.TW] * 1000).ToString();
                    break;
                case ShapeType.Angle:
                    name = "L " + (SectionData[(int)SteelSectionData.Height] * 1000).ToString() + "x" + (SectionData[(int)SteelSectionData.Width] * 1000).ToString() + "x" + (SectionData[(int)SteelSectionData.TW] * 1000).ToString();
                    if (SectionData[(int)SteelSectionData.TW] != SectionData[(int)SteelSectionData.TF1])
                        name += "x" + (SectionData[(int)SteelSectionData.TF1] * 1000).ToString();
                    break;
                case ShapeType.Circle:
                    name = "C " + (SectionData[(int)SteelSectionData.Width] * 1000).ToString();
                    break;
                case ShapeType.Rectangle:
                    name = "R " + (SectionData[(int)SteelSectionData.Height] * 1000).ToString() + "x" + (SectionData[(int)SteelSectionData.Width] * 1000).ToString();
                    break;
                case ShapeType.Tube:
                    name = "CHS " + "x" + (SectionData[(int)SteelSectionData.Width] * 1000).ToString() + "x" + (SectionData[(int)SteelSectionData.TW] * 1000).ToString();
                    break;
                default:
                    name = Shape.ToString();
                    break;
            }
            return name;
        }

        public virtual void CalculateSection()
        {
            SectionCalculator sC = new SectionCalculator(Edges);
            double cx = sC.CentreX;
            double cy = sC.CentreY;
            m_Area = sC.Area;
            m_Asx = sC.Asx;
            m_Asy = sC.Asy;
            m_Ix = sC.Ix;
            m_Iy = sC.Iy;
            m_Sx = sC.Sx;
            m_Sy = sC.Sy;
            m_Zx = sC.Zx;
            m_Zy = sC.Zy;
            m_Vx = sC.Max(0) - cx;
            m_Vpx = cx - sC.Min(0);
            m_Vy = sC.Max(0) - cy;
            m_Vpy = cy - sC.Min(0);

            Edges.Translate(new Vector(-cx, -cy, 0));
        }

        /// <summary>Section type</summary> /// 
        [DefaultValue(null)]
        public virtual ShapeType Shape { get; set; }

        ///// <summary>
        ///// Type of material
        ///// </summary>
        //[DefaultValue(null)]
        //public SectionType SectionMaterial { get; set; }

        /// <summary>
        /// Orientation
        /// </summary>
        [DefaultValue(null)]
        public virtual double Orientation { get; set; }

        /// <summary>Cross sectional area</summary>
        public virtual double GrossArea
        {
            get
            {
                if (m_Area == 0) CalculateSection();
                return m_Area;
            }
        }

        public virtual double Asx
        {
            get
            {
                if (m_Asx == 0) CalculateSection();
                return m_Asx;
            }
        }

        public virtual double Asy
        {
            get
            {
                if (m_Asy == 0) CalculateSection();
                return m_Asy;
            }
        }

        /// <summary>
        /// Total height of section
        /// </summary>
        public virtual double TotalDepth
        {
            get
            {
                return Edges.Bounds().Extents.Y * 2;
            }
        }

        /// <summary>
        /// Total width of section
        /// </summary>
        public virtual double TotalWidth
        {
            get
            {
                return Edges.Bounds().Extents.X * 2;
            }
        }

        /// <summary>Second moment of inertia about the major axis</summary>
        public virtual double Ix
        {
            get
            {
                if (m_Ix == 0) CalculateSection();
                return m_Ix;
            }
        }

        /// <summary>Second moment of inertia about the minor axis</summary>
        public virtual double Iy
        {
            get
            {
                if (m_Iy == 0) CalculateSection();
                return m_Iy;
            }
        }

        /// <summary>Torsion Constant</summary>
        public virtual double J
        {
            get
            {
                return 0;
            }
        }

        public virtual double Vy
        {
            get
            {
                if (m_Vy == 0) CalculateSection();
                return m_Vy;
            }
        }

        public virtual double Vpy
        {
            get
            {
                if (m_Vpy == 0) CalculateSection();
                return m_Vpy;
            }
        }

        public virtual double Vx
        {
            get
            {
                if (m_Vx == 0) CalculateSection();
                return m_Vx;
            }
        }

        public virtual double Vpx
        {
            get
            {
                if (m_Vpx == 0) CalculateSection();
                return m_Vpx;
            }
        }

        /// <summary>
        /// Plastic Section modulus about the major axis
        /// </summary>
        public virtual double Sx
        {
            get
            {
                if (m_Sx == 0) CalculateSection();
                return m_Sx;
            }
        }

        /// <summary>
        /// Plastic Section modulus about the minor axis
        /// </summary>
        public virtual double Sy
        {
            get
            {
                if (m_Sy == 0) CalculateSection();
                return m_Sy;
            }
        }

        /// <summary>
        /// Elastic Section modulus about the major axis
        /// </summary>
        public virtual double Zx
        {
            get
            {
                if (m_Zx == 0) CalculateSection();
                return m_Zx;
            }
        }

        /// <summary>
        /// Plastic Section modulus about the minor axis
        /// </summary>
        public virtual double Zy
        {
            get
            {
                if (m_Zy == 0) CalculateSection();
                return m_Zy;
            }
        }


        public override string ToString()
        {
            string name = !string.IsNullOrWhiteSpace(Name) ? Name + " " : "";
            string mat = (this.Material != null && !string.IsNullOrWhiteSpace(this.Material.Name)) ? "-" + this.Material.Name : "";
            return name + GenerateStandardName() + mat;

        }

    }
}
