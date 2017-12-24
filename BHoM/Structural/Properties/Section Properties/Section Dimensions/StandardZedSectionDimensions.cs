using BH.oM.Base;

namespace BH.oM.Structural.Properties
{
    public class StandardZedSectionDimensions : BHoMObject, ISectionDimensions, IImmutable
    {

        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        public ShapeType Shape { get; } = ShapeType.Zed;

        /***************************************************/

        public double Height { get; }

        /***************************************************/

        public double FlangeWidth { get; }

        /***************************************************/

        public double WebThickness { get; }

        /***************************************************/

        public double FlangeThickness { get; }

        /***************************************************/

        public double RootRadius { get; }

        /***************************************************/

        public double ToeRadius { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public StandardZedSectionDimensions(double height, double flangeWidth, double webthickness, double flangeThickness, double rootRadius, double toeRadius)
        {
            Height = height;
            FlangeWidth = flangeWidth;
            WebThickness = webthickness;
            FlangeThickness = flangeThickness;
            RootRadius = rootRadius;
            ToeRadius = toeRadius;
        }

    }
}
