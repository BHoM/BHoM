using BH.oM.Base;
using BH.oM.Geometry;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;

namespace BH.oM.Structure.Properties
{
    public class FabricatedISectionProfile : BHoMObject, IProfile, IImmutable
    {

        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        public ShapeType Shape { get; } = ShapeType.ISection;

        public double Height { get; }

        public double TopFlangeWidth { get; }

        public double BotFlangeWidth { get; }

        public double WebThickness { get; }

        public double TopFlangeThickness { get; }

        public double BotFlangeThickness { get; }

        public double WeldSize { get; }

        public ReadOnlyCollection<ICurve> Edges { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public FabricatedISectionProfile(double height, double topFlangeWidth, double botFlangeWidth, double webThickness, double topFlangeThickness, double botFlangeThickness, double weldSize, IEnumerable<ICurve> edges)
        {
            Height = height;
            TopFlangeWidth = topFlangeWidth;
            BotFlangeWidth = botFlangeWidth;
            WebThickness = webThickness;
            BotFlangeThickness = botFlangeThickness;
            TopFlangeThickness = topFlangeThickness;
            WeldSize = weldSize;
            Edges = new ReadOnlyCollection<ICurve>(edges.ToList());
        }


        /***************************************************/
    }
}
