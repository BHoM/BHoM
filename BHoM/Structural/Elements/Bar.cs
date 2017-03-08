using BHoM.Geometry;
using BHoM.Base;
using System;
using System.Reflection;
using BHoM.Structural.Loads;
using System.Collections.Generic;
using System.ComponentModel;

namespace BHoM.Structural.Elements
{
    /// <summary>
    /// Bar objects for 1D finite element bars. Note, cable elements separate.
    /// </summary>
    public class Bar : BHoMObject
    {
        #region Constructors
        public Bar()
        {
            SetStartPoint(new Point());
            SetEndPoint(new Point());
        }

        /// <summary>
        /// Construct a bar from BHoM points and name
        /// </summary>
        /// <param name="startPoint"></param>
        /// <param name="endPoint"></param>
        /// <param name="barName"></param>
        public Bar(Point startPoint, Point endPoint, string barName = "")
        {
            SetStartPoint(startPoint);
            SetEndPoint(endPoint);
            Name = barName;
        }

        /// <summary>
        /// Construct a bar from BHoM line and name
        /// </summary>
        /// <param name="line"></param>
        /// <param name="barName"></param>
        public Bar(Line line, string barName = "") : this(line.StartPoint, line.EndPoint, barName)
        {
        }
        #endregion

        #region Properties

        /// <summary>Section property</summary>
        [DisplayName("Section")]
        [Description("Section Property of the bar")]
        [DefaultValue(null)]
        public BHoM.Structural.Properties.SectionProperty SectionProperty { get; set; }

        /// <summary>Material inherited from section property</summary>
        public BHoM.Materials.Material Material
        {
            get
            {
                return SectionProperty != null ? SectionProperty.Material : null;
            }
        }

        /// <summary>Releases</summary>
        [DisplayName("Releases")]
        [Description("Bar Releases assigned to bar object")]       
        [DefaultValue(null)]
        public BHoM.Structural.Properties.BarRelease Release { get; set; }

        /// <summary>Spring</summary>
        [DisplayName("Spring")]
        [Description("Elastic bar constraint")]
        [DefaultValue(null)]
        public BHoM.Structural.Properties.BarConstraint Spring { get; set; }

        /// <summary>Spring</summary>
        [DisplayName("Offset")]
        [Description("Bar Offsets")]
        [DefaultValue(null)]
        public BHoM.Structural.Properties.Offset Offset { get; set; }

        public BarStructuralUsage StructuralUsage { get; set; }

        /// <summary>
        /// Sets wich type of elements that should be used in analysis software
        /// </summary>
        public BarFEAType FEAType { get; set; }

        public Node StartNode    
        {
            get
            {
                return m_StartNode;
            }
            set
            {
                m_StartNode = value;
            }
        }
        
        public Node EndNode           
        {
            get
            {
                return m_EndNode;
            }
            set
            {
                m_EndNode = value;
            }
        }

        [DefaultValue(null)]
        public Point StartPoint
        {
            get
            {
                return StartNode.Point;
            }
        }

        public void SetStartPoint(Point p)
        {
            if (p != null)
                StartNode = new Node(p);
        }

        [DefaultValue(null)]
        public Point EndPoint
        {
            get
            {
                return EndNode.Point;
            }
        }
        public void SetEndPoint(Point p)
        {
            if (p != null)
                EndNode = new Node(p);
        }

        /// <summary>The line defining the bar centre or location line</summary>
        public BHoM.Geometry.Line Line 
        { 
            get
            {
                return new Line(StartPoint, EndPoint);
            }
        }

        /// <summary>Bar length</summary>
        public double Length
        {
            get
            {
                return StartPoint.DistanceTo(EndPoint);
            }
        }

        /// <summary>
        /// Bar orientation angle in radians. For non-vertical bars, angle is measured in the bar YZ plane
        /// betwen the Y axis and the Y vector projected one a vertical plane defined by the start and end
        /// nodes. For vertical bars, angle is measured between the bar Y axis and global Y axis. A bar is 
        /// vertical if the distance between end points projected to a horizontal plane is less than 0.0001
        /// </summary>
        [DisplayName("OrientationAngle")]
        [Description("Bar orientation angle (Radians)")]
        [DefaultValue(0)]
        public double OrientationAngle
        {
            get;
            set;
        }
      
        /// <summary>
        /// Construct a bar from BHoM nodes and name
        /// </summary>
        /// <param name="startNode"></param>
        /// <param name="endNode"></param>
        /// <param name="barName"></param>
        public Bar(Node startNode, Node endNode, string barName = "")
        {
            this.StartNode = startNode;
            this.EndNode = endNode;
            Name = barName;
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Get the node at the opposite end to the known (input) node
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public Node GetOppositeNode(Node node)
        {
            if (EndNode.BHoM_Guid == node.BHoM_Guid)
                return StartNode;
            else
                return EndNode;
        }

        /// <summary></summary>
        public Point GetOppositeEnd(Point point)
        {
            if (StartPoint.DistanceTo(point) < EndPoint.DistanceTo(point))
                return EndPoint;
            else
                return StartPoint;
        }

        /// <summary></summary>
        public override BHoM.Geometry.GeometryBase GetGeometry()
        {
            return Line;
        }

        /// <summary></summary>
        public override void SetGeometry(GeometryBase geometry)
        {
            if (geometry is Curve)
            {
                Curve curve = geometry as Curve;
                SetStartPoint(curve.StartPoint);
                SetEndPoint(curve.EndPoint);
            }
        }

        /// <summary>
        /// Set the section property name. 
        /// </summary>
        /// <param name="sectionProperty"></param>
        public void SetSectionProperty(BHoM.Structural.Properties.SectionProperty sectionProperty)
        {
            this.SectionProperty = sectionProperty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Bar: " + StartPoint + " -> " + EndPoint;
        }

        /// <summary>
        /// Switches start and end node
        /// </summary>
        public void FlipNodes()
        {
            Node temp = StartNode;
            StartNode = EndNode;
            EndNode = temp;
        }

        #endregion

        #region Static Methods
        #endregion

        #region Fields
        private Node m_StartNode;
        private Node m_EndNode;
        private double m_EffectiveLength;
        #endregion
    }
}
