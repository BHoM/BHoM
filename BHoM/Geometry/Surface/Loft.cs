using BHoM.Base;
using BHoM.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Geometry
{
    public class Loft : Brep
    {
        public Group<Curve> Curves { get; set; }

        public Loft() { }
        public Loft(Group<Curve> curves)
        {
            Curves = curves;
        }

        public override void Mirror(Plane p)
        {
            base.Mirror(p);
            Curves.Mirror(p);
        }

        public override void Project(Plane p)
        {
            base.Project(p);
            Curves.Project(p);
        }

        public override void Transform(Transform t)
        {
            base.Transform(t);
            Curves.Transform(t);
        }

        public override void Translate(Vector v)
        {
            base.Translate(v);
            Curves.Translate(v);
        }

        public override GeometryBase Duplicate()
        {
            Loft dup = base.Duplicate() as Loft;
            dup.Curves = Curves.DuplicateGroup();
            return dup;
        }

        public override BoundingBox Bounds()
        {
            return Curves.Bounds();
        }

        public override string ToJSON()
        {
            return "{\"Primitive\": \"" + this.GetType().Name + "\", \"Curves\": " + Curves.ToJSON() + "}";
        }

        public static new Loft FromJSON(string json, Project project = null)
        {
            if (project == null)
                project = Global.Project.ActiveProject;

            Dictionary<string, string> definition = BHoMJSON.GetDefinitionFromJSON(json);
            if (!definition.ContainsKey("Primitive")) return null;

            Group<Curve> curves = BHoMJSON.ReadValue(typeof(Group<Curve>), definition["Curves"], project) as Group<Curve>;
            return new Loft(curves);
        }
    }
}
