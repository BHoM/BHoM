namespace BH.oM.Geometry
{
    public class Plane : IBHoMGeometry
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Point Origin { get; set; } = new Point();

        public Vector Normal { get; set; } = new Vector { X = 0, Y = 0, Z = 1 };


        /***************************************************/
        /**** Static special cases                      ****/
        /***************************************************/

        public static readonly Plane XY = new Plane { Origin = new Point { X = 0, Y = 0, Z = 0 }, Normal = Vector.ZAxis };

        /***************************************************/

        public static readonly Plane YZ = new Plane { Origin = new Point { X = 0, Y = 0, Z = 0 }, Normal = Vector.XAxis };

        /***************************************************/

        public static readonly Plane XZ = new Plane { Origin = new Point { X = 0, Y = 0, Z = 0 }, Normal = Vector.YAxis };

        /***************************************************/
    }
}
