using BH.oM.Geometry;
using BH.oM.Humans.Interfaces;

namespace BH.oM.Humans.BodyParts
{
    public class RightShoulder : ILineBodyPart
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Line TrackingLine { get; set; } = new Line();


        /***************************************************/
    }

}
