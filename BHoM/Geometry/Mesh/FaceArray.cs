using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Geometry
{
    public class FaceArray
    {
        private List<Face> m_Faces;

        internal FaceArray()
        {
            m_Faces = new List<Face>();
        }

        public void Add(Face f)
        {
            m_Faces.Add(f);
        }

        public Face this[int i]
        {
            get
            {
                return i < m_Faces.Count ? m_Faces[i] : null;
            }
        }

        internal FaceArray Copy()
        {
            throw new NotImplementedException();
        }
    }
}
