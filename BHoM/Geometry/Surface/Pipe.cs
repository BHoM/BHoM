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
    public class Pipe : ISurface
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public ICurve Centreline { get; set; } = new Line();

        public double Radius { get; set; } = 0;

        public bool Capped { get; set; } = true;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Pipe() { }

        /***************************************************/

        public Pipe(ICurve centreline, double radius, bool capped = true)
        {
            Centreline = centreline;
            Radius = radius;
            Capped = capped;
        }

        /***************************************************/
        /**** Local Methods                             ****/
        /***************************************************/



        /***************************************************/
        /**** IBHoMGeometry Interface                   ****/
        /***************************************************/

        public GeometryType GetGeometryType()
        {
            return GeometryType.Pipe;
        }

        /***************************************************/

        public BoundingBox GetBounds()
        {
            BoundingBox box = Centreline.GetBounds();
            box.Min -= new Vector(Radius, Radius, Radius);  // TODO: more accurate bounding box needed
            box.Max += new Vector(Radius, Radius, Radius);

            return box;
        }

        /***************************************************/

        public object Clone()
        {
            return new Pipe(Centreline.Clone() as ICurve, Radius, Capped);
        }

        /***************************************************/

        public IBHoMGeometry GetTranslated(Vector t)
        {
            return new Pipe(Centreline.GetTranslated(t) as ICurve, Radius, Capped); 
        }


        /***************************************************/
        /**** IBrep Interface                           ****/
        /***************************************************/

        public List<ICurve> GetExternalEdges()
        {
            return new List<ICurve>     // TODO: This is actually more complicated than this since the curve can be a polyline or a polycurve that would create intermediate edges
            {
                new Circle(Centreline.GetStart(), Centreline.GetStartDir(), Radius),
                new Circle(Centreline.GetEnd(), Centreline.GetEndDir(), Radius)
            };
        }

        /***************************************************/

        public List<ICurve> GetInternalEdges()
        {
            return new List<ICurve>();
        }
    }
}
