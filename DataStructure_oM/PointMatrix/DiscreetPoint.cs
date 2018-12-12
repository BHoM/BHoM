using System;

namespace BH.oM.DataStructure
{
    public class DiscreetPoint : IDataStructure, IComparable<DiscreetPoint>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;
        public int Z { get; set; } = 0;


        /***************************************************/
        /**** IComparable Interface                     ****/
        /***************************************************/

        public int CompareTo(DiscreetPoint other)
        {
            if (X != other.X)
                return X.CompareTo(other.X);
            else if (Y != other.Y)
                return Y.CompareTo(other.Y);
            else
                return Z.CompareTo(other.Z);
        }

        /***************************************************/

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
        }

        /***************************************************/

        public override bool Equals(object obj)
        {
            if (obj is DiscreetPoint)
            {
                DiscreetPoint other = (DiscreetPoint)obj;
                return ((this.X == other.X) && (this.Y == other.Y) && (this.Z == other.Z));
            }
            return false;
        }

        /***************************************************/
    }
}
