using BHoM.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural.Properties
{
    public class SectionCalculator
    {
        private List<Slice> m_VerticalSlices;
        private List<Slice> m_HorizontalSlices;

        protected Group<Curve> m_Edges;

        private double m_XIncrement = double.PositiveInfinity;
        private double m_YIncrement = double.PositiveInfinity;

        private double m_Cx = double.PositiveInfinity;
        private double m_Cy = double.PositiveInfinity;

        private double m_Area = 0;
        private double m_Asx = 0;
        private double m_Asy = 0;
        private double m_Ix = 0;
        private double m_Iy = 0;
        private double m_Zx = 0;
        private double m_Zy = 0;
        private double m_Sx = 0;
        private double m_Sy = 0;


        public SectionCalculator(Group<Curve> edges)
        {
            m_Edges = edges;
        }

        private List<Slice> CreateSlices(Plane p)
        {
            List<Slice> slices = new List<Slice>();

            List<Point> y = new List<Point>();
            List<double> cutAt = new List<double>();
            List<double> sliceSegments = new List<double>();

            double length = 0;
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
                if (i == 52)
                {

                }
                //y.AddRange(m_Edges.ValueAt(currentValue, direction, (direction + 1) % 2));
                for (int edgeIndex = 0; edgeIndex < m_Edges.Count; edgeIndex++)
                {
                    if (edgeIndex == 3)
                    {

                    }
                    y.AddRange(Intersect.PlaneCurve(new Plane(new Point(p.Normal * currentValue), p.Normal), m_Edges[edgeIndex], 0.00001));
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
                    length = length + isolatedCoords[j + 1]- isolatedCoords[j];
                }

                slices.Add(new Slice(-sliceSegments[i] + sliceSegments[i + 1], length, currentValue, isolatedCoords.ToArray()));
                length = 0;
                y.Clear();
            }
            return slices;
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

        public double Area
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

        public double AreaAtDepth(double depth)
        {
            Slice slice;
            double area = 0;

            if (depth > TotalDepth)
            {
                return Area;
            }

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

        public double CentroidAtDepth(double depth)
        {
            Slice slice;
            double centroidArea = 0;
            double area = 0;

            if (depth > TotalDepth)
            {
                return CentreY;
            }

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

        public double AreaAtWidth(double width)
        {
            Slice slice;
            double area = 0;
            if (width > TotalWidth)
            {
                return Area;
            }
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

        public double CentroidAtWidth(double width)
        {
            Slice slice;
            double centroidArea = 0;
            double area = 0;

            if (width > TotalDepth)
            {
                return CentreY;
            }

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

        public double Max(int direction)
        {
            return ((double[])m_Edges.Bounds().Max)[direction];
        }

        public double Min(int direction)
        {
            return ((double[])m_Edges.Bounds().Min)[direction];
        }

        public double rx
        {
            get
            {
                return Math.Sqrt(Ix / Area);
            }
        }

        public double ry
        {
            get
            {
                return Math.Sqrt(Iy / Area);
            }
        }

        public double Ix
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

        public double Iy
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

        public double Zx
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

        public double Zy
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

        public double Sx
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

        public double Sy
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

        public double CentreY
        {
            get
            {
                if (!double.IsInfinity(m_Cy)) return m_Cy;
                double AreaTimesY = 0;
                foreach (Slice slice in HorizontalSlices)
                {
                    AreaTimesY += slice.Length * slice.Width * slice.Centre;
                }
                m_Cy = AreaTimesY / Area;
                return m_Cy;
            }
        }

        public double CentreX
        {
            get
            {
                if (!double.IsInfinity(m_Cx)) return m_Cx;
                double AreaTimesX = 0;
                foreach (Slice slice in VerticalSlices)
                {
                    AreaTimesX += slice.Length * slice.Width * slice.Centre;
                }
                m_Cx = AreaTimesX / Area;
                return m_Cx;
            }
        }

        public double Asx
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

        public double Asy
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
