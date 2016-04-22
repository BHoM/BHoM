using BHoM.Geometry;
using System;
using System.Reflection;


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
        
        /// <summary>
        /// Design type name for design purposes (e.g. Simple Column). Can be used to help 
        /// downstream selections/filters but shouldn't be confused with Groups, which are 
        /// unique to bars (bars and objects can be added to multiple object groups).
        /// </summary>
        public string DesignGroupName { get; private set; }
        
        /// <summary>Section property name inherited from section property</summary>
        public string SectionPropertyName { get; set; }

        /// <summary>Section property</summary>
        public BHoM.Structural.SectionProperties.SectionProperty SectionProperty
        {
            get     // #AD - I think this is wrong. We should simply store sectionPropertyName or sectionProperty not do a lookup into a project
            {
                return Project.GetObject(Parameters.LookUp<Guid>(Global.Param.SectionProperty)) as BHoM.Structural.SectionProperties.SectionProperty;
            }
            set
            {
                Parameters.AddItem<Guid>(Global.Param.SectionProperty, value.BHoM_Guid);
            }
        }
        /// <summary>Material inherited from section property</summary>
        public BHoM.Materials.Material Material 
        { 
            get
            {
                return Project.GetObject(Parameters.LookUp<Guid>(Global.Param.Material)) as Materials.Material;
            }
            set
            {
                Parameters.AddItem<Guid>(Global.Param.Material, value.BHoM_Guid);
            }
        }

        /// <summary>Releases</summary>
        public BHoM.Structural.BarRelease Release
        {
            get
            {
                return Project.GetObject(Parameters.LookUp<Guid>(Global.Param.Release)) as BarRelease;
            }
            set
            {
                Parameters.AddItem<Guid>(Global.Param.Release, value.BHoM_Guid);
            }
        }

        /// <summary>Start node</summary>
        public Node StartNode 
        { 
            get
            {
                return Project.GetObject(Parameters.LookUp<Guid>(Global.Param.StartNode)) as Node;
            }
            private set
            {
                Parameters.AddItem<Guid>(Global.Param.StartNode, value.BHoM_Guid);
            }
        }

        /// <summary>End node</summary>
        public Node EndNode 
        {
            get
            {
                return Project.GetObject(Parameters.LookUp<Guid>(Global.Param.EndNode)) as Node;
            }
            private set
            {
                Parameters.AddItem<Guid>(Global.Param.EndNode, value.BHoM_Guid);
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
        public double OrientationAngle
        {
            get
            {
                return Parameters.LookUp<double>(Global.Param.Orientation);
            }
            set
            {
                Parameters.AddItem<double>(Global.Param.Orientation, value);
            }
        }
        /// <summary>Construction phase</summary>
        public BHoM.Planning.Construction.ConstructionPhase ConstructionPhase {get; set;}

        /// <summary>Storey of the building that the bar is assigned to</summary>
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
        internal Bar(BHoM.Structural.Node startNode, BHoM.Structural.Node endNode, int barNumber)
        {
            this.StartNode = startNode;
            this.EndNode = endNode;
            this.Number = barNumber;
            //if (StartNode.IsValid && EndNode.IsValid)
            //{
            //    this.Line = new Geometry.Line(startNode.Point, endNode.Point);
            //    this.Length = Line.Length;

            //    BHoM.Structural.SectionProperties.SteelBoxSection abc = new BHoM.Structural.SectionProperties.SteelBoxSection();
                                 
            //}
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
            if (EndNode.Number == node.Number)
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
           this.SectionPropertyName = sectionProperty.Name;
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
