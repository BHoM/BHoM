using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BH.oM.Base;
using BH.oM.Geometry;

namespace BH.oM.Structure.Properties.Section.Profiles
{
    public class GeneralisedFabricatedBoxProfile : BHoMObject, IProfile, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public ShapeType Shape { get; } = ShapeType.Box;

        public double Height { get; }

        public double Width { get; }

        public double WebThickness { get; }

        public double TopFlangeThickness { get; }

        public double BotFlangeThickness { get; }

        public double TopLeftCorbelWidth { get; }

        public double TopRightCorbelWidth { get; }

        public double BotLeftCorbelWidth { get; }

        public double BotRightCorbelWidth { get; }

        public ReadOnlyCollection<ICurve> Edges { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public GeneralisedFabricatedBoxProfile(double height, double width, double webThickness, double topFlangeThickness, double botFlangeThickness, double topLeftCorbelWidth, double topRightCorbelWidth, double botLeftCorbelWidth, double botRightCorbelWidth, IEnumerable<ICurve> edges)
        {
            Height = height;
            Width = width;
            WebThickness = webThickness;
            TopFlangeThickness = topFlangeThickness;
            BotFlangeThickness = botFlangeThickness;
            TopLeftCorbelWidth = topLeftCorbelWidth;
            TopRightCorbelWidth = topRightCorbelWidth;
            BotLeftCorbelWidth = botLeftCorbelWidth;
            BotRightCorbelWidth = botRightCorbelWidth;
            Edges = new ReadOnlyCollection<ICurve>(edges.ToList());
        }

        /***************************************************/
    }
}
