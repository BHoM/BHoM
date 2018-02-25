using System;
using System.Collections.Generic;
using System.Linq;
using BH.oM.Base;

namespace BH.oM.DataManipulation.Queries
{
    public class FilterQuery : IQuery
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public string Tag { get; set; } = "";

        public Type Type { get; set; } = null;

        public Dictionary<string, object> Equalities { get; set; } = new Dictionary<string, object>();


        /***************************************************/
    }
}
