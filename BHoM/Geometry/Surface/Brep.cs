using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Geometry
{
    public abstract class Brep : GeometryBase
    {
        protected Group<Curve> m_Edges;
        protected Group<Curve> m_TrimCurves;

        internal Brep()
        {
            m_Edges = new Group<Curve>();
            m_TrimCurves = new Group<Curve>();
        }

        public override BoundingBox Bounds()
        {
            return m_Edges.Bounds();
        }

        public override GeometryBase Duplicate()
        {
            throw new NotImplementedException();
        }

        public static List<Brep> Join(List<Brep> breps)
        {
            List<Brep> result = new List<Brep>();
            for (int i = 0; i < breps.Count; i++)
            {
                result.Add(breps[i]);
            }
            //Join by overlapping naked edges
            return result;
        }

        public override void Mirror(Plane p)
        {
            m_Edges.Mirror(p);
            m_TrimCurves.Mirror(p);
        }

        public override void Project(Plane p)
        {
            m_Edges.Project(p);
            m_TrimCurves.Mirror(p);
        }

        public override string ToJSON()
        {
            throw new NotImplementedException();
        }

        public override void Transform(Transform t)
        {
            m_Edges.Transform(t);
            m_TrimCurves.Transform(t);
        }

        public override void Translate(Vector v)
        {
            m_Edges.Translate(v);
            m_TrimCurves.Translate(v);
        }

        public override void Update()
        {
            m_Edges.Update();
            m_TrimCurves.Update();
        }
    }
}
