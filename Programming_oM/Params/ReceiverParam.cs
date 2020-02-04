using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Programming
{
    public class ReceiverParam : BHoMObject, INodeParam
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Guid SourceId { get; set; } = Guid.Empty;

        public Guid ParentId { get; set; } = Guid.Empty;

        public Type DataType { get; set; } = typeof(object);

        public string Description { get; set; } = "";

        public object DefaultValue { get; set; } = null;

        /***************************************************/
    }
}
