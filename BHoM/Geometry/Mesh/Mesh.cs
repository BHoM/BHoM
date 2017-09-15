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

        public List<Point> Vertices { get; set; } = new List<Point>();

        public List<PanelFace> Faces { get; set; } = new List<PanelFace>();


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Mesh() { }

        /***************************************************/

        public Mesh(IEnumerable<Point> vertices, IEnumerable<PanelFace> faces)
        {
            Vertices = vertices.ToList();
            Faces = faces.ToList();
        }

    }
}

