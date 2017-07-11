using BH.oM.Base;
using BH.oM.Geometry.Curve;
using BH.oM.Geometry.Surface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Geometry
{

    public class Extrusion : IBHoMGeometry, ISurface
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public ICurve Curve { get; set; } = new Line();

        public Vector Direction { get; set; } = new Vector(0, 0, 1);

        public bool Capped { get; set; } = true;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Extrusion() { }

        /***************************************************/

        public Extrusion(ICurve curve, Vector direction, bool capped = true)
        {
            Curve = curve;
            Direction = direction;
            Capped = curve.IsClosed() && capped;
        }

        /***************************************************/
        /**** Local Methods                             ****/
        /***************************************************/



        /***************************************************/
        /**** IBHoMGeometry Interface                   ****/
        /***************************************************/

        public GeometryType GetGeometryType()
        {
            return GeometryType.Extrusion;
        }

        /***************************************************/

        public BoundingBox GetBounds()
        {
            BoundingBox box = Curve.GetBounds();
            return box + (box + Direction);
        }

        /***************************************************/

        public object Clone()
        {
            return new Extrusion(Curve.Clone() as ICurve, Direction.Clone() as Vector, Capped);
        }

        /***************************************************/

        public IBHoMGeometry GetTranslated( Vector t)
        {
            return new Extrusion(Curve.GetTranslated(t) as ICurve, Direction.Clone() as Vector, Capped);
        }


        /***************************************************/
        /**** IBrep Interface                           ****/
        /***************************************************/

        public List<ICurve> GetExternalEdges()
        {
            return new List<ICurve>
            {
                Curve.Clone() as ICurve,
                Curve.GetTranslated(Direction) as ICurve
            };
        }

        /***************************************************/

        public List<ICurve> GetInternalEdges()
        {
            return new List<ICurve>();
        }

    }
}
