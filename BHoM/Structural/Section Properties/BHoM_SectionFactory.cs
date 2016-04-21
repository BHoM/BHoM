using BHoM.Global;
using System.Collections.Generic;

namespace BHoM.Structural.SectionProperties
{
    /// <summary>
    /// 
    /// </summary>
    public class SectionFactory : ObjectCollection
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
        /// <param name="sectionProperties"></param>
        public SectionFactory(Project p, List<BHoM.Global.BHoMObject> sectionProperties) : base(p, sectionProperties) { }

        /// <summary>
        /// Create a steel I section property
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public SectionProperty CreateSteelI(string name)
        {
            if (this.Contains(name))
            {
                return this[name] as SectionProperty;
            }
            else
            {
                SteelISection sectionProperty = new SteelISection(name);
                this.Add(sectionProperty);
                return sectionProperty;
            }
        }

        /// <summary>
        /// Create a steel I section property
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public SectionProperty CreateSteelBox(string name)
        {
            if (this.Contains(name))
            {
                return this[name] as SectionProperty;
            }
            else
            {
                SteelBoxSection sectionProperty = new SteelBoxSection(name);
                this.Add(sectionProperty);
                return sectionProperty;
            }
        }
    }
}