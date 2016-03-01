using System;

namespace BHoM.Geometry
{
    /// <summary>
    /// Arc object
    /// </summary>
    [Serializable]
    public class Circle : Curve
    {
        private Point pCenter;
        private double pRadius;
        private Plane pPlane;

        /// <summary>Start point as BHoM curve</summary>
        public override Point StartPoint
        {
            get
            {
                Vector aVector = pPlane.X * pRadius;
                return pCenter + aVector;
            }
            set
            {
                Point aProjectedPoint = pPlane.Project(value);
                Vector aX = new Vector(pCenter, aProjectedPoint);
                Vector aY = Vector.CrossProduct(pPlane.Z, aX);
                pRadius = aX.Length;
                pPlane = new Plane(aX, aY, pCenter);
            }
        }

        /// <summary>End point as BHoM curve</summary>
        public override Point EndPoint
        {
            get
            {
                return StartPoint;
            }
            set
            {
                StartPoint = value;
            }
        }

        public Circle(Point Center, double Radius, Plane Plane)
        {
            pCenter = Center;
            pRadius = Radius;
            pPlane = Plane;
        }

        /// <summary>Center</summary>
        public Point Center
        {
            get
            {
                return pCenter;
            }
            set
            {
                pPlane = new Plane(pPlane.X, pPlane.Y, value);
                pCenter = value;
            }
        }

        /// <summary>Radius</summary>
        public double Radius
        {
            get
            {
                return pRadius;
            }
            set
            {
                pRadius = value;
            }
        }

        /// <summary>Normal</summary>
        public Vector Normal
        {
            get
            {
                return Plane.Z;
            }
        }

        /// <summary>Plane</summary>
        public Plane Plane
        {
            get
            {
                return pPlane;
            }
            set
            {
                pCenter = value.Project(pCenter);
                pPlane = value;
            }
        }
    }
}