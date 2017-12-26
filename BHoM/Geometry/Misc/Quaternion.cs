namespace BH.oM.Geometry
{
    public class Quaternion
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double X { get; set; } = 0;

        public double Y { get; set; } = 0;

        public double Z { get; set; } = 0;

        public double W { get; set; } = 0;


        /***************************************************/
        /**** Static Operators Override                 ****/
        /***************************************************/

        public static Quaternion operator *(Quaternion q1, Quaternion q2)
        {
            return new Quaternion {
                X = q1.W * q2.X + q1.X * q2.W + q1.Y * q2.Z - q1.Z * q2.Y,
                Y = q1.W * q2.Y - q1.X * q2.Z + q1.Y * q2.W + q1.Z * q2.X,
                Z = q1.W * q2.Z + q1.X * q2.Y - q1.Y * q2.X + q1.Z * q2.W,
                W = q1.W * q2.W - q1.X * q2.X - q1.Y * q2.Y - q1.Z * q2.Z
            };
        }

        /***************************************************/

        public static Quaternion operator -(Quaternion q)
        {
            return new Quaternion { X = -q.X, Y = -q.Y, Z = -q.Z, W = q.W };
        }

        /***************************************************/
    }
}
