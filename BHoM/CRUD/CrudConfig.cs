using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Base.CRUD
{
    public class CrudConfig
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public PushActionType ActionType { get; set; } = PushActionType.Replace;

        /***************************************************/
    }
}
