using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Geometry
{
    public class PolySurface : ISurface
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<ISurface> Surfaces { get; set; } = new List<ISurface>();


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public PolySurface() { }

        /***************************************************/

        public PolySurface(IEnumerable<ISurface> surfaces)
        {
            Surfaces = surfaces.ToList();
        }

        /***************************************************/
        /**** Local Methods                             ****/
        /***************************************************/


        /***************************************************/
        /**** IBHoMGeometry Interface                   ****/
        /***************************************************/

        public GeometryType GetGeometryType()
        {
            return GeometryType.PolySurface;
        }

        /***************************************************/

        public BoundingBox GetBounds()
        {
            if (Surfaces.Count == 0)
                return null;

            BoundingBox box = Surfaces[0].GetBounds();
            for (int i = 1; i < Surfaces.Count; i++)
                box += Surfaces[i].GetBounds();

            return box;
        }

        /***************************************************/

        public object Clone()
        {
            return new PolySurface(Surfaces.Select(x => x.Clone() as ISurface));
        }

        /***************************************************/

        public IBHoMGeometry GetTranslated(Vector t)
        {
            return new PolySurface(Surfaces.Select(x => x.GetTranslated(t) as ISurface));
        }


        /***************************************************/
        /**** IBrep Interface                           ****/
        /***************************************************/

        public List<ICurve> GetExternalEdges()
        {
            return Surfaces.SelectMany(x => x.GetExternalEdges()).ToList();
        }

        /***************************************************/

        public List<ICurve> GetInternalEdges()
        {
            return Surfaces.SelectMany(x => x.GetInternalEdges()).ToList();
        }


        //public override void Update()
        //{
        //    base.Update();
        //}
    }
}
