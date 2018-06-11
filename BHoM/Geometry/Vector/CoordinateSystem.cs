using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Base;

namespace BH.oM.Geometry
{

    public class CoordinateSystem : IGeometry, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Vector X { get; } = Vector.XAxis;

        public Vector Y { get;} = Vector.YAxis;

        public Vector Z { get;} = Vector.ZAxis;

        public Point Orgin { get; set; } = Point.Origin;

        /***************************************************/
        /**** Constructor                               ****/
        /***************************************************/

        public CoordinateSystem(Vector x, Vector y, Vector z, Point orgin)
        {
            X = x;
            Y = y;
            Z = z;
            Orgin = orgin;
        }
    }
}
