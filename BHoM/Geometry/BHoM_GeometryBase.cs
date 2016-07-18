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

        /// <summary>Create a shallow copy of the object</summary>
        public GeometryBase ShallowClone()
        {
            return (GeometryBase)this.MemberwiseClone();
        }

        public abstract string ToJSON();
        
        /// <summary>
        /// Creates a geometry object from a json format string
        /// </summary>
        /// <param name="json"></param>
        /// <returns>Geometry object</returns>
        public static GeometryBase FromJSON(string json, Project project)
        {
            Dictionary<string, string> definition = BHoMJSON.GetDefinitionFromJSON(json);
            if (!definition.ContainsKey("Primitive")) return null;
            var typeString = definition["Primitive"].Replace("\"", "").Replace("{", "").Replace("}", "");

            switch (typeString)
            {
                case "point":
                    return new Point(BHoMJSON.ReadValue(typeof(double[]), definition["point"], project) as double[]);
                case "vector":
                    return new Vector(BHoMJSON.ReadValue(typeof(double[]), definition["vector"], project) as double[]);
                case "plane":
                    Point origin = new Point(BHoMJSON.ReadValue(typeof(double[]), definition["origin"], project) as double[]);
                    Vector normal = new Vector(BHoMJSON.ReadValue(typeof(double[]), definition["point"], project) as double[]);
                    return new Plane(origin, normal);
                case "arc":
                    Point start = new Point(BHoMJSON.ReadValue(typeof(double[]), definition["start"], project) as double[]);
                    Point middle = new Point(BHoMJSON.ReadValue(typeof(double[]), definition["middle"], project) as double[]);
                    Point end = new Point(BHoMJSON.ReadValue(typeof(double[]), definition["end"], project) as double[]);
                    return new Arc(start, middle, end);
                case "line":
                    Point startP = new Point(BHoMJSON.ReadValue(typeof(double[]), definition["start"], project) as double[]);
                    Point endP = new Point(BHoMJSON.ReadValue(typeof(double[]), definition["end"], project) as double[]);
                    return new Line(startP, endP);
                case "polyline":
                    List<double[]> points = BHoMJSON.ReadValue(typeof(List<double[]>), definition["points"], project) as List<double[]>;
                    return new Polyline(points);
                case "curve":
                    List<double[]> curvePoints = BHoMJSON.ReadValue(typeof(List<double[]>), definition["points"], project) as List<double[]>;
                    double[] knots = definition.ContainsKey("knots") ? (double[])BHoMJSON.ReadValue(typeof(double[]), definition["knots"], project) : null;
                    double[] weights = definition.ContainsKey("weights") ? (double[])BHoMJSON.ReadValue(typeof(double[]), definition["weights"], project) : null;
                    int degree = (int)BHoMJSON.ReadValue(typeof(int), definition["degree"], project);
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
                        return jsonMethod.Invoke(group, new object[] { BHoMJSON.ReadValue(data, definition["group"], project) }) as GeometryBase;
                    return group as GeometryBase;

            }
            return null;
        }
    }
}
