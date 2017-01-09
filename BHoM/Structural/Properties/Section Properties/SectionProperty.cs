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

    public abstract partial class SectionProperty : BHoMObject
    {
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
            object[] data = new SQLAccessor(Database.SteelSection, project.Config.SectionDatabase).GetDataRow(new string[] { "Name", "Name1", "Name2" }, new string[] { name });

            if (data != null)
            {
                try
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

            sec.SectionData[(int)CableSectionData.A] = (double)data[(int)CableSectionData.A];
            sec.SectionData[(int)CableSectionData.BL] = (double)data[(int)CableSectionData.BL];
            sec.SectionData[(int)CableSectionData.D] = (double)data[(int)CableSectionData.D];
            sec.SectionData[(int)CableSectionData.LimTen] = (double)data[(int)CableSectionData.LimTen];
            sec.SectionData[(int)CableSectionData.Stiffness] = (double)data[(int)CableSectionData.Stiffness];
            sec.SectionData[(int)CableSectionData.Weight] = (double)data[(int)CableSectionData.Weight];
            sec.SectionData[(int)CableSectionData.WeightEndAdjustable] = (double)data[(int)CableSectionData.WeightEndAdjustable];
            sec.SectionData[(int)CableSectionData.WeightEndOpen] = (double)data[(int)CableSectionData.WeightEndOpen];

            return sec;
        }

        protected static double[] CreateSectionData(double height, double width, double tw, double tf1, double r1, double r2, double mass = 0, double b1 = 0, double b2 = 0, double tf2 = 0, double b3 = 0, double spacing = 0)
        {
            double[] SectionData = new double[15];
            SectionData[(int)SteelSectionData.Mass] = mass;
            SectionData[(int)SteelSectionData.Width] = width;
            SectionData[(int)SteelSectionData.Height] = height;
            SectionData[(int)SteelSectionData.TW] = tw;
            SectionData[(int)SteelSectionData.TF1] = tf1;
            SectionData[(int)SteelSectionData.TF2] = tf2;
            SectionData[(int)SteelSectionData.r1] = r1;
            SectionData[(int)SteelSectionData.r2] = r2;
            SectionData[(int)SteelSectionData.B1] = b1;
            SectionData[(int)SteelSectionData.B2] = b2;
            SectionData[(int)SteelSectionData.B3] = b3;
            SectionData[(int)SteelSectionData.Spacing] = b3;
            return SectionData;
        }

        /*****************************************************/
        /*********** Static section constructors *******/
        /*****************************************************/

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
                double b1 = SectionData[(int)SteelSectionData.B1];
                double b2 = SectionData[(int)SteelSectionData.B2];
                double tf1 = SectionData[(int)SteelSectionData.TF1];
                double tf2 = SectionData[(int)SteelSectionData.TF2];
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
            if (double.IsInfinity(m_Cx))
            {
                m_Edges = m_OrigionalEdges.DuplicateGroup();
                m_Edges.Translate(new Vector(-CentreX, -CentreY, 0));
                m_Edges.Transform(Transform.Rotation(Point.Origin, Vector.ZAxis(), Orientation));
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
