using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BH.oM.Base;
using BH.oM.Geometry;

namespace BH.oM.Structure.Properties.Section.Profiles
{
    public class GeneralisedTSectionProfile : BHoMObject, IProfile, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public ShapeType Shape { get; } = ShapeType.Tee;

        public double Height { get; }

        public double WebThickness { get; }

        public double LeftOutstandWidth { get; }

        public double LeftOutstandThickness { get; }

        public double RightOutstandWidth { get; }

        public double RightOutstandThickness { get; }

        public bool MirrorAboutLocalY { get; }

        public ReadOnlyCollection<ICurve> Edges { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public GeneralisedTSectionProfile(double height, double webThickness, double leftOutstandWidth, double leftOutstandThickness, double rightOutstandWidth, double rightOutstandThickness, bool mirrorAboutLocalY, IEnumerable<ICurve> edges)
        {
            Height = height;
            WebThickness = webThickness;
            LeftOutstandWidth = leftOutstandWidth;
            LeftOutstandThickness = leftOutstandThickness;
            RightOutstandWidth = rightOutstandWidth;
            RightOutstandThickness = rightOutstandThickness;
            MirrorAboutLocalY = mirrorAboutLocalY;
            Edges = new ReadOnlyCollection<ICurve>(edges.ToList());
        }

        /***************************************************/
    }
}                                                   