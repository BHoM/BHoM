using BHoM.Base;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Geometry
{
    public class PolyCurve : Curve
    {
        private Group<Curve> m_Curves;

        public PolyCurve() { }

        /// <summary>
        /// Creates a Poly Curve from a set of joined curves
        /// </summary>
        /// <remarks>
        /// Curves must be joined at their end points or the resultant poly curve will be invalid
        /// </remarks>
        /// <param name="curves"></param>
        public PolyCurve(List<Curve> curves)
        {
            m_Curves = new Group<Curve>();
            m_Curves.AddRange(curves);
            m_Dimensions = 3;
        }

        public override GeometryType GeometryType
        {
            get
            {
                return GeometryType.PolyCurve;
            }
        }

        public Group<Curve> Curves
        {
            get
            {
                return m_Curves;
            }
            set
            {
                m_Curves = value;
            }
        }

        public override List<Curve> Explode()
        {
            List<Curve> exploded = new List<Curve>();
            for (int i = 0; i < m_Curves.Count; i++)
            {
                exploded.AddRange(m_Curves[i].Explode());
            }
            return exploded;
        }

        public override Curve DuplicateCurve()
        {
            PolyCurve c = base.DuplicateCurve() as PolyCurve;
            c.m_Curves = new Group<Curve>();
            for (int i = 0; i < m_Curves.Count; i++)
            {
                c.m_Curves.Add(m_Curves[i].DuplicateCurve());
            }
            return c;
        }

        public override void Update()
        {
            
        }
    }
}
