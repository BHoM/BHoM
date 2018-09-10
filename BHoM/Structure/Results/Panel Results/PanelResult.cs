using BH.oM.Common;
using BH.oM.Geometry;

namespace BH.oM.Structure.Results
{
    public abstract class PanelResult :  IResult
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public string ObjectId { get; set; } = "";

        public string Case { get; set; } = "";

        public double TimeStep { get; set; } = 0.0;

        public string NodeId { get; set; } = "";

        public CoordinateSystem CoordinateSystem { get; set; } = null;

        public PanelResultLayer PanelResultLayer { get; set; } = PanelResultLayer.AbsoluteMaximum;

        public PanelResultSmoothingType PanelResultSmoothingType { get; set; } = PanelResultSmoothingType.None;

        /***************************************************/
        /**** IComparable Interface                     ****/
        /***************************************************/

        public int CompareTo(IResult other)
        {
            PanelResult otherRes = other as PanelResult;

            if (otherRes == null)
                return this.GetType().Name.CompareTo(other.GetType().Name);

            int n = this.ObjectId.CompareTo(otherRes.ObjectId);
            if (n == 0)
            {
                int l = this.Case.CompareTo(otherRes.Case);
                if (l == 0)
                {
                    int t = this.TimeStep.CompareTo(otherRes.TimeStep);
                    return t == 0 ? this.NodeId.CompareTo(otherRes.NodeId) : t;
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
