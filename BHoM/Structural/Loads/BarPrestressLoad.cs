using BH.oM.Structural.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Structural.Loads
{
    [Serializable] public class BarPrestressLoad : Load<Bar>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double PrestressValue { get; set; }


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public BarPrestressLoad() { }


        /***************************************************/
        /**** ILoad Interface                           ****/
        /***************************************************/

        public override LoadType GetLoadType()
        {
            return LoadType.Pressure;
        }

    }
}
