using BHoM.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Geometry
{
    public abstract class Brep : GeometryBase
    {
        protected Group<Curve> m_NakedEdges;
        protected Group<Curve> m_InternalEdges;
        protected Group<Curve> m_TrimCurves;
        internal Brep()
        {
            //m_NakedEdges = new Group<Curve>();
            //m_InternalEdges = new Group<Curve>();
        }

        public override BoundingBox Bounds()
        {
            return m_NakedEdges.Bounds();
        }

        public override GeometryBase Duplicate()
        {
            return DuplicateBrep();
        }

        public virtual Group<Curve> NakedEdges
        {
            get
            {
                Group<Curve> result = new Group<Curve>();
                result.AddRange(m_NakedEdges);
                if (m_TrimCurves != null)
                {
                    result.AddRange(m_TrimCurves);
                }
                return result;
            }
        }

        public virtual Group<Curve> InternalEdges
        {
            get
            {
                return m_InternalEdges;
            }
        }


        public virtual Brep DuplicateBrep()
        {
            Brep b = (Brep)Activator.CreateInstance(this.GetType(), true);
            b.m_NakedEdges = m_NakedEdges.DuplicateGroup();
            b.m_InternalEdges = m_InternalEdges.DuplicateGroup();
            return b;
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
            m_NakedEdges.Mirror(p);
            m_InternalEdges.Mirror(p);
        }

        public override void Project(Plane p)
        {
            m_NakedEdges.Project(p);
            m_InternalEdges.Mirror(p);
        }

        public override string ToJSON()
        {
            throw new NotImplementedException();
        }

        public override void Transform(Transform t)
        {
            m_NakedEdges.Transform(t);
            m_InternalEdges.Transform(t);
        }

        public override void Translate(Vector v)
        {
            m_NakedEdges.Translate(v);
            m_InternalEdges.Translate(v);
        }

        public override void Update()
        {
            m_NakedEdges.Update();
            m_InternalEdges.Update();
        }
        public static new Brep FromJSON(string json, Project project = null)
        {
            return GeometryBase.FromJSON(json, project) as Brep;
        }
    }
}
