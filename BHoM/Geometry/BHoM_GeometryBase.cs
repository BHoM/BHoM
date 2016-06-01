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
        public Guid Id { get; set; }
        

        internal GeometryBase() { Id = new Guid(); }

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
                    return new Point(Utils.ReadValue(typeof(double[]), definition["point"]) as double[]);
                case "vector":
                    return new Vector(Utils.ReadValue(typeof(double[]), definition["vector"]) as double[]);
                case "plane":
                    Point origin = new Point(Utils.ReadValue(typeof(double[]), definition["origin"]) as double[]);
                    Vector normal = new Vector(Utils.ReadValue(typeof(double[]), definition["point"]) as double[]);
                    return new Plane(origin, normal);
                case "arc":
                    Point start = new Point(Utils.ReadValue(typeof(double[]), definition["start"]) as double[]);
                    Point middle = new Point(Utils.ReadValue(typeof(double[]), definition["middle"]) as double[]);
                    Point end = new Point(Utils.ReadValue(typeof(double[]), definition["end"]) as double[]);
                    return new Arc(start, middle, end);
                case "line":
                    Point startP = new Point(Utils.ReadValue(typeof(double[]), definition["start"]) as double[]);
                    Point endP = new Point(Utils.ReadValue(typeof(double[]), definition["end"]) as double[]);
                    return new Line(startP, endP);
                case "polyline":
                    List<double[]> points = Utils.ReadValue(typeof(List<double[]>), definition["points"]) as List<double[]>;
                    return new Polyline(points);
                case "curve":
                    List<double[]> curvePoints = Utils.ReadValue(typeof(List<double[]>), definition["points"]) as List<double[]>;
                    double[] knots = (double[])Utils.ReadValue(typeof(double[]), definition["knots"]);
                    double[] weights = definition.ContainsKey("weights") ? (double[])Utils.ReadValue(typeof(double[]), definition["weights"]) : null;
                    int degree = (int)Utils.ReadValue(typeof(int), definition["degree"]);
                    return new NurbCurve(curvePoints, degree, knots, weights);
                case "group":
                    Type groupDataType = Type.GetType(definition["groupType"].Trim('\"', '\"'));
                    var groupType = typeof(Group<>);
                    var dataType = typeof(List<>);
                    var data = dataType.MakeGenericType(groupDataType);
                    var groupofType = groupType.MakeGenericType(groupDataType);
                    var group = Activator.CreateInstance(groupofType);
                    System.Reflection.MethodInfo jsonMethod = groupofType.GetMethod("AddRange");
                    if (jsonMethod != null)
                        return jsonMethod.Invoke(group, new object[] { Utils.ReadValue(data, definition["group"]) }) as GeometryBase;
                    return group as GeometryBase;

            }
            return null;
        }
    }
}
