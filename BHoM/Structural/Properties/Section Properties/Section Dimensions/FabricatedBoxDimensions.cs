using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Base;

namespace BH.oM.Structural.Properties
{
    [Serializable]
    public class FabricatedBoxDimensions : BHoMObject, ISectionDimensions, IImmutable
    {

        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        public ShapeType Shape { get; } = ShapeType.Box;

        /***************************************************/

        public double Height { get; }

        /***************************************************/

        public double Width { get; }

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

        public FabricatedBoxDimensions(double height, double width, double webThickness, double topFlangeThickness, double botFlangeThickness, double weldSize)
        {
            Height = height;
            Width = width;
            WebThickness = webThickness;
            BotFlangeThickness = botFlangeThickness;
            TopFlangeThickness = topFlangeThickness;
            WeldSize = weldSize;
        }

    }
}
