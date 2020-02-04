using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Programming
{
    public interface INodeParam
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        Guid ParentId { get; set; }

        Type DataType { get; set; }

        string Description { get; set; }

        string Name { get; set; }

        Guid BHoM_Guid { get; set; }

        /***************************************************/
    }
}
