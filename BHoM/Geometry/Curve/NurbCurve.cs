using BHoM.Base;
using BHoM.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Geometry
{
    public class NurbCurve : Curve
    {
        internal NurbCurve()
        {

        }

        public NurbCurve(List<double[]> points, int degree, double[] knots, double[] weights) : base(points)
        {
            m_Dimensions = 3;
            m_Order = degree + 1;
            m_Knots = knots;
            m_Weights = weights != null ? weights : VectorUtils.Splat(1, points.Count);
        }

        public NurbCurve(List<Point> points, int degree, double[] knots, double[] weights) : base(points)
        {
            m_Dimensions = 3;
            m_Order = degree + 1;
            m_Knots = knots;
            m_Weights = weights != null ? weights : VectorUtils.Splat(1, points.Count);
        }

        public override void CreateNurbForm()
        {
            IsNurbForm = true;
        }

        public static NurbCurve Create(List<Point> points, int degree, double[] knots, double[] weights)
        {
            return new NurbCurve(points, degree, knots, weights);
        }

        public static new NurbCurve FromJSON(string json, Project project = null)
        {
            if (project == null)
                project = Global.Project.ActiveProject;

            Dictionary<string, string> definition = BHoMJSON.GetDefinitionFromJSON(json);
            string typeString = null;
            if (!definition.TryGetValue("__Type__", out typeString))
                definition.TryGetValue("Primitive", out typeString);
            if (typeString == null)
                return null;
            typeString = typeString.Replace("\"", "").Replace("{", "").Replace("}", "");

            Type type = Type.GetType(typeString);

            Curve result = Activator.CreateInstance(type, true) as Curve;

            List<double[]> curvePoints = BHoMJSON.ReadValue(typeof(List<double[]>), definition["Points"], project) as List<double[]>;
            double[] Knots = definition.ContainsKey("Knots") ? (double[])BHoMJSON.ReadValue(typeof(double[]), definition["Knots"], project) : null;
            double[] Weights = definition.ContainsKey("Weights") ? (double[])BHoMJSON.ReadValue(typeof(double[]), definition["Weights"], project) : null;
            int degree = (int)BHoMJSON.ReadValue(typeof(int), definition["Degree"], project);

            return new NurbCurve(curvePoints, degree, Knots, Weights);
        }
    }
}
