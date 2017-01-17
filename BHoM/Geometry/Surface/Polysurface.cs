using BHoM.Base;
using BHoM.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Geometry
{
    public class PolySurface : Brep
    {
        private Group<Surface> m_Surfaces;

        internal PolySurface()
        {

        }

        internal PolySurface(Group<Surface> surfaces)
        {
            m_Surfaces = surfaces;
        }

        public override GeometryBase Duplicate()
        {
            PolySurface surface = new PolySurface();
            surface.m_Surfaces = m_Surfaces.DuplicateGroup();
            surface.m_TrimCurves = m_TrimCurves.DuplicateGroup();
            return surface;
        }

        public override void Mirror(Plane p)
        {
            base.Mirror(p);
            m_Surfaces.Mirror(p);
        }

        public override void Project(Plane p)
        {
            base.Project(p);
            m_Surfaces.Project(p);
        }


        public override void Transform(Transform t)
        {
            base.Transform(t);
            m_Surfaces.Transform(t);
        }

        public override void Translate(Vector v)
        {
            base.Translate(v);
            m_Surfaces.Translate(v);
        }

        public override void Update()
        {
            base.Update();
        }
        public override string ToJSON()
        {
            return "{\"__Type__\": \"" + this.GetType().FullName + "\"," + BHoMJSON.WriteProperty("Surfaces", m_Surfaces) + "}";
        }

        public static new PolySurface FromJSON(string json, Project project = null)
        {
            Dictionary<string, string> definition = BHoMJSON.GetDefinitionFromJSON(json);

            Group<Surface> surfaces = Group<Surface>.FromJSON(definition["Surfaces"], project) as Group<Surface>;

            return new PolySurface(surfaces);
        }
    }
}
