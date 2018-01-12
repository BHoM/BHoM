using System.Collections.Generic;
using System.Linq;

namespace BH.oM.Queries
{
    public class BatchQuery : IQuery
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<IQuery> Queries { get; set; } = new List<IQuery>();


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public BatchQuery() { }

        /***************************************************/

        public BatchQuery(IEnumerable<IQuery> queries)
        {
            Queries = queries.ToList();
        }

        
    }
}
