using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Geometry
{
    public static class Intersect
    {
        public static List<Point> PlaneCurve(Plane p, Curve c)
        { 
            List<Point> result = new List<Point>();
            List<int> sameSide = p.SameSide(c.ControlPointVector);

            if (sameSide.Count < c.PointCount)
            {
                int i1 = 0;
                int i2 = 0;

                while (i1 < sameSide.Count - 1 && sameSide[i1 + 1] - sameSide[i1] == 1) i1++;
                for (int i = i1; i < sameSide.Count; i++)
                {
                    if (sameSide[i] - i2 == 1)
                    {
                        i1 = i2;
                        i2 = sameSide[i];
                        while (i < sameSide.Count - 1 && sameSide[i + 1] - sameSide[i] == 1) i++;
                    }
                    else if (i == sameSide.Count - 1 || sameSide[i + 1] - sameSide[i] > 1)
                    {
                        i1 = sameSide[i];
                        i2 = sameSide[i] + 1;
                        while (i < sameSide.Count - 1 && i2 < sameSide[i + 1] - 1) i2++;
                    }
                    else continue;
                    double maxT = c.Knots[i1 + c.Degree + 1];
                    double minT = c.Knots[i1 + 1];
                    result.Add(new Point(CurveParameterAtPlane(p, c, minT, maxT, c.PointAt(minT), c.PointAt(maxT))));
                }
            }
           
            return result;
        }

        public static List<Point> CurveCurve(Curve c1, Curve c2)
        {
            List<Point> result = new List<Point>();
            if (BoundingBox.InRange(c1.Bounds(), c2.Bounds()))
            {
                Point p11 = c1.ControlPoint(0);
                for (int i = 1; i < c1.PointCount; i++)
                {
                    Point p12 = c1.ControlPoint(i);
                    Point p21 = c2.ControlPoint(0);
                    for (int j = 1; j < c2.PointCount; j++)
                    {
                        Point p22 = c2.ControlPoint(j);
                        double[] intersectPoint = VectorUtils.Intersect(p11, p12 - p11, p21, p22 - p21, true);
                        if (intersectPoint != null)
                        {
                            double maxT1 = c1.Knots[i + c1.Degree];
                            double minT1 = c1.Knots[i];

                            double maxT2 = c2.Knots[j + c2.Degree];
                            double minT2 = c2.Knots[j];

                            double[] p1Max = c1.PointAt(maxT1);
                            double[] p1Min = c1.PointAt(minT1);

                            double[] p2Max = c2.PointAt(maxT2);
                            double[] p2Min = c2.PointAt(minT2);

                            double[] cP1 = c1.Degree == 1 ? intersectPoint : CurveNearestPoint(c1, intersectPoint, minT1, maxT1, p1Min, p1Max);
                            double[] cP2 = c2.Degree == 1 ? intersectPoint : CurveNearestPoint(c2, intersectPoint, minT2, maxT2, p2Min, p2Max);

                            int interations = 0;
                            while (interations++ < 5 && !VectorUtils.Equal(cP1, cP2, 0.001))
                            {
                                cP1 = CurveNearestPoint(c1, cP2, minT1, maxT1, p1Min, p1Max);
                                cP2 = CurveNearestPoint(c2, cP1, minT2, maxT2, p2Min, p2Max);
                            }
                            if (VectorUtils.Equal(cP1, cP2, 0.001))
                            result.Add(new Point(cP1));
                        }
                        p21 = p22;
                    }
                    p11 = p12;
                }
            }
            return result;
        }

        private static double[] CurveNearestPoint(Curve c, double[] point, double minT, double maxT, double[] p1, double[] p2)
        {
            
            if (VectorUtils.Equal(p1, p2, 0.001)) return p1;

            double mid = (minT + maxT) / 2;

            double[] p3 = c.PointAt(mid);

            double distance1 = VectorUtils.LengthSq(VectorUtils.Sub(point, p1));
            double distance2 = VectorUtils.LengthSq(VectorUtils.Sub(point, p2));
            if (distance1 > distance2)
            {
                return CurveNearestPoint(c, point, mid, maxT, p3, p2);
            }
            else
            {
                return CurveNearestPoint(c, point, minT, mid, p1, p3);
            }
        }

        private static double[] CurveParameterAtPlane(Plane p, Curve c, double minT, double maxT, double[] p1, double[] p2)
        {
            double mid = (minT + maxT) / 2;

            //double[] p1 = c.PointAt(minT);
            double[] p3 = c.PointAt(mid);
            if (p.InPlane(p3, 4)) return p3;
            
            if (p.IsSameSide(p1, p3))
            {
                return CurveParameterAtPlane(p, c, mid, maxT, p3, p2);
            }
            else
            {
                return CurveParameterAtPlane(p, c, minT, mid, p1, p3);
            }
        }
    }
}
