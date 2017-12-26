using System.Collections.Generic;

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
    }
}

