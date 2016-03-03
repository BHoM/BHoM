using System;

namespace BHoM.Geometry
{
    /// <summary>
    /// Arc object
    /// </summary>
    [Serializable]
    public class Arc : Circle
    {
        private Point pStartPoint;

        private Point pEndPoint;

        /// <summary>
        /// Constructs an arc based on circle, start and end point
        /// </summary>
        /// <param name="Circle">Circle</param>
        /// <param name="StartPoint">Start Point</param>
        /// <param name="EndPoint">End Point</param>
        public Arc(Circle Circle, Point StartPoint, Point EndPoint)
            : base(Circle.Center, Circle.Radius, Circle.Plane)
        {
            pStartPoint = Circle.Plane.Project(StartPoint);
            Vector aVector = new Vector(Circle.Center, pStartPoint);
            aVector.Unitize();
            aVector = aVector * Circle.Radius;
            pStartPoint = Circle.Center + aVector;

            pEndPoint = Circle.Plane.Project(EndPoint);
            aVector = new Vector(Circle.Center, pEndPoint);
            aVector.Unitize();
            aVector = aVector * Circle.Radius;
            pEndPoint = Circle.Center + aVector;
        }

        /// <summary>Start point of arc</summary>
        public override Point StartPoint
        {
            get
            {
                return pStartPoint;
            }

            set
            {
                pStartPoint = value;
            }
        }

        /// <summary>End point of arc</summary>
        public override Point EndPoint
        {
            get
            {
                return pEndPoint;
            }

            set
            {
                pEndPoint = value;
            }
        }

        /// <summary>Mid point of the line</summary>
        public Point MidPoint
        {
            get
            {
                Point aPoint = new Point((StartPoint.X + EndPoint.X) / 2, (StartPoint.Y + EndPoint.Y) / 2, (StartPoint.Z + EndPoint.Z) / 2);
                Vector aVector_1 = new Vector(aPoint, Center);
                Vector aVector_2 = new Vector(StartPoint, Center);
                Vector aVector_3 = new Vector(EndPoint, Center);

                double aAngle_1 = Vector.VectorAngle(aVector_1, aVector_2);
                Vector aCrossProductVector_1 = Vector.CrossProduct(aVector_1, aVector_2);
                aCrossProductVector_1.Unitize();
                double aValue_1 = Vector.DotProduct(Normal, aCrossProductVector_1);
                if (aValue_1 < 0)
                    aAngle_1 = - aAngle_1;

                double aAngle_2 = Vector.VectorAngle(aVector_1, aVector_3);
                Vector aCrossProductVector_2 = Vector.CrossProduct(aVector_1, aVector_3);
                aCrossProductVector_2.Unitize();
                double aValue_2 = Vector.DotProduct(Normal, aCrossProductVector_2);
                if (aValue_2 < 0)
                    aAngle_2 = - aAngle_2;

                aVector_1.Unitize();
                if (aAngle_1 < aAngle_2)
                    aVector_1 = aVector_1.Reverse();
                aVector_1 = aVector_1 * Radius;
                return Center + aVector_1;
            }
        }
    }
}