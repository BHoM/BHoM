using BH.oM.Base;
using BH.oM.Geometry;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;

namespace BH.oM.Structure.Properties
{
    public class ISectionProfile : BHoMObject, IProfile, IImmutable
    {

        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        public ShapeType Shape { get; } = ShapeType.ISection;

        public double Height { get; }

        public double Width { get; }

        public double WebThickness { get; }

        public double FlangeThickness { get; }

        public double RootRadius { get; }

        public double ToeRadius { get; }

        public ReadOnlyCollection<ICurve> Edges { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public ISectionProfile(double height, double width, double webthickness, double flangeThickness, double rootRadius, double toeRadius, IEnumerable<ICurve> edges)
        {
            Height = height;
            Width = width;
            WebThickness = webthickness;
            FlangeThickness = flangeThickness;
            RootRadius = rootRadius;
            ToeRadius = toeRadius;
            Edges = new ReadOnlyCollection<ICurve>(edges.ToList());
        }

        /***************************************************/
    }
}
