using BH.oM.Base;

namespace BH.oM.Structural.Properties
{
    public class CircleDimensions : BHoMObject, ISectionDimensions, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        public ShapeType Shape { get; } = ShapeType.Circle;

        /***************************************************/

        public double Diameter { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public CircleDimensions(double diameter)
        {
            Diameter = diameter;
        }

    }
}
