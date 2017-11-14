using BH.oM.Base;

namespace BH.oM.Architecture.Elements
{
    /// <summary>
    /// 
    /// </summary>
    public class Level : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double Elevation { get; set; } = 0.0;

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Level(double elevation)
        {
            this.Elevation = elevation;
        }

        /***************************************************/

    }
}
