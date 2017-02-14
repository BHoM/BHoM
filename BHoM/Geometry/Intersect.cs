using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Geometry
{
    public static class Intersect
    {

        public static Point PlaneLine(Plane p, Line l, bool finiteLineSegment = true, double tolerance = 0.0001)
        {
            Vector v = l.EndPoint - l.StartPoint;
            v.Unitize();

            //Check if parallell
            if (Math.Abs(Vector.DotProduct(v, p.Normal)) < tolerance) { return null; }

            double s = (Vector.DotProduct(p.Normal, (p.Origin - l.StartPoint))) / (Vector.DotProduct(p.Normal, (v)));

            if (finiteLineSegment && (s < 0 || s > 1))
                return null;

            return l.StartPoint + s * v;

        }


        /// <summary>
        /// Gets the plane curve intersection geometry within the provided tolerance
        /// </summary>
        /// <param name="p">Plane</param>
        /// <param name="c">Curve</param>
        /// <param name="tolerance"></param>
        /// <returns></returns>
        public static List<Point> PlaneCurve(Plane p, Curve c, double tolerance)
        {
            List<double> curveParameters;
            return PlaneCurve(p, c, tolerance, out curveParameters);
        }

        public static List<Point> PlaneCurve(Plane p, Curve c, double tolerance, out List<double> curveParameters)
        {
            List<Point> result = new List<Point>();
            int rounding = (int)Math.Log(1.0 / tolerance, 10);
            curveParameters = new List<double>();
            int[] sameSide = p.GetSide(c.ControlPointVector, tolerance);

            int previousSide = sameSide[0];
            int Length = c.IsClosed() && sameSide[sameSide.Length - 1] == 0 ? sameSide.Length - 1 : sameSide.Length;

            for (int i = 1; i < Length; i++)
            {
                if (sameSide[i] != previousSide)
                {
                    if (previousSide != 0)
                    {
                        double maxT = i < Length - 1 && sameSide[i] == 0 && sameSide[i + 1] != 0 ? c.Knots[i++ + c.Degree + 1] : c.Knots[i + c.Degree];
                        double minT = c.Knots[i];
                        result.Add(new Point(CurveParameterAtPlane(p, c, tolerance, ref minT, ref maxT, c.UnsafePointAt(minT), c.UnsafePointAt(maxT))));
                        curveParameters.Add(Math.Round((minT + maxT) / 2, rounding));
                    }
                    else
                    {
                        result.Add(c.PointAt(c.Knots[i - 1]));
                        curveParameters.Add(c.Knots[i - 1]);
                    }
                    previousSide = sameSide[i];
                }
            }

            if (sameSide[sameSide.Length - 1] == 0 && previousSide != sameSide[sameSide.Length - 1] && result.Count % 2 == 1)
            {
                result.Add(c.EndPoint);
                curveParameters.Add(sameSide[sameSide.Length - 1]);
            }

            return result;
        }

        //public static bool CurveCurve(Curve c1, Curve c2, double tolerance, out List<Curve> overLap, out List<Point> intersect)
        //{

        //}

        public static List<Point> CurveCurve(Curve c1, Curve c2, double tolerance)
        {
            List<Point> result = new List<Point>();
            if (BoundingBox.InRange(c1.Bounds(), c2.Bounds()))
            {
                //tolerance = tolerance * tolerance;
                double[] p11 = c1.ControlPoint(0);
                double knot1 = 0;
                for (int i = c1.Degree; i < c1.Knots.Length; i++)
                {
                    if (c1.Knots[i] == knot1) continue;
                    knot1 = c1.Knots[i];

                    double[] p12 = c1.PointAt(knot1);
                    double[] p21 = c2.ControlPoint(0);
                    double[] v1 = VectorUtils.Sub(p12, p11);
                    double knot2 = 0;
                    for (int j = c2.Degree; j < c2.Knots.Length; j++)
                    {
                        if (c2.Knots[j] == knot2) continue;
                        knot2 = c2.Knots[j];

                        double[] p22 = c2.PointAt(knot2);
                        double[] v2 = VectorUtils.Sub(p22, p21);
                        double[] intersectPoint = VectorUtils.Intersect(p11, v1, p21, v2, true);

                        if (intersectPoint != null)
                        {
                            if (c1.Degree > 1 || c2.Degree > 1)
                            {
                                double maxT1 = c1.Knots[i];
                                double minT1 = c1.Knots[i - c1.Degree];

                                double maxT2 = c2.Knots[j];
                                double minT2 = c2.Knots[j - c2.Degree];

                                double[] p1Max = c1.UnsafePointAt(maxT1);
                                double[] p1Min = c1.UnsafePointAt(minT1);

                                double[] p2Max = c2.UnsafePointAt(maxT2);
                                double[] p2Min = c2.UnsafePointAt(minT2);

                                int interations = 0;
                                double d1 = double.MaxValue;
                                double d2 = double.MaxValue;
                                while (interations++ < 10)
                                {
                                    if (d1 > tolerance)
                                    {
                                        d1 = UpdateNearestEnd(c1, intersectPoint, ref minT1, ref maxT1, ref p1Min, ref p1Max);
                                        v1 = VectorUtils.Sub(p1Max, p1Min);
                                    }
                                    if (d2 > tolerance)
                                    {
                                        d2 = UpdateNearestEnd(c2, intersectPoint, ref minT2, ref maxT2, ref p2Min, ref p2Max);
                                        v2 = VectorUtils.Sub(p2Max, p2Min);
                                    }
                                    intersectPoint = VectorUtils.Intersect(p1Min, v1, p2Min, v2, false);

                                    if (d1 < tolerance && d2 < tolerance) break;
                                }
                            }
                            result.Add(new Point(intersectPoint));
                        }
                        p21 = p22;
                    }
                    p11 = p12;
                }
            }
            return result;
        }

        public static Point LineLine(Line line1, Line line2)
        {
            return new Point(VectorUtils.Intersect(line1.StartPoint, line1.Direction, line2.StartPoint, line2.Direction));
        }

        private static double UpdateNearestEnd(Curve c, double[] pointComparison, ref double minT, ref double maxT, ref double[] pMin, ref double[] pMax)
        {
            double distance1 = VectorUtils.LengthSq(VectorUtils.Sub(pointComparison, pMin));
            double distance2 = VectorUtils.LengthSq(VectorUtils.Sub(pointComparison, pMax));
            double distanceRatio = distance1 / distance2;
            if (distanceRatio < 1.30 && distanceRatio > 0.60)
            {
                double midQuart = (maxT - minT) / 4;
                minT = minT + midQuart;
                maxT = maxT - midQuart;
                pMin = c.UnsafePointAt(minT);
                pMax = c.UnsafePointAt(maxT);

                return (distance1 + distance2) / 2;
            }
            else
            {
                double mid = (minT + maxT) / 2;
                double[] midP = c.UnsafePointAt(mid);

                if (distance1 < distance2)
                {
                    maxT = mid;
                    pMax = midP;
                    return distance1;
                }
                else
                {
                    minT = mid;
                    pMin = midP;
                    return distance2;
                }
            }
        }

        private static bool InRange(double[] value, double[] min, double[] max)
        {
            for (int i = 0; i < value.Length; i++)
            {
                if (value[i] >= min[i] && value[i] <= max[i]) continue;
                if (value[i] >= max[i] && value[i] <= min[i]) continue;
                return false;
            }
            return true;
        }

        //private static double[] CurveNearestPoint(Curve c, double[] point, double minT, double maxT, double[] p1, double[] p2)
        //{

        //    if (VectorUtils.Equal(p1, p2, 0.1)) return p1;

        //    double mid = (minT + maxT) / 2;

        //    double[] p3 = c.PointAt(mid);

        //    double distance1 = VectorUtils.LengthSq(VectorUtils.Sub(point, p1));
        //    double distance2 = VectorUtils.LengthSq(VectorUtils.Sub(point, p2));
        //    if (distance1 > distance2)
        //    {
        //        return CurveNearestPoint(c, point, mid, maxT, p3, p2);
        //    }
        //    else
        //    {
        //        return CurveNearestPoint(c, point, minT, mid, p1, p3);
        //    }
        //}

        private static double[] CurveParameterAtPlane(Plane p, Curve c, double tolerance, ref double minT, ref double maxT, double[] p1, double[] p2)
        {
            double mid = (minT + maxT) / 2;
            if (minT == maxT)
            {
                return p1;
            }

            double[] p3 = c.UnsafePointAt(mid);
            if (p.InPlane(p3, p3.Length, tolerance)) return p3;

            if (p.IsSameSide(p1, p3, tolerance))
            {
                minT = mid;
                return CurveParameterAtPlane(p, c, tolerance, ref minT, ref maxT, p3, p2);
            }
            else
            {
                maxT = mid;
                return CurveParameterAtPlane(p, c, tolerance, ref minT, ref maxT, p1, p3);
            }
        }
    }
}
