using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Common;

namespace BH.oM.Structural.Results
{
    public class PanelResult :  IStructuralResult
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public string ModelDescription { get; set; } = "";

        public string ObjectId { get; set; } = "";

        public string LoadCase { get; set; } = "";

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
                int l = this.LoadCase.CompareTo(otherRes.LoadCase);
                if (l == 0)
                {
                    int f = this.NodeId.CompareTo(otherRes.NodeId);
                    return f == 0 ? this.TimeStep.CompareTo(otherRes.TimeStep) : f;
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
