using BH.oM.Base;

namespace BH.oM.Structural.Loads
{
    /// <summary>
    /// Simple Loadcase class
    /// </summary>
    public class Loadcase : BHoMObject, ICase
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public LoadNature Nature { get; set; } = LoadNature.Other;

        public int Number { get; set; } = 0;


        /***************************************************/
    }

}