using BH.oM.Structural.Elements;

namespace BH.oM.Structural.Loads
{
    [Serializable]
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
            TemperatureChange = new Geometry.Vector { X = tx, Y = ty, Z = tz };
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
