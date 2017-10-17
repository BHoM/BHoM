using BH.oM.Structural.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Structural.Loads
{
    public class BarTemperatureLoad : Load<Bar>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Geometry.Vector TemperatureChange { get; set; }


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public BarTemperatureLoad() { }

        /***************************************************/

        public BarTemperatureLoad(Loadcase loadcase, double tx, double ty, double tz)
        {
            Loadcase = loadcase;
            TemperatureChange = new Geometry.Vector(tx, ty, tz);
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
