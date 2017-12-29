using BH.oM.Structural.Elements;

namespace BH.oM.Structural.Loads
{
    public class BarVaryingDistributedLoad : Load<Bar>  //TODO: patch load for bars. Should include patch moments. 
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double DistanceFromA { get; set; }  //TODO: Provide default values

        public Geometry.Vector ForceA { get; set; }

        public Geometry.Vector MomentA { get; set; }

        public double DistanceFromB { get; set; }

        public Geometry.Vector ForceB { get; set; }

        public Geometry.Vector MomentB { get; set; }


        /***************************************************/ 
    }
}
