using BH.oM.Base;

namespace BH.oM.Architecture
{
    /// <summary>
    /// 
    /// </summary>
    public class Level : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double Elevation { get; set; }

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
