using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using BH.oM.Base;
using BH.oM.Geometry;

namespace BH.oM.Structure.Properties
{
    public class KiteProfile : BHoMObject, IProfile, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public ShapeType Shape { get; } = ShapeType.DoubleAngle;

        public double Width1 { get; }

        public double Angle1 { get; } 

        public double Thickness { get; }

        public ReadOnlyCollection<ICurve> Edges { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public KiteProfile(double width1, double angle1, double thickness, IEnumerable<ICurve> edges)
        {
            Width1 = width1;
            Angle1 = angle1;
            Thickness = thickness;
            Edges = new ReadOnlyCollection<ICurve>(edges.ToList());
        }

        /***************************************************/
    }
}
