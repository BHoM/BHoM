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
            m_NakedEdges = new Group<Curve>();
            m_InternalEdges = new Group<Curve>();
            m_TrimCurves = new Group<Curve>();
        }

        public override BoundingBox Bounds()
        {
            return NakedEdges.Bounds();
        }

        public override GeometryBase Duplicate()
        {
            return DuplicateBrep();
        }

        public virtual Group<Curve> NakedEdges
        {
            get
            {
                return m_NakedEdges;
            }
        }

        public virtual Group<Curve> InternalEdges
        {
            get
            {
                return m_InternalEdges;
            }
        }

        public void AddTrimCurves(List<Curve> curves, Point keep)
        {

        }

        public virtual Brep DuplicateBrep()
        {
            Brep b = (Brep)Activator.CreateInstance(this.GetType(), true);
            b.m_NakedEdges = m_NakedEdges.DuplicateGroup();
            b.m_InternalEdges = m_InternalEdges.DuplicateGroup();
            return b;
        }

        public static bool TryJoin(Brep b1, Brep b2, out Brep result)
        {
            List<Curve> c1 = Curve.Join(b1.NakedEdges);
            List<Curve> c2 = Curve.Join(b2.NakedEdges);

            List<Curve> nakedEdges = new List<Curve>();
            List<Curve> overlappedEdges = new List<Curve>();
            List<Point> pts = new List<Point>();

            List<Curve> updatedN = new List<Curve>();
            List<Curve> updatedI = new List<Curve>();

            for (int i = 0; i < c1.Count;i++)
            {
                for (int j = 0; j < c2.Count; j++)
                {
                    if (Intersect.CurveCurve(c1[i], c2[j], 0.001, out pts, out overlappedEdges, out nakedEdges))
                    {
                        updatedN.AddRange(nakedEdges);
                        updatedN.AddRange(overlappedEdges);
                    }
                }
            }
            if (updatedN.Count > 0)
            {
                Group<Brep> polySurface = new Group<Brep>();

                if (b1 is PolySurface)
                {
                    polySurface.AddRange((b1 as PolySurface).Surfaces);
                }
                else
                {
                    polySurface.Add(b1);
                }

                if (b2 is PolySurface)
                {
                    polySurface.AddRange((b2 as PolySurface).Surfaces);
                }
                else
                {
                    polySurface.Add(b2);
                }
                result = new PolySurface(polySurface);
                result.m_NakedEdges.AddRange(updatedN);
                result.m_InternalEdges.AddRange(updatedI);
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

        public static List<Brep> Join(List<Brep> breps)
        {
            Brep joined = null;
            List<Brep> result = new List<Brep>();
            for (int i = 0; i < breps.Count; i++)
            {
                result.Add(breps[i]);
            }
            //Join by overlapping naked edges

            int counter = 0;

            while (counter < result.Count)
            {
                List<Curve> b1Curves = Curve.Join(result[counter].NakedEdges);
                for (int j = counter + 1; j < result.Count; j++)
                {
                    
                    if (TryJoin(result[counter], result[j], out joined))
                    {
                        result[j] = joined;
                        result.RemoveAt(counter--);
                        break;
                    }
                }
            }

            return result;
        }

        public bool IsSolid
        {
            get
            {
                return m_InternalEdges.Count > 0 && NakedEdges.Count == 0;
            }
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
