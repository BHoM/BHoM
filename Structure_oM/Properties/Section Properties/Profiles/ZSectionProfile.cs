using BH.oM.Base;
using BH.oM.Geometry;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;

namespace BH.oM.Structure.Properties
{
    public class ZSectionProfile : BHoMObject, IProfile, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public ShapeType Shape { get; } = ShapeType.Zed;

        public double Height { get; }

        public double FlangeWidth { get; }

        public double WebThickness { get; }

        public double FlangeThickness { get; }

        public double RootRadius { get; }

        public double ToeRadius { get; }

        public bool MirrorAboutLocalZ { get; }

        public ReadOnlyCollection<ICurve> Edges { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public ZSectionProfile(double height, double flangeWidth, double webthickness, double flangeThickness, double rootRadius, double toeRadius, bool mirrorAboutLocalZ, IEnumerable<ICurve> edges)
        {
            Height = height;
            FlangeWidth = flangeWidth;
            WebThickness = webthickness;
            FlangeThickness = flangeThickness;
            RootRadius = rootRadius;
            ToeRadius = toeRadius;
            MirrorAboutLocalZ = mirrorAboutLocalZ;
            Edges = new ReadOnlyCollection<ICurve>(edges.ToList());
        }


        /***************************************************/
    }
}
