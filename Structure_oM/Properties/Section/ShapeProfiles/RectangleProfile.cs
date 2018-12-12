using BH.oM.Base;
using BH.oM.Geometry;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;

namespace BH.oM.Structure.Properties.Section.ShapeProfiles
{
    public class RectangleProfile : BHoMObject, IProfile, IImmutable
    {

        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        public ShapeType Shape { get; } = ShapeType.Rectangle;

        public double Height { get; }

        public double Width { get; }

        public double CornerRadius { get; }

        public ReadOnlyCollection<ICurve> Edges { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public RectangleProfile(double height, double width, double cornerRadius, IEnumerable<ICurve> edges)
        {
            Height = height;
            Width = width;
            CornerRadius = cornerRadius;
            Edges = new ReadOnlyCollection<ICurve>(edges.ToList());
        }


        /***************************************************/
    }
}
