using BHoM.Global;
using System.Collections.Generic;
using BHoM.Structural.Sections;

namespace BHoM.Structural
{
    /// <summary>
    /// 
    /// </summary>
    public class SectionFactory : ObjectFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        public SectionFactory(Project p) : base(p) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="sectionProperty"></param>
        public SectionFactory(Project p, List<BHoM.Global.BHoMObject> sectionProperty) : base(p, sectionProperty) { }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public SectionProperty Create(ShapeType shapeType, string name)
        {
            if (this.ContainsName(name))
            {
                return this[name] as SectionProperty;
            }
            else
            {
                SectionProperty sectionProperty = new SectionProperty(shapeType, name);
                sectionProperty.Number = this.FreeNumber();
                this.Add(sectionProperty);
                return sectionProperty;
            }
        }
    }
}