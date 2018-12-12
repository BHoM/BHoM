using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Common;

namespace BH.oM.Structure.Results
{
    public abstract class StructuralGlobalResult : IResult
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public IComparable ObjectId { get; set; } = "";

        public IComparable ResultCase { get; set; } = "";

        public double TimeStep { get; set; } = 0.0;

        /***************************************************/
        /**** IComparable Interface                     ****/
        /***************************************************/

        public int CompareTo(IResult other)
        {
            StructuralGlobalResult otherRes = other as StructuralGlobalResult;

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
