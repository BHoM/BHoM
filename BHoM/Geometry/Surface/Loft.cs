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
    public partial class Loft : ISurface
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<ICurve> Curves { get; set; } = new List<ICurve>();


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Loft() { }

        /***************************************************/

        public Loft(IEnumerable<ICurve> curves)
        {
            Curves = curves.ToList();
        }


        /***************************************************/
        /**** Local Methods                             ****/
        /***************************************************/



        /***************************************************/
        /**** IBHoMGeometry Interface                   ****/
        /***************************************************/

        public GeometryType GetGeometryType()
        {
            return GeometryType.Loft;
        }

        /***************************************************/

        public BoundingBox GetBounds()
        {
            if (Curves.Count == 0)
                return null;

            BoundingBox box = Curves[0].GetBounds();
            for (int i = 1; i < Curves.Count; i++)
                box += Curves[i].GetBounds();

            return box;
        }

        /***************************************************/

        public object Clone()
        {
            return new Loft(Curves.Select(x => x.Clone() as ICurve));
        }

        /***************************************************/

        public IBHoMGeometry GetTranslated(Vector t)
        {
            return new Loft(Curves.Select(x => x.GetTranslated(t) as ICurve)); 
        }


        /***************************************************/
        /**** IBrep Interface                           ****/
        /***************************************************/

        public List<ICurve> GetExternalEdges()
        {
            return Curves;

        }

        /***************************************************/

        public List<ICurve> GetInternalEdges()
        {
            return new List<ICurve>();
        }

    }
}
