using BHoM.Base;
using BHoM.Global;
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

        internal PolyCurve() { }

        internal PolyCurve(List<Curve> curves)
        {
            m_Curves = new Group<Curve>();
            m_Curves.AddRange(curves);
            m_Dimensions = 3;
        }

        public override void CreateNurbForm()
        {
            IsNurbForm = true;
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

        public override double Length
        {
            get
            {
                double length = 0;
                for (int i = 0; i < m_Curves.Count; i++)
                {
                    length += m_Curves[i].Length;
                }
                return length;
            }
        }

        public override void Transform(Transform t)
        {
            m_Curves.Transform(t);
            base.Transform(t);
        }

        public override void Translate(Vector v)
        {
            m_Curves.Translate(v);

            base.Translate(v);
        }

        public override void Mirror(Plane p)
        {
            m_Curves.Mirror(p);
            base.Mirror(p);
        }

        public override void Project(Plane p)
        {
            m_Curves.Project(p);

            base.Project(p);
        }

        public override void Update()
        {
            for (int i = 0; i < m_Curves.Count; i++)
            {
                m_Curves[i].Update();
            }
            base.Update();
        }

        public override Curve Flip()
        {
            for (int i = 0; i < m_Curves.Count; i++)
            {
                m_Curves[i].Flip();
            }
            m_Curves.Reverse();
            return base.Flip();
        }

        public override Point ClosestPoint(Point point)
        {
            List<Point> points = ControlPoints;

            double minDist = 1e10;
            Point closest = StartPoint;

            for (int i = 0; i < m_Curves.Count; i++)
            {
                Point cp = m_Curves[i].ClosestPoint(point);
                double dist = cp.DistanceTo(point);
                if (dist < minDist)
                {
                    closest = cp;
                    minDist = dist;
                }
            }

            return closest;
        }

        public override string ToJSON()
        {
            return "{\"__Type__\": \"" + this.GetType().FullName + "\"," + BHoMJSON.WriteProperty("Curves", m_Curves) + "}";
        }

        public static new PolyCurve FromJSON(string json, Project project = null)
        {
            if (project == null)
                project = Global.Project.ActiveProject;

            Dictionary<string, string> definition = BHoMJSON.GetDefinitionFromJSON(json);

            Group<Curve> curves = Group<Curve>.FromJSON(definition["Curves"], project) as Group<Curve>;

            return Curve.Join(curves)[0] as PolyCurve;
        }
    }
}
