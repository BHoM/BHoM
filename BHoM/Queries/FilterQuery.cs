using System;
using System.Collections.Generic;
using System.Linq;
using BH.oM.Base;

namespace BH.oM.Queries
{
    public class FilterQuery : IQuery
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public string Tag { get; set; } = "";

        public Type Type { get; set; } = null;

        //public Func<object, bool> Filter { get; set; }
        public Dictionary<string, object> Equalities { get; set; } = new Dictionary<string, object>();


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public FilterQuery() {}

        /***************************************************/

        public FilterQuery(Type type = null, string tag = "")
        {
            Type = type;
            Tag = tag;
        }

        /***************************************************/

        public IEnumerable<IBHoMObject> Filter(IEnumerable<IBHoMObject> objects)
        {
            IEnumerable<IBHoMObject> result = objects;

            if (Tag != "")
                result = objects.Where(x => x.Tags.Contains(Tag));

            if (Type != null)
                result = result.Where(x => Type.IsAssignableFrom(x.GetType()));

            foreach (KeyValuePair<string, object> kvp in Equalities)
            {
                //TODO: Need to check the equalities as well
            }

            return result;
        }
    }
}
