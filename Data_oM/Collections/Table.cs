using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Base;

namespace BH.oM.Data.Collections
{
    public class Table : BHoMObject
    {

        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        public DataTable Data { get; set; }

        public string MetaData { get; set; }

        /***************************************************/

    }

}
