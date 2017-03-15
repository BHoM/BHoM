using BHoM.Base;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Geometry
{
    public class PolySurface : Brep
    {
        public Group<Brep> Surfaces { get; set; }
        public Group<Curve> ExternalEdges
        {
            get
            {
                return m_ExternalEdges;
            }
            set
            {
                m_ExternalEdges = value;
            }
        }
        public Group<Curve> InternalEdges
        {
            get { return m_InternalEdges; }
                
            set { m_InternalEdges = value; }
        }

        public override GeometryType GeometryType
        {
            get
            {
                return GeometryType.PolySurface;
            }
        }


        public PolySurface()
        {
            Surfaces = new Group<Brep>();
        }

        public PolySurface(Group<Brep> surfaces)
        {
            Surfaces = surfaces;
        }

        public override BHoMGeometry Duplicate()
        {
            PolySurface surface = new PolySurface();
            surface.Surfaces = Surfaces.DuplicateGroup();
            surface.ExternalEdges = ExternalEdges.DuplicateGroup();
            surface.InternalEdges = InternalEdges.DuplicateGroup();
            return surface;
        }

        public override void Update()
        {
            base.Update();
        }
    }
}
