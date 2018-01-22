using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Common;

namespace BH.oM.Structural.Results
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
    }
}
