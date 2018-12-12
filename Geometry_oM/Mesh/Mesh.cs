using System.Collections.Generic;

namespace BH.oM.Geometry
{
    public class Mesh : IGeometry
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<Point> Vertices { get; set; } = new List<Point>();

        public List<Face> Faces { get; set; } = new List<Face>();
        
        /***************************************************/
    }
}
