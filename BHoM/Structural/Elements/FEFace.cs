using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural.Elements
{
    public class FEFace : BHoM.Base.BHoMObject
    {
        public FEFace()
        {
            NodeIndices = new List<int>();
        }

        public List<int> NodeIndices { get; set; }

        public bool IsQuad
        {
            get { return NodeIndices.Count == 4; }
        }

        public bool IsTri
        {
            get { return NodeIndices.Count == 3; }
        }
    }
}
