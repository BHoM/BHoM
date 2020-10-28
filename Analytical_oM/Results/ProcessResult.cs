using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using BH.oM.Analytical.Results;
using BH.oM.Geometry;

namespace BH.oM.Analytical.Elements
{
    //Result per analytic
    public class ProcessResult : IResult, IImmutable
    {
        [Description("ID of the object that this result belongs to.")]
        public virtual IComparable ObjectId { get; }

        [Description("Identifier for the search that the result belongs to.")]
        public virtual IComparable ResultCase { get; }

        [Description("Time step for time history results.")]
        public virtual double TimeStep { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/
        public ProcessResult(IComparable objectId, IComparable resultCase, double timeStep)
        {
            ObjectId = objectId;
            ResultCase = resultCase;
            TimeStep = timeStep;
        }
        /***************************************************/
        /**** IComparable Interface                     ****/
        /***************************************************/

        public int CompareTo(IResult other)
        {
            ShortestPathResult otherRes = other as ShortestPathResult;

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
    }
}