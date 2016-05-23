

using BHoM.Geometry;

namespace BHoM.Structural.SectionProperties
{
    public enum ShapeType
    {
        Rectangle = 0,
        Box,
        Angle,
        ISection,
        Tee,
        Channel,
        Tube,
        Circle,
    }

    public static class ShapeBuilder
    {
        public static Group<Curve> CreateISecction(double tft, double tfw, double bft, double bfw, double wt, double wd, double r1, double r2)
        {
            Group<Curve> perimeter = new Group<Curve>();
            Point p = new Point(bfw / 2, 0, 0);

            perimeter.Add(new Line(p, p = p + Vector.YAxis(bft - r2)));
            if (r2 > 0) perimeter.Add(new Arc(p - Vector.XAxis(r2), p, p = p + new Vector(-r2, r2, 0)));
            perimeter.Add(new Line(p, p = p - Vector.XAxis(bfw / 2 - wt / 2 - r1 - r2)));
            if (r1 > 0) perimeter.Add(new Arc(p + Vector.YAxis(r1), p, p = p + new Vector(-r1, r1, 0)));
            perimeter.Add(new Line(p, p = p + Vector.YAxis(wd - 2 * r1)));
            if (r1 > 0) perimeter.Add(new Arc(p + Vector.XAxis(r1), p, p = p + new Vector(r1, r1, 0)));
            perimeter.Add(new Line(p, p = p + Vector.XAxis(tfw / 2 - wt / 2 - r1 - r2)));
            if (r2 > 0) perimeter.Add(new Arc(p + Vector.YAxis(r2), p, p = p + new Vector(r2, r2, 0)));
            perimeter.Add(new Line(p, p = p + Vector.YAxis(tft - r2)));
            Group<Curve> oppositeSide = perimeter.DuplicateGroup();
            oppositeSide.Mirror(new Plane(Point.Origin, Vector.XAxis(1)));
            perimeter.AddRange(oppositeSide);
            perimeter.Add(new Line(p, p - Vector.XAxis(tfw)));
            perimeter.Add(new Line(Point.Origin + Vector.XAxis(-bfw / 2), Point.Origin + Vector.XAxis(bfw / 2)));

            //double xVector = -(perimeter.Max(0) + perimeter.Min(0)) / 2;
            //double yVector = -(perimeter.Max(1) + perimeter.Min(1)) / 2;

            perimeter.Update();

            return perimeter;//.Move(new XYZ(xVector, yVector, 0)) as Curve;
        }
    }

    /// <summary>
    /// Section shape time (circular, I section etc.)
    /// </summary>
    //public enum ShapeType
    //{
    //   /// <summary> Steel I section, hot rolled or welded up</summary>
    //   SteelI = 0,

    //   /// <summary>Steel circular section (CHS or fabricated)</summary>
    //   SteelCircularHollow,

    //   /// <summary>Steel rectangular hollow section (RHS or fabricated)</summary>
    //   SteelRectangularHollow,


    //}
}
