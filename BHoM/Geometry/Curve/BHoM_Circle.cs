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
        }

        public override void CreateNurbForm()
        {
            double root2on2 = Math.Sqrt(2) / 2;

            m_Knots = new double[] { 0, 0, 0, Math.PI / 2, Math.PI / 2, Math.PI, Math.PI, 3 * Math.PI / 2, 3 * Math.PI / 2, 2 * Math.PI, 2 * Math.PI, 2 * Math.PI };
            m_Weights = new double[] { 1, root2on2, 1, root2on2, 1, root2on2, 1, root2on2, 1};

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

            IsNurbForm= true;
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
    }
}
