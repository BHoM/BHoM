using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Geometry
{
    public class Quarternion
    {
        private double[] m_Quarternion;

        private Quarternion(double[] q)
        {
            m_Quarternion = q;
        }

        public static implicit operator double[] (Quarternion q)
        {
            return q.m_Quarternion;
        }



        public static Quarternion QuaternionRotationNormal(Vector axis, double angle)
        {
            double sin = Math.Sin(angle / 2);
            double[] q = VectorUtils.Normalise(new double[] { axis.X * sin, axis.Y * sin, axis.Z * sin, Math.Cos(angle / 2) });
            return new Quarternion(q);
        }

        public Quarternion Inverse()
        {
            return new Quarternion(new double[] { -X, -Y, -Z, W });
        }

        public Quarternion Multiply(Quarternion q)
        {
            double[] q1 = this;
            double[] q2 = q;

            double q23 = q2.Length > 3 ? q2[3] : 0;

            return new Quarternion(new double[]
            {
                q1[3]*q2[0] + q1[0]*q23 + q1[1]*q2[2] - q1[2]*q2[1],
                q1[3]*q2[1] - q1[0]*q2[2] + q1[1]*q23 + q1[2]*q2[0],
                q1[3]*q2[2] + q1[0]*q2[1] - q1[1]*q2[0] + q1[2]*q23,
                q1[3]*q23 - q1[0]*q2[0] - q1[1]*q2[1] - q1[2]*q2[2]
            });
        }

        public static Quarternion operator*(Quarternion q1, Quarternion q2)
        {
            return q1.Multiply(q2);
        }

        public double X
        {
            get
            {
                return m_Quarternion[0];
            }
        }

        public double Y
        {
            get
            {
                return m_Quarternion[1];
            }
        }

        public double Z
        {
            get
            {
                return m_Quarternion[2];
            }
        }

        public double W
        {
            get
            {
                return m_Quarternion[3];
            }
        }
    }
}
