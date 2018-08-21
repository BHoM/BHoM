using BH.oM.Base;
using BH.oM.Geometry;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;

namespace BH.oM.Structural.Properties
{
    public class TubeProfile : BHoMObject, IProfile, IImmutable
    {

        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        public ShapeType Shape { get; } = ShapeType.Tube;

        public double Diameter { get; }

        public double Thickness { get; }

        public ReadOnlyCollection<ICurve> Edges { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public TubeProfile(double diameter, double thickness, IEnumerable<ICurve> edges)
        {
            Diameter = diameter;
            Thickness = thickness;
            Edges = new ReadOnlyCollection<ICurve>(edges.ToList());
        }


        /***************************************************/
    }
}
