using System;
using BHoM.Common;
using System.Collections.Generic;
using BHoM.Global;
using BHoM.Base;

namespace BHoM.Geometry
{
    /// <summary>
    /// BHoM Plane object
    /// </summary>
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

        internal Plane(double[] pnts, int length)
        {
            double[] v1 = VectorUtils.Sub(pnts, length, 0, length);
            double[] v2 = VectorUtils.Sub(pnts, 2 * length, 0, length);

            m_Normal = VectorUtils.Normalise(VectorUtils.CrossProduct(v1, v2));
            D = -VectorUtils.DotProduct(m_Normal, Common.Utils.SubArray<double>(pnts, 0, length));
            Origin = new Point(Common.Utils.SubArray<double>(pnts, 0, 4));
        }

        internal bool IsSameSide(double[] p1, double[] p2, double tolerance)
        {
            double dotProduct1 = VectorUtils.DotProduct(p1, m_Normal, p1.Length)[0];
            double dotProduct2 = VectorUtils.DotProduct(p2, m_Normal, p2.Length)[0];

            if (dotProduct1 + D >= -tolerance && dotProduct2 + D >= -tolerance)
                return true;
            else if (dotProduct1 + D < tolerance && dotProduct2 + D < tolerance)
                return true;
            return false;
        }

        internal bool IsSameSide(double[] pnts, double tolerance)
        {
            int[] side = GetSide(pnts, tolerance);

            int nonZeroIndex = 0;
            while (nonZeroIndex < side.Length && side[nonZeroIndex] == 0) nonZeroIndex++;

            int previousSide = side[nonZeroIndex];

            for (int i = nonZeroIndex; i < side.Length; i++)
            {
                if (side[i] != 0 && side[i] != previousSide)
                {
                    return false;
                }
            }
            return true;
        }

        internal int[] GetSide(double[] pnts, double tolerance)
        {
            double[] result = VectorUtils.DotProduct(pnts, m_Normal, m_Normal.Length);
            int[] sameSide = new int[result.Length];

            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] + D > tolerance)
                {
                    sameSide[i] = 1;
                }
                else if (result[i] + D < -tolerance)
                {
                    sameSide[i] = -1;
                }
                else
                {
                    sameSide[i] = 0;
                }
            }
            return sameSide;
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
                vectors[i] = m_Normal[i % 4] * -(distances[i / 4] + D) * multiplier;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="tolerance"></param>
        /// <returns></returns>
        public bool InPlane(Point p, double tolerance)
        {
            double dotProduct = VectorUtils.DotProduct(m_Normal, p) + D;
            return dotProduct < tolerance && dotProduct > -tolerance;
        }


        internal bool InPlane(double[] pnts, int length, double tolerance)
        {
            double[] dotProducts = VectorUtils.DotProduct(pnts, m_Normal, length);
            double sum = VectorUtils.Sum(dotProducts);

            for (int i = 0; i < dotProducts.Length; i++)
            {
                if (dotProducts[i] + D > tolerance || dotProducts[i] + D < -tolerance) return false;
            }

            return true;
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
                    if (((counter + 2) * length) < pnts.Length)
                    {
                        currentPoint = nextPoint;
                        nextPoint = Common.Utils.SubArray<double>(pnts, length * (++counter), length);
                    }
                    else
                    {
                        return null;
                    }
                }
                Array.Copy(nextPoint, 0, planePts, length, length);

                currentVector = VectorUtils.Sub(nextPoint, currentPoint);

                for (int i = counter; i < pnts.Length / length - 1; i++)
                {
                    currentPoint = nextPoint;
                    nextPoint = Common.Utils.SubArray<double>(pnts, length * (i + 1), length);
                    if (!VectorUtils.Equal(currentPoint, nextPoint))
                    {
                        if (VectorUtils.Parallel(currentVector, VectorUtils.Sub(nextPoint, currentPoint), 0.0001) == 0)
                        {
                            Array.Copy(nextPoint, 0, planePts, 2 * length, length);
                            Plane plane = new Plane(planePts, length);
                            return plane.InPlane(pnts, length, 0.0001) ? plane : null;
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
            return "{\"__Type__\": \"" + this.GetType().FullName + "\", \"Normal\": " + Normal + ", \"Origin\":" + Origin + "}";
        }

        public static new Plane FromJSON(string json, Project project = null)
        {
            if (project == null)
                project = Global.Project.ActiveProject;

            Dictionary<string, string> definition = BHoMJSON.GetDefinitionFromJSON(json);

            Point origin = new Point(BHoMJSON.ReadValue(typeof(double[]), definition["Origin"], project) as double[]);
            Vector normal = new Vector(BHoMJSON.ReadValue(typeof(double[]), definition["Normal"], project) as double[]);
            return new Plane(origin, normal);
        }

    }
}
