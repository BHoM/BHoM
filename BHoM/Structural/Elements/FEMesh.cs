using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHB = BHoM.Base;
using BHoM.Structural.Properties;
using BHoM.Geometry;

namespace BHoM.Structural.Elements
{
    public class FEMesh : BHB.BHoMObject, IAreaElement
    {
        public FEMesh()
        {
            Nodes = new List<Node>();
            Faces = new List<FEFace>();
        }

        public PanelProperty PanelProperty { get; set; }

        public List<Node> Nodes { get; set; }

        public List<FEFace> Faces { get; set; }

        public AreaElementType ElementType
        {
            get
            {
                return AreaElementType.Mesh;
            }
        }

        public override BHoMGeometry GetGeometry()
        {
            Group<Point> points = new Group<Point>();
            List<Geometry.Face> faces = new List<Geometry.Face>();

            for(int i = 0; i < Nodes.Count;i++)
            {
                points.Add(Nodes[i].Point);
            }

            for (int i = 0; i < Faces.Count; i++)
            {
                faces.Add(new Geometry.Face(Faces[i].NodeIndices.ToArray()));
            }
            return new Mesh(points, faces);
        }
    }
}
