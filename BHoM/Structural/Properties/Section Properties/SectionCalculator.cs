using BHoM.Geometry;
using BHoM.Structural.Databases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural.Properties
{
    public partial class SectionProperty
    {
        private List<Slice> m_VerticalSlices;
        private List<Slice> m_HorizontalSlices;

        protected Group<Curve> m_OrigionalEdges;
        protected Group<Curve> m_Edges;

        private double m_XIncrement = double.PositiveInfinity;
        private double m_YIncrement = double.PositiveInfinity;

        protected double m_Cx = double.PositiveInfinity;
        protected double m_Cy = double.PositiveInfinity;

        protected double m_Area = 0;
        protected double m_Asx = 0;
        protected double m_Asy = 0;
        protected double m_Ix = 0;
        protected double m_Iy = 0;
        protected double m_Zx = 0;
        protected double m_Zy = 0;
        protected double m_Sx = 0;
        protected double m_Sy = 0;
        protected double m_Orientation = 0;

        protected void Update()
        {
            m_HorizontalSlices = null;
            m_VerticalSlices = null;

            m_XIncrement = double.PositiveInfinity;
            m_YIncrement = double.PositiveInfinity;

            m_Cx = double.PositiveInfinity;
            m_Cy = double.PositiveInfinity;

            m_Area = 0;
            m_Asx = 0;
            m_Asy = 0;
            m_Ix = 0;
            m_Iy = 0;
            m_Zx = 0;
            m_Zy = 0;
            m_Sx = 0;
            m_Sy = 0;

            m_Edges = m_OrigionalEdges.DuplicateGroup();
            if (Orientation > 0)
            {
                m_Edges.Transform(Transform.Rotation(Point.Origin, Vector.ZAxis(), Orientation));
            }
        }

        private List<Slice> CreateSlices(Plane p)
        {
            List<Slice> slices = new List<Slice>();
            
            List<double> cutAt = new List<double>();
            List<double> sliceSegments = new List<double>();
            
            for (int i = 0; i < m_Edges.Count; i++)
            {
                for (int j = 0; j < m_Edges[i].PointCount; j++)
                {
                    cutAt.Add(VectorUtils.DotProduct(m_Edges[i].ControlPoint(j), p.Normal));
                }
            }

            cutAt.Sort();
            cutAt = cutAt.Distinct<double>().ToList();

            double currentValue = VectorUtils.DotProduct(m_Edges.Bounds().Min, p.Normal);
            double max = VectorUtils.DotProduct(m_Edges.Bounds().Max, p.Normal);
            int index = 0;

            while (currentValue < max)
            {
                if (cutAt.Count > index && currentValue > cutAt[index])
                {
                    sliceSegments.Add(cutAt[index]);
                    index++;
                }
                else
                {
                    sliceSegments.Add(currentValue);
                    currentValue += Increment(0);
                }
            }

            sliceSegments.Add(max);

            for (int i = 0; i < sliceSegments.Count - 1; i++)
            {
                if (sliceSegments[i] == sliceSegments[i + 1])
                {
                    continue;
                }

                currentValue = (sliceSegments[i] + sliceSegments[i + 1]) / 2;

                //for (int edgeIndex = 0; edgeIndex < m_Edges.Count; edgeIndex++)
                //{
                //    if (edgeIndex == 3)
                //    {

                //    }
                //    y.AddRange(Intersect.PlaneCurve(new Plane(new Point(p.Normal * currentValue), p.Normal), m_Edges[edgeIndex], 0.00001));
                //}

                //List<double> isolatedCoords = new List<double>();

                //for (int point = 0; point < y.Count; point++)
                //{
                //    if (p.Normal.X > 0)
                //    {
                //        isolatedCoords.Add(y[point].Y);
                //    }
                //    else
                //    {
                //        isolatedCoords.Add(y[point].X);
                //    }
                //}


                //isolatedCoords.Sort();

                //if (isolatedCoords.Count % 2 != 0)
                //{
                //    for (int k = 0; k < isolatedCoords.Count - 1; k++)
                //    {
                //        if (isolatedCoords[k] == isolatedCoords[k + 1])
                //        {
                //            isolatedCoords.RemoveAt(k + 1);
                //        }
                //    }
                //}

                //for (int j = 0; j < isolatedCoords.Count - 1; j += 2)
                //{
                //    length = length + isolatedCoords[j + 1] - isolatedCoords[j];
                //}

                slices.Add(GetSliceAt(currentValue, -sliceSegments[i] + sliceSegments[i + 1], p));
                //new Slice(-sliceSegments[i] + sliceSegments[i + 1], length, currentValue, isolatedCoords.ToArray()));
            }
            return slices;
        }

        private Slice GetSliceAt(double location, double width, Plane p)
        {
            List<Point> y = new List<Point>();
            double length = 0;
            for (int edgeIndex = 0; edgeIndex < m_Edges.Count; edgeIndex++)
            {
                if (edgeIndex == 3)
                {

                }
                y.AddRange(Intersect.PlaneCurve(new Plane(new Point(p.Normal * location), p.Normal), m_Edges[edgeIndex], 0.00001));
            }

            List<double> isolatedCoords = new List<double>();

            for (int point = 0; point < y.Count; point++)
            {
                if (p.Normal.X > 0)
                {
                    isolatedCoords.Add(y[point].Y);
                }
                else
                {
                    isolatedCoords.Add(y[point].X);
                }
            }


            isolatedCoords.Sort();

            if (isolatedCoords.Count % 2 != 0)
            {
                for (int k = 0; k < isolatedCoords.Count - 1; k++)
                {
                    if (isolatedCoords[k] == isolatedCoords[k + 1])
                    {
                        isolatedCoords.RemoveAt(k + 1);
                    }
                }
            }

            for (int j = 0; j < isolatedCoords.Count - 1; j += 2)
            {
                length = length + isolatedCoords[j + 1] - isolatedCoords[j];
            }
            return new Slice(width, length, location, isolatedCoords.ToArray());
        }

        private double Increment(int direction)
        {
            if (direction == 0)
            {
                if (!double.IsInfinity(m_XIncrement)) return m_XIncrement;
                if (TotalWidth > 1000)
                    m_XIncrement = 10;
                else if (TotalWidth > 100)
                    m_XIncrement = 1;
                else if (TotalWidth > 10)
                    m_XIncrement = 0.1;
                else if (TotalWidth > 1)
                    m_XIncrement = 0.01;
                else
                    m_XIncrement = 0.001;
                return m_XIncrement;
            }
            else
            {
                if (!double.IsInfinity(m_YIncrement)) return m_YIncrement;
                if (TotalDepth > 1000)
                    m_YIncrement = 10;
                else if (TotalDepth > 100)
                    m_YIncrement = 1;
                else if (TotalDepth > 10)
                    m_YIncrement = 0.1;
                else if (TotalDepth > 1)
                    m_YIncrement = 0.01;
                else
                    m_YIncrement = 0.001;
                return m_YIncrement;
            }
        }

        internal List<Slice> VerticalSlices
        {
            get
            {
                return null != m_VerticalSlices ? m_VerticalSlices :
                    m_VerticalSlices = CreateSlices(new Plane(Point.Origin, Vector.XAxis()));
            }
        }

        internal List<Slice> HorizontalSlices
        {
            get
            {
                return null != m_HorizontalSlices ? m_HorizontalSlices :
                    m_HorizontalSlices = CreateSlices(new Plane(Point.Origin, Vector.YAxis()));
            }
        }

        public Group<Curve> Perimeter
        {
            get
            {
                return m_Edges;
            }
        }

        public virtual double GrossArea
        {
            get
            {
                if (m_Area > 0) return m_Area;

                foreach (Slice slice in HorizontalSlices)
                {
                    m_Area += slice.Width * slice.Length;
                }

                return m_Area;
            }
        }

        public virtual double AreaAtDepth(double depth)
        {
            Slice slice;
            double area = 0;

            if (depth > TotalDepth)
            {
                return GrossArea;
            }

            depth = Max(1) - depth;

            for (int i = 0; i < HorizontalSlices.Count; i++)
            {
                slice = m_HorizontalSlices[i];
                area += slice.Width * slice.Length;
                if (slice.Centre + slice.Width / 2 > depth)
                {
                    area -= slice.Length * (slice.Centre + slice.Width / 2 - depth);
                    break;
                }
            }

            return area;
        }

        public virtual double CentroidAtDepth(double depth)
        {
            Slice slice;
            double centroidArea = 0;
            double area = 0;

            if (depth > TotalDepth)
            {
                return CentreY;
            }

            depth = Max(1) - depth;

            for (int i = 0; i < HorizontalSlices.Count; i++)
            {
                slice = m_HorizontalSlices[i];
                if (slice.Centre + slice.Width / 2 < depth)
                {
                    centroidArea += (slice.Width + slice.Length) * slice.Centre;
                    area += slice.Width + slice.Length;
                }
                else
                {
                    double remainingWidth = slice.Width / 2 - depth + slice.Centre;
                    centroidArea += remainingWidth * slice.Length * (slice.Centre + (slice.Width - remainingWidth) / 2);
                    area += remainingWidth * slice.Length;
                    break;
                }
            }

            return centroidArea / area;
        }

        public virtual double AreaAtWidth(double width)
        {
            Slice slice;
            double area = 0;
            if (width > TotalWidth)
            {
                return GrossArea;
            }

            width = Max(0) - width;

            for (int i = VerticalSlices.Count - 1; i > 0; i--)
            {
                slice = m_VerticalSlices[i];
                if (slice.Centre - slice.Width / 2 > width)
                {
                    area += slice.Width + slice.Length;
                }
                else
                {
                    area += (slice.Width / 2 - width + slice.Centre) * slice.Length;
                    break;
                }
            }
            return area;
        }

        public virtual double CentroidAtWidth(double width)
        {
            Slice slice;
            double centroidArea = 0;
            double area = 0;

            if (width > TotalWidth)
            {
                return CentreX;
            }

            width = Max(0) - width;

            for (int i = VerticalSlices.Count - 1; i > 0; i--)
            {
                slice = m_VerticalSlices[i];
                if (slice.Centre - slice.Width / 2 > width)
                {
                    centroidArea += (slice.Width + slice.Length) * slice.Centre;
                    area += slice.Width + slice.Length;
                }
                else
                {
                    double remainingWidth = slice.Width / 2 - width + slice.Centre;
                    centroidArea += remainingWidth * slice.Length * (slice.Centre + (slice.Width - remainingWidth) / 2);
                    area += remainingWidth * slice.Length;
                    break;
                }
            }
            return centroidArea / area;
        }

        public virtual double WidthAt(double y)
        {
            Slice slice = GetSliceAt(y, 1, Plane.XZ());// new Plane(Point.Origin, Vector.YAxis()));
            return slice.Length;
        }


        public virtual double WidthAt(double y, ref double[] range)
        {
            Slice slice = GetSliceAt(y, 1, Plane.XZ());
            range = slice.Placement;
            return slice.Length;
        }

        public virtual double DepthAt(double x)
        {
            Slice slice = GetSliceAt(x, 1, Plane.YZ());// new Plane(Point.Origin, Vector.XAxis()));
            return slice.Length;
        }

        public virtual double DepthAt(double x, ref double[] range)
        {
            Slice slice = GetSliceAt(x, 1, Plane.YZ());
            range = slice.Placement;
            return slice.Length;
        }

        public double Max(int direction)
        {
            return ((double[])m_Edges.Bounds().Max)[direction];
        }

        public double Min(int direction)
        {
            return ((double[])m_Edges.Bounds().Min)[direction];
        }

        public double Rgx
        {
            get
            {
                return Math.Sqrt(Ix / GrossArea);
            }
        }

        public double Rgy
        {
            get
            {
                return Math.Sqrt(Iy / GrossArea);
            }
        }

        public virtual double Ix
        {
            get
            {
                if (m_Ix > 0) return m_Ix;
                double temp;
                foreach (Slice slice in HorizontalSlices)
                {
                    temp = slice.Length * Math.Pow(slice.Width, 3) / 12;
                    m_Ix += temp + slice.Length * slice.Width * Math.Pow((slice.Centre - CentreY), 2);
                }
                return m_Ix;
            }
        }

        public virtual double Iy
        {
            get
            {
                if (m_Iy > 0) return m_Iy;
                double temp;
                foreach (Slice slice in VerticalSlices)
                {
                    temp = slice.Length * Math.Pow(slice.Width, 3) / 12;
                    m_Iy += temp + slice.Length * slice.Width * Math.Pow((slice.Centre - CentreX), 2);
                }
                return m_Iy;
            }
        }

        public virtual double Zx
        {
            get
            {
                if (m_Zx != 0)
                    return m_Zx;
                else
                    m_Zx = Ix / (CentreY - Min(1));
                return m_Zx;
            }
        }

        public virtual double Zy
        {
            get
            {
                if (m_Zy != 0)
                    return m_Zy;
                else
                    m_Zy = Iy / (CentreX - Min(0));
                return m_Zy;
            }
        }

        public virtual double Sx
        {
            get
            {
                if (m_Sx != 0)
                    return m_Sx;
                else
                    foreach (Slice slice in HorizontalSlices)
                    {
                        m_Sx += slice.Length * slice.Width * (Math.Abs(CentreY - slice.Centre));
                    }
                return m_Sx;
            }
        }

        public virtual double Sy
        {
            get
            {
                if (m_Sy != 0)
                    return m_Sy;
                else
                    foreach (Slice slice in VerticalSlices)
                    {
                        m_Sy += slice.Length * slice.Width * (Math.Abs(CentreX - slice.Centre));
                    }
                return m_Sy;
            }
        }

        public virtual double CentreY
        {
            get
            {
                if (!double.IsInfinity(m_Cy)) return m_Cy;
                double AreaTimesY = 0;
                foreach (Slice slice in HorizontalSlices)
                {
                    AreaTimesY += slice.Length * slice.Width * slice.Centre;
                }
                m_Cy = AreaTimesY / GrossArea;
                return m_Cy;
            }
        }

        public virtual double CentreX
        {
            get
            {
                if (!double.IsInfinity(m_Cx)) return m_Cx;
                double AreaTimesX = 0;
                foreach (Slice slice in VerticalSlices)
                {
                    AreaTimesX += slice.Length * slice.Width * slice.Centre;
                }
                m_Cx = AreaTimesX / GrossArea;
                return m_Cx;
            }
        }


        public virtual double Vy
        {
            get
            {
                return Max(1) - CentreY;
            }
        }

        public virtual double Vpy
        {
            get
            {
                return CentreY - Min(1);
            }
        }

        public virtual double Vx
        {
            get
            {
                return Max(0) - CentreX;
            }
        }

        public virtual double Vpx
        {
            get
            {
                return CentreX - Min(0);
            }
        }


        public virtual double Asx
        {
            get
            {
                if (m_Asx != 0) return m_Asx;
                double sy = 0;
                double b = 0;
                double sum = 0;

                foreach (Slice slice in VerticalSlices)
                {
                    sy += slice.Length * slice.Width * (CentreX - slice.Centre);
                    b = slice.Length;
                    sum += Math.Pow(sy, 2) / (b) * slice.Width;

                }
                m_Asx = Math.Pow(Iy, 2) / sum;
                return m_Asx;
            }
        }

        public virtual double Asy
        {
            get
            {
                if (m_Asy != 0) return m_Asy;
                double sx = 0;
                double b = 0;
                double sum = 0;
                foreach (Slice slice in HorizontalSlices)
                {
                    sx += slice.Length * slice.Width * (CentreY - slice.Centre);
                    b = slice.Length;
                    sum += Math.Pow(sx, 2) / b * slice.Width;

                }
                m_Asy = Math.Pow(Ix, 2) / sum;
                return m_Asy;
            }
        }

        public double Integrate(int direction, double value1, double value2, double length)
        {
            return Integrate(direction, value1, value2, double.MaxValue, length);
        }

        /// <summary>
        /// Linear integration
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="max"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public double Integrate(int direction, double value1, double value2, double max, double length)
        {
            double result = 0;
            List<Slice> slices;
            if (direction == 0)
            {
                slices = VerticalSlices;
            }
            else
            {
                slices = HorizontalSlices;
            }
            for (int i = 0; i < slices.Count; i++)
            {
                Slice slice = slices[i];
                double currentLength = slice.Centre;
                double currentValue = value1 + (value2 - value1) * currentLength / length;
                currentValue = Math.Min(max, Math.Max(currentValue, -max));
                if (currentLength > length)
                {
                    break;
                }
                result += currentValue * slice.Length * slice.Width;
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="curve">f(x) -> integrated in the x direction</param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="centroid"></param>
        /// <returns></returns>
        public double Integrate(int direction, Curve curve, double from, double to, ref double centroid)
        {
            double result = 0;
            double max = Math.Max(from, to);
            double min = Math.Min(from, to);

            List<Slice> slices;
            double sumAreaLength = 0;
            if (direction == 0)
            {
                slices = VerticalSlices;
            }
            else
            {
                slices = HorizontalSlices;
            }
            for (int i = 0; i < slices.Count; i++)
            {
                Slice slice = slices[i];
                if (slice.Centre > min && slice.Centre < max)
                {
                    double currentLength = slice.Centre;
                    List<Point> points = Intersect.PlaneCurve(Plane.YZ(currentLength), curve, 0.001);
                    double currentValue = 0;
                    if (points.Count == 2)
                    {
                        currentValue = Math.Abs(points[0].Y - points[1].Y);
                    }
                    else if (points.Count == 1)
                    {
                        currentValue = points[0].Y;
                    }
                    result += currentValue * slice.Length * slice.Width;
                    sumAreaLength += currentValue * slice.Length * slice.Width * currentLength;
                }
            }
            centroid = sumAreaLength / result;
            return result;
        }


        public double TotalDepth
        {
            get
            {
                return Max(1) - Min(1);
            }
        }

        public double TotalWidth
        {
            get
            {
                return Max(0) - Min(0);
            }
        }
    }
    public class Slice
    {
        public double Width;
        public double Length;
        public double Centre;
        public double[] Placement;

        public Slice(double width, double length, double centre, double[] placement)
        {
            Width = width;
            Length = length;
            Centre = centre;
            Placement = placement;
        }

        public override string ToString()
        {
            return (Width * Length).ToString();
        }
    }

}
