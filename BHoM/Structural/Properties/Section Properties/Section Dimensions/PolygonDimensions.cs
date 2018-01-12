using BH.oM.Base;

namespace BH.oM.Structural.Properties
{
    public class PolygonDimensions : BHoMObject, ISectionDimensions, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        public ShapeType Shape { get; } = ShapeType.Polygon;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public PolygonDimensions() { }


        /***************************************************/
    }
}
