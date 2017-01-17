using BHoM.Base;
using BHoM.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Geometry
{
    public class Pipe : Brep
    {
        public double Radius { get; set; }
        public Curve Centreline { get; set; }
        public bool Capped { get; set; }
        public Pipe() { }
        public Pipe(Curve centreline, double radius)
        {
            Radius = radius;
            Centreline = centreline;
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
                        m_NakedEdges.AddRange(GetEndPerimeters());
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
                        m_InternalEdges.AddRange(GetEndPerimeters());
                    }
                }
                return base.InternalEdges;
            }
        }

        private Group<Curve> GetEndPerimeters()
        {
            Group<Curve> geom = new Group<Curve>();
            Vector t1 = Centreline.TangentAt(Centreline.Knots[0]);
            Vector t2 = Centreline.TangentAt(Centreline.Knots[Centreline.Knots.Length - 1]);

            Plane p1 = new Plane(Centreline.StartPoint, t1);
            Plane p2 = new Plane(Centreline.EndPoint, t2);
            geom.Add(new Circle(Radius, p1));
            geom.Add(new Circle(Radius, p2));
            return geom;
        }

        public Curve GetProfile()
        {
            return GetEndPerimeters()[0];
        }

        public override void Mirror(Plane p)
        {
            base.Mirror(p);
            Centreline.Mirror(p);
        }

        public override void Project(Plane p)
        {
            base.Project(p);
            Centreline.Project(p);
        }

        public override void Transform(Transform t)
        {
            base.Transform(t);
            Centreline.Transform(t);
        }

        public override void Translate(Vector v)
        {
            base.Translate(v);
            Centreline.Translate(v);
        }

        public override GeometryBase Duplicate()
        {
            Pipe dup = base.Duplicate() as Pipe;
            dup.Centreline = Centreline.DuplicateCurve();
            return dup;
        }

        public override BoundingBox Bounds()
        {
            BoundingBox box = Centreline.Bounds().Add(GetEndPerimeters());
            //return box.Add(new List<GeometryBase>() { box.Max + Direction, box.Min + Direction });
            return box;
        }
        public override string ToJSON()
        {
            return "{\"__Type__\": \"" + this.GetType().FullName + "\", \"Centreline\": " + Centreline.ToJSON() + ", \"Radius\": " + Radius + ", \"Capped\": " + Capped + "}";
        }

        public static new Pipe FromJSON(string json, Project project = null)
        {
            if (project == null)
                project = Global.Project.ActiveProject;

            Dictionary<string, string> definition = BHoMJSON.GetDefinitionFromJSON(json);

            Curve centreline = BHoMJSON.ReadValue(typeof(Curve), definition["Centreline"], project) as Curve;
            double radius = (double)BHoMJSON.ReadValue(typeof(double), definition["Radius"], project);
            bool capped = (bool)BHoMJSON.ReadValue(typeof(bool), definition["Capped"], project);
            return new Pipe(centreline, radius);
        }
    }
}
