using System.Reflection;
using System.Collections.Generic;
using System;
using System.Linq;

namespace BHoM.Structural.SectionProperties
{
    /// <summary>
    /// Section property class, the parent abstract class for all structural 
    /// sections (RC, steel, PT beams, columns, bracing). Properties defined in this 
    /// parent class are those that would populate a multi category section database only
    /// </summary>
    public class SectionFactory 
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shapeType"></param>
        public SectionProperty Create(ShapeType shapeType)
        {
            switch (shapeType)
            {
                case ShapeType.SteelCircularHollow : return new  SteelISection();
                case ShapeType.SteelI: return new SteelISection();
                default: throw new ArgumentException("Invalid type", "type");
            }
        }
      
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static BHoM.Collections.Dictionary<string, object> GetProperties()
        {
            BHoM.Collections.Dictionary<string, object> prop_dict = new Collections.Dictionary<string, object>();
            BHoM.Structural.SectionProperties.SectionFactory dummyFactory = new SectionFactory();
            
            Type lookupType = typeof(ISectionProperty);
            IEnumerable<Type> lookupTypes = dummyFactory.GetType().Assembly.GetTypes().Where(
                t => lookupType.IsAssignableFrom(t) && !t.IsInterface);

            foreach(Type t in lookupTypes)
            {
                if (t.IsAssignableFrom(lookupType))
                    foreach (var prop in t.GetType().GetProperties())
                    {
                        if (!prop_dict.ContainsKey(prop.Name)) prop_dict.Add(prop.Name, prop.GetValue(t));
                    }
            }
            return prop_dict;
        }
    }
}