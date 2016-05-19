using BHoM.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Geometry
{
    public abstract class GeometryBase
    {
        public Guid Id
        {
            get
            {
                return Guid.NewGuid();
            }
        }
        public abstract BoundingBox Bounds();
        public abstract void Transform(Transform t);
        public abstract void Translate(Vector v);
        public abstract void Mirror(Plane p);
        public abstract void Project(Plane p);
        public abstract void Update();
        public abstract GeometryBase Duplicate();

        public abstract string ToJSON();
        
        /// <summary>
        /// Creates a geometry object from a json format string
        /// </summary>
        /// <param name="json"></param>
        /// <returns>Geometry object</returns>
        public static GeometryBase FromJSON(string json)
        {
            Dictionary<string, string> definition = Utils.GetDefinitionFromJSON(json);
            if (!definition.ContainsKey("Primitive")) return null;
            var typeString = definition["Primitive"].Replace("\"", "").Replace("{", "").Replace("}", "");

            switch (typeString)
            {
                case "point":
                    return Utils.ReadValue(typeof(Point), definition["point"]) as Point;
                case "vector":
                    return new Vector(Utils.ReadValue(typeof(double[]), definition["vector"]) as double[]);
                case "plane":
                    Point origin = Utils.ReadValue(typeof(Point), definition["start"]) as Point;
                    Vector normal = new Vector(Utils.ReadValue(typeof(double[]), definition["point"]) as double[]);
                    return new Plane(origin, normal);
                case "arc":
                    Point start = Utils.ReadValue(typeof(Point), definition["start"]) as Point;
                    Point middle = Utils.ReadValue(typeof(Point), definition["middle"]) as Point;
                    Point end = Utils.ReadValue(typeof(Point), definition["end"]) as Point;
                    return new Arc(start, middle, end);
                case "line":
                    Point startP = Utils.ReadValue(typeof(Point), definition["start"]) as Point;
                    Point endP = Utils.ReadValue(typeof(Point), definition["end"]) as Point;
                    return new Line(startP, endP);
                case "polyline":
                    List<Point> points = Utils.ReadValue(typeof(List<Point>), definition["points"]) as List<Point>;
                    return new Polyline(points);
                case "curve":
                    List<Point> curvePoints = Utils.ReadValue(typeof(List<Point>), definition["points"]) as List<Point>;
                    double[] knots = (double[])Utils.ReadValue(typeof(double[]), definition["knots"]);
                    double[] weights = definition.ContainsKey("weights") ? (double[])Utils.ReadValue(typeof(double[]), definition["weights"]) : null;
                    int degree = (int)Utils.ReadValue(typeof(int), definition["degree"]);
                    return new NurbCurve(curvePoints, degree, knots, weights);
            }
            return null;
        }
    }
}
