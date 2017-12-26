using BH.oM.Structural.Elements;

namespace BH.oM.Structural.Loads
{
    [Serializable]
    public class BarVaryingDistributedLoad : Load<Bar>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double DistanceFromA { get; set; }

        public Geometry.Vector ForceVectorA { get; set; }

        public Geometry.Vector MomentVectorA { get; set; }

        public double DistanceFromB { get; set; }

        public Geometry.Vector ForceVectorB { get; set; }

        public Geometry.Vector MomentVectorB { get; set; }


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public BarVaryingDistributedLoad() { }


        /***************************************************/
        /**** ILoad Interface                           ****/
        /***************************************************/

        public override LoadType GetLoadType()
        {
            return LoadType.BarVaryingLoad;
        }

        //patch load for bars. Should include patch moments. 
    }
}
