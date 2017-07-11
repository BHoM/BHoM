using BH.oM.Base;
using BH.oM.Geometry.Curve;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Geometry
{
    public class PolyCurve : ICurve
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<ICurve> Curves { get; set; } = new List<ICurve>();


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public PolyCurve() { }

        /***************************************************/

        public PolyCurve(IEnumerable<ICurve> curves)
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
            return GeometryType.PolyCurve;
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
            return new PolyCurve(Curves.Select(x => x.Clone() as ICurve));
        }

        /***************************************************/

        public IBHoMGeometry GetTranslated(Vector t)
        {
            return new PolyCurve(Curves.Select(x => x.GetTranslated(t) as ICurve));
        }


        /***************************************************/
        /**** ICurve Interface                          ****/
        /***************************************************/

        public Point GetStart()
        {
            return Curves.Count > 0 ? Curves.First().GetStart() : null;
        }

        /***************************************************/

        public Point GetEnd()
        {
            return Curves.Count > 0 ? Curves.Last().GetEnd() : null;
        }

        /***************************************************/

        public Vector GetStartDir()
        {
            return Curves.Count > 0 ? Curves.First().GetStartDir() : null;
        }

        /***************************************************/

        public Vector GetEndDir()
        {
            return Curves.Count > 0 ? Curves.Last().GetEndDir() : null;
        }

        /***************************************************/

        public bool IsClosed()
        {
            if (Curves.Count == 0) return false;

            for (int i = 1; i < Curves.Count; i++)
            {
                if (Curves[i - 1].GetEnd() != Curves[i].GetStart())
                    return false;
            }

            return true;
        }


        //public override List<Curve> Explode()
        //{
        //    List<Curve> exploded = new List<Curve>();
        //    for (int i = 0; i < m_Curves.Count; i++)
        //    {
        //        exploded.AddRange(m_Curves[i].Explode());
        //    }
        //    return exploded;
        //}

        //public override Curve DuplicateCurve()
        //{
        //    PolyCurve c = base.DuplicateCurve() as PolyCurve;
        //    c.m_Curves = new Group<Curve>();
        //    for (int i = 0; i < m_Curves.Count; i++)
        //    {
        //        c.m_Curves.Add(m_Curves[i].DuplicateCurve());
        //    }
        //    return c;
        //}

        //public override void Update()
        //{

        //}
    }
}
