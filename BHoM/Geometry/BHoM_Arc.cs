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

            pEndPoint = Circle.Plane.Project(StartPoint);
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
    }
}