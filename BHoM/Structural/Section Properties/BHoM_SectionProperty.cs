

using BHoM.Geometry;
using BHoM.Global;
using BHoM.Materials;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BHoM.Structural.SectionProperties
{
    /// <summary>
    /// Section property class, the parent abstract class for all structural 
    /// sections (RC, steel, PT beams, columns, bracing). Properties defined in this 
    /// parent class are those that would populate a multi category section database only
    /// </summary>
    public class SectionProperty : BHoM.Global.BHoMObject
    {
        private double m_Area;
        private double m_Ix;
        private double m_Iy;
        private double m_Sx;
        private double m_Sy;
        private double m_Zx;
        private double m_Zy;

        private double m_Vx;
        private double m_Vpx;
        private double m_Vy;
        private double m_Vpy;

        public double[] SectionData { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public SectionProperty()
        {
            SectionData = new double[15];
        }

        /// <summary>
        /// Create a section property from standard input values
        /// </summary>
        /// <param name="sType">Shape type</param>
        /// <param name="mType">Material type</param>
        /// <param name="height">Total Height</param>
        /// <param name="width">Total width</param>
        /// <param name="t1">Flange Thickness</param>
        /// <param name="t2">Web Thickness</param>
        /// <param name="r1">Radius 1</param>
        /// <param name="r2">Radius 2</param>
        /// <param name="mass">Mass per metre</param>
        public SectionProperty(ShapeType sType, SectionType mType, double height, double width, double t1, double t2, double r1, double r2, double mass = 0, double b1 = 0, double b2 = 0, double t3 = 0, double b3 = 0)
        {
            SectionData = CreateSectionData(height, width, t1, t2, r1, r2, mass, b1, b2, t3, b3);
            Edges = CreateGeometry(sType, height, width, t1, t2, r1, r2, b1, b2, t3, b3);
            Shape = sType;
            SectionMaterial = mType;
        }

        /// <summary>
        /// Create a section property from a list of edges, shape type and material
        /// </summary>
        /// <param name="edges"></param>
        /// <param name="sType"></param>
        /// <param name="mType"></param>
        public SectionProperty(Group<Curve> edges, ShapeType sType, SectionType mType)
        {
            Edges = edges;
            Shape = sType;
            SectionMaterial = mType;
        }

        /// <summary>
        /// Geometry of the cross section
        /// </summary>
        [DefaultValue(null)]
        public Group<Curve> Edges { get; internal set; }

        /// <summary>Mass per metre based on section properties</summary>
        [DefaultValue(null)]
        public double MassPerMetre { get; set; }


        /// <summary>Explicitly defined area</summary>
        [DefaultValue(null)]
        public double Area { get; set; }


        public static SectionProperty LoadFromDB(string name)
        {
            return LoadFromDB(Project.ActiveProject, name);
        }


        /// <summary>
        /// Searches for the input name in the selected database and returns the corresponding section
        /// </summary>
        /// <param name="name">Name of section to search for</param>
        /// <returns></returns>
        public static SectionProperty LoadFromDB(Project project, string name)
        {
            if (name.EndsWith(".0")) name = name.Substring(0, name.Length - 2);
            object[] data = project.Structure.SectionDatabase.GetDataRow(new string[] { "Name", "Name1", "Name2" }, new string[] { name });

            if (data != null)
            {
                ShapeType shape = (ShapeType)data[(int)SectionTableColumn.Shape];
                double mass = (double)data[(int)SectionTableColumn.Mass];
                double breadth = (double)data[(int)SectionTableColumn.Width];
                double height = (double)data[(int)SectionTableColumn.Height];
                double tw = (double)data[(int)SectionTableColumn.TW];
                double tf1 = (double)data[(int)SectionTableColumn.TF1];
                double tf2 = (double)data[(int)SectionTableColumn.TF2];
                double b1 = (double)data[(int)SectionTableColumn.B1];
                double b2 = (double)data[(int)SectionTableColumn.B2];
                double b3 = (double)data[(int)SectionTableColumn.B3];
                double s = (double)data[(int)SectionTableColumn.Spacing];
                double r1 = (double)data[(int)SectionTableColumn.r1];
                double r2 = (double)data[(int)SectionTableColumn.r2];

                string[] enumNames = Enum.GetNames(typeof(SectionTableColumn));
                double[] sectionData = new double[enumNames.Length - 3];
                for (int i = 3; i < enumNames.Length; i++)
                {
                    sectionData[i - 3] = (double)data[i];
                }
                Group<Curve> edges = CreateGeometry(shape, breadth, height, tw, tf1, r1, r2, b1, b2, tf2, b3);
                SectionProperty property = new SectionProperty(edges, shape, SectionType.Steel);
                property.Name = name;
                property.SectionData = sectionData;
                return edges != null ? property : null;
            }
            return null;
        }

        public static SectionProperty CreateTee(SectionType mType, double totalHeight, double totalwidth, double flangeThickness, double webThickness, double r1 = 0, double r2 = 0)
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
        public static SectionProperty CreateISection(SectionType mType, double widthTopFlange, double widthBotFlange, double totalDepth, double flangeThicknessTop, double flangeThicknessBot, double webThickness, double webRadius, double toeRadius)
        {
            return new SectionProperty(ShapeType.ISection, mType, totalDepth, Math.Max(widthTopFlange, widthBotFlange), flangeThicknessTop, webThickness, webRadius, toeRadius, 0, widthTopFlange, widthBotFlange, flangeThicknessBot);
        }

        /// <summary>
        /// Create a rectangular shaped section
        /// </summary>
        /// <param name="mType"></param>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <param name="outerRadius"></param>
        /// <returns></returns>
        public static SectionProperty CreateRectangularSection(SectionType mType, double height, double width, double outerRadius = 0)
        {
            return new SectionProperty(ShapeType.Rectangle, mType, height, width, 0, 0, outerRadius, 0);
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
        public static SectionProperty CreateAngleSection(SectionType mType, double height, double width, double flangeThickness, double webThickness, double webRadius, double toeRadius)
        {
            return new SectionProperty(ShapeType.Angle, mType, height, width, flangeThickness, webThickness, webRadius, toeRadius);
        }

        /// <summary>
        /// create a circular section
        /// </summary>
        /// <param name="mType"></param>
        /// <param name="diameter"></param>
        /// <returns></returns>
        public static SectionProperty CreateCircularSection(SectionType mType, double diameter)
        {
            return new SectionProperty(ShapeType.Circle, mType, diameter, diameter, 0, 0, 0, 0);
        }

        private static double[] CreateSectionData(double height, double width, double tw, double tf1, double r1, double r2, double mass = 0, double b1 = 0, double b2 = 0, double tf2 = 0, double b3 = 0, double spacing = 0)
        {
            double[] SectionData = new double[15];
            SectionData[(int)SectionTableColumn.Mass] = mass;
            SectionData[(int)SectionTableColumn.Width] = width;
            SectionData[(int)SectionTableColumn.Height] = height;
            SectionData[(int)SectionTableColumn.TW] = tw;
            SectionData[(int)SectionTableColumn.TF1] = tf1;
            SectionData[(int)SectionTableColumn.TF2] = tf2;
            SectionData[(int)SectionTableColumn.r1] = r1;
            SectionData[(int)SectionTableColumn.r2] = r2;
            SectionData[(int)SectionTableColumn.B1] = b1;
            SectionData[(int)SectionTableColumn.B2] = b2;
            SectionData[(int)SectionTableColumn.B3] = b3;
            SectionData[(int)SectionTableColumn.Spacing] = b3;
            return SectionData;
        }

        private static Group<Curve> CreateGeometry(ShapeType shapeType, double height, double breadth, double tw, double tf1, double r1, double r2, double b1 = 0, double b2 = 0, double tf2 = 0, double b3 = 0)
        {
            Group<Curve> edges = null;

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

        private void CalculateSection()
        {
            SectionCalculator sC = new SectionCalculator(Edges);
            double cx = sC.CentreX;
            double cy = sC.CentreY;
            m_Area = sC.Area;
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

        /// <summary>Section type</summary>
        /// 
        [DefaultValue(null)]
        public ShapeType Shape { get; set; }

        /// <summary>
        /// Type of material
        /// </summary>
        /// 
        [DefaultValue(null)]
        public SectionType SectionMaterial { get; set; }

        /// <summary>
        /// Orientation
        /// </summary>
        /// 
        [DefaultValue(null)]
        public double Orientation { get; set; }

        /// <summary>Cross sectional area</summary>
        public double GrossArea
        {
            get
            {
                if (m_Area == 0) CalculateSection();
                return m_Area;
            }
        }

        /// <summary>
        /// Total height of section
        /// </summary>
        public double TotalDepth
        {
            get
            {
                return Edges.Bounds().Extents.Y * 2;
            }
        }

        /// <summary>
        /// Total width of section
        /// </summary>
        public double TotalWidth
        {
            get
            {
                return Edges.Bounds().Extents.X * 2;
            }
        }

        /// <summary>Second moment of inertia about the major axis</summary>
        public double Ix
        {
            get
            {
                if (m_Ix == 0) CalculateSection();
                return m_Ix;
            }
        }

        /// <summary>Second moment of inertia about the minor axis</summary>
        public double Iy
        {
            get
            {
                if (m_Iy == 0) CalculateSection();
                return m_Iy;
            }
        }

        /// <summary>Torsion Constant</summary>
        public double J
        {
            get
            {
                return 0;
            }
        }

        public double Vy
        {
            get
            {
                if (m_Vy == 0) CalculateSection();
                return m_Vy;
            }
        }

        public double Vpy
        {
            get
            {
                if (m_Vpy == 0) CalculateSection();
                return m_Vpy;
            }
        }

        public double Vx
        {
            get
            {
                if (m_Vx == 0) CalculateSection();
                return m_Vx;
            }
        }

        public double Vpx
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
        public double Sx
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
        public double Sy
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
        public double Zx
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
        public double Zy
        {
            get
            {
                if (m_Zy == 0) CalculateSection();
                return m_Zy;
            }
        }

        /// <summary>Information regarding section property type for the user</summary>
        /// 
        [DefaultValue(null)]
        public string Description { get; set; }

    }
}
