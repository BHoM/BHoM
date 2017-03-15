
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Geometry
{
    public abstract class Brep : BHoMGeometry
    {
        protected Group<Curve> m_ExternalEdges;
        protected Group<Curve> m_InternalEdges;

        public Brep()
        {
            m_ExternalEdges = new Group<Curve>();
            m_InternalEdges = new Group<Curve>();
        }

        public virtual Group<Curve> GetExternalEdges()
        {
            return m_ExternalEdges;
        }

        public virtual Group<Curve> GetInternalEdges()
        {
            return m_InternalEdges;
        }

        public override BoundingBox Bounds()
        {
            return null;
        }

        public override BHoMGeometry Duplicate()
        {
            return DuplicateBrep();
        }

        public bool IsSolid
        {
            get
            {
                return m_InternalEdges.Count > 0 && m_ExternalEdges.Count == 0;
            }
        }

        public virtual Brep DuplicateBrep()
        {
            Brep b = (Brep)Activator.CreateInstance(this.GetType(), true);
            b.m_ExternalEdges = m_ExternalEdges.DuplicateGroup();
            b.m_InternalEdges = m_InternalEdges.DuplicateGroup();
            return b;
        }

        public override void Update()
        {
            m_ExternalEdges.Update();
            m_InternalEdges.Update();
        }
    }
}
