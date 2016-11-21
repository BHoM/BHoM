using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHB = BHoM.Base;
using BHoM.Structural.Properties;

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
    }
}
