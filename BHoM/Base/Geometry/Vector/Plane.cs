using System;
using System.Collections.Generic;

using BHoM.Base;

namespace BHoM.Geometry
{
    /// <summary>
    /// BHoM Plane object
    /// </summary>
    public class Plane : BHoMGeometry
    {
        //Plane: ax + by + cz + d = 0
        //Normal: { a, b, c, 0 }

        double[] m_Normal;
        double[] m_Origin;

        public override GeometryType GeometryType
        {
            get
            {
                return GeometryType.Plane;
            }
        }


        public Point Origin
        {
            get
            {
                return new Point(m_Origin);
            }
            set
            {
                m_Origin = value;
                Update();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Vector Normal
        {
            get
            {
                return new Vector(m_Normal);
            }
            set
            {
                m_Normal = value;
                Update();
            }
        }

        /// <summary>
        /// Scalar value in the plane equation ax + by + cz + d = 0
        /// </summary>
        public double D { get; private set; }

        public Plane(Point origin, Vector normal)
        {
            m_Normal = normal.Normalise();
            Origin = origin.DuplicatePoint();
        }

        public Plane(Point p1, Point p2, Point p3)
        {
            m_Normal = Vector.CrossProduct(p2 - p1, p3 - p1).Normalise();
            D = -Vector.DotProduct(Normal, p1);
            Origin = p1.DuplicatePoint();
        }

        public static Plane XY(double z = 0)
        {
            return new Plane(new Point(0,0,z), Vector.ZAxis());
        }

        public static Plane YZ(double x = 0)
        {
            return new Plane(new Point(x, 0, 0), Vector.XAxis());
        }

        public static Plane XZ(double y = 0)
        {
            return new Plane(new Point(0, y, 0), Vector.YAxis());
        }
        public override BoundingBox Bounds()
        {
            return null;
        }


        public override void Update()
        {
            for (int i = 0; i < 3; i++)
            {
                D -= m_Normal[i] * m_Origin[i];
            }
        }

        public override BHoMGeometry Duplicate()
        {
            return DuplicatePlane();
        }

        public Plane DuplicatePlane()
        {
            return new Plane(Origin.DuplicatePoint(), Normal.DuplicateVector());
        }
    }
}
