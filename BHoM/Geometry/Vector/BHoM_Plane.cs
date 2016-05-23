using System;
using BHoM.Common;
using System.Collections.Generic;
namespace BHoM.Geometry
{
    /// <summary>
    /// BHoM Plane object
    /// </summary>
    [Serializable]
    public class Plane : GeometryBase
    {
        //Plane: ax + by + cz + d = 0
        //Normal: { a, b, c, 0 }

        double[] m_Normal;
        public Point Origin { get; private set; }

        public Plane(Point origin, Vector normal)
        {          
            m_Normal = VectorUtils.Normalise(normal);
            Origin = origin.DuplicatePoint();
            D = -VectorUtils.DotProduct(normal, origin);           
        }

        public Plane(Point p1, Point p2, Point p3)
        {
            m_Normal = VectorUtils.Normalise(VectorUtils.CrossProduct(p2 - p1, p3 - p1));
            D = -VectorUtils.DotProduct(m_Normal, p1);
            Origin = p1.DuplicatePoint();
        }

        internal Plane(double[] pnts)
        {
            double[] v1 = VectorUtils.Sub(pnts, 3, 0, 3);
            double[] v2 = VectorUtils.Sub(pnts, 6, 0, 3);

            m_Normal = VectorUtils.Normalise(VectorUtils.CrossProduct(v1, v2));
            D = -VectorUtils.DotProduct(m_Normal, Utils.SubArray<double>(pnts, 0, 3));
            Origin = new Point(Utils.SubArray<double>(pnts, 0, 4));
        }

        internal bool IsSameSide(double[] p1, double[] p2)
        {
            if (VectorUtils.DotProduct(p1, m_Normal) + D >= 0 && VectorUtils.DotProduct(p2, m_Normal) + D >= 0)
                return true;
            else if(VectorUtils.DotProduct(p1, m_Normal) + D < 0 && VectorUtils.DotProduct(p2, m_Normal) + D < 0)
                return true;
            return false;
        }

        internal List<int> SameSide(double[] pnts)
        {
            double[] result = VectorUtils.DotProduct(pnts, m_Normal, m_Normal.Length);
            List<int> sameSide = new List<int>();
            bool isNegative = false;
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] + D >= 0 && !isNegative)
                {
                    sameSide.Add(i);
                }
                else if (result[i] + D < 0)
                {
                    if (i == 0) isNegative = true;
                    if (isNegative) sameSide.Add(i);
                }
            }
            return sameSide;
        }

        public static Plane XY()
        {
            return new Plane(Point.Origin, Vector.ZAxis());
        }

        public static Plane YZ()
        {
            return new Plane(Point.Origin, Vector.XAxis());
        }

        public static Plane XZ()
        {
            return new Plane(Point.Origin, Vector.YAxis());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public double DistanceTo(Point point)
        {
            return (VectorUtils.DotProduct(m_Normal, point) + D) / VectorUtils.Length(m_Normal);
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
        }

        internal double[] ProjectionVectors(double[] v, double multiplier = 1)
        {
            double[] distances = VectorUtils.Sum(VectorUtils.Multiply(v, m_Normal), 4);
            double[] vectors = new double[v.Length];
            for (int i = 0; i < v.Length; i++)
            {
                vectors[i] = (m_Normal[i % 4] * -distances[i / 4] + D) * multiplier;
            }
            return vectors;
        }

        internal double[] ProjectionVectors(double[] pnts, double[] direction)
        {
            double[] distances = VectorUtils.Sum(VectorUtils.Multiply(pnts, m_Normal), 3);
            double[] vectors = new double[pnts.Length];
            double angle = VectorUtils.Angle(m_Normal, direction);
            double cosAngle = Math.Cos(angle);

            for (int i = 0; i < pnts.Length; i++)
            {
                vectors[i] = direction[i % 4] * -(distances[i / 4] + D) / cosAngle;
            }
            return vectors;
        }

        /// <summary>
        /// 
        /// </summary>
        public double D { get; private set; }

        public bool InPlane(Point p)
        {
            double dotProduct = VectorUtils.DotProduct(m_Normal, p);
            return dotProduct < 0.001 && dotProduct > -0.001;
        }

        internal bool InPlane(double[] pnts, int length)
        {
            double[] dotProducts = VectorUtils.DotProduct(pnts, m_Normal, length);
            double sum = VectorUtils.Sum(dotProducts);
            return sum + D < 0.001 && sum + D > -0.001;
        }

        internal static Plane PlaneFromPoints(double[] pnts, int length)
        {
            if (pnts.Length > 3 * length)
            {
                double[] planePts = new double[3 * length];
                double[] currentPoint = Common.Utils.SubArray<double>(pnts, 0, length);
                double[] nextPoint = Common.Utils.SubArray<double>(pnts, length, length);
                double[] currentVector = null;
                Array.Copy(currentPoint, planePts, length);

                int counter = 1;

                while (VectorUtils.Equal(currentPoint, nextPoint, 0.0001))
                {
                    currentPoint = nextPoint;
                    nextPoint = Common.Utils.SubArray<double>(pnts, length * (++counter), length);
                }
                Array.Copy(nextPoint, 0, planePts, length, length);

                currentVector = VectorUtils.Sub(nextPoint, currentPoint);

                for (int i = counter; i < pnts.Length / length; i += length)
                {
                    currentPoint = nextPoint;
                    nextPoint = Common.Utils.SubArray<double>(pnts, length * (i + 1), length);
                    if (!VectorUtils.Equal(currentPoint, nextPoint))
                    {
                        if (VectorUtils.Parallel(currentVector, VectorUtils.Sub(nextPoint, currentPoint), 0.0001) == 0)
                        {
                            Array.Copy(nextPoint, 0, planePts, 2 * length, length);
                            Plane plane = new Plane(planePts);
                            return plane.InPlane(pnts, length) ? plane : null;
                        }
                    }
                }
            }
            return null;
        }

        internal static bool PointsInSamePlane(double[] pnts, int length)
        {
            return PlaneFromPoints(pnts, length) != null;
        }

        public override BoundingBox Bounds()
        {
            return null;
        }

        public override void Transform(Transform t)
        {
            m_Normal = VectorUtils.Multiply(t, m_Normal);
            Origin = new Point(VectorUtils.Multiply(t, Origin));
        }

        public override void Translate(Vector v)
        {
            Origin = new Point(VectorUtils.Add(v, Origin));
        }

        /// <summary>
        /// Mirrors vector about a plane
        /// </summary>
        /// <param name="p"></param>
        public override void Mirror(Plane p)
        {
            m_Normal = VectorUtils.Add(p.ProjectionVectors(m_Normal, 2), m_Normal);
            Origin = new Point(VectorUtils.Add(p.ProjectionVectors(Origin, 2), Origin));
        }

        /// <summary>
        /// Projects a vector onto a plane
        /// </summary>
        /// <param name="plane"></param>
        public override void Project(Plane p)
        {
            Origin = new Point(VectorUtils.Add(p.ProjectionVectors(Origin), Origin));
            m_Normal = p.m_Normal;
        }

        public override void Update()
        {
           
        }

        public override GeometryBase Duplicate()
        {
            return DuplicatePlane();
        }

        public Plane DuplicatePlane()
        {
            return new Plane(Origin.DuplicatePoint(), Normal.DuplicateVector());
        }

        public override string ToJSON()
        {
            return "{\"Primitive\": \"plane\", \"normal\": " + Normal + ", \"origin\":" + Origin + "}";
        }
    }
}
