

namespace BHoM.Structural.SectionProperties
{
    /// <summary>
    /// Section property class, the parent abstract class for all structural 
    /// sections (RC, steel, PT beams, columns, bracing). Properties defined in this 
    /// parent class are those that would populate a multi category section database only
    /// </summary>
    public interface ISectionFactory
    {
        /// <summary></summary>
        SectionProperty Create(ShapeType shapeType);        
    }
}