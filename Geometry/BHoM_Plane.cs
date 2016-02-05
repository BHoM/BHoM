using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Geometry
{
    [Serializable]
    public class Plane
    {

        public Vector X { get; private set; }
        public Vector Y { get; private set; }
        public Vector Z { get; private set; }

        public Point Origin { get; private set; }

        public Plane(Point origin)
        {
            Origin = origin;
            X = new Vector(1.0, 0.0, 0.0);
            Y = new Vector(0.0, 1.0, 0.0);
            Z = new Vector(0.0, 0.0, 1.0);
        }

        public Plane(Vector x, Vector y, Point origin)
        {
            X = x;
            Y = y;
            Z = Vector.CrossProduct(x, y);

            X.Unitize();
            Y.Unitize();
            Z.Unitize();

            Origin = origin;
        }


        /// <summary>
        /// Calculate which planar octant an angle lies within. 
        /// Convention for Cardinal lines is 0 => 1, PI/4 => 2, PI/2 => 3, -PI/4 => 8 etc.
        /// </summary>
        /// <param name="angle"> Angle in Radians</param>
        /// <returns></returns>
        public static int CalculateOctant(double angle)
        {
            ///                        |
            ///                   \  3 | 2  / 
            ///                  4  \  |  /  1   
            ///                 ______\|/______
            ///                       /|\ 
            ///                  5  /  |  \  8
            ///                   /  6 | 7  \
            ///                        | 

            int oct = (int)Math.Floor(Math.Abs(angle) / (Math.PI * 0.25)) + 1;
            if (angle <= 0.0) oct = 9 - oct;

            return oct;

        }

        /// <summary>
        /// Returns the nearest local axis based on the octant number 
        /// </summary>
        /// <param name="octant"></param>
        /// <returns></returns>
        public BHoM.Geometry.Vector GetAxisVectorFromOctant(int octant)
        {
            switch (octant)
            {
                case 8:
                case 1: return this.X;
                case 2:
                case 3: return this.Y;
                case 4:
                case 5: return -1.0 * this.X;
                case 6:
                case 7: return -1.0 * this.Y;

                default:
                    return null;
            }

        }

        /// <summary>
        /// Returns the nearest 45 degree axis vector based on the octant number 
        /// This vector is not unitised, having a magnitude of root2
        /// </summary>
        /// <param name="octant"></param>
        /// <returns></returns>
        public BHoM.Geometry.Vector Get45DegreeVectorFromOctant(int octant)
        {
            switch (octant)
            {
                case 1:
                case 2: return this.X + this.Y;
                case 3:
                case 4: return (-1.0 * this.X) + this.Y;
                case 5:
                case 6: return (-1.0 * this.X) - this.Y;
                case 7:
                case 8: return this.X - this.Y;

                default:
                    return null;
            }

        }


    }
}
