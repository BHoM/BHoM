using BH.oM.Base;
using BH.oM.Geometry;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;

namespace BH.oM.Structure.Properties.Section.ShapeProfiles
{
    public class TSectionProfile : BHoMObject, IProfile, IImmutable
    {

        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        public ShapeType Shape { get; } = ShapeType.Tee;

        public double Height { get; }

        public double Width { get; }

        public double WebThickness { get; }

        public double FlangeThickness { get; }

        public double RootRadius { get; }

        public double ToeRadius { get; }

        public bool MirrorAboutLocalY { get; }

        public ReadOnlyCollection<ICurve> Edges { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public TSectionProfile(double height, double width, double webthickness, double flangeThickness, double rootRadius, double toeRadius, bool mirrorAboutLocalY, IEnumerable<ICurve> edges)
        {
            Height = height;
            Width = width;
            WebThickness = webthickness;
            FlangeThickness = flangeThickness;
            RootRadius = rootRadius;
            ToeRadius = toeRadius;
            MirrorAboutLocalY = mirrorAboutLocalY;
            Edges = new ReadOnlyCollection<ICurve>(edges.ToList());
        }

        /***************************************************/
    }
}
