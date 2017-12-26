using BH.oM.Geometry;


namespace BH.oM.Humans.BodyParts
{
    public class LeftHand
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Point TrackingPoint { get; set; } = new Point();

        public Line TrackingLine { get; set; } = new Line();

        public HandStateName State { get; set; } = HandStateName.Unknown;


        /***************************************************/
    }

}
