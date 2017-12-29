using BH.oM.Structural.Elements;

namespace BH.oM.Structural.Loads
{
    /// <summary>
    /// Gravity load
    /// </summary>   

    /// <summary>
    /// Point load along a bar
    /// </summary>
    public class BarPointLoad : Load<Bar>  //Bar point load object - different to nodal or point load as it needs a 'position' variable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double DistanceFromA { get; set; }   //TODO: define default values

        public Geometry.Vector Force { get; set; }

        public Geometry.Vector Moment { get; set; }


        /***************************************************/
    }
}
