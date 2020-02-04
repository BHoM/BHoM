using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Programming
{
    public interface INode
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        List<ReceiverParam> Inputs { get; set; }

        List<DataParam> Outputs { get; set; }

        string Description { get; set; }

        string Name { get; set; }

        Guid BHoM_Guid { get; set; }

        bool IsInline { get; set; }

        bool IsDeclaration { get; set; }

        /***************************************************/
    }
}
