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

        public List<Face> Faces { get; set; } = new List<Face>();


        /***************************************************/
    }
}

