using BHoM.Base;

using System;
using System.Collections.Generic;
using System.Linq;

namespace BHoM.Geometry
{
   


    /// <summary>
    /// BHoM Mesh geometry object
    /// </summary>
    [Serializable]
    public class Mesh : BHoMGeometry
    {
        private Group<Point> m_Vertices;
        private List<Face> m_Faces;


        public override GeometryType GeometryType
        {
            get
            {
                return GeometryType.Mesh;
            }
        }

        /// <summary>Vertices as a list of points</summary>
        public Group<Point> Vertices
        {
            get
            {
                return m_Vertices;
            }
            set
            {
                m_Vertices = value;
            }
        }

        /// <summary>Faces as a list of integer arrays</summary>
        public List<Face> Faces
        {
            get
            {
                return m_Faces;
            }
            set
            {
                m_Faces = value;
            }
        }

        public Guid Id
        {
            get
            {
                return new Guid();
            }
        }

        public override BoundingBox Bounds()
        {
            return m_Vertices.Bounds();
        }

        public Vector FaceNormal(int face)
        {
            Point p1 = m_Vertices[(m_Faces[face].A)];
            Point p2 = m_Vertices[(m_Faces[face].B)];
            Point p3 = m_Vertices[(m_Faces[face].C)];
            return Vector.CrossProduct(p2 - p1, p3 - p1);        
        }

        /// <summary>
        /// Construct empty mesh
        /// </summary>
        public Mesh()
        {
            m_Vertices = new Group<Point>();
            m_Faces = new List<Face>();
        }
        struct VertexIndex
        {
            public VertexIndex(Point point, int index)
            {
                Location = point;
                Index = index;
                Faces = new List<Face>();
            }
            public List<Face> Faces;
            public Point Location;
            public int Index;
        }

        public void RemoveDuplicateVertices(double tolerance = 0.001)
        {
            List<int> culledIndices = new List<int>();
            List<VertexIndex> vertices = new List<VertexIndex>();
            for (int i = 0; i < m_Vertices.Count;i++)
            {
                vertices.Add(new VertexIndex(m_Vertices[i], i));
            }

            for (int i = 0; i < m_Faces.Count; i++)
            {
                for (int j = 0; j < m_Faces[i].Indices.Length; j++)
                {
                    vertices[m_Faces[i].Indices[j]].Faces.Add(m_Faces[i]);
                }
            }

            vertices.Sort(delegate (VertexIndex v1, VertexIndex v2)
            {
                return v1.Location.DistanceTo(Point.Origin).CompareTo(v2.Location.DistanceTo(Point.Origin));
            });

            for (int i = 0; i < vertices.Count; i++)
            {
                double distance = vertices[i].Location.DistanceTo(Point.Origin);
                int j = i + 1;
                while (j < vertices.Count && Math.Abs(vertices[j].Location.DistanceTo(Point.Origin) - distance) < tolerance)
                {
                    VertexIndex v2 = vertices[j];
                    if (vertices[i].Location.DistanceTo(vertices[j].Location) < tolerance)
                    {
                        SetFaceIndex(v2.Faces, vertices[j].Index, vertices[i].Index);
                        culledIndices.Add(vertices[j].Index);
                        v2.Index = vertices[i].Index;
                        break;
                    }
                    j++;
                }
            }

            for (int i = 0; i < Faces.Count; i++)
            {
                for (int j = 0; j < Faces[i].Indices.Length; j++)
                {
                    for (int k = 0; k < culledIndices.Count; k++)
                    {
                        if (Faces[i].Indices[j] > culledIndices[k])
                        {
                            Faces[i].Indices[j]--;
                        }
                    }
                }
            }
        }

        private void SetFaceIndex(List<Face> faces, int from, int to)
        {
            foreach (Face f in faces)
            {
                for (int i = 0; i < f.Indices.Length;i++)
                {
                    if (f.Indices[i] == from) f.Indices[i] = to;
                }
            }
        }

        public Mesh(Group<Point> vertices, List<Face> faces)
        {
            m_Vertices = vertices;
            m_Faces = faces;
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
            m_Vertices.AddRange(vertices);
        }

        /// <summary>
        /// Add a mesh vertice
        /// </summary>
        /// <param name="vertice"></param>
        public void AddFace(Face face)
        {
            m_Faces.Add(face);
            for (int i = 0; i < face.Indices.Length;i++)
            {
                //m_Vertices[face.Indices[i]].AddConnectedFace
            }
        }

        public override void Update()
        {
            m_Vertices.Update();
        }

        public override BHoMGeometry Duplicate()
        {
            return DuplicateMesh();
        }

        public Mesh DuplicateMesh()
        {
            Mesh m = new Mesh();
            List<Face> f = new List<Face>();
            for (int i = 0; i < m.m_Faces.Count; i++)
            {
                f.Add(m_Faces[i].Duplicate());
            }
            m.m_Faces = f;
            m.m_Vertices = m_Vertices.DuplicateGroup();
            return m;
        }
    }
}
