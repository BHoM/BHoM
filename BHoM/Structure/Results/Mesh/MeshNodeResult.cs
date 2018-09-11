using BH.oM.Common;
using BH.oM.Geometry;

namespace BH.oM.Structure.Results
{
    public abstract class MeshNodeResult :  IResult
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public string ObjectId { get; set; } = "";

        public string Case { get; set; } = "";

        public double TimeStep { get; set; } = 0.0;

        public string NodeId { get; set; } = "";

        /***************************************************/
        /**** IComparable Interface                     ****/
        /***************************************************/

        public int CompareTo(IResult other)
        {
            MeshNodeResult otherRes = other as MeshNodeResult;

            if (otherRes == null)
                return this.GetType().Name.CompareTo(other.GetType().Name);

            int n = this.NodeId.CompareTo(otherRes.NodeId);
            if (n == 0)
            {
                int l = this.Case.CompareTo(otherRes.Case);
                if (l == 0)
                {
                    int t = this.TimeStep.CompareTo(otherRes.TimeStep);
                    return t == 0 ? this.NodeId.CompareTo(otherRes.ObjectId) : t;
                }
                else
                {
                    return l;
                }
            }
            else
            {
                return n;
            }

        }

        /***************************************************/
    }
}
