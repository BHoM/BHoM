using BHoM.Base;
using BHoM.Global;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BHoM.Geometry
{
   


    /// <summary>
    /// BHoM Mesh geometry object
    /// </summary>
    [Serializable]
    public class Mesh : GeometryBase
    {
        private Group<Point> m_Vertices;
        private List<Face> m_Faces;
        

      
        /// <summary>Vertices as a list of points</summary>
        public Group<Point> Vertices
        {
            get
            {
                return m_Vertices;
            }
        }

        /// <summary>Faces as a list of integer arrays</summary>
        public List<Face> Faces
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
            return new Vector( VectorUtils.CrossProduct(VectorUtils.Sub(p2, p1), VectorUtils.Sub(p3, p1)));        
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

        public void AddFaces(List<Face> faces)
        {
            m_Faces.AddRange(faces);
        }

        public override void Transform(Transform t)
        {
            m_Vertices.Transform(t);
        }

        public override void Translate(Vector v)
        {
            m_Vertices.Translate(v);
        }

        public override void Mirror(Plane p)
        {
            m_Vertices.Mirror(p);
        }

        public override void Project(Plane p)
        {
            m_Vertices.Project(p);
        }

        public override void Update()
        {
            m_Vertices.Update();
        }

        public override GeometryBase Duplicate()
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

        /// <summary>
        /// Turns quad faces of a BHoM mesh into triangles
        /// </summary>
        public Mesh Triangulate()
        {
            Mesh m = new Mesh();
            m.AddVertices(m_Vertices.ToList());
            for (int i = 0; i < m_Faces.Count; i++)
            {
                int i1 = m_Faces[i].A;
                int i2 = m_Faces[i].B;
                int i3 = m_Faces[i].C;
                int i4 = m_Faces[i].D;
                Point p1 = m_Vertices[i1];
                Point p2 = m_Vertices[i2];
                Point p3 = m_Vertices[i3];
                Point p4 = m_Vertices[i4];
                double d1 = new Line(p1, p3).Length;
                double d2 = new Line(p2, p4).Length;
                if (d1 > d2)    //Bracing based on shortest diagonal criteria
                {
                    Face fA = new Face(i1, i2, i4);
                    Face fB = new Face(i2, i3, i4);
                    m.AddFace(fA);
                    m.AddFace(fB);
                }
                else
                {
                    Face fA = new Face(i1, i2, i3);
                    Face fB = new Face(i1, i3, i4);
                    m.AddFace(fA);
                    m.AddFace(fB);
                }
            }
            return m;
        }            

        /// <summary>
        /// Returns edges of a BHoM mesh
        /// </summary>
        public List<Polyline> GetEdges()
        {
            List<Polyline> edges = new List<Polyline>();
            for (int i=0; i < m_Faces.Count; i++)
            {
                List<Point> faceVertices = new List<Point>();
                Point p1 = m_Vertices[m_Faces[i].A];
                Point p2 = m_Vertices[m_Faces[i].B];
                Point p3 = m_Vertices[m_Faces[i].C];
                Point p4 = new Point();
                if (m_Faces[i].IsQuad) { p4 = m_Vertices[m_Faces[i].D]; }               
                faceVertices.Add(p1);
                faceVertices.Add(p2);
                faceVertices.Add(p3);
                if (m_Faces[i].IsQuad) { faceVertices.Add(p4); }
                faceVertices.Add(p1);                               // Closed Polyline
                Polyline edge = new Polyline(faceVertices);
                edges.Add(edge);
            }
            return edges;
        }

        /// <summary>
        /// Returns area of a BHoM mesh
        /// </summary>
        public double Area()
        {          
            List<double> faceArea = new List<double>();
            for ( int i = 0; i < m_Faces.Count; i++)
            {
                Point pA = m_Vertices[m_Faces[i].A];
                Point pB = m_Vertices[m_Faces[i].B];
                Point pC = m_Vertices[m_Faces[i].C];
                if (m_Faces[i].IsTriangle)
                {
                    Vector AB = new Vector(pB.X - pA.X, pB.Y - pA.Y, pB.Z - pA.Z);
                    Vector AC = new Vector(pC.X - pA.X, pC.Y - pA.Y, pC.Z - pA.Z);
                    faceArea.Add(Vector.CrossProduct(AB, AC).Length);
                }
                else
                {
                    Point pD = m_Vertices[m_Faces[i].D];
                    Vector AB = new Vector(pB.X - pA.X, pB.Y - pA.Y, pB.Z - pA.Z);
                    Vector AC = new Vector(pC.X - pA.X, pC.Y - pA.Y, pC.Z - pA.Z);
                    Vector CB = new Vector(pB.X - pC.X, pB.Y - pC.Y, pB.Z - pC.Z);
                    Vector CD = new Vector(pD.X - pC.X, pD.Y - pC.Y, pD.Z - pC.Z);
                    faceArea.Add(Vector.CrossProduct(AB, AC).Length + Vector.CrossProduct(CB, CD).Length);
                }
            }
            return faceArea.Sum();
        }
        
        public override string ToJSON()
        {
            string aResult = "[";
            for (int i = 0; i < m_Faces.Count; i++)
            {
                aResult += "[";
                for (int j = 0; j < m_Faces[i].Indices.Length;  j++)
                {
                    aResult += m_Faces[i].Indices[j] + ",";
                }
                aResult = aResult.Trim(',') + "]";
            }
            aResult += "]";

            return "{\"__Type__\": \"" + this.GetType().FullName + "\"," + BHoMJSON.WriteProperty("Vertices", m_Vertices) + ",\"Faces\": " + aResult + "}";
        }

        public static new Mesh FromJSON(string json, Project project = null)
        {
            Dictionary<string, string> definition = BHoMJSON.GetDefinitionFromJSON(json);

            Group<Point> verticies = Group<Point>.FromJSON(definition["Vertices"], project) as Group<Point>;
            List<int[]> faceArray = BHoMJSON.ReadValue(typeof(List<int[]>), definition["Faces"]) as List<int[]>;

            List<Face> faces = new List<Face>();
            for (int i =0; i < faceArray.Count;i++)
            {
                faces.Add(new Geometry.Face(faceArray[i]));
            }

            return new Mesh(verticies, faces);
        }
    }
}
