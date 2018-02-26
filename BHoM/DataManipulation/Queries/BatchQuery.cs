using System.Collections.Generic;
using System.Linq;

namespace BH.oM.DataManipulation.Queries
{
    public class BatchQuery : IQuery
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<IQuery> Queries { get; set; } = new List<IQuery>();


        /***************************************************/
    }
}
