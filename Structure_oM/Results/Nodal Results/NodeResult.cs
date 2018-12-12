using BH.oM.Common;
using BH.oM.Geometry;
using System.ComponentModel;
using System;

namespace BH.oM.Structure.Results
{
    public abstract class NodeResult :  IResult
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public IComparable ObjectId { get; set; } = "";

        public IComparable ResultCase { get; set; } = "";

        public double TimeStep { get; set; } = 0.0;

        [Description("CoordinateSystem required in order to report results in a particular direction, for example, for anisotropic materials")]
        public CoordinateSystem CoordinateSystem { get; set; } = new CoordinateSystem();

        /***************************************************/
        /**** IComparable Interface                     ****/
        /***************************************************/

        public int CompareTo(IResult other)
        {
            NodeResult otherRes = other as NodeResult;

            if (otherRes == null)
                return this.GetType().Name.CompareTo(other.GetType().Name);

            int n = this.ObjectId.CompareTo(otherRes.ObjectId);
            if (n == 0)
            {
                int l = this.ResultCase.CompareTo(otherRes.ResultCase);
                return l == 0 ? this.TimeStep.CompareTo(otherRes.TimeStep) : l;
            }
            else
            {
                return n;
            }

        }

        /***************************************************/
    }
}
