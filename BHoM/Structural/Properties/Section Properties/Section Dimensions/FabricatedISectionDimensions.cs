using BH.oM.Base;

namespace BH.oM.Structural.Properties
{
    public class FabricatedISectionDimensions : BHoMObject, ISectionDimensions, IImmutable
    {

        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        public ShapeType Shape { get; } = ShapeType.ISection;

        /***************************************************/

        public double Height { get; }

        /***************************************************/

        public double TopFlangeWidth { get; }

        /***************************************************/

        public double BotFlangeWidth { get; }

        /***************************************************/

        public double WebThickness { get; }

        /***************************************************/

        public double TopFlangeThickness { get; }

        /***************************************************/

        public double BotFlangeThickness { get; }

        /***************************************************/

        public double WeldSize { get; }


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public FabricatedISectionDimensions(double height, double topFlangeWidth, double botFlangeWIdth, double webThickness, double topFlangeThickness, double botFlangeThickness, double weldSize)
        {
            Height = height;
            TopFlangeWidth = topFlangeWidth;
            BotFlangeWidth = botFlangeWIdth;
            WebThickness = webThickness;
            BotFlangeThickness = botFlangeThickness;
            TopFlangeThickness = topFlangeThickness;
            WeldSize = weldSize;
        }

    }
}
