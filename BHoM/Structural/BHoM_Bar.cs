using BHoM.Geometry;
using System;
using System.Reflection;
using BHoM.Structural.Loads;
using System.Collections.Generic;
using System.ComponentModel;

namespace BHoM.Structural 
{
    /// <summary>
    /// Bar objects for 1D finite element bars. Note, cable elements separate.
    /// </summary>
    public class Bar : BHoM.Global.BHoMObject, IStructuralObject
    {
        /////////////////
        ////Properties///
        /////////////////

        private Line m_Line;
        private double m_Length;
        private Node m_StartNode;
        private Node m_EndNode;

        /// <summary>
        /// Design type name for design purposes (e.g. Simple Column). Can be used to help 
        /// downstream selections/filters but shouldn't be confused with Groups, which are 
        /// unique to bars (bars and objects can be added to multiple object groups).
        /// </summary>
        public string DesignGroupName { get; private set; }

        /// <summary>Section property</summary>
        [DisplayName("Section")]
        [Description("Section Property of the bar")]
        [DefaultValue(null)]
        public BHoM.Structural.SectionProperties.SectionProperty SectionProperty { get; set; }

        /// <summary>Material inherited from section property</summary>
        [DisplayName("Material")]
        [Description("Bar Material assigned to the bar object")]
        [DefaultValue(null)]
        public BHoM.Materials.Material Material  {  get; set; }

        /// <summary>Releases</summary>
        [DisplayName("Bar Releases")]
        [Description("Bar Releases assigned to bar object")]       
        [DefaultValue(null)]
        public BHoM.Structural.BarRelease Release { get; set; }

        /// <summary>Start node</summary>
        public Node StartNode 
        {
            get
            {
                return m_StartNode;
            }
            set
            {
                if (m_StartNode != null)
                {
                    m_StartNode.ConnectedBars.Remove(this);
                }
                m_StartNode = value;
                m_StartNode.ConnectedBars.Add(this);
                m_Line = null;
                m_Length = 0;
            }
        }

        /// <summary>End node</summary>
        public Node EndNode 
        {
            get
            {
                return m_EndNode;
            }
            set
            {
                if (m_EndNode != null)
                {
                    m_EndNode.ConnectedBars.Remove(this);
                }
                m_EndNode = value;
                m_EndNode.ConnectedBars.Add(this);
                m_Line = null;
                m_Length = 0;
            }
        }

        /// <summary>The line defining the bar centre or location line</summary>
        public BHoM.Geometry.Line Line 
        { 
            get
            {
                return m_Line != null ? m_Line : m_Line = new Line(StartNode.Point, EndNode.Point);
            }
        }

        /// <summary>Bar length</summary>
        public double Length
        {
            get
            {
                return m_Length != 0 ? m_Length : m_Length = Line.Length;
            }
        }

        /// <summary>
        /// Bar orientation angle. For non-vertical bars, angle is measured in the bar YZ plane
        /// betwen the Y axis and the Y vector projected one a vertical plane defined by the start and end
        /// nodes. For vertical bars, angle is measured between the bar Y axis and global Y axis. A bar is 
        /// vertical if the distance between end points projected to a horizontal plane is less than 0.0001
        /// </summary>
        [DisplayName("Orientation")]
        [Description("Bar axis rotation")]
        [DefaultValue(0)]
        public double OrientationAngle
        {
            get;
            set;
        }
        /// <summary>Construction phase</summary>
        //public BHoM.Planning.Construction.ConstructionPhase ConstructionPhase {get; set;}

        /// <summary>Storey of the building that the bar is assigned to</summary>
        /// 
        [DisplayName("Story")]
        [Description("Storey that the bar is assigned to")]
        [DefaultValue(null)]
        public BHoM.Structural.Storey Storey { get; private set; }

        ////////////////////
        ////CONSTRUCTORS////
        ////////////////////

        internal Bar() { }

        /// <summary>
        /// Construct a bar from BHoM nodes and set number
        /// </summary>
        /// <param name="barNumber"></param>
        /// <param name="startNode"></param>
        /// <param name="endNode"></param>
        public Bar(BHoM.Structural.Node startNode, BHoM.Structural.Node endNode)
        {
            this.StartNode = startNode;
            this.EndNode = endNode;
        }


        /// <summary>
        /// Construct a bar from BHoM nodes and set number
        /// </summary>
        /// <param name="barNumber"></param>
        /// <param name="startNode"></param>
        /// <param name="endNode"></param>
        public Bar(BHoM.Structural.Node startNode, BHoM.Structural.Node endNode, string barName)
        {
            this.StartNode = startNode;
            this.EndNode = endNode;
            Name = barName;
        }

        ///////////////
        ////METHODS////
        ///////////////


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

        /// <summary>
        /// Set the storey which the bar belongs to
        /// </summary>
        /// <param name="storey"></param>
        public void SetStorey(BHoM.Structural.Storey storey)
        {
            this.Storey = storey;
        }

        /// <summary>
        /// Set the section property name. 
        /// </summary>
        /// <param name="sectionProperty"></param>
        public void SetSectionProperty(BHoM.Structural.SectionProperties.SectionProperty sectionProperty)
        {
           this.SectionProperty = sectionProperty;
        }

        /// <summary>
        /// Set the design group name
        /// </summary>
        /// <param name="designGroupName"></param>
        public void SetDesignGroupName(string designGroupName)
        {
            this.DesignGroupName = designGroupName;
        }
    }
}
