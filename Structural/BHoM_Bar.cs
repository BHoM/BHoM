namespace BHoM.Structural
{
    /// <summary>
    /// Bar objects for 2D finite element bars. Note, cable elements separate.
    /// </summary>
    public class Bar
    {
        /// <summary>BHoM unique ID</summary>
        public System.Guid BHoM_Guid { get; private set; }
        /// <summary>Robot unique ID</summary>
        public int Robot_Guid { get; private set; }
        /// <summary>GSA unique ID</summary>
        public int GSA_Guid { get; private set; }
        /// <summary>ETABS unique ID</summary>
        public int ETABS_Guid { get; private set; }

        /// <summary>Bar number</summary>
        public int Number { get; private set; }

        /// <summary>Bar name</summary>
        public string Name { get; private set; }

        /// <summary>
        /// Design type name for design purposes (e.g. Simple Column). Can be used to help 
        /// downstream selections/filters but shouldn't be confused with Groups, which are 
        /// unique to bars (bars and objects can be added to multiple object groups).
        /// </summary>
        public string DesignGroupName { get; private set; }
        
        /// <summary>Section property name inherited from section property</summary>
        public string SectionPropertyName { get; private set; }

        /// <summary>Section property</summary>
        public BHoM.Structural.SectionProperties.ISectionProperty SectionProperty { get; set; }

        /// <summary>Material inherited from section property</summary>
        public BHoM.Materials.Material Material { get; set; }

        /// <summary>Material name inherited from section property BHoM.Materials.Material name</summary>
        public string MaterialPropertyName { get; private set; }

        /// <summary>Releases</summary>
        public BHoM.Structural.BarRelease Release { get; private set; }

        /// <summary>Release name is generated from the start and end BHoM.Structural.</summary>
        public string ReleaseName { get; private set; }

        /// <summary>Start node</summary>
        public Node StartNode { get; private set; }

        /// <summary>End node</summary>
        public Node EndNode { get; private set; }

        /// <summary>
        /// Bar orientation angle. For non-vertical bars, angle is measured in the bar YZ plane
        /// betwen the Y axis and the Y vector projected one a vertical plane defined by the start and end
        /// nodes. For vertical bars, angle is measured between the bar Y axis and global Y axis. A bar is 
        /// vertical if the distance between end points projected to a horizontal plane is less than 0.0001
        /// </summary>
        public double OrientationAngle { get; set; }

        /// <summary>Storey of the building that the bar is assigned to</summary>
        public BHoM.Structural.Storey Storey { get; private set; }

        ////////////////////
        ////CONSTRUCTORS////
        ////////////////////

        /// <summary>
        /// Construct a bar from BHoM nodes
        /// </summary>
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
        public Bar(int barNumber, BHoM.Structural.Node startNode, BHoM.Structural.Node endNode)
        {
            this.Number = barNumber;
            this.StartNode = startNode;
            this.EndNode = endNode;
        }

        ///////////////
        ////METHODS////
        ///////////////

        /// <summary>
        /// Get the node at the opposite end to the known (input) node
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public Node GetOtherEnd(Node node)
        {
            if (EndNode.Number == node.Number)
                return StartNode;
            else
                return EndNode;
        }

        /// <summary>
        /// Set the bar number
        /// </summary>
        /// <param name="i"></param>
        public void SetNumber(int i)
        {
            this.Number = i;
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
        /// <param name="sectionPropertyName"></param>
        public void SetSectionPropertyName(string sectionPropertyName)
        {
            this.SectionPropertyName = sectionPropertyName;
        }


    }
}
