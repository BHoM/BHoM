using BH.oM.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Structural.Elements
{
    public class FEFace : BH.oM.Base.BHoMObject     //TODO: There is already the face class in the BHoM Geoemtry. There should at least be coherent with each other
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<int> NodeIndices { get; set; } = new List<int>();


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public FEFace() {}

    }
}



//public bool IsQuad
//{
//    get { return NodeIndices.Count == 4; }
//}

///***************************************************/

//public Geometry.Face GetGeometryFace()      // TODO: this again feels unecessary
//{
//    Geometry.Face face = new Geometry.Face(NodeIndices[0], NodeIndices[1], NodeIndices[2]);
//    if (NodeIndices.Count == 4)
//        face.D = NodeIndices[3];
//    return face;
//}