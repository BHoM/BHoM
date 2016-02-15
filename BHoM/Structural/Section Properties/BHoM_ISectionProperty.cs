

namespace BHoM.Structural.SectionProperties
{
    /// <summary>
    /// Section property class, the parent abstract class for all structural 
    /// sections (RC, steel, PT beams, columns, bracing). Properties defined in this 
    /// parent class are those that would populate a multi category section database only
    /// </summary>
    public interface ISectionProperty
    {
        /// <summary>Mass per metre based on section properties</summary>
        double MassPerMetre { get; set; }

        /// <summary>Name of section propert - a user defined, instance based parameter</summary>
        string Name { get; set; }

        /// <summary>Section type</summary>
        string Type { get; set; }

        /// <summary>Information regarding section property type for the user</summary>
        string Description { get; set; }

        /// <summary>Section material</summary>
        BHoM.Materials.Material Material {get; set;}

        

    }
}