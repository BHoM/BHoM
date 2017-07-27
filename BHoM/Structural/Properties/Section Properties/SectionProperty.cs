﻿using BHoM.Geometry;
using BHoM.Base;
using BHoM.Materials;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using BHoM.Global;
using BHoM.Structural.Databases;
using BHoM.Base.Data;

namespace BHoM.Structural.Properties
{
    /// <summary>
    /// Section property class, the parent abstract class for all structural 
    /// sections (RC, steel, PT beams, columns, bracing). Properties defined in this 
    /// parent class are those that would populate a multi category section database only
    /// </summary>

    public abstract partial class SectionProperty : BHoMObject
    {
        private double[] m_SectionData;

        [Browsable(false)]
        public virtual double[] SectionData
        {
            get
            {
                if (m_SectionData == null)
                {
                    m_SectionData = GetSectionData();
                }
                return m_SectionData;
            }
            set
            {
                m_SectionData = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public SectionProperty() { }

        /// <summary>
        /// Geometry of the cross section
        /// </summary>

        [Browsable(false)]
        [DefaultValue(null)]
        public BHoM.Geometry.Group<Curve> Edges
        {
            get
            {
                return m_OrigionalEdges;
            }
            set
            {
                m_OrigionalEdges = value;
                Update();
            }
        }

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
            IDataAdapter database = Project.ActiveProject.GetDatabase<SteelSectionRow>(Database.SteelSection);
            database.TableName = Project.ActiveProject.Config.SectionDatabase;
            SteelSectionRow data = database.GetDataRow<SteelSectionRow>("Name", name);
            if (data != null)
            {
                try
                {
                    ShapeType shape = (ShapeType)data.Shape;
                    double mass = data.Mass;
                    double breadth = data.Width;
                    double height = data.Height;
                    double tw = data.T1;
                    double tf1 = data.T2;
                    double tf2 = data.T3;
                    double b1 = data.B1;
                    double b2 = data.B2;
                    double b3 = data.B3;
                    double s = data.GAP;
                    double r1 = data.r1;
                    double r2 = data.r2;
                    

                    BHoM.Geometry.Group<Curve> edges = CreateGeometry(shape, height, breadth, tw, tf1, r1, r2, b1, b2, tf2, b3);
                    SectionProperty property = new SteelSection(edges, shape);
                    property.Name = name;
                    property.SectionData = CreateSectionData(height, breadth, tw, tf1, r1, r2, mass, b1, b2, tf2, b3, s);
                    property.Material = Material.Default(MaterialType.Steel);
                    return edges != null ? property : null;
                }
                catch
                {
                    return null;
                }
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
            if (name.EndsWith(".0")) name = name.Substring(0, name.Length - 2);
            IDataAdapter database = Project.ActiveProject.GetDatabase<CableSectionRow>(Database.Cables);
            database.TableName = Project.ActiveProject.Config.CableDataBase;
            CableSectionRow data = database.GetDataRow<CableSectionRow>("Name", name);

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
            IDataAdapter database = Project.ActiveProject.GetDatabase<CableSectionRow>(Database.Cables);
            database.TableName = Project.ActiveProject.Config.CableDataBase;
            CableSectionRow data = database.GetDataRow<CableSectionRow>("Diameter", diameter.ToString());

            Material mat = null;

            if (database.TableName == "BridonFullLocked")
            {
                mat = Material.LoadFromDB("CaFullLockBridon");
            }

            if (data != null)
            {
                return CreateCableSectionFromDB(data, numberOfCables, mat);
            }

            return null;
        }

        private static SectionProperty CreateCableSectionFromDB(CableSectionRow data, int numberOfCables, Material mat = null)
        {
            if (mat == null)
                mat = BHoM.Materials.Material.Default(Materials.MaterialType.Cable);

            CableSection sec = new CableSection(data.Diameter, data.Area, mat, numberOfCables);

            sec.SectionData[(int)CableSectionData.A] = data.Area;
            sec.SectionData[(int)CableSectionData.BL] = data.BreakingLoad;
            sec.SectionData[(int)CableSectionData.D] = data.Diameter;
            sec.SectionData[(int)CableSectionData.LimTen] = data.LimitTension;
            sec.SectionData[(int)CableSectionData.Stiffness] = data.AxialStiffness;
            sec.SectionData[(int)CableSectionData.Weight] = data.Weight;
            sec.SectionData[(int)CableSectionData.WeightEndAdjustable] = data.AdjustableSpeltFork;
            sec.SectionData[(int)CableSectionData.WeightEndOpen] = data.SelfWeightEnd;

            return sec;
        }

        //private static SectionProperty CreateCableSectionFromDB(object[] data, int numberOfCables)
        //{
        //    double d = (double)data[(int)CableSectionData.D];
        //    double A = (double)data[(int)CableSectionData.A];
        //    string name = (string)data[(int)CableSectionData.Name];
        //    CableSection sec = new CableSection(d, A, numberOfCables);

        //    sec.SectionData[(int)CableSectionData.A] = (double)data[(int)CableSectionData.A];
        //    sec.SectionData[(int)CableSectionData.BL] = (double)data[(int)CableSectionData.BL];
        //    sec.SectionData[(int)CableSectionData.D] = (double)data[(int)CableSectionData.D];
        //    sec.SectionData[(int)CableSectionData.LimTen] = (double)data[(int)CableSectionData.LimTen];
        //    sec.SectionData[(int)CableSectionData.Stiffness] = (double)data[(int)CableSectionData.Stiffness];
        //    sec.SectionData[(int)CableSectionData.Weight] = (double)data[(int)CableSectionData.Weight];
        //    sec.SectionData[(int)CableSectionData.WeightEndAdjustable] = (double)data[(int)CableSectionData.WeightEndAdjustable];
        //    sec.SectionData[(int)CableSectionData.WeightEndOpen] = (double)data[(int)CableSectionData.WeightEndOpen];

        //    return sec;
        //}

        protected static double[] CreateSectionData(double height, double width, double tw, double tf1, double r1, double r2, double mass = 0, double b1 = 0, double b2 = 0, double tf2 = 0, double b3 = 0, double spacing = 0)
        {
            double[] SectionData = new double[15];
            SectionData[(int)SteelSectionData.Mass] = mass;
            SectionData[(int)SteelSectionData.Width] = width;
            SectionData[(int)SteelSectionData.Height] = height;
            SectionData[(int)SteelSectionData.TW] = tw;
            SectionData[(int)SteelSectionData.TF1] = tf1;
            SectionData[(int)SteelSectionData.TF2] = tf2 == 0 ? tf1 : tf2;
            SectionData[(int)SteelSectionData.r1] = r1;
            SectionData[(int)SteelSectionData.r2] = r2;
            SectionData[(int)SteelSectionData.B1] = b1 == 0 ? width : b1;
            SectionData[(int)SteelSectionData.B2] = b2 == 0 ? b1 : b2;
            SectionData[(int)SteelSectionData.B3] = b3;
            SectionData[(int)SteelSectionData.Spacing] = b3;
            return SectionData;
        }

        /*****************************************************/
        /*********** Static section constructors *******/
        /*****************************************************/

        private double[] GetSectionData()
        {
            if (Edges != null)
            {
                double area = GrossArea;
                double width = TotalWidth;
                double depth = TotalDepth;
                List<Slice> hSlices = HorizontalSlices;
                List<Slice> vSlices = VerticalSlices;
                double b1 = hSlices[0].Length;
                double b2 = hSlices[hSlices.Count - 1].Length;
                double d1 = vSlices[0].Length;
                double d2 = vSlices[vSlices.Count - 1].Length;
                double tw = hSlices[hSlices.Count / 2].Length;
                double tf1 = 0;
                double tf2 = 0;

                if (area > width * depth * 0.95)
                {
                    //Rectangle
                    Shape = ShapeType.Rectangle;
                }
                else if (Utils.NearEqual(area, width * depth * Math.PI / 4, 0.001))
                {
                    Shape = ShapeType.Circle;
                }
                else if (Utils.NearEqual(vSlices[(int)vSlices.Count / 2].Length, depth, 0.001))
                {
                    //ISection, TSection, ZSection
                    Slice verticalThird = vSlices[vSlices.Count / 3];
                    Slice verticalTwoThird = vSlices[vSlices.Count * 2 / 3];
                    for (int i = vSlices.Count / 3; i < vSlices.Count * 2; i++)
                    {
                        if (vSlices[i].Placement.Length == 4)
                        {
                            tf2 = vSlices[i].Placement[1] - vSlices[i].Placement[0];
                            tf1 = vSlices[i].Placement[3] - vSlices[i].Placement[2];
                            Shape = ShapeType.ISection;
                            break;
                        }
                    }
                    if (Shape != ShapeType.ISection)
                    {
                        if (b1 > tw && b2 > tw) //not a tee
                        {
                            tf1 = verticalThird.Placement[0] > verticalTwoThird.Placement[0] ? verticalTwoThird.Length : verticalThird.Length;
                            tf2 = verticalThird.Placement[0] > verticalTwoThird.Placement[0] ? verticalThird.Length : verticalTwoThird.Length;
                            Shape = ShapeType.Zed;
                        }
                        else
                        {
                            tf1 = verticalThird.Length;
                            Shape = ShapeType.Tee;
                        }
                    }
                }
                else if (b1 > width * 0.8 && b2 > width * 0.8 && d1 > depth * 0.8 && d2 > depth * 0.8)
                {
                    tw = hSlices[hSlices.Count / 2].Placement[1] - hSlices[hSlices.Count / 2].Placement[0];
                    tf1 = vSlices[vSlices.Count / 3].Length;
                    Shape = ShapeType.Box;
                }
                else if ((Utils.NearEqual(b1, width, 0.001) || Utils.NearEqual(b2, width, 0.001)) &&
                    (Utils.NearEqual(d1, width, 0.001) || Utils.NearEqual(d2, width, 0.001)))
                {
                    Shape = ShapeType.Angle;
                    tf1 = tf1 = vSlices[vSlices.Count / 2].Length;
                }
                else if (Utils.NearEqual(tw, vSlices[vSlices.Count / 2].Length, 0.001))
                {
                    Shape = ShapeType.Tube;
                    tf1 = tw / 2;
                    tw = tf1;
                }
                else
                {
                    Shape = ShapeType.Polygon;
                }
                double mass = GrossArea * Material.Density / 9.8;
                return CreateSectionData(depth, width, tw, tf1, 0, 0, mass, b1, b2, tf2);
            }
            return null;
        }

        public static SectionProperty CreateCustomSection(MaterialType matType, BHoM.Geometry.Group<Curve> edges)
        {
            SectionProperty section = CreateSection(matType);
            //section.SectionData = CreateSectionData(totalDepth, totalwidth, webThickness, flangeThickness, r1, r2);
            section.Edges = edges;
            section.SectionData = section.GetSectionData();
            return section;
        }

        public static SectionProperty CreateTeeSection(MaterialType matType, double totalDepth, double totalwidth, double flangeThickness, double webThickness, double r1 = 0, double r2 = 0)
        {
            SectionProperty section = CreateSection(matType);
            section.SectionData = CreateSectionData(totalDepth, totalwidth, webThickness, flangeThickness, r1, r2);
            section.Edges = CreateGeometry(ShapeType.Tee, totalDepth, totalwidth, webThickness, flangeThickness, r1, r2);
            section.Shape = ShapeType.Tee;
            return section;
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
        public static SectionProperty CreateISection(MaterialType matType, double widthTopFlange, double widthBotFlange, double totalDepth, double flangeThicknessTop, double flangeThicknessBot, double webThickness, double webRadius, double toeRadius)
        {
            SectionProperty section = CreateSection(matType);
            section.SectionData = CreateSectionData(totalDepth, Math.Max(widthTopFlange, widthBotFlange), webThickness, flangeThicknessTop, webRadius, toeRadius, 0, widthTopFlange, widthBotFlange, flangeThicknessBot);
            section.Edges = CreateGeometry(ShapeType.ISection, totalDepth, Math.Max(widthTopFlange, widthBotFlange), webThickness, flangeThicknessTop, webRadius, toeRadius, widthTopFlange, widthBotFlange, flangeThicknessBot);
            section.Shape = ShapeType.ISection;
            return section;
        }

        /// <summary>
        /// Create a rectangular shaped section
        /// </summary>
        /// <param name="mType"></param>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <param name="outerRadius"></param>
        /// <returns></returns>
        public static SectionProperty CreateRectangularSection(MaterialType matType, double height, double width, double outerRadius = 0)
        {
            SectionProperty section = CreateSection(matType);
            section.SectionData = CreateSectionData(height, width, 0, 0, outerRadius, 0);
            section.Edges = CreateGeometry(ShapeType.Rectangle, height, width, 0, 0, outerRadius, 0);
            section.Shape = ShapeType.Rectangle;
            return section;
        }

        /// <summary>
        /// Create a rectangular shaped section
        /// </summary>
        /// <param name="mType"></param>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <param name="outerRadius"></param>
        /// <returns></returns>
        public static SectionProperty CreateBoxSection(MaterialType matType, double height, double width, double tf, double tw, double outerRadius = 0, double innerRadius = 0)
        {
            SectionProperty section = CreateSection(matType);
            section.SectionData = CreateSectionData(height, width, tw, tf, outerRadius, innerRadius);
            section.Edges = CreateGeometry(ShapeType.Box, height, width, tw, tf, outerRadius, innerRadius);
            section.Shape = ShapeType.Box;
            return section;// new SteelSection(ShapeType.Box, height, width, tw, tf, outerRadius, innerRadius);
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
        public static SectionProperty CreateAngleSection(MaterialType matType, double height, double width, double flangeThickness, double webThickness, double webRadius, double toeRadius)
        {
            SectionProperty section = CreateSection(matType);
            section.SectionData = CreateSectionData(height, width, webThickness, flangeThickness, webRadius, toeRadius);
            section.Edges = CreateGeometry(ShapeType.Angle, height, width, webThickness, flangeThickness, webRadius, toeRadius);
            section.Shape = ShapeType.Angle;
            return section;
        }

        /// <summary>
        /// create a circular section
        /// </summary>
        /// <param name="mType"></param>
        /// <param name="diameter"></param>
        /// <returns></returns>
        public static SectionProperty CreateCircularSection(MaterialType matType, double diameter)
        {
            SectionProperty section = CreateSection(matType);
            section.SectionData = CreateSectionData(diameter, diameter, 0, 0, 0, 0);
            section.Edges = CreateGeometry(ShapeType.Circle, diameter, diameter, 0, 0, 0, 0);
            section.Shape = ShapeType.Circle;
            return section;// new SteelSection(ShapeType.Box, height, width, tw, tf, outerRadius, innerRadius);
        }

        /// <summary>
        /// create a circular section
        /// </summary>
        /// <param name="mType"></param>
        /// <param name="diameter"></param>
        /// <returns></returns>
        public static SectionProperty CreateTubeSection(MaterialType matType, double diameter, double thickness)
        {
            SectionProperty section = CreateSection(matType);
            section.SectionData = CreateSectionData(diameter, diameter, thickness, thickness, 0, 0);
            section.Edges = CreateGeometry(ShapeType.Tube, diameter, diameter, thickness, thickness, 0, 0);
            section.Shape = ShapeType.Tube;
            return section;
        }

        public static SectionProperty CreateSection(BHoM.Geometry.Group<Curve> edges, ShapeType type, MaterialType matType)
        {
            SectionProperty property = null;
            switch (matType)
            {
                case BHoM.Materials.MaterialType.Steel:
                    return new SteelSection(edges, type);
                case BHoM.Materials.MaterialType.Concrete:
                    return new ConcreteSection(edges, type);
                default:
                    property = new SteelSection(edges, type);
                    property.Material = Material.Default(matType);
                    return property;
            }
        }

        public static SectionProperty CreateSection(MaterialType matType)
        {
            SectionProperty property = null;
            switch (matType)
            {
                case BHoM.Materials.MaterialType.Steel:
                    return new SteelSection();
                case BHoM.Materials.MaterialType.Concrete:
                    return new ConcreteSection();
                default:
                    property = new SteelSection();
                    property.Material = Material.Default(matType);
                    return property;
            }
        }

        public static SectionProperty CreateSectionPropertyFromString(string str)
        {
            string[] arr = System.Text.RegularExpressions.Regex.Split(str, @"\s+");

            //Assuming [mm]
            double scalefactor = 0.001;

            if (arr[0] == "RHS")
            {
                double h, w, tw, tf;
                string[] props = arr[1].Split('x');

                if (props.Length < 3)
                    return null;

                if (!(double.TryParse(props[0], out h) && double.TryParse(props[1], out w) && double.TryParse(props[2], out tw)))
                    return null;

                if (props.Length == 3)
                    tf = tw;
                else
                {
                    if (!double.TryParse(props[3], out tf))
                        return null;
                }

                return CreateBoxSection(MaterialType.Steel, h * scalefactor, w * scalefactor, tf * scalefactor, tw * scalefactor);

            }
            else if (arr[0] == "CHS")
            {
                double d, t;
                string[] props = arr[1].Split('x');

                if (props.Length < 2)
                    return null;

                if (!(double.TryParse(props[0], out d) && double.TryParse(props[1], out t)))
                    return null;


                return CreateTubeSection(MaterialType.Steel, d * scalefactor, t * scalefactor);
            }
            else if (arr[0] == "C")
            {
                double d;
                if (!double.TryParse(arr[1], out d))
                    return null;

                return CreateCircularSection(MaterialType.Steel, d * scalefactor);
            }
            else if (arr[0] == "R")
            {
                double w, h;
                string[] props = arr[1].Split('x');

                if (props.Length < 2)
                    return null;

                if (!(double.TryParse(props[0], out h) && double.TryParse(props[1], out w)))
                    return null;

                return CreateRectangularSection(MaterialType.Steel, h * scalefactor, w * scalefactor);
            }


            return null;
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
                    edges = ShapeBuilder.CreateBox(breadth, height, tw, tf1, r1, r2);
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
                    edges = ShapeBuilder.CreateTube(breadth / 2, tw);
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
                    if (SectionData[(int)SteelSectionData.TW] != SectionData[(int)SteelSectionData.TF1])
                        name += "x" + (SectionData[(int)SteelSectionData.TF1] * 1000).ToString();
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
                    name = "CHS " + (SectionData[(int)SteelSectionData.Width] * 1000).ToString() + "x" + (SectionData[(int)SteelSectionData.TW] * 1000).ToString();
                    break;
                default:
                    name = Shape.ToString();
                    break;
            }
            return name;
        }

        /// <summary>Section type</summary> /// 
        [DefaultValue(null)]
        public virtual ShapeType Shape { get; set; }

        /// <summary>
        /// Orientation
        /// </summary>
        [DefaultValue(null)]
        public virtual double Orientation
        {
            get
            {
                return m_Orientation;
            }
            set
            {
                m_Orientation = value;
                Update();
            }
        }

        /// <summary>Cross sectional area</summary>

        /// <summary>Torsion Constant</summary>
        public virtual double J
        {
            get
            {
                double b1 = SectionData[(int)SteelSectionData.B1];
                double b2 = SectionData[(int)SteelSectionData.B2];
                double tf1 = SectionData[(int)SteelSectionData.TF1];
                double tf2 = SectionData[(int)SteelSectionData.TF2];
                double tw = SectionData[(int)SteelSectionData.TW];
                switch (Shape)
                {
                    case ShapeType.ISection:
                    case ShapeType.Channel:
                    case ShapeType.Zed:
                        return (b1 * Math.Pow(tf1, 3) + b2 * Math.Pow(tf2, 3) + (TotalDepth - tf1) * Math.Pow(tw, 3)) / 3;
                    case ShapeType.Tee:
                    case ShapeType.Angle:
                        return TotalWidth * Math.Pow(tf1, 3) + TotalDepth * Math.Pow(tw, 3);
                    case ShapeType.Circle:
                        return Math.PI * Math.Pow(TotalDepth, 4) / 2;
                    case ShapeType.Box:
                        return 2 * tf1 * tw * Math.Pow(TotalWidth - tw, 2) * Math.Pow(TotalDepth - tf1, 2) /
                            (TotalWidth * tw + TotalDepth * tf1 - Math.Pow(tw, 2) - Math.Pow(tf1, 2));
                    case ShapeType.Tube:
                        return Math.PI * (Math.Pow(TotalDepth, 4) - Math.Pow(TotalDepth - tw, 4)) / 2;
                    default:
                        return 0;
                }
            }
        }

        public virtual double Iw
        {
            get
            {
                double b1 = SectionData[(int)SteelSectionData.B1] == 0 ? TotalWidth : SectionData[(int)SteelSectionData.B1];
                double b2 = SectionData[(int)SteelSectionData.B2] == 0 ? TotalWidth : SectionData[(int)SteelSectionData.B2];
                double tf1 = SectionData[(int)SteelSectionData.TF1];
                double tf2 = SectionData[(int)SteelSectionData.TF2] == 0 ? tf1 : SectionData[(int)SteelSectionData.TF2];
                double tw = SectionData[(int)SteelSectionData.TW];

                switch (Shape)
                {
                    case ShapeType.ISection:
                        if (tf1 == tf2 && b1 == b2)
                        {
                            return tf1 * Math.Pow(TotalDepth - tf1, 2) * Math.Pow(TotalWidth, 3) / 24;
                        }
                        else
                        {
                            return tf1 * Math.Pow(TotalDepth - (tf1 + tf2) / 2, 2) / 12 * (Math.Pow(b1, 3) * Math.Pow(b2, 3) / (Math.Pow(b1, 3) + Math.Pow(b2, 3)));
                        }
                    case ShapeType.Channel:
                        return tf1 * Math.Pow(TotalDepth, 2) / 12 * (3 * b1 * tf1 + 2 * TotalDepth * tw / (6 * b1 * tf1 + TotalDepth * tw));
                    default:
                        return 0;
                }
            }
        }


        public override GeometryBase GetGeometry()
        {
            if (double.IsInfinity(m_Cy))
            {
                Update();
                m_Edges.Translate(new Vector(-CentreY, -CentreZ, 0));
            }
            return m_Edges;
        }

        public override string ToString()
        {
            string name = !string.IsNullOrWhiteSpace(Name) ? Name + " " : "";
            string mat = (this.Material != null && !string.IsNullOrWhiteSpace(this.Material.Name)) ? "-" + this.Material.Name : "";
            return name + GenerateStandardName() + mat;

        }
    }
}
