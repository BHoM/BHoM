using BH.oM.Base;

namespace BH.oM.Environmental.Elements
{
    public class Location : BHoMObject

    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double Latitude { get; set; } = 0.0;
        public double Longitude { get; set; } = 0.0;
        public double Elevation { get; set; } = 0.0;


        /***************************************************/
    }

}