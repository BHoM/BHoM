using System;


namespace BHoM.Structural 
{
    /// <summary>
    /// Bar objects for 1D finite element bars. Note, cable elements separate.
    /// </summary>
    public interface IBar 
        {
        /////////////////
        ////Properties///
        /////////////////
        
        /// <summary>Bar number</summary>
        int Number { get; set; }
                
        /// <summary>Bar name</summary>
        string Name { get; set; }     
        
        /// <summary>
        /// Design type name for design purposes (e.g. Simple Column). Can be used to help 
        /// downstream selections/filters but shouldn't be confused with Groups, which are 
        /// unique to bars (bars and objects can be added to multiple object groups).
        /// </summary>
        string DesignGroupName { get; set; }

        
        /// <summary>Section property name inherited from section property</summary>
        string SectionPropertyName { get; set; }

        /// <summary>Section property</summary>
        BHoM.Structural.SectionProperties.SectionProperty SectionProperty { get; set; }

        /// <summary>Material inherited from section property</summary>
        BHoM.Materials.Material Material { get; set; }

        /// <summary>Material name inherited from section property BHoM.Materials.Material name</summary>
        string MaterialPropertyName { get; set; }

        /// <summary>Releases</summary>
        BHoM.Structural.BarRelease Release { get; set; }

        /// <summary>Release name is generated from the start and end BHoM.Structural.</summary>
        string ReleaseName { get; set; }

        /// <summary>Start node</summary>
        Node StartNode { get; set; }

        /// <summary>End node</summary>
        Node EndNode { get; set; }

        /// <summary>The line defining the bar centre or location line</summary>
        BHoM.Geometry.Line Line { get; set; }

        /// <summary>Bar length</summary>
        double Length { get; set; }

        /// <summary>
        /// Bar orientation angle. For non-vertical bars, angle is measured in the bar YZ plane
        /// betwen the Y axis and the Y vector projected one a vertical plane defined by the start and end
        /// nodes. For vertical bars, angle is measured between the bar Y axis and global Y axis. A bar is 
        /// vertical if the distance between end points projected to a horizontal plane is less than 0.0001
        /// </summary>
        double OrientationAngle { get; set; }

        /// <summary>Construction phase</summary>
        BHoM.Planning.Construction.ConstructionPhase ConstructionPhase {get; set;}

        /// <summary>Storey of the building that the bar is assigned to</summary>
        BHoM.Structural.Storey Storey { get; set; }

    }
}
