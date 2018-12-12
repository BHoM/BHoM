using BH.oM.Base;
using BH.oM.Geometry;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;

namespace BH.oM.Structure.Properties.Section.Profiles
{
    public class BoxProfile : BHoMObject, IProfile, IImmutable
    {

        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        public ShapeType Shape { get; } = ShapeType.Box;

        public double Height { get; }

        public double Width { get; }

        public double Thickness { get; }

        public double OuterRadius { get; }

        public double InnerRadius { get; }

        public ReadOnlyCollection<ICurve> Edges { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public BoxProfile(double height, double width, double thickness, double outerRadius, double innerRadius, IEnumerable<ICurve> edges)
        {
            Height = height;
            Width = width;
            Thickness = thickness;
            OuterRadius = outerRadius;
            InnerRadius = innerRadius;
            Edges = new ReadOnlyCollection<ICurve>(edges.ToList());
        }


        /***************************************************/
    }
}
