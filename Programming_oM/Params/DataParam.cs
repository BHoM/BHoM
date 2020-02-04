using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Programming
{
    public class DataParam : BHoMObject, INodeParam
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public object Data { get; set; } = null;

        public List<Guid> TargetIds { get; set; } = new List<Guid>();

        public Guid ParentId { get; set; } = Guid.Empty;

        public Type DataType { get; set; } = typeof(object);

        public string Description { get; set; } = "";

        /***************************************************/
    }
}
