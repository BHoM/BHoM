using BHoM.Base;

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

        public override GeometryType GeometryType
        {
            get
            {
                return GeometryType.Circle;
            }
        }

        public override int PointCount
        {
            get
            {
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
            set
            {
                m_Radius = value;
            }
        }

        public Plane Plane
        {
            get
            {
                return m_Plane;
            }
            set
            {
                m_Plane = value;
            }
        }

        public override void Update()
        {
            base.Update();
        }
    }
}
