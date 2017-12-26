using BH.oM.Base;

namespace BH.oM.Structural.Elements
{
    /// <summary>
    /// Storey class to store information about building storeys for post processing of results
    /// </summary>
    public class Storey : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double Elevation { get; set; } = 0.0;  // in meters

        public double Height { get; set; } = 0.0;  // in meters


        /***************************************************/
    }
}



