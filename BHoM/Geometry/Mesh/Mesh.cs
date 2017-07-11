using BH.oM.Base;

using System;
using System.Collections.Generic;
using System.Linq;

namespace BH.oM.Geometry
{
    public class Mesh : IBHoMGeometry
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        List<Point> Vertices { get; set; } = new List<Point>();

        List<Face> Faces { get; set; } = new List<Face>();


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Mesh() { }

        /***************************************************/

        public Mesh(IEnumerable<Point> vertices, IEnumerable<Face> faces)
        {
            Vertices = vertices.ToList();
            Faces = faces.ToList();
        }

        /***************************************************/
        /**** Local Methods                             ****/
        /***************************************************/


        /***************************************************/
        /**** IBHoMGeometry Interface                   ****/
        /***************************************************/

        public GeometryType GetGeometryType()
        {
            return GeometryType.Mesh;
        }

        /***************************************************/

        public BoundingBox GetBounds()
        {
            if (Vertices.Count == 0) return null;

            Point pt = Vertices[0];
            double minX = pt.X;
            double minY = pt.Y;
            double minZ = pt.Z;
            double maxX = minX;
            double maxY = minY;
            double maxZ = minZ;

            for (int i = Vertices.Count - 1; i > 0; i--)
            {
                pt = Vertices[i];
                if (pt.X < minX) minX = pt.X;
                if (pt.Y < minY) minY = pt.Y;
                if (pt.Z < minZ) minZ = pt.Z;
                if (pt.X > maxX) maxX = pt.X;
                if (pt.Y > maxY) maxY = pt.Y;
                if (pt.Z > maxZ) maxZ = pt.Z;
            }

            return new BoundingBox(new Point(minX, minY, minZ), new Point(maxX, maxY, maxZ));
        }

        /***************************************************/

        public object Clone()
        {
            return new Mesh(Vertices.Select(x => x.Clone() as Point), Faces.Select(x => x.Clone() as Face));
        }

        /***************************************************/

        public IBHoMGeometry GetTranslated(Vector t)
        {
            return new Mesh(Vertices.Select(x => x+t), Faces.Select(x => x.Clone() as Face));
        }





        

        //public Vector FaceNormal(int face)
        //{
        //    Point p1 = m_Vertices[(m_Faces[face].A)];
        //    Point p2 = m_Vertices[(m_Faces[face].B)];
        //    Point p3 = m_Vertices[(m_Faces[face].C)];
        //    return Vector.CrossProduct(p2 - p1, p3 - p1);        
        //}

        
        //struct VertexIndex
        //{
        //    public VertexIndex(Point point, int index)
        //    {
        //        Location = point;
        //        Index = index;
        //        Faces = new List<Face>();
        //    }
        //    public List<Face> Faces;
        //    public Point Location;
        //    public int Index;
        //}

        //public void RemoveDuplicateVertices(double tolerance = 0.001)
        //{
        //    List<int> culledIndices = new List<int>();
        //    List<VertexIndex> vertices = new List<VertexIndex>();
        //    for (int i = 0; i < m_Vertices.Count;i++)
        //    {
        //        vertices.Add(new VertexIndex(m_Vertices[i], i));
        //    }

        //    for (int i = 0; i < m_Faces.Count; i++)
        //    {
        //        for (int j = 0; j < m_Faces[i].Indices.Length; j++)
        //        {
        //            vertices[m_Faces[i].Indices[j]].Faces.Add(m_Faces[i]);
        //        }
        //    }

        //    vertices.Sort(delegate (VertexIndex v1, VertexIndex v2)
        //    {
        //        return v1.Location.DistanceTo(Point.Origin).CompareTo(v2.Location.DistanceTo(Point.Origin));
        //    });

        //    for (int i = 0; i < vertices.Count; i++)
        //    {
        //        double distance = vertices[i].Location.DistanceTo(Point.Origin);
        //        int j = i + 1;
        //        while (j < vertices.Count && Math.Abs(vertices[j].Location.DistanceTo(Point.Origin) - distance) < tolerance)
        //        {
        //            VertexIndex v2 = vertices[j];
        //            if (vertices[i].Location.DistanceTo(vertices[j].Location) < tolerance)
        //            {
        //                SetFaceIndex(v2.Faces, vertices[j].Index, vertices[i].Index);
        //                culledIndices.Add(vertices[j].Index);
        //                v2.Index = vertices[i].Index;
        //                break;
        //            }
        //            j++;
        //        }
        //    }

        //    for (int i = 0; i < Faces.Count; i++)
        //    {
        //        for (int j = 0; j < Faces[i].Indices.Length; j++)
        //        {
        //            for (int k = 0; k < culledIndices.Count; k++)
        //            {
        //                if (Faces[i].Indices[j] > culledIndices[k])
        //                {
        //                    Faces[i].Indices[j]--;
        //                }
        //            }
        //        }
        //    }
        //}

        //private void SetFaceIndex(List<Face> faces, int from, int to)
        //{
        //    foreach (Face f in faces)
        //    {
        //        for (int i = 0; i < f.Indices.Length;i++)
        //        {
        //            if (f.Indices[i] == from) f.Indices[i] = to;
        //        }
        //    }
        //}

        
        ///// <summary>
        ///// Add a mesh vertice
        ///// </summary>
        ///// <param name="vertice"></param>
        //public void AddVertice(Point vertice)
        //{
        //    m_Vertices.Add(vertice);
        //}
        
        ///// <summary>
        ///// Add multiple mesh vertices
        ///// </summary>
        ///// <param name="vertices"></param>
        //public void AddVertices(List<Point> vertices)
        //{
        //    m_Vertices.AddRange(vertices);
        //}

        ///// <summary>
        ///// Add a mesh vertice
        ///// </summary>
        ///// <param name="vertice"></param>
        //public void AddFace(Face face)
        //{
        //    m_Faces.Add(face);
        //    for (int i = 0; i < face.Indices.Length;i++)
        //    {
        //        //m_Vertices[face.Indices[i]].AddConnectedFace
        //    }
        //}

        //public override void Update()
        //{
        //    m_Vertices.Update();
        //}
    }
}
