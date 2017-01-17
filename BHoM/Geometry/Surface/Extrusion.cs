using BHoM.Base;
using BHoM.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Geometry
{
    public class Extrusion : Brep
    {
        public bool Capped { get; private set; }
        public Curve Curve { get; set; }
        public Vector Direction { get; set; }
        public Extrusion() { }
        public Extrusion(Curve curve, Vector direction, bool capped)
        {
            Curve = curve;
            Direction = direction;
            Capped = curve.IsClosed() && capped;
        }
        public override Group<Curve> NakedEdges
        {
            get
            {
                if (m_NakedEdges == null)
                {
                    m_NakedEdges = new Group<Curve>();
                    if (!Capped)
                    {
                        m_NakedEdges.Add(Curve);
                        Curve other = Curve.DuplicateCurve();
                        other.Translate(Direction);
                        m_NakedEdges.Add(other);
                    }
                    if (!Curve.IsClosed())
                    {
                        m_NakedEdges.Add(new Line(Curve.StartPoint, Curve.StartPoint + Direction));
                        m_NakedEdges.Add(new Line(Curve.EndPoint, Curve.EndPoint + Direction));
                    }              
                }

                return base.NakedEdges;
            }
        }

        public override Group<Curve> InternalEdges
        {
            get
            {
                if (m_InternalEdges == null)
                {
                    m_InternalEdges = new Group<Curve>();
                    if (Capped)
                    {
                        m_InternalEdges.Add(Curve);
                        Curve other = Curve.DuplicateCurve();
                        other.Translate(Direction);
                        m_InternalEdges.Add(other);
                    }
                    if (Curve.IsClosed())
                    {
                        m_InternalEdges.Add(new Line(Curve.StartPoint, Curve.StartPoint + Direction));
                        m_InternalEdges.Add(new Line(Curve.EndPoint, Curve.EndPoint + Direction));
                    }
                    int degree = Curve.Degree;
                    int sameValue = 0;
                    for (int i = 0; i < Curve.Knots.Length-1; i++)
                    {
                        sameValue = Curve.Knots[i] == Curve.Knots[i + 1] ? sameValue + 1 : 0;
                        if (sameValue == degree)
                        {
                            Point p = Curve.PointAt(Curve.Knots[i]);
                            m_InternalEdges.Add(new Line(p, p + Direction));
                        }
                    }
                }

                return base.InternalEdges;
            }
        }

        public override void Mirror(Plane p)
        {
            base.Mirror(p);
            Curve.Mirror(p);
            Direction.Mirror(p);
        }

        public override void Project(Plane p)
        {
            base.Project(p);
            Curve.Project(p);
            Direction.Project(p);
        }

        public override void Transform(Transform t)
        {
            base.Transform(t);
            Curve.Transform(t);
            Direction.Transform(t);
        }

        public override void Translate(Vector v)
        {
            base.Translate(v);
            Curve.Translate(v);
        }

        public override GeometryBase Duplicate()
        {
            Extrusion dup = base.Duplicate() as Extrusion;
            dup.Curve = Curve.DuplicateCurve();
            dup.Direction = Direction.DuplicateVector();
            return dup;
        }

        public override BoundingBox Bounds()
        {
            BoundingBox box = Curve.Bounds();
            return box.Add(new List<GeometryBase>() { box.Max + Direction, box.Min + Direction });
        }

        public override string ToJSON()
        {
            return "{\"__Type__\": \"" + this.GetType().FullName + 
                "\", \"Curve\": " + Curve.ToJSON() + 
                ", \"Vector\": " + Direction.ToJSON() + 
                ", \"Capped\": " + Capped + "}";
        }

        public static new Extrusion FromJSON(string json, Project project = null)
        {
            if (project == null)
                project = Global.Project.ActiveProject;

            Dictionary<string, string> definition = BHoMJSON.GetDefinitionFromJSON(json);

            Curve curve = BHoMJSON.ReadValue(typeof(Curve), definition["Curve"], project) as Curve;
            Vector direction = (Vector)BHoMJSON.ReadValue(typeof(Vector), definition["Vector"], project);
            bool capped = (bool)BHoMJSON.ReadValue(typeof(bool), definition["Capped"], project);
            return new Extrusion(curve, direction, capped);
        }
    }
}
