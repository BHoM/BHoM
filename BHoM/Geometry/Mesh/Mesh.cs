using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BH.oM.Geometry
{
    [Serializable]
    public class Mesh : IBHoMGeometry
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<Point> Vertices { get; set; } = new List<Point>();

        public List<Face> Faces { get; set; } = new List<Face>();


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

    }
}

