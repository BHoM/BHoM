
namespace BHoM.Structural
{
    /// <summary>
    /// Section property class, the parent abstract class for all structural 
    /// sections (RC, steel, PT beams, columns, bracing). Properties defined in this 
    /// parent class are those that would populate a multi category section database only
    /// </summary>
    public abstract class SectionProperty
    {
        /// <summary>Mass per metre based on section properties</summary>
        public abstract double MassPerMetre { get; set; }

        /// <summary>Base constructor</summary>
        public SectionProperty()
        {
       
        }

        /// <summary>Name of section propert - a user defined, instance based parameter</summary>
        public string Name { get; set; }

        /// <summary>Section type</summary>
        public string Type { get; set; }
    }
}