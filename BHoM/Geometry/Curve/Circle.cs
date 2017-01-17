using BHoM.Base;
using BHoM.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Geometry
{
    public class Circle : Curve
    {
        double m_Radius;
        Plane m_Plane;

        internal Circle() { }

        public Circle(double radius, Plane p)
        {
            m_Radius = radius;
            m_Dimensions = 3;
            m_Order = 3;
            m_Plane = p;
            CreateNurbForm();
        }

        public Circle(Point p1, Point p2, Point p3)
        {
            Arc arc = new Arc(p1, p2, p3);
            m_Radius = arc.Radius;
            arc.TryGetPlane(out m_Plane);
            CreateNurbForm();
        }

        public override void CreateNurbForm()
        {
            double root2on2 = Math.Sqrt(2) / 2;

            m_Knots = new double[] { 0, 0, 0, Math.PI / 2, Math.PI / 2, Math.PI, Math.PI, 3 * Math.PI / 2, 3 * Math.PI / 2, 2 * Math.PI, 2 * Math.PI, 2 * Math.PI };
            m_Weights = new double[] { 1, root2on2, 1, root2on2, 1, root2on2, 1, root2on2, 1 };

            m_ControlPoints = new double[]
            {
                m_Radius, 0, 0, 1,
                m_Radius, m_Radius, 0, 1,
                0, m_Radius, 0, 1,
               -m_Radius, m_Radius, 0, 1,
               -m_Radius, 0, 0, 1,
               -m_Radius,-m_Radius, 0, 1,
                0,-m_Radius, 0, 1,
                m_Radius,-m_Radius, 0, 1,
                m_Radius, 0, 0, 1
            };

            if (m_Plane.Normal.Z < 1)
            {
                Vector axis = new Vector(VectorUtils.CrossProduct(m_Plane.Normal, new double[] { 0, 0, 1, 0 }));
                double angle = VectorUtils.Angle(m_Plane.Normal, new double[] { 0, 0, 1, 0 });
                Geometry.Transform t = Geometry.Transform.Rotation(Point.Origin, axis, angle);
                t = Geometry.Transform.Translation(m_Plane.Origin - Point.Origin) * t;
                m_ControlPoints = VectorUtils.MultiplyMany(t, m_ControlPoints);
            }
            else
            {
                Geometry.Transform t = Geometry.Transform.Translation(m_Plane.Origin - Point.Origin);
                m_ControlPoints = VectorUtils.MultiplyMany(t, m_ControlPoints);
            }

            IsNurbForm = true;
        }

        public override int PointCount
        {
            get
            {
                if (!IsNurbForm) CreateNurbForm();
                return base.PointCount;
            }
        }

        public Point Centre
        {
            get
            {
                return m_Plane.Origin;
            }
        }

        public double Radius
        {
            get
            {
                return m_Radius;
            }
        }

        public override string ToJSON()
        {
            return "{\"__Type__\":\"" + this.GetType() + "\", \"Plane\": " + m_Plane.ToJSON() + ", \"Radius\": " + m_Radius + "}";
        }
        public static new Circle FromJSON(string json, Project project = null)
        {
            if (project == null)
                project = Global.Project.ActiveProject;

            Dictionary<string, string> definition = BHoMJSON.GetDefinitionFromJSON(json);

            Plane plane = BHoMJSON.ReadValue(typeof(Plane), definition["Plane"], project) as Plane;
            double radius = double.Parse(definition["Radius"]);
            return new Circle(radius, plane);
        }
    }
}
