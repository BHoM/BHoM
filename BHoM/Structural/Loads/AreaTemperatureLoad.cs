using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Base;
using BH.oM.Structural.Elements;

namespace BH.oM.Structural.Loads
{
    [Serializable]
    public class AreaTemperatureLoad : Load<IAreaElement>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double TemperatureChange { get; set; }


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public AreaTemperatureLoad() { }

        /***************************************************/

        public AreaTemperatureLoad(Loadcase loadcase, double t)
        {
            Loadcase = loadcase;
            TemperatureChange = t;
        }


        /***************************************************/
        /**** ILoad Interface                           ****/
        /***************************************************/

        public override LoadType GetLoadType()
        {
            return LoadType.BarTemperature;
        }

    }
}
