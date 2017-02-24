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
        private Group<Brep> m_Surfaces;

        internal PolySurface()
        {
            m_Surfaces = new Group<Brep>();
        }

        internal PolySurface(Group<Brep> surfaces)
        {
            m_Surfaces = surfaces;
        }

        public override GeometryBase Duplicate()
        {
            PolySurface surface = new PolySurface();
            surface.m_Surfaces = m_Surfaces.DuplicateGroup();
            surface.m_TrimCurves = m_TrimCurves.DuplicateGroup();
            surface.m_NakedEdges = m_NakedEdges.DuplicateGroup();
            surface.m_InternalEdges = m_InternalEdges.DuplicateGroup();
            return surface;
        }

        public List<Brep> Surfaces
        {
            get
            {
                return m_Surfaces.ToList();
            }
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
            return "{\"__Type__\": \"" + this.GetType().FullName +
                "\", " + BHoMJSON.WriteProperty("Surfaces", m_Surfaces) + "}" +
                "\", " + BHoMJSON.WriteProperty("NakedEdges", m_NakedEdges) + "}" +
                "\", " + BHoMJSON.WriteProperty("InternalEdges", m_InternalEdges);

        }

        public static new PolySurface FromJSON(string json, Project project = null)
        {
            Dictionary<string, string> definition = BHoMJSON.GetDefinitionFromJSON(json);

            Group<Brep> surfaces = Group<Brep>.FromJSON(definition["Surfaces"], project) as Group<Brep>;
            Group<Curve> nakedEdges = Group<Curve>.FromJSON(definition["NakedEdges"], project) as Group<Curve>;
            Group<Curve> internalEdges = Group<Curve>.FromJSON(definition["InternalEdges"], project) as Group<Curve>;
            PolySurface surface = new PolySurface(surfaces);
            surface.m_InternalEdges = internalEdges;
            surface.m_NakedEdges = nakedEdges;
            return surface;
        }
    }
}
