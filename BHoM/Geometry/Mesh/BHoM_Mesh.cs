using System;
using System.Collections.Generic;
using System.Linq;

namespace BHoM.Geometry
{
    /// <summary>
    /// BHoM Mesh geometry object
    /// </summary>
    [Serializable]
    public class Mesh : IGeometry
    {
        private VertexArray m_Vertices;
        private FaceArray m_Faces;
        
        /// <summary>Vertices as a list of points</summary>
        public VertexArray Vertices
        {
            get
            {
                return m_Vertices;
            }
        }

        /// <summary>Faces as a list of integer arrays</summary>
        public FaceArray Faces
        {
            get
            {
                return m_Faces;
            }
        }

        public Guid Id
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public BoundingBox Bounds()
        {
            throw new NotImplementedException();
        }

        public Vector FaceNormal(int face)
        {
            double[] p1 = m_Vertices.GetVertex(m_Faces[face].A);
            double[] p2 = m_Vertices.GetVertex(m_Faces[face].B);
            double[] p3 = m_Vertices.GetVertex(m_Faces[face].C);
            return new Vector( VectorUtils.CrossProduct(VectorUtils.Sub(p2, p1), VectorUtils.Sub(p3, p1)));        
        }

        /// <summary>
        /// Construct empty mesh
        /// </summary>
        public Mesh()
        {
            m_Vertices = new VertexArray();
            m_Faces = new FaceArray();
        }

        /// <summary>
        /// Add a mesh vertice
        /// </summary>
        /// <param name="vertice"></param>
        public void AddVertice(Point vertice)
        {
            m_Vertices.Add(vertice);
        }
        
        /// <summary>
        /// Add multiple mesh vertices
        /// </summary>
        /// <param name="vertices"></param>
        public void AddVertices(List<Point> vertices)
        {
            m_Vertices.Add(vertices);
        }

        public void Transform(Transform t)
        {
            throw new NotImplementedException();
        }

        public void Translate(Vector v)
        {
            throw new NotImplementedException();
        }

        public void Mirror(Plane p)
        {
            throw new NotImplementedException();
        }

        public void Project(Plane p)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public IGeometry Duplicate()
        {
            throw new NotImplementedException();
        }

        public Mesh DuplicateMesh()
        {
            Mesh m = new Mesh();
            m.m_Faces = m_Faces.Copy();
            m.m_Vertices = m_Vertices.Copy();
            return m;
        }
    }
}
