using BH.oM.Base;

namespace BH.oM.Structural.Properties
{
    public class TubeDimensions : BHoMObject, ISectionDimensions, IImmutable
    {

        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        public ShapeType Shape { get; } = ShapeType.Tube;

        /***************************************************/

        public double Diameter { get; }

        /***************************************************/

        public double Thickness { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public TubeDimensions(double diameter, double thickness)
        {
            Diameter = diameter;
            Thickness = thickness;
        }

    }
}
