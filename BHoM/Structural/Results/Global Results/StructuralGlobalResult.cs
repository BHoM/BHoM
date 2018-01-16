using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Common;

namespace BH.oM.Structural.Results
{
    public abstract class StructuralGlobalResult : IStructuralResult
    {

        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public string ModelDescription { get; set; } = "";

        public string LoadCase { get; set; } = "";

        public double TimeStep { get; set; } = 0.0;

        /***************************************************/
        /**** IComparable Interface                     ****/
        /***************************************************/

        public int CompareTo(IResult other)
        {
            NodeResult otherRes = other as NodeResult;

            if (otherRes == null)
                return this.GetType().Name.CompareTo(other.GetType().Name);


            int l = this.LoadCase.CompareTo(otherRes.LoadCase);
            return l == 0 ? this.TimeStep.CompareTo(otherRes.TimeStep) : l;


        }
    }
}
