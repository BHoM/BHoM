using BHoM.Geometry;
using System;

namespace BHoM.Structural.Properties
{
    public enum ShapeType
    {
        Rectangle = 0,
        Box = 1,
        Angle = 2,
        ISection = 3,
        Tee = 4,
        Channel = 5,
        Tube = 6,
        Circle = 7,
        Zed = 8,
        Polygon = 9,

        DoubleAngle = 22,
        CutISection = 23,
        DoubleChannel = 25,

        //Maybe should move elsewhere
        Cable = 30,
    }

    public static class ShapeBuilder
    {
        /// <summary>
        /// Create an I Section shape
        /// </summary>
        /// <param name="tft">Thickness of top Flange</param>
        /// <param name="tfw">Width of Top flange</param>
        /// <param name="bft">Thicknees of bottom flange</param>
        /// <param name="bfw">With of bottom flange</param>
        /// <param name="wt">thickness of web</param>
        /// <param name="wd">depth of web</param>
        /// <param name="r1">web radius</param>
        /// <param name="r2">toe radius</param>
        /// <returns></returns>
        public static Group<Curve> CreateISecction(double tft, double tfw, double bft, double bfw, double wt, double wd, double r1, double r2)
        {
            Group<Curve> perimeter = new Group<Curve>();
            Point p = new Point(bfw / 2, 0, 0);

            perimeter.Add(new Line(p, p = p + Vector.YAxis(bft - r2)));
            if (r2 > 0) perimeter.Add(new Arc(p, p = p + new Vector(-r2, r2, 0), new Plane(p - Vector.YAxis(r2), Vector.ZAxis())));
            perimeter.Add(new Line(p, p = p - Vector.XAxis(bfw / 2 - wt / 2 - r1 - r2)));
            if (r1 > 0) perimeter.Add(new Arc(p, p = p + new Vector(-r1, r1, 0), new Plane(p + Vector.XAxis(r1), Vector.ZAxis())));
            perimeter.Add(new Line(p, p = p + Vector.YAxis(wd - 2 * r1)));
            if (r1 > 0) perimeter.Add(new Arc(p, p = p + new Vector(r1, r1, 0), new Plane(p - Vector.YAxis(r1), Vector.ZAxis())));
            perimeter.Add(new Line(p, p = p + Vector.XAxis(tfw / 2 - wt / 2 - r1 - r2)));
            if (r2 > 0) perimeter.Add(new Arc(p, p = p + new Vector(r2, r2, 0), new Plane(p - Vector.XAxis(r2), Vector.ZAxis())));
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

        /// <summary>
        /// Create an T Section shape
        /// </summary>
        /// <param name="tft">Thickness of Flange</param>
        /// <param name="tfw">Width of flange</param>
        /// <param name="wt">thickness of web</param>
        /// <param name="wd">depth of web</param>
        /// <param name="r1">web radius</param>
        /// <param name="r2">toe radius</param>
        /// <returns></returns>
        public static Group<Curve> CreateTee(double tft, double tfw, double wt, double wd, double r1, double r2)
        {
            Group<Curve> perimeter = new Group<Curve>();
            Point p = new Point(wt / 2, 0, 0);
            
            perimeter.Add(new Line(p, p = p + Vector.YAxis(wd - r1)));
            if (r1 > 0) perimeter.Add(new Arc(p, p = p + new Vector(r1, r1, 0), new Plane(p - Vector.YAxis(r1), Vector.ZAxis())));
            perimeter.Add(new Line(p, p = p + Vector.XAxis(tfw / 2 - wt / 2 - r1 - r2)));
            if (r2 > 0) perimeter.Add(new Arc(p, p = p + new Vector(r2, r2, 0), new Plane(p - Vector.XAxis(r2), Vector.ZAxis())));
            perimeter.Add(new Line(p, p = p + Vector.YAxis(tft - r2)));
            Group<Curve> oppositeSide = perimeter.DuplicateGroup();
            oppositeSide.Mirror(new Plane(Point.Origin, Vector.XAxis(1)));
            perimeter.AddRange(oppositeSide);
            perimeter.Add(new Line(p, p - Vector.XAxis(tfw)));
            perimeter.Add(new Line(Point.Origin + Vector.XAxis(-wd / 2), Point.Origin + Vector.XAxis(wd / 2)));
            
            perimeter.Update();

            return perimeter;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="depth"></param>
        /// <param name="flangeThickness"></param>
        /// <param name="webThickness"></param>
        /// <param name="innerRadius"></param>
        /// <param name="toeRadius"></param>
        /// <returns></returns>
        public static Group<Curve> CreateAngle(double width, double depth, double flangeThickness, double webThickness, double innerRadius, double toeRadius)
        {
            Group<Curve> perimeter = new Group<Curve>();
            Point p = new Point(0, 0, 0);
            perimeter.Add(new Line(p, p = p + Vector.XAxis(width)));
            perimeter.Add(new Line(p, p = p + Vector.YAxis(flangeThickness - toeRadius)));
            if (toeRadius > 0) perimeter.Add(new Arc(p, p = p + new Vector(-toeRadius, toeRadius, 0), new Plane(p - Vector.YAxis(toeRadius), Vector.ZAxis())));
            perimeter.Add(new Line(p, p = p - Vector.XAxis(width - webThickness - innerRadius - toeRadius)));
            if (innerRadius > 0) perimeter.Add(new Arc(p, p = p + new Vector(-innerRadius, innerRadius, 0), new Plane(p + Vector.XAxis(innerRadius),Vector.ZAxis())));
            perimeter.Add(new Line(p, p = p + Vector.YAxis(depth - flangeThickness - innerRadius - toeRadius)));
            if (toeRadius > 0) perimeter.Add(new Arc(p, p = p + new Vector(-toeRadius, toeRadius, 0), new Plane(p - Vector.YAxis(toeRadius), Vector.ZAxis())));
            perimeter.Add(new Line(p, p = p - Vector.XAxis(webThickness - toeRadius)));
            perimeter.Add(new Line(p, p = p - Vector.YAxis(depth)));

            perimeter.Translate(new Vector(-width / 2, -depth / 2, 0));

            return perimeter;
        }

        /// <summary>
        /// Create a rectange in the XY plane with it's centre at the origin
        /// </summary>
        /// <param name="width">Width</param>
        /// <param name="height">Height</param>
        /// <param name="radius">Radius at sharp edge</param>
        /// <returns></returns>
        public static Group<Curve> CreateRectangle(double width, double height, double radius)
        {
            Group<Curve> perimeter = new Group<Curve>();
            perimeter.Add(new Line(new double[] { -width / 2, radius - height / 2, 0 }, new double[] { -width / 2, height / 2 - radius, 0 }));
            perimeter.Add(new Line(new double[] { radius - width / 2, height / 2, 0 }, new double[] { -radius + width / 2, height / 2, 0 }));
            perimeter.Add(new Line(new double[] { width / 2, height / 2 - radius, 0 }, new double[] { width / 2, radius - height / 2, 0 }));
            perimeter.Add(new Line(new double[] { width / 2 - radius, -height / 2, 0 }, new double[] { -width / 2 + radius, -height / 2, 0 }));

            if (radius > 0)
            {
                perimeter.Add(new Arc(-Math.PI / 2, -Math.PI, radius, new Plane(new Point(radius + -width / 2, radius - height / 2, 0), Vector.ZAxis())));
                perimeter.Add(new Arc(Math.PI, Math.PI / 2, radius, new Plane(new Point(radius + -width / 2, height / 2 - radius, 0), Vector.ZAxis())));
                perimeter.Add(new Arc(Math.PI / 2, 0, radius, new Plane(new Point(-radius + width / 2, height / 2 - radius, 0), Vector.ZAxis())));
                perimeter.Add(new Arc(0, -Math.PI/2, radius, new Plane(new Point(-radius + width / 2, radius - height / 2, 0), Vector.ZAxis())));
            }

            return perimeter;
        }

        /// <summary>
        /// Create a Box in the XY plane with it's centre at the origin
        /// </summary>
        /// <param name="width">Width</param>
        /// <param name="height">Height</param>
        /// <param name="thickness">plate thickness</param>
        /// <param name="innerRadius">inner radius</param>
        /// <param name="outerRadius">outer radius</param>
        /// <returns></returns>
        public static Group<Curve> CreateBox(double width, double height, double thickness, double innerRadius, double outerRadius)
        {
            Group<Curve> box = CreateRectangle(width, height, outerRadius);
            box.AddRange(CreateRectangle(width - 2 * thickness, height - 2 * thickness, innerRadius));

            return box;
        }

        /// <summary>
        /// Create a Circle in the XY plane with it's centre at the origin
        /// </summary>
        /// <param name="radius">Radius</param>
        /// <returns></returns>
        public static Group<Curve> CreateCircle(double radius)
        {
            return new Group<Curve>() { new Circle(radius, new Plane(Point.Origin, Vector.ZAxis())) };
        }

        /// <summary>
        /// Create a hollow tube in the XY plane with it's centre at the origin
        /// </summary>
        /// <param name="outerRadius"></param>
        /// <param name="thickness"></param>
        /// <returns></returns>
        public static Group<Curve> CreateTube(double outerRadius, double thickness)
        {
            Group<Curve> group = new Group<Curve>();
            group.AddRange(CreateCircle(outerRadius));
            group.AddRange(CreateCircle(outerRadius - thickness));
            return group;
        }
    }
}
