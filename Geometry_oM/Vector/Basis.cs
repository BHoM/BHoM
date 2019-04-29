using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Base;

namespace BH.oM.Geometry
{
    public class Basis : IGeometry, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Vector X { get; } = Vector.XAxis;

        public Vector Y { get; } = Vector.YAxis;

        public Vector Z { get; } = Vector.ZAxis;

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Basis(Vector x, Vector y, Vector z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /***************************************************/
        /**** Static special cases                      ****/
        /***************************************************/

        public static readonly Basis XY = new Basis(Vector.XAxis, Vector.YAxis, Vector.ZAxis);

        /***************************************************/

        public static readonly Basis XZ = new Basis(Vector.XAxis, Vector.ZAxis, -Vector.YAxis);

        /***************************************************/

        public static readonly Basis YZ = new Basis(Vector.YAxis, Vector.ZAxis, Vector.XAxis);

        /***************************************************/
        /**** Explicit Casting                          ****/
        /***************************************************/

        public static explicit operator Basis(CoordinateSystem.Cartesian coordinateSystem)
        {
            return new Basis(coordinateSystem.X, coordinateSystem.Y, coordinateSystem.Z);
        }

        /***************************************************/
    }
}