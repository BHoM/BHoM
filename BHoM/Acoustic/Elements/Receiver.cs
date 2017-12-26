using BH.oM.Base;
using BH.oM.Geometry;

namespace BH.oM.Acoustic
{
    [Serializable]
    public class Receiver : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Point Location { get; set; } = new Point();

        public string Category { get; set; } = "Omni";

        public int ReceiverID { get; set; } = 0;


        /***************************************************/
    }
}
