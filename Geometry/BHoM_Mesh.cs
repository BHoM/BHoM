using System;
using System.Collections.Generic;
using System.Linq;

namespace BHoM.Geometry
{
    /// <summary>
    /// BHoM Mesh geometry object
    /// </summary>
    [Serializable]
    public class Mesh
    {

        private List<Point> _vertices;
        private List<int[]> _faces;
        /// <summary>Vertice groups for mesh face definition</summary>
        public List<List<int>> VerticeGroups { get; set; }

        /// <summary>Vertices as a list of points</summary>
        public List<Point> Vertices
        {
            get
            {
                return new List<Point>(_vertices);
            }
        }

        /// <summary>Faces as a list of integer arrays</summary>
        public List<int[]> Faces
        {
            get
            {
                return new List<int[]>(_faces);
            }
        }

        /// <summary>
        /// Construct empty mesh
        /// </summary>
        public Mesh()
        {
            _vertices = new List<Point>();
            _faces = new List<int[]>();
        }

        /// <summary>
        /// Add a mesh vertice
        /// </summary>
        /// <param name="vertice"></param>
        public void AddVertice(Point vertice)
        {
            _vertices.Add(vertice);
        }
        
        /// <summary>
        /// Add multiple mesh vertices
        /// </summary>
        /// <param name="vertices"></param>
        public void AddVertices(List<Point> vertices)
        {
            _vertices.AddRange(vertices);
        }

        /// <summary>
        /// Get vertices as a list of points
        /// </summary>
        /// <returns></returns>
        public List<Point> GetVertices()
        {
            List<Point> vertices = new List<Point>(_vertices.Count);

            foreach (Point pt in _vertices)
            {
                vertices.Add(new Point(pt.X, pt.Y, pt.Z));
            }

            return vertices;

        }

        /// <summary>
        /// Remove a mesh vertice
        /// </summary>
        /// <param name="v"></param>
        public void RemoveVertice(int v)
        {
            if (v < 0 || v > _vertices.Count)
                return;
            _vertices.RemoveAt(v);

            for (int i = 0; i < _faces.Count; i++)
            {
                int[] face = _faces[i];

                foreach (int j in face)
                {
                    if (j == v)
                    {
                        _faces.RemoveAt(i);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Add a meshface
        /// </summary>
        /// <param name="face"></param>
        /// <returns></returns>
        public bool AddFace(int[] face)
        {
            if (face.Length < 3 || face.Length > 4)
                return false;

            for (int i = 0; i < face.Length; i++)
            {
                if (face[i] == 0)
                    return false;

                if (face[i] < 0 || face[i] > _vertices.Count)
                    return false;
            }

            _faces.Add(face);

            return true;
        }

        /// <summary>
        /// Add multiple mesh faces
        /// </summary>
        /// <param name="faces"></param>
        /// <returns></returns>
        public bool AddFaces(List<int[]> faces)
        {
            bool success = true;

            foreach (int[] face in faces)
            {
                if (!this.AddFace(face))
                    success = false;
            }

            return success;
        }

        /// <summary>
        /// Remoeve a mesh face
        /// </summary>
        /// <param name="f"></param>
        public void RemoveFace(int f)
        {
            if (f < 0 || f > _faces.Count)
                return;
            _faces.RemoveAt(f);
        }

        /// <summary>
        /// Get mesh faces as list of arrays
        /// </summary>
        /// <returns></returns>
        public List<int[]> GetFaces()
        {
            return _faces.ToArray().ToList();
        }
    }
}
